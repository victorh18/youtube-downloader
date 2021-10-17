using ytd_api.Core.Interfaces;
using System.Reflection;

namespace ytd_api.Core.Services
{
    public class MetadataService : IMetadataService {
        string[] urlPrefixes = {
            @"https://www.youtube.com/watch?v=",
            @"https://youtu.be/"
        };

        public MetadataService()
        {
            
        }

        public string getVideoId(string videoUrl) {
            string id = "";
        
            foreach (string prefix in urlPrefixes)
            {
                if (videoUrl.Contains(prefix))
                {
                    id = videoUrl.Substring(prefix.Length, videoUrl.Length - prefix.Length); 
                }
            }
            return id;
        }

        public string getApiVersion() {
            return Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
        }
    }
}