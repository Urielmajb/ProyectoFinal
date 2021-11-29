using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;

namespace INVEQUIPOWEB.Controllers
{
    [Authorize (Roles ="Administrador, SubAdmin")]
    public class tblEquipoController : Controller
    {

        private tblEquipo Oequipo = new tblEquipo();

        // GET: tblEquipo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult tblEquipoListar ()
        {
            return View(Oequipo.Listar());
        }

        public ActionResult tblEquipoVer(int ID)
        {
            return View(Oequipo.Obtener(ID));
        }

        public ActionResult tblEquiposAdd(int ID = 0)
        {
            return View(ID == 0 ? new tblEquipo() : Oequipo.Obtener(ID));
        }

        public JsonResult Guardar(tblEquipo model)
        {
            var rm = new JsonModel();
            if (ModelState.IsValid)
            {
                rm = model.Guardar();
                if (rm.response)
                {
                    rm.href = Url.Content("~/tblEquipo/tblEquipoListar");
                }
            }
            return Json(rm);
        }

        public ActionResult tblEquipoEliminar(int ID)
        {
            Oequipo.ID_Equipo = ID;
            Oequipo.Eliminar();
            return Redirect("~/tblEquipo/tblEquipoListar");
        }







    }
}