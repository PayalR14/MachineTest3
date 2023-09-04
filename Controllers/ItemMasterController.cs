using MachineTest3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MachineTest3.Controllers
{
    public class ItemMasterController : Controller
    {
        // GET: ItemMaster
        public ActionResult ItemMasterIndex()
        {
            return View();
        }
        public ActionResult SaveItemMaster(ItemMasterModel model)
        {
            try
            {
                return Json(new { model = new ItemMasterModel().SaveItemMaster(model) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new {model=ex.Message},JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult ListItem()
        {
            try
            {
                return Json(new { model = new ItemMasterModel().GetItemList() }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        
        public ActionResult EditItem(int ItemID)
        {
            try
            {
                return Json(new { model = (new ItemMasterModel()).EditItem(ItemID) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult DeleteItem(int ItemID)
        {
            try
            {
                return Json(new { model = (new ItemMasterModel().DeleteItem(ItemID)) }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(new { model = ex.Message },JsonRequestBehavior.AllowGet);
            }
        }
        
    }
}