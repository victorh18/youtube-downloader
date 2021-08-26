using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ytd_api.Services.Interfaces;

namespace ytd_api.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class MetadataController {
        private readonly IMetadataService metadataService;
        public MetadataController(IMetadataService _metadataService)
        {
            metadataService = _metadataService;
        }

        [HttpGet]
        public object GetMetadata(string url) {
            return new {
                id = metadataService.getVideoId(url)
            };
        }

        [HttpGet]
        [Route("ApiVersion")]
        public string GetVersion() {
            return metadataService.getApiVersion();
        }
    }
}
