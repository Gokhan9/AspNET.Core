using System.ComponentModel.DataAnnotations;

namespace FormsApp.Models
{
    public class Product
    {
        [Display(Name="Ürün ID")]
        public int ProductID { get; set; }
        
        [Required(ErrorMessage = "İsim Alanını Girmeniz Zorunlu.")]
        [StringLength(50, ErrorMessage = "Aramak istediğiniz ürün 0 - 50 karakter arası olmalıdır!")]
        [Display(Name="Ürün Adı")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Fiyat Alanını Girmeniz Zorunlu.")]
        [Range(0, 100000, ErrorMessage = "0 - 100.000 Fiyat Aralığında Arama Yapabilirsiniz.")]
        [Display(Name="Fiyat")]
        public decimal? Price { get; set; }

        
        [Display(Name="Görseller")]
        public string Image { get; set; } = string.Empty;
        
        [Display(Name="Aktif")]
        public bool isActive { get; set; }
        
        [Required(ErrorMessage = "Bir Kategori Seçimi Yapmalısınız.")]
        [Display(Name="Kategori")]
        public int? CategoryID { get; set; }

    }
}