using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiciosSeguros.Models;
using ServiciosSeguros.Repositoios;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicioSegurosTest
{
    [TestClass]
    public class PolizaTest
    {
        private RepositorioPoliza repositorioPoliza;

        public PolizaTest()
        {
            repositorioPoliza = new RepositorioPoliza();
        }

        [TestMethod]
        public void PostAddPoliza_objeto_valido_Async()
        {
            var poliza = new TbPoliza();
            poliza.PolizaId = 0;
            poliza.Nombre = "test 1";
            poliza.Descriocion = "desc test 1";
            poliza.TipoCubrimiento = 1;
            poliza.Cubrimiento = 90;
            poliza.InicioVigencia = DateTime.Now;
            poliza.PeriodoCobertura = 10;
            poliza.Precio = 10000;
            poliza.TipoRiesgo = 1;

            var response = repositorioPoliza.AddPoliza(poliza).Result;
            // Assert
            Assert.IsInstanceOfType(response, typeof(CreatedAtActionResult));
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestObjectResult))]
        public void PostAddPoliza_objeto_No_valido_Async()
        {
            var poliza = new TbPoliza();
            poliza.PolizaId = 0;
            poliza.Nombre = "test 1";
            poliza.Descriocion = "desc test 1";
            poliza.TipoCubrimiento = 1;
            poliza.Cubrimiento = 90;
            poliza.InicioVigencia = DateTime.Now;
            poliza.PeriodoCobertura = 10;
            poliza.Precio = 10000;
            poliza.TipoRiesgo = 4;

            var response = repositorioPoliza.AddPoliza(poliza).Result;
            // Assert
            Assert.IsInstanceOfType(response, typeof(BadRequestObjectResult));
        }
    }
}
