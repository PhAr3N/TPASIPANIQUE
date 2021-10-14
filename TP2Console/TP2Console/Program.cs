using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TP2Console.Models.EntityFramework;

namespace TP2Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (var ctx = new FilmsDBContext())
            //{
            //    Film titanic = ctx.Films.First(f => f.Nom.Contains("Titanic"));
            //    titanic.Description = "Un Bateau échoué. Date : " + DateTime.Now;
            //    int nbchanges = ctx.SaveChanges();
            //    Console.WriteLine("Nombre d'enregistrements modifiés ou ajoutés : " + nbchanges);
            //}
            //using (var ctx = new FilmsDBContext())
            //{
            //    Categorie categorieAction = ctx.Categories.First(c => c.Nom == "Action");
            //    Console.WriteLine("Categorie : " + categorieAction.Nom);
            //    //Chargement des films dans categorieAction
            //    ctx.Entry(categorieAction).Collection(c => c.Films).Load();
            //    Console.WriteLine("Films : ");
            //    foreach (var film in categorieAction.Films)
            //    {
            //        Console.WriteLine(film.Nom);
            //    }

            //}
            //using (var ctx = new FilmsDBContext())
            //{
            //    //Chargement de la catégorie Action et des films de cette catégorie
            //    Categorie categorieAction = ctx.Categories.Include(c => c.Films).First(c => c.Nom == "Action");
            //    Console.WriteLine("Categorie : " + categorieAction.Nom);
            //    Console.WriteLine("Films : ");
            //    foreach (var film in categorieAction.Films)
            //    {
            //        Console.WriteLine(film.Nom);
            //    }
            //}

            //using (var ctx = new FilmsDBContext())
            //{
            //    //Chargement de la catégorie Action, des films de cette catégorie et des avis
            //    Categorie categorieAction = ctx.Categories
            //    .Include(c => c.Films)
            //    .ThenInclude(f => f.Avis)
            //    .First(c => c.Nom == "Action");
            //}
            //using (var ctx = new FilmsDBContext())
            //{
            //    //Chargement de la catégorie Action
            //    Categorie categorieAction = ctx.Categories.First(c => c.Nom == "Action");
            //    Console.WriteLine("Categorie : " + categorieAction.Nom);
            //    Console.WriteLine("Films : ");
            //    //Chargement des films de la catégorie Action.
            //    foreach (var film in categorieAction.Films) // lazy loading initiated
            //    {
            //        Console.WriteLine(film.Nom);
            //    }
            //}
            Exo2Q1();
            Console.ReadKey();
        }
        public static void Exo2Q1()
        {
            var ctx = new FilmsDBContext();
            foreach (var film in ctx.Films)
            {
                Console.WriteLine(film.ToString());
            }
        }

        public static void Exo2Q2()
        {
            var ctx = new FilmsDBContext();
            foreach (var user in ctx.Utilisateurs)
            {
                Console.WriteLine(user.Email.ToString());
            }
        }
        public static void Exo2Q3()
        {
            var ctx = new FilmsDBContext();
            foreach (var user in ctx.Utilisateurs.OrderBy(u => u.Login))
            {
                Console.WriteLine(user.ToString());
            }
        }
        public static void Exo2Q4()
        {
            var ctx = new FilmsDBContext();
            foreach (var user in ctx.Utilisateurs.OrderBy(u => u.Login))
            {
                Console.WriteLine(user.ToString());
            }
        }
        public static void Exo2Q5()
        {
            var ctx = new FilmsDBContext();
            var count = ctx.Categories.Count();
            Console.WriteLine(count);
        }
        public static void Exo2Q6()
        {
            var ctx = new FilmsDBContext();
            var min = ctx.Avis.Min(Avis => Avis.Note);
            Console.WriteLine(min);
        }
        public static void Exo2Q7()
        {
            var ctx = new FilmsDBContext();
            foreach (var film in ctx.Films)
            {
                if (film.Nom.ToLower().StartsWith("le"))
                {
                    Console.WriteLine(film.ToString());
                }
            }
        }
        public static void Exo2Q8()
        {
            var ctx = new FilmsDBContext();
            decimal tempMoy = 0, moy = 0;
            int cpt = 0;
            foreach (var avis in ctx.Avis)
            {
                if (avis.Film == 17)
                {
                    tempMoy += avis.Note;
                    cpt++;
                }
            }
            moy = tempMoy / cpt;
            Console.WriteLine(moy);
        }

        public static void Exo3QAddUser()
        {
            using (var ctx = new FilmsDBContext())
            {
                ctx.Utilisateurs.Add(new Utilisateur
                {
                    Login = "Antonin",
                    Pwd = "motdepasse",
                    Email = "antonin.poulard@gmoil.com"
                });
                ctx.SaveChanges();
            }
        }
        public static void Exo3QUpdateMovie()
        {
            using (var ctx = new FilmsDBContext())
            {
                var result = ctx.Films.SingleOrDefault(film => film.Nom == "L'armee des douze singes");
                if (result != null)
                {
                    result.Description = "Ceci est une description !";
                    result.Categorie = 5;
                    ctx.SaveChanges();
                }
            }
        }
        public static void Exo3QDeleteMovie()
        {
            using (var ctx = new FilmsDBContext())
            {
                var result = ctx.Films.SingleOrDefault(film => film.Nom == "L'armee des douze singes");
                ctx.Avis.RemoveRange(ctx.Avis.Where(avis => avis.Film == result.Id));
                ctx.Films.Remove(result);
                ctx.SaveChanges();

            }
        }
        public static void Exo3QAddReview()
        {
            using (var ctx = new FilmsDBContext())
            {
                ctx.Avis.Add(new Avi
                {
                    Film = 28,
                    Utilisateur = 1,
                    Avis = "un classique",
                    Note = 0.86758394M
                });
                ctx.SaveChanges();
            }
        }
        public static void Exo3Add2Dramas()
        {
            using (var ctx = new FilmsDBContext())
            {
                ctx.Films.AddRange(new Film
                {
                    Nom = "filmFictif1",
                    Description = "descriptionFictive1",
                    Categorie=5
                },new Film
                {
                    Nom = "filmFictif2",
                    Description = "descriptionFictive2",
                    Categorie = 5
                }
                );
                ctx.SaveChanges();
            }
        }
    }
}
