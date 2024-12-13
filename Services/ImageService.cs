using Microsoft.AspNetCore.Components.Forms;

namespace BlazorBackgroundCSS.Services
{
    /// <summary>
    /// This would be a service that handles image uploading to
    /// a server in a real-world application
    /// </summary>
    public class ImageService
    {
        public static int MaxFileSize = 512000;

        public async Task<string> UploadImage(IBrowserFile file)
        {
            using Stream fileStream = file.OpenReadStream(MaxFileSize);
            using MemoryStream ms = new MemoryStream();
            await fileStream.CopyToAsync(ms);

            byte[] imageBytes = ms.ToArray();
            string base64String = Convert.ToBase64String(imageBytes);
            string dataUrl = $"data:{file.ContentType};base64,{base64String}";

            return dataUrl;
        }
    }
}
