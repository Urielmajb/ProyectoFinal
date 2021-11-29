using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;

namespace INVEQUIPOWEB.Controllers
{

    [Authorize(Roles = "Administrador, SubAdmin")]

    public class tblPersonasController : Controller
    {

        private tblPersonas Opersonas = new tblPersonas();
        // GET: tblPersonas
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult tblPersonasListar()
        {
            return View(Opersonas.Listar());
        }

        public ActionResult tblPersonaVer(int ID)
        {
            return View(Opersonas.Obtener(ID));
        }

        public ActionResult tblPersonaAdd(int ID = 0)
        {
            return View(ID == 0 ? new tblPersonas() : Opersonas.Obtener(ID));
        }

        public JsonResult Guardar(tblPersonas model)
        {
            var rm = new JsonModel();
            if (ModelState.IsValid)
            {
                rm = model.Guardar();
                if (rm.response)
                {
                    rm.href = Url.Content("~/tblPersonas/tblPersonasListar");
                }
            }
            return Json(rm);
        }

        public ActionResult tblPersonasliminar(int ID)
        {
            Opersonas.IDPersona = ID;
            Opersonas.Eliminar();
            return Redirect("~/tblPersonas/tblPersonasListar");
        }

    }
}