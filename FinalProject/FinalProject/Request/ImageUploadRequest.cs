using FinalProject.Attributes;

namespace FinalProject.Request
{
    public class ImageUploadRequest
    {
        [FileSize(200 * 200, 4 * 200 * 200)]
        [AllowedExtensions(".JPG", ".JPEG", ".PNG", ".GIF", ".TIFF", ".BMP", ".RAW", ".SVG", ".WEBP", ".HEIF", ".PSD")]
        public IFormFile Image { get; set; }
        public Guid PersonalInformationId { get; set; }

    }
}
