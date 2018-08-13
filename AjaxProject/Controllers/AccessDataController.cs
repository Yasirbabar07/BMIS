using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using AjaxProject.Models;
namespace AjaxProject.Controllers
{
    public class AccessDataController : Controller
    {
        AjaxProject.Models.dbclass ObjClass = new AjaxProject.Models.dbclass();
        // GET: Home
       

        public JsonResult LoginAction(DataKeeper[] data, string action)
        {

            return Json(ObjClass.LoginSelector(data, action), JsonRequestBehavior.AllowGet);

        }

        //public JsonResult SingleAction(DataKeeper[] data, string action)
        //{

        //    return Json(ObjClass.DataProcessor(data, action), JsonRequestBehavior.AllowGet);

        //}
        //public JsonResult MultiAction(DataKeeper[] data, int colms, ArrayDetails[] Details, string action)
        //{

        //    return Json(ObjClass.DataProcessor1(data, colms, Details, action), JsonRequestBehavior.AllowGet);

        //}
        //public JsonResult SingleList(DataKeeper[] data, string action)
        //{
        //    return Json(ObjClass.DataSelectorLess(data, action), JsonRequestBehavior.AllowGet);
        //}
        //public JsonResult MultiList(DataKeeper[] data, string action)
        //{
        //    return Json(ObjClass.DataSelector(data, action), JsonRequestBehavior.AllowGet);
        //}

    }
}