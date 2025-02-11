using AssetAPI.Repository;
using DataService.Model;
using DataService.MongoDB;
using MongoDB.Driver;


namespace AssetAPI.Extraction
{
    internal static class LatestAssetExtension
    {
        public static List<AssetSummary> GetLatestAssets( this List<MachineAssetSeries> _assetMachineData)
        {
            var LatestAssets = _assetMachineData
             .GroupBy(a => a.AssetName)
            .Select(g => new AssetSummary
            {
                Name = g.Key,
                Series = g.Select(a => a.AssetSeries).Aggregate(GetLatestSeries)
            })
            .ToList();
            return LatestAssets;
        }
        private static string GetLatestSeries(string s1, string s2)
        {
            if (s1 is null) return s2;
            if (s2 is null) return s1;
            var n1 = int.Parse(s1[1..]); //var n1 = int.Parse(s1.Substring(1));
            var n2 = int.Parse(s2[1..]); // var n2 = int.Parse(s2.Substring(1));

            return n1 > n2 ? s1 : s2;
        }
    }
}
