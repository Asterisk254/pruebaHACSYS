using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pruebaHACSYS.Controllers
{
    [Produces("application/json")]
    [Route("api/Reporte")]
    [ApiController]

    public class ReporteController : ControllerBase
    {
        [HttpGet]
        public List<Reporte> Get()
        {
            List<Reporte> lista = null;

            using (Models.vueContext db = new Models.vueContext())
            {
                lista = (from dato in db.Reportes
                         select new Reporte {  
                            Fecha = dato.Fecha,
                            Descripcion = dato.Descripcion, 
                            Acciones = dato.Acciones,
                            Nombre = dato.Nombre,
                            Estatus = dato.Estatus
                         }
                ).ToList();
            }

            return lista;
        }
    

    [HttpPost]
    public List<Models.Reporte> Post()
    {
            List<Models.Reporte> r = null;
            using (Models.vueContext db = new Models.vueContext())
        {
            
            r = (from dato in db.Reportes
            select new Models.Reporte
            {
                IdReporte = dato.IdReporte,
                Fecha = dato.Fecha,
                Descripcion = dato.Descripcion,
                Acciones = dato.Acciones,
                Nombre = dato.Nombre,
                Estatus = dato.Estatus
            }).ToList();
                foreach (Models.Reporte e in r)
                {
                    db.Reportes.Add(e);
                }
            db.SaveChanges();
            return r;
            };
        }
    }

    public class Reporte
    {
        public string Id { get; set; }
        public string Fecha { get; set; }
        public string Descripcion { get; set; }
        public string Nombre { get; set; }
        public string Acciones { get; set; }
        public string Estatus { get; set; }
        public string Razon { get; set; }
    }
}
