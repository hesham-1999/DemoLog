using System.ComponentModel.DataAnnotations;

namespace DemoLog.Controllers.Request
{
    public class FileUpload
    {
        [Display(Name =" Upload File ")]
        public IFormFile File { get; set; }
    }
}
