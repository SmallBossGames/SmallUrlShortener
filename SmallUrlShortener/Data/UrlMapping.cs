using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallUrlShortener.Data
{
    [Index(nameof(DirectLink), nameof(ShortLink))]
    public class UrlMapping
    {
        public int URLMappingId { get; set; }
        public string DirectLink { get; set; }
        public string ShortLink { get; set; }
    }
}
