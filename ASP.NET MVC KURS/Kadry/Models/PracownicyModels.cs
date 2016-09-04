using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Kadry.Models
{
    public class Pracownik
    {
        [Required(ErrorMessage =" Pole Imię jest wymagane")]
        [DisplayName("Imię")]
        [StringLength(50, ErrorMessage="Imię nie może być dłuższe niż 50 znaków")]
        public string Imie { get; set; }

        [Required(ErrorMessage = " Pole Nazwisko jest wymagane")]        
        [StringLength(50, ErrorMessage = "Nazwisko nie może być dłuższe niż 50 znaków")]
        public string Nazwisko { get; set; }

        [Required(ErrorMessage = " Pole Wiek jest wymagane")]
        [Range(0,100, ErrorMessage = "Wiek powinien mieć wartość z przedziału od 0 do 100")]
        public int Wiek { get; set; }

        [Required(ErrorMessage = " Pole Stanowisko jest wymagane")]
        [StringLength(50, ErrorMessage = "Łańcuch znakowy w polu Stanowisko nie może być dłuższy niż 50 znaków")]
        public string Stanowisko { get; set; }

        [Required(ErrorMessage ="Pole Data Zatrudnienia jest wymagane")]
        [DataType(DataType.Date)]
        [DisplayName("Data Zatrudnienia (DD/MM/RRRR)")]
        [CustomValidationAttribute(typeof(Pracownik), "SprawdzPoprawnoscDatyZatrudnienia")]
        public System.DateTime DataZatrudnienia { get; set; }

        public static ValidationResult SprawdzPoprawnoscDatyZatrudnienia(System.DateTime data)
        {
            if (data.Date > System.DateTime.Now.Date)
                return new ValidationResult("Data zatrudnienia nie może być póżniejsza od daty dzisiejszej");  
            return ValidationResult.Success;
        }
    }
}