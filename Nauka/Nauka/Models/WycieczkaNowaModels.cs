﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nauka.Models
{
    public class WycieczkaViewModel
    {

        [Key]
        [ScaffoldColumn(false)]
        [Display(Name = "WycieczkaID")]
        public int WycieczkaId { get; set; }

        [Required]
        [Display(Name = "Nazwa")]
        public string Nazwa { get; set; }

        [Required]
        [Display(Name = "MaxLiczbaMiejsc")]
        public int Max_miejsc { get; set; }

        [Required]
        [Display(Name = "Czas trwania w dniach")]
        public int Czas_trwania { get; set; }

        [Required]
        [Display(Name = "Rodzaj (inclisive")]
        public bool Rodzaj { get; set; }

        [Required]
        [Display(Name = "Termin wyjazdu")]
        public string termin_wyjazdu { get; set; }

        [Required]
        [Display(Name = "Cena")]
        public float cena { get; set; }

        [Display(Name = "Godzina wyjazdu")]
        public string godzina_wyjazdu { get; set; }

        [Display(Name = "Czy Promocja?")]
        public bool promocja { get; set; }

    }


}