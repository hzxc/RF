using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RF.Web.Models
{
    public class ResultViewModel
    {
        public AjaxMsgStatus Status { get; set; }
        public string Msg { get; set; }
        public object Data { get; set; }
    }


    public enum AjaxMsgStatus
    {
        Success = 1,
        Error = 2
    }
}
