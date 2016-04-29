using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nauka.Models
{
    public class Trip
    {
        [Remote("CheckForDuplication", "Validation")]
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
    }
}