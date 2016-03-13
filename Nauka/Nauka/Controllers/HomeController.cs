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
        public ActionResult Wololo(NewItem model) //Dodatkowo jako parametr przyjmuje ten model który utworzyłeć specjalnie dla tej akcji w pliku AccountViewModels.cs
        {
            using (var ctx = new DataContext())
            {
                if (ModelState.IsValid)
                {
                    //tworzę nowy obiekt który zostanie dopisany do bazy
                    var item = new NewItem();
                    //P.S. ta linijka to to samo co  "NewItem item = new NewItem();" z  C++. Tutaj nie musimy za każdym razem podawać typu (ale możemy). Kompilator sam sie domyśli.

                    item.Imie = model.Imie;
                    item.Nazwisko = model.Nazwisko;
                    //id wygeneruje się automatycznie, bo jest kluczem głównym


                    //te dwie linijki dodają obiekt do bazy. Nic więcej nie trzeba robić.
                    ctx.NewItems.Add(item);
                    ctx.SaveChanges();
                }
            }
            return View(model);
        }
    }
}