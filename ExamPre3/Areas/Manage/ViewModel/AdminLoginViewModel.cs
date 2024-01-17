using System.ComponentModel.DataAnnotations;

namespace ExamPre3.Areas.Manage.ViewModel
{
    public class AdminLoginViewModel
    {
        [Required]
        [MaxLength(25)]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string Password { get; set; }
    }
}
