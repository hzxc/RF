using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RF.DataAcess;
using RF.Models;
using RF.Web.Models;
using System.Text.RegularExpressions;

namespace RF.Web.Controllers
{
    public class OrderPartInfoController : Controller
    {
        // GET: OrderPartInfo
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddInfo(string trackingNumber, string serialNumber)
        {
            ResultViewModel Result = new ResultViewModel();

            if (string.IsNullOrEmpty(trackingNumber) || string.IsNullOrEmpty(serialNumber)) {
                Result.Status = AjaxMsgStatus.Error;
                Result.Msg = "数据不能为NULL";
                Result.Data = trackingNumber + ":" + serialNumber;
                return Json(Result);
            }

            string pattern = @"^\d+$";
            Regex reg = new Regex(pattern);
            if (reg.IsMatch(trackingNumber) == false) {
                Result.Status = AjaxMsgStatus.Error;
                Result.Msg = "运单号格式错误";
                Result.Data = trackingNumber + ":" + serialNumber;
                return Json(Result);
            }
            try
            {
                using (ScvDbContext ctx = new ScvDbContext())
                {
                    OrderPartInfo info = new OrderPartInfo()
                    {
                        TrackingNumber = trackingNumber,
                        SerialNumber = serialNumber
                    };
                    if (ctx.OrderPartInfos.Any(o => o.TrackingNumber == trackingNumber && o.SerialNumber == serialNumber)) {
                        Result.Status = AjaxMsgStatus.Error;
                        Result.Msg = "当前条目已经存在";
                        Result.Data = trackingNumber + ":" + serialNumber;
                        return Json(Result);
                    }
                    ctx.OrderPartInfos.Add(info);
                    if (ctx.SaveChanges() > 0)
                    {
                        Result.Status = AjaxMsgStatus.Success;
                        Result.Msg = "成功";
                        Result.Data = trackingNumber + ":" + serialNumber;
                    }
                    else
                    {
                        Result.Status = AjaxMsgStatus.Error;
                        Result.Msg = "失败";
                        Result.Data = trackingNumber + ":" + serialNumber;
                    }
                }
            }
            catch
            {
                Result.Status = AjaxMsgStatus.Error;
                Result.Msg = "失败";
                Result.Data = trackingNumber + ":" + serialNumber;
            }

            return Json(Result);
        }

    }
}