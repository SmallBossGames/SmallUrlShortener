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
    public class RedirectionController : ControllerBase
    {
        private readonly ShortenerContext _shortenerContext;

        public RedirectionController(ShortenerContext shortenerContext)
        {
            _shortenerContext = shortenerContext;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> RedirectByShortUrlId(string id)
        {
            var targetUrl = await _shortenerContext.UrlMappings
               .Where(x => x.ShortLink == id)
               .Select(x => x.DirectLink)
               .SingleOrDefaultAsync();

            if(targetUrl == null)
            {
                return NotFound();
            }

            return Redirect(targetUrl);
        }
    }
}
