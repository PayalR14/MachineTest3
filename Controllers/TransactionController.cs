using MachineTest3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MachineTest3.Controllers
{
    public class TransactionController : Controller
    {
        // GET: Transaction
        public ActionResult TransactionIndex()
        {
            return View();
        }
        public ActionResult SaveTrans(TransactionModel model)
        {
            try
            {
                return Json(new { model = new TransactionModel().SaveTrans(model) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetTransList() 
        {
            try
            {
                return Json(new { model = new TransactionModel().GetTransList() }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult EditTrans(int TransID)
        {
            try
            {
                return Json(new { model = new TransactionModel().EditTrans(TransID) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { model = ex.Message },JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult DeleteTrans(int TransID)
        {
            try
            {
                return Json(new { model = new TransactionModel().DeleteTrans(TransID) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}