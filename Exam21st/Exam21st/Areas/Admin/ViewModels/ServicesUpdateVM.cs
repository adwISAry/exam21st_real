using System.ComponentModel.DataAnnotations;

namespace Exam21st.Areas.Admin.ViewModels
{
    public class ServicesUpdateVM
    {
        public int Id { get; set; }
        [Required, MaxLength(32)]
        public string Name { get; set; }
        [Required, MaxLength(128)]

        public string Description { get; set; }

        public string ImageUrl { get; set; }
        public IFormFile formFile { get; set; }
    }
}
