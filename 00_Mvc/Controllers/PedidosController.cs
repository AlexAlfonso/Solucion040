﻿using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using _04_Data.Data;
using _02_Services.PedidosServices;
using _04_Data.ViewModels;
using _04_Data.Dtos;

namespace _00_Mvc.Controllers
{
    public class PedidosController : Controller
    {
        //private NorthWindTuneadoDbContext db = new NorthWindTuneadoDbContext();

        // GET: Pedidos
        public ActionResult Index(int? id, string madre, string nombreMadre)
        {
            //Necesitamos un IList<Pedido> para pasárselo a la View
            IList<PedidoDto> pedidoDto = null;
            //Creamos un objeto de la Clase PedidosService
            PedidosService service = null;
            service = new PedidosService();
            //Lo utilizamos para llegar a su método List 
            //Y, así rellenar nuestro IList<Pedido> pedidos
            pedidoDto = service.List(id, madre);
            ViewBag.Message = "";
            if (madre != null && madre != "")
            {
                ViewBag.Message = "Pedidos del " + madre + ": " + nombreMadre;
            }
            return View(pedidoDto);
        }

        // GET: Pedidos/Details/5
        public ActionResult Details(int? id)
        {
            //Esto como estaba:
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //hasta aquí
            //Nuevo
            //Necesitamos un objeto Pedido para pasárselo a la View
            PedidoDto pedidoDto = null;
            //Creamos un objeto de la Clase PedidosService
            PedidosService service = null;
            service = new PedidosService();
            //Lo utilizamos para llegar a su método Detail 
            //Y, así rellenar nuestro Pedido pedido
            pedidoDto = service.Detail(id.Value);
            //Fin Nuevo
            //Esto como estaba:
            if (pedidoDto == null)
            {
                return HttpNotFound();
            }
            return View(pedidoDto);
            //hasta aquí
        }

        // GET: Pedidos/Create
        public ActionResult Create()
        {
            ClientesEmpleadosNavierasPedidoViewModel viewModel = null;

            PedidosService service = null;
            service = new PedidosService();

            viewModel = service.RellenaViewModel();
            //ViewBag.CustomerID = SelectListsClienteRellenator(null);
            //ViewBag.EmployeeID = SelectListsEmpleadoRellenator(null);
            //ViewBag.shipperID = SelectListsNavieraRellenator(null);
            return View(viewModel);
        }

        // POST: Pedidos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PedidoDto pedidoDto)
        {
            if (ModelState.IsValid)
            {
                PedidosService service = new PedidosService();
                bool ok = false;
                ok = service.Create(pedidoDto);
                if (ok == true)
                {
                    //Si esto sucede, entonces llama al método "Index"
                    return RedirectToAction("Index");
                }
            }
            ViewBag.Message = "Las Cagao";

            //ViewBag.CustomerID = SelectListsClienteRellenator(viewModel.pedido.CustomerID);
            //ViewBag.EmployeeID = SelectListsEmpleadoRellenator(viewModel.pedido.EmployeeID);
            //ViewBag.shipperID = SelectListsNavieraRellenator(viewModel.pedido.shipperID);

            //ClientesEmpleadosNavierasPedidoViewModel viewModel = null;

            return View(pedidoDto);
        }

        // GET: Pedidos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Nuevo
            //Necesitamos un objeto Pedido para pasárselo a la View
            PedidoDto pedidoDto = null;
            //Creamos un objeto de la Clase PedidosService
            PedidosService service = null;
            service = new PedidosService();
            //Lo utilizamos para llegar a su método Detail 
            //Y, así rellenar nuestro Pedido pedido
            pedidoDto = service.Detail(id.Value);

            //Fin Nuevo
            if (pedidoDto == null)
            {
                return HttpNotFound();
            }
            //ViewBag.CustomerID = SelectListsClienteRellenator(pedido.CustomerID);
            //ViewBag.EmployeeID = SelectListsEmpleadoRellenator(pedido.EmployeeID);
            //ViewBag.shipperID = SelectListsNavieraRellenator(pedido.shipperID);

            return View(pedidoDto);
        }

