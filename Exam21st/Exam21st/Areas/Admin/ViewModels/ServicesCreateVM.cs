using System.ComponentModel.DataAnnotations;

namespace Exam21st.Areas.Admin.ViewModels
{
    public class ServicesCreateVM
    {
        public int Id { get; set; }
        [Required,MaxLength(32)]
        public string Name { get; set; }
        [Required, MaxLength(128)]

        public string Description { get; set; }
        [DataType(DataType.Upload)]
        [Display(Name = "Upload File")]
        [Required(ErrorMessage = "Please choose file to upload.")]
        public IFormFile formFile { get; set; }
    }
}
