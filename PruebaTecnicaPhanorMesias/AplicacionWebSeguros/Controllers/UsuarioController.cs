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
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(tbUsuario model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            try
            {
                //Variables
                string login = model.Login;
                string psw = model.Contrasena;
                HttpWebRequest request = null;
                string urlServicio = WebConfigurationManager.AppSettings["urlServicioUsuario"].ToString() + "GetUsuario?login=" + login + "&psw=" + psw;

                //LLama servicio de login
                request = WebRequest.Create(urlServicio) as HttpWebRequest;
                request.Timeout = 10 * 100000000;
                request.Method = "GET";
                request.ContentType = "application/json; charset=utf-8";
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string body = reader.ReadToEnd();

                //Valida usuario valido
                if (string.IsNullOrEmpty(body))
                {
                    ModelState.AddModelError("", "Login o contraseña invalidos.");
                    return View(model);
                }
                else
                {
                    string respData = Json(body).Data.ToString();
                    tbUsuario userLog = JsonConvert.DeserializeObject<tbUsuario>(respData);
                    Session["usrValido"] = userLog;
                    return RedirectToAction("Index", "Home");
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
            
        }
    }
}

//request = WebRequest.Create(urlServicio) as HttpWebRequest;
//                    request.Timeout = 10 * 100000000;
//                    request.Method = "POST";
//                    request.ContentLength = data.Length;
//                    request.ContentType = "application/json; charset=utf-8";

//                    Stream postStream = request.GetRequestStream();
//postStream.Write(data, 0, data.Length);

//                    HttpWebResponse response = request.GetResponse() as HttpWebResponse;
//StreamReader reader = new StreamReader(response.GetResponseStream());
//string body = reader.ReadToEnd();

//string respData = Json(body).Data.ToString();

//req = JsonConvert.DeserializeObject<Response>(respData);