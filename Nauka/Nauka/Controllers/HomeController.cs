using Nauka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nauka.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //GET: Jak nie napiszesz nic przed akcją to domyślnie wywoływana jest metoda GET. O metodach HTTP można poczytać w necie.
        public ActionResult Wololo()
        {
            ViewBag.Message = "Nowy przycisk na miarę moich możliwości";

            return View();
        }

        //POST: Jeśli chcemy wywołać metodę POST to dodajemy przed akcją dopisek specjalny.
        [HttpPost]
        public ActionResult Wololo(RegisterUserViewModel model) //Dodatkowo jako parametr przyjmuje ten model który utworzyłeć specjalnie dla tej akcji w pliku AccountViewModels.cs
        {
            //Tutaj trzeba utworzyć nowy obiekt jakiegoś typu, przypisać do niego wartości z modelu pobranego przez parametr
            //I można go zapisać do bazy danych
            //Ta metoda POST wywoływana jest wtedy jak coś wysyłamy na serwer z przeglądarki.
            //Najczęściej po kliknięciu submit, register czy coś takiego
            return View(model);
        }
    }
}