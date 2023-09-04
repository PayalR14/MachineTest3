using MachineTest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace MachineTest3.Models
{
    public class ItemMasterModel
    {
        public int ItemID { get; set; }
        public string ItemDescr { get; set; }
        public Nullable<int> BalQty { get; set; }
        public System.String CreatedOn { get; set; }

        public string SaveItemMaster(ItemMasterModel model)
        {
            string msg = "";
            MachineTest3Entities Db = new MachineTest3Entities();
            if (model.ItemID == 0)
            {
                var ItemData = new ItemMaster()
                {
                    
                    ItemDescr = model.ItemDescr,
                    BalQty = model.BalQty,
                    CreatedOn = Convert.ToDateTime(model.CreatedOn),
                };
                Db.ItemMasters.Add(ItemData);
                Db.SaveChanges();
                msg = "Data Saved";
            }
            else
            {
                var ItemData = Db.ItemMasters.Where(p => p.ItemID == model.ItemID).FirstOrDefault();
                if (ItemData != null)
                {
                    ItemData.ItemID = model.ItemID;
                    ItemData.ItemDescr = model.ItemDescr;
                    ItemData.BalQty = model.BalQty;
                    ItemData.CreatedOn = Convert.ToDateTime(model.CreatedOn);

                };
                Db.SaveChanges();
                msg = "Updated Successfully";
            }
            return msg;
            
        }

        public List<ItemMasterModel> GetItemList()
        {
            MachineTest3Entities db = new MachineTest3Entities();
            List<ItemMasterModel> lstItem = new List<ItemMasterModel>();
            var itemData = (from i in db.ItemMasters
                            join t in db.Transactions on i.ItemID equals t.ItemID

                            select new
                            {
                                i.ItemID,
                                i.ItemDescr,
                                i.BalQty,
                                i.CreatedOn,

                            });
            if (itemData != null)
            {
                foreach (var item in itemData)
                {
                    lstItem.Add(new ItemMasterModel()
                    {
                        ItemID = item.ItemID,    
                        ItemDescr = item.ItemDescr,
                        BalQty = item.BalQty,
                        CreatedOn=item.CreatedOn.ToString(),    
                    });
                }
            }
            return lstItem;
        }

        public ItemMasterModel EditItem(int ItemID)
        {
            string msg = "";
            var model = new ItemMasterModel();
            MachineTest3Entities Db=new MachineTest3Entities();
            var itemdata=Db.ItemMasters.Where(p=>p.ItemID == ItemID).FirstOrDefault();
            if (itemdata != null)
            {
                model.ItemID = itemdata.ItemID;
                model.ItemDescr = itemdata.ItemDescr;
                model.BalQty = itemdata.BalQty;
                model.CreatedOn = itemdata.CreatedOn.ToString();
            };
            return model;
        }

        public string DeleteItem(int ItemID)
        {
            string msg = "";
            MachineTest3Entities Db = new MachineTest3Entities();
            var ItemData=Db.ItemMasters.Where(p=>p.ItemID == ItemID).FirstOrDefault();
            if (ItemData != null)
            {
                Db.ItemMasters.Remove(ItemData);
            };
            Db.SaveChanges();
            msg = "Record id deleted";
            return msg;
        }

    }
}