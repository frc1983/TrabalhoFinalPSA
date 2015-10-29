using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;
using System.Linq;
using System.Data;
using Pipocao.Persistence;
using Pipocao.Persistence.Model;

namespace Pipocao.Models
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Display(Name = "Lembrar?")]
        public bool RememberMe { get; set; }

        public bool IsValid()
        {
            using (var ctx = new DatabaseContext())
            {
                var user = ctx.User
                    .Where(x => x.Email.ToLower().Equals(this.Email.ToLower()) && x.Password.Equals(this.Password))
                    .FirstOrDefault();

                return user != null;
            }
        }
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "A {0} deve ter pelo menos {2} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmação da senha")]
        [Compare("Password", ErrorMessage = "A senha e a confirmação da senha não estão iguais.")]
        public string ConfirmPassword { get; set; }

        public void InsertUser()
        {
            using (var ctx = new DatabaseContext())
            {
                var u = new User();
                u.Email = this.Email;
                u.Password = this.Password;

                ctx.User.Add(u);
                ctx.SaveChanges();
            }
        }
    }
}
