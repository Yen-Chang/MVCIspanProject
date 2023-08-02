using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjWantWant.ViewModels
{
    public class CAccountStatus
    {
        public string 會員名稱 { get; set; }
        public string 會員信箱 { get; set; }
        public bool 會員狀態 { get; set; }
        public int AccountID { get; set; }
        public MemberAccount 客服 { get; set; }       
        public string 檢舉原因 { get; set; }





        

    }
}