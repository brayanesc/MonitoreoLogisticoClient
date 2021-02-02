using MonitoreoLogisticoClient.Data;
using MonitoreoLogisticoClient.Helpers;
using MonitoreoLogisticoClient.Models;
using MonitoreoLogisticoClient.Models.Dtos;
using MonitoreoLogisticoClient.Models.Mapas;
using MonitoreoLogisticoClient.Models.Reportes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MonitoreoLogisticoClient.Controllers
{
    public class ReportesController : Controller
    {
        public OrdenesService ordenesService = new OrdenesService();
        public ItinerariosService itinerariosService = new ItinerariosService();
        public MarcacionesService marcacionesService = new MarcacionesService();
        public MotivosService motivosService = new MotivosService();
        public ClientesService clientesService = new ClientesService();
        public RepartidoresService repartidoresService = new RepartidoresService();
        public UbicacionesService ubicacionesService = new UbicacionesService();


        // GET: Reportes
        [HttpGet]
        public async Task<ActionResult> ReporteMotivosNoEntrega()
        {
            string fechaInicio = Request.QueryString["i"];
            string fechaFinalizacion = Request.QueryString["f"];



            List<ReporteMotivoNoEntrega> modelos = new List<ReporteMotivoNoEntrega>();

            IEnumerable<OrdenEntrega> ordenes;
            ordenes = await ordenesService.obtenerOrdenesEntrega();

            IEnumerable<Itinerario> itinerarios;
            itinerarios = await itinerariosService.obtenerItinerarios();

            IEnumerable<MarcacionEntrega> marcaciones;
            marcaciones = await marcacionesService.obtenerMarcacionesEntrega();

            IEnumerable<MotivoNoEntrega> motivos;
            motivos = await motivosService.obtenerMotivosNoEntrega();

            foreach (var motivo in motivos)
            {
                ReporteMotivoNoEntrega modelo = new ReporteMotivoNoEntrega();

                //buscar marcacionEntrega Asociada
                MarcacionEntrega me = new MarcacionEntrega();
                me = marcaciones.FirstOrDefault(x => x.Id == motivo.MarcacionEntregaId);

                //buscar ordendeEntrega Asociada
                OrdenEntrega o = new OrdenEntrega();
                o = ordenes.FirstOrDefault(x => x.Id == me.OrdenEntregaId);

                //buscar itinerario Asociada
                Itinerario it = new Itinerario();
                it = itinerarios.FirstOrDefault(x => x.Id == o.ItinerarioId);

                modelo.OrdenEntrega = o.Id;
                modelo.Factura = o.NroFactura;

                modelo.Itinerario = it.Descripcion;
                modelo.Fecha = me.Hora;
                modelo.Motivo = motivo.Descripcion;

                modelos.Add(modelo);

            }


            if (fechaInicio != null && fechaFinalizacion != null)
            {
                DateTime FechaInicio = DateTime.Parse(fechaInicio);
                DateTime FechaFinalizacion = DateTime.Parse(fechaFinalizacion);

                modelos = modelos.Where(x => x.Fecha >= FechaInicio && x.Fecha <= FechaFinalizacion).ToList();
            }


            #region datos prueba

            //List<ReporteMotivoNoEntrega> datos = new List<ReporteMotivoNoEntrega>();
            //datos.Add(new ReporteMotivoNoEntrega {
            //    OrdenEntrega = 15,                                  //id                    OrdenEntrega
            //    Factura = 6854,                                     //nroFactura            OrdenEntrega
            //    Itinerario = "Itinerario Sirari",                   //descripcion           Itinerario
            //    Fecha = new DateTime(2018, 03, 12, 8, 30, 12),      //hora                  MarcacionEntrega
            //    Motivo = "Cliente en vacaciones"                    //descripcion           MotivoNoEntrega
            //});

            //datos.Add(new ReporteMotivoNoEntrega {
            //    OrdenEntrega = 16,
            //    Factura = 6854,
            //    Itinerario = "Itinerario Urbari",
            //    Fecha = new DateTime(2018,03,15,8,45,12),
            //    Motivo = "Cliente desconoce la visita"
            //});

            //datos.Add(new ReporteMotivoNoEntrega
            //{
            //    OrdenEntrega = 16,
            //    Factura = 6854,
            //    Itinerario = "Itinerario Polanco",
            //    Fecha = new DateTime(2018, 03, 19, 8, 45, 12),
            //    Motivo = "Cliente en Reunion"
            //});

            //datos.Add(new ReporteMotivoNoEntrega
            //{
            //    OrdenEntrega = 17,
            //    Factura = 6854,
            //    Itinerario = "Itinerario La Salle",
            //    Fecha = new DateTime(2018, 03, 24, 8, 45, 12),
            //    Motivo = "Cliente no recibe al personal"
            //});

            //datos.Add(new ReporteMotivoNoEntrega
            //{
            //    OrdenEntrega = 18,
            //    Factura = 6854,
            //    Itinerario = "Itinerario Banzer",
            //    Fecha = new DateTime(2018, 03, 25, 9, 4, 4),
            //    Motivo = "Cliente cambio la fecha"
            //});


            //datos.Add(new ReporteMotivoNoEntrega
            //{
            //    OrdenEntrega = 21,
            //    Factura = 6854,
            //    Itinerario = "Itinerario Alemana",
            //    Fecha = new DateTime(2018, 03, 27, 7, 38, 12),
            //    Motivo = "Cliente cambio de direccion"
            //});

            #endregion





            return View(modelos);
        }


        public async Task<ActionResult> ObtenerItinerarios(int repartidorId)
        {
            List<Itinerario> itinerarios;
            itinerarios = await itinerariosService.obtenerItinerarios();
            itinerarios = itinerarios.Where(x => x.RepartidorId == repartidorId).ToList();

            return Json(itinerarios, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public async Task<ActionResult> ReporteCumplimiento()
        {

            //selecciona repartidor y el itinerario que desea para el reporte

            //se muestra las ordenes de entrega que fueron realizadas por el repartidor

            List<ReporteCumplimiento> modelos = new List<ReporteCumplimiento>();

            string r = Request.QueryString["r"];
            string i = Request.QueryString["i"];

            int repartidorid = 0;
            int itinerarioid = 0;

            IEnumerable<Repartidor> repartidores;
            repartidores = await repartidoresService.obtenerRepartidores();

            IEnumerable<OrdenEntrega> ordenes;
            ordenes = await ordenesService.obtenerOrdenesEntrega();

            IEnumerable<Cliente> clientes;
            clientes = await clientesService.obtenerClientes();

            IEnumerable<Itinerario> itinerarios;
            itinerarios = await itinerariosService.obtenerItinerarios();


            ViewBag.RepartidoresListItems = repartidores;


            if (r != null && i != null)
            {
                if (Int32.TryParse(r, out repartidorid) && Int32.TryParse(i, out itinerarioid))
                {


                    ordenes = ordenes.Where(x => x.ItinerarioId == itinerarioid);

                    foreach (var orden in ordenes)
                    {
                        Cliente c = new Cliente();
                        c = clientes.FirstOrDefault(x => x.Id == orden.ClienteId);

                        Itinerario it = new Itinerario();
                        it = itinerarios.FirstOrDefault(x => x.Id == itinerarioid);

                        ReporteCumplimiento modelo = new ReporteCumplimiento();
                        modelo.CodigoCliente = c.Id;
                        modelo.Factura = orden.NroFactura;
                        modelo.NombreCliente = c.NombreCompleto;
                        modelo.Estado = orden.Estado;
                        modelo.Itinerario = it.Descripcion;

                        modelos.Add(modelo);
                    }
                }






            }

            //IEnumerable<OrdenEntrega> ordenes;
            //ordenes = await ordenesService.obtenerOrdenesEntrega();


            //IEnumerable<Cliente> clientes;
            //clientes = await clientesService.obtenerClientes();

            //ViewBag.RepartidoresListItems = repartidores;
            //ViewBag.ItinerariosListItems = itinerarios;

            //if (Int32.TryParse(r,out repartidorid) && Int32.TryParse(i,out itinerarioid)) {
            //    ordenes = ordenes.Where(x => x.ItinerarioId == itinerarioid);


            //}

            return View(modelos);


            #region
            //List<ReporteCumplimiento> datos = new List<Models.Reportes.ReporteCumplimiento>();
            //datos.Add(new ReporteCumplimiento {
            //    CodigoCliente = 10,                   //Cliente
            //    Factura = 6854,                       //OrdenEntrega
            //    NombreCliente = "Juan Perez Alvarez", //Cliente
            //    Estado = "Pendiente",                 //OrdenEntrega
            //    Itinerario = "Itinerario Sirari"      //Itinerario
            //});

            //datos.Add(new ReporteCumplimiento {
            //    CodigoCliente = 30,
            //    Factura = 6855,
            //    NombreCliente = "Alejandro Altamirano Vallejo",
            //    Estado = "Entregado",
            //    Itinerario = "Itinerario Sirari"
            //});

            //datos.Add(new ReporteCumplimiento {
            //    CodigoCliente = 70,
            //    Factura = 6856,
            //    NombreCliente = "Carolina Belgrado Paz",
            //    Estado = "No Entregado",
            //    Itinerario = "Itinerario Banzer"
            //});

            //datos.Add(new ReporteCumplimiento {
            //    CodigoCliente = 40,
            //    Factura = 6857,
            //    NombreCliente = "Carlos Galvez Uribe",
            //    Estado = "Entregado",
            //    Itinerario = "Itinerario Zona Alemana"
            //});

            //datos.Add(new ReporteCumplimiento {
            //    CodigoCliente = 80,
            //    Factura = 6858,
            //    NombreCliente = "Pedro Aguilera Roca",
            //    Estado = "Pendiente",
            //    Itinerario = "Itinerario Zona Alemana"
            //});

            #endregion


        }

        public async Task<ActionResult> ReporteItinerario()
        {
            List<ReporteItinerario> datos = new List<ReporteItinerario>();

            datos.Add(new ReporteItinerario
            {
                Itinerario = "Itinerario Banzer",
                OrdenEntrega = 10,
                Estado = "Pendiente",
                FechaEmision = new DateTime(2018, 4, 19, 14, 30, 00)

            });
            //datos.Add(new ReporteItinerario { });
            //datos.Add(new ReporteItinerario { });
            //datos.Add(new ReporteItinerario { });
            //datos.Add(new ReporteItinerario { });
            //datos.Add(new ReporteItinerario { });
            //datos.Add(new ReporteItinerario { });

            return View();


        }


        public async Task<ActionResult> ReporteEstadoEntregas()
        {
            return View();
        }

        public async Task<ActionResult> datosReporteEstadoEntregas()
        {

            IEnumerable<OrdenEntrega> ordenes;
            ordenes = await ordenesService.obtenerOrdenesEntrega();

            IEnumerable<Cliente> clientes;
            clientes = await clientesService.obtenerClientes();

            IEnumerable<Ubicacion> ubicaciones;
            ubicaciones = await ubicacionesService.obtenerUbicaciones();

            List<Marcador> Marcadores = new List<Marcador>();

            foreach (var orden in ordenes)
            {
                Cliente c = new Cliente();
                c = clientes.FirstOrDefault(x => x.Id == orden.ClienteId);

                Ubicacion u = new Ubicacion();
                u = ubicaciones.FirstOrDefault(x => x.Id == c.UbicacionId);

                Marcador marcador = new Marcador();

                marcador.Nombre = c.NombreCompleto;
                marcador.Descripcion = orden.Estado;
                marcador.Latitud = (float)double.Parse(u.Latitud, CultureInfo.InvariantCulture);
                marcador.Longitud = (float)double.Parse(u.Longitud, CultureInfo.InvariantCulture);

                switch (orden.Estado)
                {
                    case "Entregado":
                        marcador.Icono = "http://maps.google.com/mapfiles/ms/icons/green-dot.png";
                        break;
                    case "Pendiente":
                        marcador.Icono = "http://maps.google.com/mapfiles/ms/icons/yellow-dot.png";
                        break;
                    case "No Entregado":
                        marcador.Icono = "http://maps.google.com/mapfiles/ms/icons/red-dot.png";
                        break;
                    default:
                        marcador.Icono = "http://maps.google.com/mapfiles/ms/icons/blue-dot.png";
                        break;
                }

                Marcadores.Add(marcador);

            }


            return (Json(Marcadores, JsonRequestBehavior.AllowGet));
        }
    }
}