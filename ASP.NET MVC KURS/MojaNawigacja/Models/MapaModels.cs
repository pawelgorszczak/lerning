using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MojaNawigacja.Models
{
    [MetadataType(typeof(AdresyMetaData))]
    public partial class Adresy
    { 
    }

    public class AdresyMetaData
    {
        public object IdTrasy { get; set; }

        [Required(ErrorMessage="Pole Miejsce wyjazdu jest wymagane")]
        [StringLength(50,ErrorMessage="Maksymalna długość adresu wynosi 50 znaków")]
        [DisplayName("Miejsce wyjazdu")]
        public object MiejsceWyjazdu { get; set; }

        [Required(ErrorMessage="Pole Miejsce docelowe jest wymagane")]
        [StringLength(50, ErrorMessage = "Maksymalna długość adresu wynosi 50 znaków")]
        [DisplayName("Miejsce docelowe")]
        public object MiejsceDocelowe { get; set; }

        [DisplayName("Data dodania")]
        public object DataDodania { get; set; }
    }

}