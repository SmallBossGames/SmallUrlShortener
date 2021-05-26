using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmallUrlShortener.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallUrlShortener.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShortifyLinkController : ControllerBase
    {
        private readonly ShortenerContext _shortenerContext;

        public ShortifyLinkController(ShortenerContext shortenerContext)
        {
            _shortenerContext = shortenerContext;
        }

        [HttpPost]
        public async Task<string> GetShortUrlId([FromForm] string url)
        {
            var shortLinkId = Guid.NewGuid().ToString();

            UrlMapping mapping = await _shortenerContext.UrlMappings
                .Where(x => x.DirectLink == url)
                .SingleOrDefaultAsync();

            if(mapping == null)
            {
                mapping = new UrlMapping
                {
                    ShortLink = shortLinkId,
                    DirectLink = url,
                };

                await _shortenerContext.AddAsync(mapping);
                await _shortenerContext.SaveChangesAsync();
            }

            return mapping.ShortLink;
        }
    }
}
