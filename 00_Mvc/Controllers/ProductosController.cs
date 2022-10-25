using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using _04_Data.Data;
using _02_Services.ProductosServices;
using _02_Services.CategoriasServices;
using _02_Services.ProveedoresServices;
using _04_Data.Dtos;

namespace _00_Mvc.Controllers
{
    public class ProductosController : Controller
    {
        //private NorthWindTuneadoDbContext db = new NorthWindTuneadoDbContext();

        // GET: Productos
        public ActionResult Index(int? id)
        {
            //Necesitamos un IList<Producto> para pasárselo a la View
            IList<ProductoDto> productoDtos = null;
            //Creamos un objeto de la Clase ProductosService
            ProductosService service = null;
            service = new ProductosService();
            //Lo utilizamos para llegar a su método List 
            //Y, así rellenar nuestro IList<Producto> productos
            productoDtos = service.List(id);

            return View(productoDtos);
        }

        // GET: Productos/Details/5
        public ActionResult Details(int? id)
        {
            //Esto como estaba:
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //hasta aquí
            //Nuevo
            //Necesitamos un objeto Producto para pasárselo a la View
            ProductoDto productoDto = null;
            //Creamos un objeto de la Clase ProductosService
            ProductosService service = null;
            service = new ProductosService();
            //Lo utilizamos para llegar a su método Detail 
            //Y, así rellenar nuestro Producto producto
            productoDto = service.Detail(id.Value);
            //Fin Nuevo
            //Esto como estaba:
            if (productoDto == null)
            {
                return HttpNotFound();
            }
            return View(productoDto);
            //hasta aquí
        }

        // GET: Productos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Productos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductoDto productoDto)
        {
            if (ModelState.IsValid)
            {
                ProductosService service = new ProductosService();
                bool ok = false;
                ok = service.Create(productoDto);
                if (ok == true)
                {
                    //Si esto sucede, entonces llama al método "Index"
                    return RedirectToAction("Index");
                }
            }
            ViewBag.Message = "Las Cagao";
            
            return View(productoDto);
        }

        // GET: Productos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }            
            //Nuevo
            //Necesitamos un objeto Producto para pasárselo a la View
            ProductoDto productoDto = null;
            //Creamos un objeto de la Clase ProductosService
            ProductosService service = null;
            service = new ProductosService();
            //Lo utilizamos para llegar a su método Detail 
            //Y, así rellenar nuestro Producto producto
            productoDto = service.Detail(id.Value);
            //Fin Nuevo
            if (productoDto == null)
            {
                return HttpNotFound();
            }

            return View(productoDto);
        }

        // POST: Productos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductoDto productoDto)
        {
            //ESTE OBJETO producto que ha entrado es NUEVO
            //para comprobarlo, buscamos el que está en la Tabla Producto
            if (ModelState.IsValid)
            {
                ProductosService service = new ProductosService();
                bool ok = false;
                //Vamos a testear el registro que hay en la tabla:
                ProductoDto buscada = service.Detail(productoDto.ProductID);
                //Vemos los valores de el objeto Producto buscada
                //id = 9
                //name = Bicho
                //description = Cambiamos la descripción
                //El registro de dentro de la Tabla Producto NO HA CAMBIADO. PORQUE ES OTRO

                ok = service.Edit(productoDto);
                if (ok == true)
                {
                    //Si esto sucede, entonces llama al método "Index"
                    return RedirectToAction("Index");
                }
            }
            ViewBag.Message = "Las Cagao";

            return View(productoDto);
        }

        // GET: Productos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }            
            //Nuevo
            //Necesitamos un objeto Producto para pasárselo a la View
            ProductoDto productoDto = null;
            //Creamos un objeto de la Clase ProductosService
            ProductosService service = null;
            service = new ProductosService();
            //Lo utilizamos para llegar a su método Detail 
            //Y, así rellenar nuestro Producto producto
            productoDto = service.Detail(id.Value);
            //Fin Nuevo
            if (productoDto == null)
            {
                return HttpNotFound();
            }
            return View(productoDto);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {            //Nuevo
            //Necesitamos un objeto Producto para pasárselo a la View
            ProductoDto productoDto = null;
            //Creamos un objeto de la Clase ProductosService
            ProductosService service = null;
            service = new ProductosService();
            //Lo utilizamos para llegar a su método Detail 
            //Y, así rellenar nuestro Producto producto
            productoDto = service.Detail(id);
            //Fin Nuevo
            bool ok = false;
            ok = service.Delete(productoDto);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            //bool ok = false;
            ////Creamos un objeto de la Clase ProductosService
            //ProductosService service = null;
            //service = new ProductosService();
            ////Lo utilizamos para llegar a su método Dispose 
            //ok = service.Dispose(disposing);

            //base.Dispose(disposing);
        }
    }
}
