using AplicacionWebSeguros.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
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
            string body = llamaServicio(urlServicio, null, "GET");
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

            combos(0,0);

            tbPoliza model = new tbPoliza();
            model.InicioVigencia = DateTime.Now;
            model.PeriodoCobertura = 12;
            return View(model);
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

            if (ModelState.IsValid)
            {
                try
                {
                    byte[] data = null;
                    string json = JsonConvert.SerializeObject(model);
                    data = UTF8Encoding.UTF8.GetBytes(json);

                    string urlServicio = WebConfigurationManager.AppSettings["urlServicioPoliza"].ToString() + "AddPoliza";
                    //LLama servicio
                    string body = llamaServicio(urlServicio, data, "POST");
                    int respData = 0;

                    if (!string.IsNullOrEmpty(body))
                        respData = int.Parse(Json(body).Data.ToString());

                    if (respData != 0)
                        return RedirectToAction("ListaPolizas");
                    else
                    {
                        ModelState.AddModelError("", "Error en el servicio de crear Poliza.");
                        
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error en el servicio de crear Poliza. " + ex.Message);
                }
            }

            combos((int)model.TipoCubrimiento, (int)model.TipoRiesgo);
            return View(model);
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

        #region metodos

        public void combos(int cubri, int ries)
        {
            List<SelectListItem> cmbCubrimientos = new List<SelectListItem>();
            List<SelectListItem> cmbRiesgos = new List<SelectListItem>();

            string urlServicio = WebConfigurationManager.AppSettings["urlServicioPoliza"].ToString() + "GetTipoCubrimiento";
            //LLama servicio
            string body = llamaServicio(urlServicio, null, "GET");
            string respData = Json(body).Data.ToString();
            List<tbTipoCubrimiento> cubrimientos = JsonConvert.DeserializeObject<List<tbTipoCubrimiento>>(respData);

            cmbCubrimientos = new SelectList(cubrimientos, "TipoCubrimientoId", "TipoCubrimiento", cubri).ToList();
            cmbCubrimientos.Insert(0, (new SelectListItem { Text = "Seleccionar", Value = "0" }));
            ViewBag.TipoCubrimiento = cmbCubrimientos;

            urlServicio = WebConfigurationManager.AppSettings["urlServicioPoliza"].ToString() + "GetTipoRiesgo";
            //LLama servicio
            body = llamaServicio(urlServicio, null, "GET");
            respData = Json(body).Data.ToString();
            List<TbTipoRiesgo> riesgos = JsonConvert.DeserializeObject<List<TbTipoRiesgo>>(respData);

            cmbRiesgos = new SelectList(riesgos, "TipoRiesgoId", "TipoRiesgo", ries).ToList();
            cmbRiesgos.Insert(0, (new SelectListItem { Text = "Seleccionar", Value = "0" }));
            ViewBag.TipoRiesgo = cmbRiesgos;
        }

        public string llamaServicio(string urlServicio, byte[] data, string metodo)
        {
            //Variables
            HttpWebRequest request = null;

            //LLama servicio de login
            request = WebRequest.Create(urlServicio) as HttpWebRequest;
            request.Timeout = 10 * 100000000;
            request.Method = metodo;

            if (metodo.Equals("POST"))
            {
                request.ContentLength = data.Length;
                request.ContentType = "application/json; charset=utf-8";
                Stream postStream = request.GetRequestStream();
                postStream.Write(data, 0, data.Length);
            }
            else
                request.ContentType = "application/json; charset=utf-8";


            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string body = reader.ReadToEnd();

            return body;
        }

        #endregion metodos

    }
}