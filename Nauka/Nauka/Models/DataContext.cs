using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
//TIP: ten plik utworzyłem żeby zadziałał mechanizm migracji, o którym warto poczytać w necie
//Działa to tak, że dla encji czyli klas które dodamy tutaj utworzone zostaną tabele w bazie
namespace Nauka.Models
{
    public class DataContext : System.Data.Entity.DbContext
    {
        //Dopisałem linijkę dla NewItems, klasy którą sam utworzyłem.
        //EF sam utworzy tabelę dla nich w bazie i doda to niej takie kolumny jakie ma pola
        //            VVVV    wystarczy tutaj dać wskaźnik i wcisnąć F12 to przejdzie do tej klasy (NewItem)
        public DbSet<NewItem> NewItems { get; set; }
        public DbSet<WycieczkaViewModel> NewItemsa { get; set; }
        public DbSet<Trip> Trips { get; set; }

        public DataContext() : base ("DefaultConnection")
        {
        }
    }
}