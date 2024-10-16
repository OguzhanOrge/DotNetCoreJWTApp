using System.ComponentModel.DataAnnotations;

namespace JWTCQRSProject.UI.Model
{
	public class UserLoginModel
	{
		[Required(ErrorMessage ="Kullanıcı adı boş olamaz")]
		public string UserName { get; set; } = null!;
		[Required(ErrorMessage = "Şifre adı boş olamaz")]
		public string Password { get; set; } = null!;
	}
}
