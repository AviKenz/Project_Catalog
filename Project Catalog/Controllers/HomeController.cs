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
            ViewBag.Projects = getProjects;
            List<ProjectModel> data = new List<ProjectModel>();
            data.Add(new ProjectModel { Id = 1, Cathegory = "Robotik" });
            data.Add(new ProjectModel { Id = 2, Cathegory = "Web development" });
            data.Add(new ProjectModel { Id = 3, Cathegory = "Sofware development" });
            data.Add(new ProjectModel { Id = 4, Cathegory = "UI Roboter" });

            ViewBag.Roles = new SelectList(data, "Id", "Cathegory");


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

        private List<ProjectModel> getProjects
        {
            get
            {
                List<ProjectModel> projects = new List<ProjectModel>();

                for (int i = 0; i < 3; i++)
                {
                    ProjectModel pr = new ProjectModel
                    {
                        Name = "Project Nr: " + i,
                        Description = "",



                        Id = i,


                    };

                    projects.Add(pr);

                }

                return projects;

            }
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





        [HttpGet]
        public bool Cathe(bool choice)
        {

            if (choice)
            {
                var cat = new ProjectModel();


                List<string> cathegory = new List<string>();
                cathegory.Add(cat.ToString());
                cat.Cathegory = "Robotik";
                cat.Cathegory = "Web development";
                ViewBag.ProjectModel = new SelectList(cathegory, "Cathegory");
            }
            return CatalogDataBase.getDatabase().Cathe(choice);
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