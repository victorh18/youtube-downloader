using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NYoutubeDL;
using System.IO;
using ytd_api.Services.Interfaces;

namespace ytd_api.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class DownloadController : ControllerBase
    {
        private readonly IDownloadService downloadService;
        public DownloadController(IDownloadService _downloadController)
        {
            downloadService = _downloadController;
        }

        [HttpGet]
        public IActionResult Download(string url, string format = "mp4", string filenameFormat = "uploaderTitle")
        {
            var file = downloadService.DownloadVideo(url, format, filenameFormat);
            Response.Headers.Add("X-Filename", System.Net.WebUtility.UrlEncode(file.Key));
            return File(file.Value, "application/octet-stream", file.Key);

        }
    }
}