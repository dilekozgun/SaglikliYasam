using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Asim.Models
{
    public class KayitOl
    {
        public int Id { get; set; }
        public string Adı { get; set; }
        public string Soyadı { get; set; }
        public string EPosta { get; set; }
        public string Password { get; set; }
        public string DoğumTarihi { get; set; }
        public string Kullanıcıadı { get; set; }
        public string Cinsiyet { get; set; }
        public long Telefon { get; set; }

        public List<GirisYap> girisYap { get; set; }

    }
}