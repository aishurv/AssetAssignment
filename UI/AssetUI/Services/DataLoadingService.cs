namespace AssetUI.Services
{
    public class DataLoadingService
    {
        private readonly HttpClient _httpClient;
        public DataLoadingService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("AssetAPI");
        }
        public void LoadData()
        {
            _httpClient.GetAsync("/loaddata");
        }
    }
}
