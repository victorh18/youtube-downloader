using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ytd_api.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class MetadataController {
        [HttpGet]
        public object GetMetadata(string url) {
            string id = "";
            if (url.Contains("https://www.youtube.com/watch?v="))
            {
                id = url.Substring("https://www.youtube.com/watch?v=".Length, url.Length - "https://www.youtube.com/watch?v=".Length);
            }

            return new {
                id = id
            };
        }
    }
}
