namespace ytd_api.Services.Interfaces {
    public interface IMetadataService {
        string getVideoId(string videoUrl);
        string getApiVersion();
    }
}