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
    public class ClienteController : Controller
    {
        tbUsuario userLog;
        public ActionResult PolizasCiente()
        {
            userLog = (tbUsuario)Session["usrValido"];
            if (userLog == null)
            {
                return RedirectToAction("Login", "Usuario");
            }

            //Variables            
            string urlServicio = WebConfigurationManager.AppSettings["urlServicioCliente"].ToString() + "GetClientesPoliza";
            //LLama servicio
            string body = llamaServicio(urlServicio, null, "GET");
            string respData = Json(body).Data.ToString();
            List<tbPolizaPorCliente> clientes = JsonConvert.DeserializeObject<List<tbPolizaPorCliente>>(respData);

            return View(clientes);

        }
        public ActionResult CreatePP()
        {
            userLog = (tbUsuario)Session["usrValido"];
            if (userLog == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            polizasClienteModel modelo = new polizasClienteModel();
            List<SelectListItem> cmbPolizas = new List<SelectListItem>();
            List<SelectListItem> cmbClientes = new List<SelectListItem>();

            //Combo polizas
            string urlServicio = WebConfigurationManager.AppSettings["urlServicioPoliza"].ToString() + "GetPolizas";            
            string body = llamaServicio(urlServicio, null, "GET");
            string respData = Json(body).Data.ToString();
            List<tbPoliza> polizas = JsonConvert.DeserializeObject<List<tbPoliza>>(respData);

            cmbPolizas = new SelectList(polizas, "PolizaId", "Nombre").ToList();
            cmbPolizas.Insert(0, (new SelectListItem { Text = "Seleccionar", Value = "0" }));
            ViewBag.PolizaId = cmbPolizas;

            //Combo clientes                      
            urlServicio = WebConfigurationManager.AppSettings["urlServicioCliente"].ToString() + "GetClientes";
            body = llamaServicio(urlServicio, null, "GET");
            respData = Json(body).Data.ToString();
            List<tbCliente> clientes = JsonConvert.DeserializeObject<List<tbCliente>>(respData);

            cmbClientes = new SelectList(clientes, "ClienteId", "NombreCompleto").ToList();
            cmbClientes.Insert(0, (new SelectListItem { Text = "Seleccionar", Value = "0" }));
            ViewBag.ClienteId = cmbClientes;

            //Fecha
            modelo.FechaInicio = DateTime.Now;
            return View(modelo);
        }
        public ActionResult ListaClientes()
        {
            userLog = (tbUsuario)Session["usrValido"];
            if (userLog == null)
            {
                return RedirectToAction("Login", "Usuario");
            }

            //Variables            
            string urlServicio = WebConfigurationManager.AppSettings["urlServicioCliente"].ToString() + "GetClientes";
            //LLama servicio
            string body = llamaServicio(urlServicio, null, "GET");
            string respData = Json(body).Data.ToString();
            List<tbCliente> clientes = JsonConvert.DeserializeObject<List<tbCliente>>(respData);

            return View(clientes);
        }

        public ActionResult Create()
        {
            userLog = (tbUsuario)Session["usrValido"];
            if (userLog == null)
            {
                return RedirectToAction("Login", "Usuario");
            }

            combos(0);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tbCliente model)
        {
            userLog = (tbUsuario)Session["usrValido"];
            if (userLog == null)
            {
                return RedirectToAction("Login", "Usuario");
            }

            if (ModelState.IsValid)
            {
                List<string> valida = validaciones(model); 

                if(valida.Count == 0)
                {
                    try
                    {
                        byte[] data = null;
                        string json = JsonConvert.SerializeObject(model);
                        data = UTF8Encoding.UTF8.GetBytes(json);

                        string urlServicio = WebConfigurationManager.AppSettings["urlServicioCliente"].ToString() + "AddCliente";
                        //LLama servicio
                        string body = llamaServicio(urlServicio, data, "POST");
                        int respData = 0;

                        if (!string.IsNullOrEmpty(body))
                            respData = int.Parse(Json(body).Data.ToString());

                        if (respData != 0)
                            return RedirectToAction("ListaClientes");
                        else
                            ModelState.AddModelError("", "Error en el servicio de crear Cliente.");
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", "Error en el servicio de Crear Cliente. " + ex.Message);

                    }
                }
                else
                {
                    foreach (string st in valida)
                    {
                        ModelState.AddModelError("", st);
                    }
                }
                
            }

            combos((int)model.TipoDoc);
            return View(model);
        }

        public ActionResult Edit(int? id)
        {
            userLog = (tbUsuario)Session["usrValido"];
            if (userLog == null)
            {
                return RedirectToAction("Login", "Usuario");
            }

            if (id == null)
            {
                return RedirectToAction("Login", "Usuario");
            }

            //Variables  
            tbCliente cliente = new tbCliente();
            string urlServicio = WebConfigurationManager.AppSettings["urlServicioCliente"].ToString() + "GetCliente?clienteId=" + id.ToString();
            //LLama servicio
            string body = llamaServicio(urlServicio, null, "GET");
            //Valida usuario valido
            if (string.IsNullOrEmpty(body))
            {
                ModelState.AddModelError("", "Error al cargar el cliente.");                
                return View(cliente);
            }
            else
            {
                string respData = Json(body).Data.ToString();
                cliente = JsonConvert.DeserializeObject<tbCliente>(respData);
            }

            combos((int)cliente.TipoDoc);
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tbCliente ciente)
        {
            userLog = (tbUsuario)Session["usrValido"];
            if (userLog == null)
            {
                return RedirectToAction("Login", "Usuario");
            }

            if (ModelState.IsValid)
            {
                List<string> valida = validaciones(ciente);

                if (valida.Count == 0)
                {
                    try
                    {
                        byte[] data = null;
                        string json = JsonConvert.SerializeObject(ciente);
                        data = UTF8Encoding.UTF8.GetBytes(json);

                        string urlServicio = WebConfigurationManager.AppSettings["urlServicioCliente"].ToString() + "UpdateCliente";
                        //LLama servicio
                        string body = llamaServicio(urlServicio, data, "POST");
                        return RedirectToAction("ListaClientes");
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", "Error en el servicio de Actualizar Cliente. " + ex.Message);
                    }
                }
                else
                {
                    foreach (string st in valida)
                    {
                        ModelState.AddModelError("", st);
                    }
                }  

            }

            combos((int)ciente.TipoDoc);
            return View(ciente);
        }

        public ActionResult Delete(int? id)
        {
            userLog = (tbUsuario)Session["usrValido"];
            if (userLog == null)
            {
                return RedirectToAction("Login", "Usuario");
            }

            if (id == null)
            {
                return RedirectToAction("Login", "Usuario");
            }

            //Variables  
            tbCliente cliente = new tbCliente();
            string urlServicio = WebConfigurationManager.AppSettings["urlServicioCliente"].ToString() + "GetCliente?clienteId=" + id.ToString();
            //LLama servicio
            string body = llamaServicio(urlServicio, null, "GET");
            //Valida usuario valido
            if (string.IsNullOrEmpty(body))
            {
                ModelState.AddModelError("", "Error al cargar el cliente.");
                
                return View(cliente);
            }
            else
            {
                string respData = Json(body).Data.ToString();
                cliente = JsonConvert.DeserializeObject<tbCliente>(respData);
            }

            return View(cliente);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            string urlServicio;
            string body;
            try
            {
                tbCliente cli = new tbCliente();
                cli.ClienteId = id;
                byte[] data = null;
                string json = JsonConvert.SerializeObject(cli);
                data = UTF8Encoding.UTF8.GetBytes(json);

                urlServicio = WebConfigurationManager.AppSettings["urlServicioCliente"].ToString() + "DeleteCliente";
                //LLama servicio
                body = llamaServicio(urlServicio, data, "POST");
                int respData = 0;

                if (!string.IsNullOrEmpty(body))
                    respData = int.Parse(Json(body).Data.ToString());

                if (respData != 0)
                    return RedirectToAction("ListaClientes");
                else
                    ModelState.AddModelError("", "Error en el servicio de eliminar cliente.");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error en el servicio de eliminar cliente. " + ex.Message);
            }

            tbCliente cliente = new tbCliente();
            urlServicio = WebConfigurationManager.AppSettings["urlServicioCliente"].ToString() + "GetCliente?clienteId=" + id.ToString();
            //LLama servicio
            body = llamaServicio(urlServicio, null, "GET");
            //Valida usuario valido
            if (string.IsNullOrEmpty(body))
            {
                ModelState.AddModelError("", "Error al cargar el cliente.");
                return View(cliente);
            }
            else
            {
                string respData = Json(body).Data.ToString();
                cliente = JsonConvert.DeserializeObject<tbCliente>(respData);
            }

            combos((int)cliente.TipoDoc);
            return View(cliente);
        }

        #region metodos

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

        public void combos(int tipoDoc)
        {
            List<SelectListItem> cmbTipoDoc = new List<SelectListItem>();

            string urlServicio = WebConfigurationManager.AppSettings["urlServicioCliente"].ToString() + "GetTipoDoc";
            //LLama servicio
            string body = llamaServicio(urlServicio, null, "GET");
            string respData = Json(body).Data.ToString();
            List<tbTipoDoc> tiposDctod = JsonConvert.DeserializeObject<List<tbTipoDoc>>(respData);

            cmbTipoDoc = new SelectList(tiposDctod, "TipoDocId", "TipoDocumento", tipoDoc).ToList();
            cmbTipoDoc.Insert(0, (new SelectListItem { Text = "Seleccionar", Value = "0" }));
            ViewBag.TipoDoc = cmbTipoDoc;
        }

        public List<string> validaciones(tbCliente cliente)
        {
            List<string> resp = new List<string>();
            string urlServicio = WebConfigurationManager.AppSettings["urlServicioCliente"].ToString() + "GetClientes";

            //Valida nro documnto unico
            string body = llamaServicio(urlServicio, null, "GET");
            string respData = Json(body).Data.ToString();
            List<tbCliente> clientes = JsonConvert.DeserializeObject<List<tbCliente>>(respData);

            tbCliente client = (from c in clientes
                                where c.Documento == cliente.Documento
                                   && c.ClienteId != cliente.ClienteId
                                select c).FirstOrDefault();

            if (client != null)
            {
                resp.Add("El número de documento ya existe en la base de datos.");
            }

            return resp;
        }

        public JsonResult ActualizaListaPolizaCliente(string[] clientes, string[] polizas, string[] fecha)
        {
            string resp = "OK";
            List<tbPolizaPorCliente> lstPolizaCLient = new List<tbPolizaPorCliente>();
            for (int i = 0; i < clientes.Length; i++)
            {
                tbPolizaPorCliente polizaCLie = new tbPolizaPorCliente();
                polizaCLie.ClientreId = int.Parse(clientes[i].Split('-')[0].Trim().ToString());
                polizaCLie.PolizaId = int.Parse(polizas[i].Split('-')[0].Trim().ToString());
                polizaCLie.FechaInicio = DateTime.Parse(fecha[i]);

                lstPolizaCLient.Add(polizaCLie);
            }

            try
            {
                byte[] data = null;
                string json = JsonConvert.SerializeObject(lstPolizaCLient);
                data = UTF8Encoding.UTF8.GetBytes(json);

                string urlServicio = WebConfigurationManager.AppSettings["urlServicioCliente"].ToString() + "AddClientePoliza";
                //LLama servicio
                string body = llamaServicio(urlServicio, data, "POST");

                if (!string.IsNullOrEmpty(body))
                    resp = "Registros agregados";
                else
                    resp = "Error en el servicio.";
            }
            catch (Exception ex)
            {
                resp = "Exception: " + ex.Message; ;

            }

            return Json(resp);
        }

        #endregion
    }
}