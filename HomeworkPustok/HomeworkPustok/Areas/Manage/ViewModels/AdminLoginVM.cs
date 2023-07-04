using System.ComponentModel.DataAnnotations;

namespace HomeworkPustok.Areas.Manage.ViewModels
{
    public class AdminLoginVM
    {
        [Required]
        [MaxLength(30)]
        public string Username { get; set; }
        [Required]
        [MaxLength(30)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
