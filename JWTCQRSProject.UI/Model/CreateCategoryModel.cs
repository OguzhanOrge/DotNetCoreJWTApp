using System.ComponentModel.DataAnnotations;

namespace JWTCQRSProject.UI.Model
{
    public class CreateCategoryModel
    {
        [Required(ErrorMessage ="Kategori Adı Gereklidir")]
        public string? Definations { get; set; }
    }
}
