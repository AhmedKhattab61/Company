using System.ComponentModel.DataAnnotations;

namespace Company.PL.Dtos
{
    public class ForgotPasswordDto
    {
        [Required(ErrorMessage = "Email is Required!")]
        [EmailAddress(ErrorMessage = "Email is not valid!")]
        public string Email { get; set; }
    }
}
