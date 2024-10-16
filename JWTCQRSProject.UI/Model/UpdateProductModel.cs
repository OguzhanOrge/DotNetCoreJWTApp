using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace JWTCQRSProject.UI.Model
{
	public class UpdateProductModel
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "Name Boş Gecilemez")]
		public string? Name { get; set; }
		[Required(ErrorMessage = "Stock Boş Gecilemez")]
		public int Stock { get; set; }
		[Required(ErrorMessage = "Price Boş Gecilemez")]
		public decimal Price { get; set; }
		[Required(ErrorMessage = "CategoryId Boş Gecilemez")]
		public int CategoryId { get; set; }
		public SelectList? Categories { get; set; }
	}
}
