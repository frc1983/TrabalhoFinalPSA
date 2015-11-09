using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;
using System.Linq;
using System.Data;
using Entities;

namespace Pipocao.ViewModels
{
    public class UserViewModel
    {
        [Required]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "A {0} deve ter pelo menos {2} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        public static User Parse(UserViewModel viewModel)
        {
            User user = new User();
            user.Email = viewModel.Email;
            user.Password = viewModel.Password;

            return user;
        }
    }

    public class LoginViewModel : UserViewModel
    {
        [Display(Name = "Lembrar?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel : UserViewModel
    {
        [DataType(DataType.Password)]
        [Display(Name = "Confirmação da senha")]
        [Compare("Password", ErrorMessage = "A senha e a confirmação da senha não estão iguais.")]
        public string ConfirmPassword { get; set; }
    }
}
