using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace SmallUrlShortener.Data
{
    [Index(nameof(ShortLinkId), IsUnique = true)]
    [Index(nameof(OriginalLink), IsUnique = true)]
    public class UrlMapping
    {
        public int URLMappingId { get; set; }
        [Required]
        public string OriginalLink { get; set; }
        [Required]
        public string ShortLinkId { get; set; }
    }
}
