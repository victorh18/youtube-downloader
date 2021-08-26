using System;
using System.IO;
using NYoutubeDL;
using ytd_api.Services.Interfaces;
using System.Linq;
using System.Collections.Generic;

namespace ytd_api.Services.Implementations
{
    public class DownloadService : IDownloadService
    {
        public KeyValuePair<string, byte[]> DownloadVideo(string url, string format = "mp4", string filenameFormat = "uploaderTitle")
        {
            var yd = new YoutubeDL();
            string fileFormat = "";
            string filenamePattern = "";

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

            switch (filenameFormat)
            {
                case "justTitle":
                    filenamePattern = "%(title)s.%(ext)s";
                    break;
                case "uploaderTitle":
                    filenamePattern = "%(uploader)s-%(title)s.%(ext)s";
                    break;
                default:
                    break;
            }
            
            var filePrefix = DateTime.Now.ToString("yyyymmss_hhMMss");
            var fileRoot = Path.Combine(AppContext.BaseDirectory, filePrefix);
            var filePath = fileRoot + fileFormat;
            
            yd.Options.FilesystemOptions.Output = fileRoot + filenamePattern;
            yd.VideoUrl = url;
            yd.Download();

            var newFilePath = Directory.GetFiles(AppContext.BaseDirectory, filePrefix + "*").First();
            var fileName = Path.GetFileName(newFilePath).Substring(filePrefix.Length);
            var file = System.IO.File.ReadAllBytes(newFilePath);
            return new KeyValuePair<string, byte[]>(fileName, file);
            
        }
    }
}