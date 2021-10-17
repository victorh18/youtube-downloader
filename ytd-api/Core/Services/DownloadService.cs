using System;
using System.IO;
using ytd_api.Core.Interfaces;
using System.Linq;
using System.Collections.Generic;

namespace ytd_api.Core.Services
{
    public class DownloadService : IDownloadService
    {
        private readonly IYoutubeDownloader youtubeDownloader;

        public DownloadService(IYoutubeDownloader _youtubeDownloader)
        {
            youtubeDownloader = _youtubeDownloader;
        }
        public KeyValuePair<string, byte[]> Download(string url, string format, string filenameFormat)
        {
            var filenamePattern = "";
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
            KeyValuePair<string, byte[]> data = new KeyValuePair<string, byte[]>();
            switch (format)
            {
                case "mp3":
                    data = youtubeDownloader.DownloadAudio(url, format, filenamePattern);
                    break;
                case "mp4":
                    data = youtubeDownloader.DownloadVideo(url, format, filenamePattern);
                    break;
                default:
                    break;
            }

            return data;
        }
    }
}