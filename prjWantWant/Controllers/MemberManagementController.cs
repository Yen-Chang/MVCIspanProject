using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prjWantWant.Controllers
{
    public class MemberManagementController : Controller
    {
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("List");
            NewIspanProjectEntities db = new NewIspanProjectEntities();
            MemberAccount prod = db.MemberAccount.FirstOrDefault(p => p.AccountID == id);
            if (prod == null)
                return RedirectToAction("List");
            return View(prod);
        }

        [HttpPost]
        public ActionResult Edit(MemberAccount pIn)
        {
            NewIspanProjectEntities db = new NewIspanProjectEntities();
            MemberAccount pDb = db.MemberAccount.FirstOrDefault(p => p.AccountID == pIn.AccountID);
            if (pDb != null)
            {                
                pDb.Name = pIn.Name;
                pDb.Email = pIn.Email;
                // 會員帳號狀態: 1正常 0停權
                pDb.AccountStatus = pIn.AccountStatus;
                // 會員ID
                pDb.MemberStatusList.First().AccountID = pIn.MemberStatusList.First().AccountID;
                // 客服
                pDb.MemberStatusList.First().UpdateUser = pIn.MemberStatusList.First().UpdateUser;
                // 會員登入時間
                pDb.MemberStatusList.First().UpdateTime = pIn.MemberStatusList.First().UpdateTime;
                // 檢舉原因
                pDb.MemberStatusList.First().StatusChangeReasonList.StatusChangeReason = pIn.MemberStatusList.First().StatusChangeReasonList.StatusChangeReason;
                
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }

        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                NewIspanProjectEntities db = new NewIspanProjectEntities();
                MemberAccount prod = db.MemberAccount.FirstOrDefault(p => p.AccountID == id);
                if (prod != null)
                {
                    db.MemberAccount.Remove(prod);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("List");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(MemberAccount p)
        {
            NewIspanProjectEntities db = new NewIspanProjectEntities();
            db.MemberAccount.Add(p);
            db.SaveChanges();
            return RedirectToAction("List");
        }
        
        public ActionResult List()
        {
            string keyword = Request.Form["txtKeyword"];
            IEnumerable<MemberAccount> datas = null;
            NewIspanProjectEntities db = new NewIspanProjectEntities();
            if (string.IsNullOrEmpty(keyword))
                datas = from p in db.MemberAccount
                        select p;
            else
                datas = db.MemberAccount.Where(p => p.Name.Contains(keyword));
            return View(datas);
        }
    }
}
