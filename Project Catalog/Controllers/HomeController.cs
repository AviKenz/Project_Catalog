using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_cathalogue.Models;



namespace Project_cathalogue.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string name)
        {
            ViewBag.test = "NOT USED...";
            ViewBag.Categories = CatalogDataBase.getDatabase().getCategories();
            ViewBag.Courses = CatalogDataBase.getDatabase().getCourses();
            return View();
        }
        // TODO H project in der Datenbank anlegen
        // TODO H benutzer Oberfläsche fertig einstellen
        // TODO I muss ein enscheidund für der oberfläsche treffen
        // TODO I utiliser create project
        //TODO I formular benutzen
        // TODO I reussir a faire le formulaire
        //TODO M demander au prof si il faut un formulaire pour devenir dozent
        //TODO H reperer le view


        public bool addProject(ProjectModel project)
        {
            return CatalogDataBase.getDatabase().addProject(project);
        }


        /**************Login*****************/

        [HttpPost]
        public ActionResult CheckUser(string username, string password)
        {
            LoginModel log = new LoginModel();
           
            if (username == log.UserName && password == log.Passwort)
            {

                return RedirectToAction("Success");
            }
            else
            {
                return RedirectToAction("Index", new { error = true });
            }
        }

        public ActionResult Success()
        {
            return View();
        }




        [HttpGet]
        [Authorize]
        public ActionResult chooseRole(List<string> roles)
        {
            return View();
        }

        public ActionResult Cathe(ProjectModel cat)
        {
            return View();
        }


        public dynamic Projects { get; private set; }

        public ActionResult PojectAnlegen()
        {


            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Website for Administration of Project on FB2";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Jackie and Abdallah";

            return View();
        }
    }
};