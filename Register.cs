using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Asim.Models
{
    public class Register
    {
      
        [Required]
        [DisplayName("Adınız")]
        public string Ad { get; set; }

        [Required]
        [DisplayName("Soyadınız")]
        public string Soyad { get; set; }

        [Required]
        [DisplayName("Kullanıcı Adı")]
        public string UserName { get; set; }

        [Required]
        [DisplayName("Eposta")]
        [EmailAddress(ErrorMessage ="Eposta adresinizi düzgün giriniz.")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Şifre")]
        public string Şifre { get; set; }

        [Required]
        [DisplayName("Şifre Tekrar")]
        [Compare("Şifre",ErrorMessage="Şifreleriniz uyuşmuyor.")]
        public string RePassword { get; set; }
    
       
    }
}