        // POST: Pedidos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PedidoDto pedidoDto)
        {
            //ESTE OBJETO pedido que ha entrado es NUEVO
            //para comprobarlo, buscamos el que está en la Tabla Pedido
            if (ModelState.IsValid)
            {
                PedidosService service = new PedidosService();
                bool ok = false;
                //Vamos a testear el registro que hay en la tabla:
                PedidoDto buscada = service.Detail(pedidoDto.OrderID);
                //Vemos los valores de el objeto Pedido buscada
                //id = 9
                //name = Bicho
                //description = Cambiamos la descripción
                //El registro de dentro de la Tabla Pedido NO HA CAMBIADO. PORQUE ES OTRO

                ok = service.Edit(pedidoDto);
                if (ok == true)
                {
                    //Si esto sucede, entonces llama al método "Index"
                    return RedirectToAction("Index");
                }
            }
            ViewBag.Message = "Las Cagao";
            //ViewBag.CustomerID = SelectListsClienteRellenator(pedido.CustomerID);
            //ViewBag.EmployeeID = SelectListsEmpleadoRellenator(pedido.EmployeeID);
            //ViewBag.shipperID = SelectListsNavieraRellenator(pedido.shipperID);

            return View(pedidoDto);
        }

        // GET: Pedidos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Nuevo
            //Necesitamos un objeto Pedido para pasárselo a la View
            PedidoDto pedidoDto = null;
            //Creamos un objeto de la Clase PedidosService
            PedidosService service = null;
            service = new PedidosService();
            //Lo utilizamos para llegar a su método Detail 
            //Y, así rellenar nuestro Pedido pedido
            pedidoDto = service.Detail(id.Value);
            //Fin Nuevo
            if (pedidoDto == null)
            {
                return HttpNotFound();
            }
            return View(pedidoDto);
        }

        // POST: Pedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {            //Nuevo
                     //Necesitamos un objeto Pedido para pasárselo a la View
            PedidoDto pedidoDto = null;
            //Creamos un objeto de la Clase PedidosService
            PedidosService service = null;
            service = new PedidosService();
            //Lo utilizamos para llegar a su método Detail 
            //Y, así rellenar nuestro Pedido pedido
            pedidoDto = service.Detail(id);
            //Fin Nuevo
            bool ok = false;
            ok = service.Delete(pedidoDto);

            return RedirectToAction("Index");
        }
        ////SelectListsRellenators
        //private SelectList SelectListsClienteRellenator(int? id)
        //{
        //    ClientesService service = null;
        //    service = new ClientesService();
        //    IList<Cliente> clientes = null;
        //    clientes = service.List(null);
        //    SelectList selectList = null;
        //    if (id != null && id > 0)
        //    {
        //        selectList = new SelectList(clientes, "CustomerID", "CustomerName", id);
        //    }
        //    else
        //    {
        //        selectList = new SelectList(clientes, "CustomerID", "CustomerName");
        //    }

        //    return selectList;
        //}
        //private SelectList SelectListsEmpleadoRellenator(int? id)
        //{
        //    EmpleadosService service = null;
        //    service = new EmpleadosService();
        //    IList<Empleado> empleados = null;
        //    empleados = service.List(null);
        //    SelectList selectList = null;
        //    if (id != null && id > 0)
        //    {
        //        selectList = new SelectList(empleados, "EmployeeID", "FirstName", id);
        //    }
        //    else
        //    {
        //        selectList = new SelectList(empleados, "EmployeeID", "FirstName");
        //    }

        //    return selectList;
        //}
        //private SelectList SelectListsNavieraRellenator(int? id)
        //{
        //    NavierasService service = null;
        //    service = new NavierasService();
        //    IList<Naviera> navieras = null;
        //    navieras = service.List(null);
        //    SelectList selectList = null;
        //    if (id != null && id > 0)
        //    {
        //        selectList = new SelectList(navieras, "shipperID", "shipperName", id);
        //    }
        //    else
        //    {
        //        selectList = new SelectList(navieras, "shipperID", "shipperName");
        //    }

        //    return selectList;
        //}
        protected override void Dispose(bool disposing)
        {
            //bool ok = false;
            ////Creamos un objeto de la Clase PedidosService
            //PedidosService service = null;
            //service = new PedidosService();
            ////Lo utilizamos para llegar a su método Dispose 
            //ok = service.Dispose(disposing);

            //base.Dispose(disposing);
        }
    }
}
