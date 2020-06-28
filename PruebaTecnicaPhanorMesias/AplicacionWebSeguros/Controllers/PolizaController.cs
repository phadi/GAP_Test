using AplicacionWebSeguros.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace AplicacionWebSeguros.Controllers
{
    
    public class PolizaController : Controller
    {
        tbUsuario userLog;
        // GET: Poliza
        public ActionResult Index()
        {
            userLog = (tbUsuario)Session["usrValido"];
            if (userLog == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            return View();
        }

        public ActionResult ListaPolizas()
        {
            userLog = (tbUsuario)Session["usrValido"];
            if (userLog == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            //Variables            
            string urlServicio = WebConfigurationManager.AppSettings["urlServicioPoliza"].ToString() + "GetPolizas";
            //LLama servicio
            string body = llamaServicio(urlServicio, "GET");
            string respData = Json(body).Data.ToString();
            List<tbPoliza> polizas = JsonConvert.DeserializeObject<List<tbPoliza>>(respData);

            return View(polizas);
        }

        public ActionResult Create()
        {
            userLog = (tbUsuario)Session["usrValido"];
            if (userLog == null)
            {
                return RedirectToAction("Login", "Usuario");
            }

            string urlServicio = WebConfigurationManager.AppSettings["urlServicioPoliza"].ToString() + "GetPolizas";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tbPoliza model)
        {
            userLog = (tbUsuario)Session["usrValido"];
            if (userLog == null)
            {
                return RedirectToAction("Login", "Usuario");
            }

            return View();
        }

        public ActionResult Edit()
        {
            userLog = (tbUsuario)Session["usrValido"];
            if (userLog == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            return View();
        }

        public ActionResult Details()
        {
            userLog = (tbUsuario)Session["usrValido"];
            if (userLog == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            return View();
        }

        public ActionResult Delete()
        {
            userLog = (tbUsuario)Session["usrValido"];
            if (userLog == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            return View();
        }

        public string llamaServicio(string urlServicio, string metodo)
        {
            //Variables
            HttpWebRequest request = null;

            //LLama servicio de login
            request = WebRequest.Create(urlServicio) as HttpWebRequest;
            request.Timeout = 10 * 100000000;
            request.Method = metodo;
            request.ContentType = "application/json; charset=utf-8";
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string body = reader.ReadToEnd();

            return body;
        }
    }
}