using MachineTest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MachineTest3.Models
{
    public class TransactionModel
    {
        public int TransID { get; set; }
        public int ItemID { get; set; }
        public string TransType { get; set; }
        public int TransQty { get; set; }
        public System.String TransDate { get; set; }

        public string SaveTrans(TransactionModel model)
        {
            string msg = "";
            MachineTest3Entities Db = new MachineTest3Entities();
            if (model.TransID == 0)
            {
                var ItemData = new Transaction()
                {
                    ItemID = model.ItemID,
                    TransType = model.TransType,
                    TransQty = model.TransQty,
                    TransDate = Convert.ToDateTime(model.TransDate),

                };
                Db.Transactions.Add(ItemData);
                Db.SaveChanges();
                return msg;
            }
            else
            {
              var TransData = Db.Transactions.Where(p=>p.TransID == model.TransID).FirstOrDefault();
                if(TransData != null)
                {
                    TransData.TransID = model.TransID;
                    TransData.ItemID = model.ItemID;
                    TransData.TransType = model.TransType;
                    TransData.TransQty = model.TransQty;
                    TransData.TransDate =Convert.ToDateTime(model.TransDate);
                };
                Db.SaveChanges();
                msg = "Updated Successfully";
            }
            return msg;
            
        }

        public List<TransactionModel> GetTransList()
        {
            MachineTest3Entities db = new MachineTest3Entities();
            List<TransactionModel> lstTrans = new List<TransactionModel>();
            
            var TransData = db.Transactions.ToList();
            if (TransData != null)
            {
                foreach (var trans in TransData)
                {
                    lstTrans.Add(new TransactionModel()
                    {
                        TransID= trans.TransID, 
                        ItemID = trans.ItemID,
                        TransType = trans.TransType,
                        TransQty = trans.TransQty,
                        TransDate = trans.TransDate.ToString(),
                    
                    });
                }
            }
            return lstTrans;
        } 

        public TransactionModel EditTrans(int TransID)
        {
            string msg = "";
            TransactionModel model = new TransactionModel();
            MachineTest3Entities Db = new MachineTest3Entities();
            var transData = Db.Transactions.Where(p => p.TransID == TransID).FirstOrDefault();
            if (transData != null)
            {
                model.TransID = transData.TransID;
                model.ItemID = transData.ItemID;
                model.TransType = transData.TransType;
                model.TransQty = transData.TransQty;
                model.TransDate = Convert.ToString(transData.TransDate);
            };
            return model;
        }

        public string DeleteTrans(int TransID)
        {
            string msg = "";
            MachineTest3Entities Db = new MachineTest3Entities();
            var TransData = Db.Transactions.Where(p => p.TransID == TransID).FirstOrDefault();
            if (TransData != null)
            {
                Db.Transactions.Remove(TransData);
            };
            Db.SaveChanges();
            msg = "Record id deleted";
            return msg;
        }
    }

}
