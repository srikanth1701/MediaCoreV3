using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MediaCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MediaDeliveryController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly","Genre"
        };

        private static readonly string[] YoutubeLinks = new[]{
            "kIWRBz8o9W0","f60dheI4ARg", "6OdKZRnmRQ0","srikanth","sri"
        };

        private readonly ILogger<MediaDeliveryController> _logger;
        private IMediaService _service;

        public MediaDeliveryController(ILogger<MediaDeliveryController> logger, IMediaService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]  
        [Route("GetMedia")]
        public Media Get()
        {
            var result = _service.GetItemAsync("1");
            // var rng = new Random();
            // return Enumerable.Range(1, 5).Select(index => new Media
            // {
            //     MediaPath = YoutubeLinks[rng.Next(YoutubeLinks.Length)],
            //     Summary = Summaries[rng.Next(Summaries.Length)]
            // })
            return result.Result;
        }

        [HttpGet]  
        [Route("GetMedias")]
        public IEnumerable<Media> GetMedias()
        {
            var result = _service.GetItemsAsync("1");
            // var rng = new Random();
            // return Enumerable.Range(1, 5).Select(index => new Media
            // {
            //     MediaPath = YoutubeLinks[rng.Next(YoutubeLinks.Length)],
            //     Summary = Summaries[rng.Next(Summaries.Length)]
            // })
            return result.Result.ToArray();
        }
    }
}
