using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NYoutubeDL;
using System.IO;

namespace ytd_api.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class DownloadController : ControllerBase
    {

        [HttpGet]
        public IActionResult Download(string url, string format = "mp4")
        {
            var yd = new YoutubeDL();
            string fileFormat = "";

            switch (format)
            {
                case "mp3":
                    yd.Options.PostProcessingOptions.ExtractAudio = true;
                    yd.Options.PostProcessingOptions.AudioFormat = NYoutubeDL.Helpers.Enums.AudioFormat.mp3;
                    yd.Options.PostProcessingOptions.AudioQuality = "0";
                    fileFormat = ".mp3";
                    break;
                case "mp4":
                    yd.Options.VideoFormatOptions.Format = NYoutubeDL.Helpers.Enums.VideoFormat.mp4;
                    fileFormat = ".mp4";
                    break;
                default:
                    break; 
            }
            
            var filePrefix = DateTime.Now.ToString("yyyymmss_hhMMss");
            var fileRoot = Path.Combine(AppContext.BaseDirectory, filePrefix);
            var filePath = fileRoot + fileFormat;
            
            yd.Options.FilesystemOptions.Output = fileRoot + "%(title)s.%(ext)s";
            yd.VideoUrl = url;
            yd.Download();

            //var fileName = Path.GetFileName(filePath);
            var newFilePath = Directory.GetFiles(AppContext.BaseDirectory, filePrefix + "*").First();
            var fileName = Path.GetFileName(newFilePath).Substring(filePrefix.Length);
            Response.Headers.Add("X-Filename", fileName);
            var file = System.IO.File.ReadAllBytes(newFilePath);
            return File(file, "application/octet-stream", fileName);

        }
    }
}