﻿using DataService.Model;

namespace AssetUI.Services
{
    public class MachineDataService
    {
        private readonly HttpClient _httpClient;
        public MachineDataService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("AssetAPI");
        }
        public async Task<List<MachineData>> GetAllAsync()
        {
            var machines = await _httpClient.GetFromJsonAsync<List<MachineData>>("Machines");
            return machines ?? [];
        }
        public async Task<List<string>> GetLatestAssetSeriesMachines()
        {
            var machines = await _httpClient.GetFromJsonAsync<List<string>>("MachineWithLatestAssetSeries");
            return machines ?? [];
        }
        public async Task<List<string>> GetMachineModelByAssetName(string assetName)
        {
            var req = "Machine/Asset/";
            assetName=assetName.Replace("{", "").Replace("}", "");
            req += assetName.Replace(" ","%20");
            var machines = await _httpClient.GetFromJsonAsync<List<string>>(req);
            return machines ?? [];
        }
        public async Task<MachineData> GetById(string id)
        {
            var req = "Machine/";
            id = id.Replace("{", "").Replace("}", "");
            req += id;
            var data = await _httpClient.GetFromJsonAsync<MachineData>(req);
            return data!;
        }
    }
}
