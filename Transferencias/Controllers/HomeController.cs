using System.Web.Mvc;
using WebService;

namespace Transferencias.Controllers
{
    public class HomeController : Controller
    {
        Transactions _trans = new Transactions();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Transacciones()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetClientes()
        {
            var dato = _trans.GetClientes();
            return Json(dato, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetCuentas(int id)
        {
            var dato = _trans.GetCuentas(id);
            return Json(dato, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CrearTransaccion(TransaccionDto transaccion)
        {
            _trans.InsTransaccion(transaccion);
            return View();
        }

        [HttpPost]
        public JsonResult GetTransacciones()
        {
            var datos = _trans.GetTransacciones();
            return Json(datos, JsonRequestBehavior.AllowGet);
        }
    }
}