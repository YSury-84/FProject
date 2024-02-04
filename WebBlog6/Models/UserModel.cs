using System;
using System.ComponentModel.DataAnnotations;

namespace WebBlog6.Models
{
    public class UserModel
    {
        [Display(Name = "Логин:")]
        [Required(ErrorMessage = "Необходимо ввести Имя")]
        public string Login { get; set; }
        [Display(Name = "Пароль:")]
        [Required(ErrorMessage = "Необходимо ввести Пароль")]
        public string Pass { get; set; }
        [Display(Name = "ФИО:")]
        [Required(ErrorMessage = "Необходимо ввести ФИО")]
        public string Fio { get; set; }
        [Required(ErrorMessage = "Необходимо ввести Дата")]
        [Display(Name = "Дата регистрации:")]
        public string RegDate { get; set; }
        [Required(ErrorMessage = "Необходимо ввести Роль")]
        public string Role { get; set; }

        public UserModel()
        {
            RegDate = Convert.ToString(DateTime.Now);
            Role = "user";
        }
    }
}
