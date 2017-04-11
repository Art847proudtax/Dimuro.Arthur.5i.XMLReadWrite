using System.Web.Hosting;
using System.Web.Mvc;

namespace DiMuro.Arthur._5i.XMLReadWrite.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        private Persone person { get; set; }
        // GET: Default
        public ActionResult Index()
        {
            string fileName = HostingEnvironment.MapPath(@"~/App_Data/dati.xml");
            person = new Persone(fileName);
            return View(person);
        }


        public ActionResult @event(string a)
        {
            return View(a);
        }

        public ActionResult AddPerson()
        {
            string fileName = HostingEnvironment.MapPath(@"~/App_Data/dati.xml");
            person = new Persone(fileName);
            person.Aggiungi();
            return View("Index", person);
        }
    }
}