
using System.ComponentModel.DataAnnotations;

namespace HomeworkPustok.ViewModels
{
    public class MemberRegisterUserVM
    {
        [Required]
        [MaxLength(30)]
        public string Fullname { get; set; }
        [Required]
        [MaxLength(30)]
        public string Username { get; set; }
        [Required]
        [MaxLength(50)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [MaxLength(30)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MaxLength(30)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
