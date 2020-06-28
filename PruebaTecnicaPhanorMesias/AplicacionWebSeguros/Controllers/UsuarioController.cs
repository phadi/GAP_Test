using AplicacionWebSeguros.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web.Configuration;
using System.Web.Mvc;

namespace AplicacionWebSeguros.Controllers
{
    public class UsuarioController : Controller
    {
        
        public ActionResult Index()
        {
            try
            {
                //Variables            
                string urlServicio = WebConfigurationManager.AppSettings["urlServicioUsuario"].ToString() + "GetUsuarios";
                //LLama servicio
                string body = llamaServicioUsuario(urlServicio);
                string respData = Json(body).Data.ToString();
                List<tbUsuario> userLog = JsonConvert.DeserializeObject<List<tbUsuario>>(respData);

                return View(userLog);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error en lista de usuarios. " + ex.Message);
                return RedirectToAction("Login");
            }
            
        }

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
                string urlServicio = WebConfigurationManager.AppSettings["urlServicioUsuario"].ToString() + "GetUsuario?login=" + login + "&psw=" + psw;

                //LLama servicio
                string body = llamaServicioUsuario(urlServicio);

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

                    //Permisos por rol
                    urlServicio = WebConfigurationManager.AppSettings["urlServicioUsuario"].ToString() + "GetPermisos?rolId=" + userLog.RolId;
                    body = llamaServicioUsuario(urlServicio);
                    respData = Json(body).Data.ToString();
                    List<tbPermisoPorRol> permisos = JsonConvert.DeserializeObject<List<tbPermisoPorRol>>(respData);
                    userLog.permisos = permisos;

                    //Asigna sesion
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

        public ActionResult usuarioValido()
        {
            tbUsuario userLog = (tbUsuario)Session["usrValido"];
            if (userLog == null)
            {
                return RedirectToAction("Login");
            }

            return View(userLog);
        }

        public ActionResult Salir()
        {
            Session["usrValido"] = null;
            return View();
        }

        public string llamaServicioUsuario(string urlServicio)
        {
            //Variables
            HttpWebRequest request = null;

            //LLama servicio de login
            request = WebRequest.Create(urlServicio) as HttpWebRequest;
            request.Timeout = 10 * 100000000;
            request.Method = "GET";
            request.ContentType = "application/json; charset=utf-8";
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string body = reader.ReadToEnd();

            return body;
        }


    }
}