using System.ComponentModel.DataAnnotations;

namespace ChatApp.Web.Models
{
    public class SignInViewModel
    {
        [Required(ErrorMessage = "UserName required")]
        public string UserName { get; set; }
    }
}