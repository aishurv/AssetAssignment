using System.Net.Http.Json;
using DataService.Model;
namespace AssetUI.Services
{
    public class AssetService
    {
        private readonly HttpClient _httpClient;
        public AssetService(IHttpClientFactory httpClientFactory) 
        {
            _httpClient = httpClientFactory.CreateClient("AssetAPI");
        }
        public async Task<List<AssetData>> GetAllAsync()
        {
            var assets = await _httpClient.GetFromJsonAsync<List<AssetData>>("Assets"); 
            return assets?? [];
        }
        public async Task<Dictionary<string, string>> GetLatestAssetsAsync()
        {
            var data = await _httpClient.GetFromJsonAsync<Dictionary<string, string>>("LatestAssets");
            return data?? [];
        }
        public async Task<List<AssetData>> GetAssetByMachineModel(string machineModel)
        {
            var req = "Assets/";
            machineModel= machineModel.Replace("{", "").Replace("}", "");
            req += machineModel;
            var data = await _httpClient.GetFromJsonAsync<List<AssetData>>(req);
            return data?? [];
        }
    }
}
