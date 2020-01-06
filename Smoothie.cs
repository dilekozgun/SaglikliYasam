using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Asim.Models
{
    public class Smoothie
    {
   
        public int Id { get; set; }
        public string SmoothieAdi { get; set; }
        public string Malzemeler { get; set; }
        public string Hazirlanisi { get; set; }
        public string Resim { get; set; }
    }
}