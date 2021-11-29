using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;

namespace INVEQUIPOWEB.Views
{
    [Authorize(Roles = "Administrador, SubAdmin")]

    public class tblReunionController : Controller
    {
        private tblReunion Oreunion = new tblReunion();
        private tblEquipo Oequipo = new tblEquipo();
        private tblPersonas Opersonas = new tblPersonas();

        //private IEnumerable<SelectListItem> tblEquipo;

        // GET: tblReunion
        public ActionResult Index()
        {
            return View();
        }

      

        public ActionResult tblReunionListar()
        {
            return View(Oreunion.Listar());
        }

        public ActionResult tblReunionVer(int ID)
        {
            ViewBag.Equipo = Oequipo.ListadoCmbEquipo();
            ViewBag.Persona = Opersonas.ListadoCmbPersonas();
            return View(Oreunion.Obtener(ID));
        }

        public ActionResult tblReunionAdd(int ID = 0)
        {
            ViewBag.Equipo = Oequipo.ListadoCmbEquipo();
            ViewBag.Persona = Opersonas.ListadoCmbPersonas();

            return View(ID == 0 ? new tblReunion() : Oreunion.Obtener(ID));
        }

        //public PartialViewResult tblReunionEquipo (int Equipo_id)
        //{

        //    var oEquipo = Oreunion.Listar(Equipo_id);
        //    //Listar los equipos disponibles
        //    ViewBag.Equipos = oEquipo;

        //    //Listar Equipos Disponibles para la reunion
        //    ViewBag.oEquipo = Oequipo.tblEquipoDisponibles(Equipo_id);

        //    Oreunion.Equipo_Id = Equipo_id;

        //    return PartialView(Oreunion);




        //}


        public JsonResult Guardar(tblReunion model)
        {
            var rm = new JsonModel();
            if (ModelState.IsValid)
            {
                rm = model.Guardar();
                if (rm.response)
                {
                    rm.href = Url.Content("~/tblReunion/tblReunionListar");
                }
            }
            return Json(rm);
        }

        public ActionResult tblReunionEliminar(int ID)
        {
            Oreunion.IDReunion = ID;
            Oreunion.Eliminar();
            return Redirect("~/tblReunion/tblReunionListar");
        }
    }
}