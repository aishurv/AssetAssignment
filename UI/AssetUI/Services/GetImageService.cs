namespace AssetUI.Services
{
    public class GetImageService
    {
        public string GetImage(string ActualName, string AlternateName)
        {
            string ImagePath = $"Assets/img/{ActualName}.png";
            if (!ImageExistsLocally(ImagePath))
            {
                if (AlternateName == "Asset") {
                    ImagePath = $"Assets/img/sample.png";
                }
                else if (AlternateName == "Machine")
                {
                    ImagePath = $"Assets/img/SampleMachine.png";
                }
            }
            return ImagePath;
        }

        public bool ImageExistsLocally(string imagePath)
        {
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", imagePath);

            return File.Exists(fullPath);
        }
    }
}
