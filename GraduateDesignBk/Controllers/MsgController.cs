using GraduateDesignBk.Models;
using GraduateDesignBk.Models.ViewsModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GraduateDesignBk.Controllers
{
    [Authorize(Roles = "管理员")]
    public class MsgController : Controller
    {
        // GET: Msg
        public ActionResult MsgNotes()
        {
            List<MsgViewModel> msgs =  getMsgList(MsgType.通知);
            ViewBag.msgType = MsgType.通知;
            return View(msgs);
        }
        public ActionResult MsgPrivate()
        {
            List<MsgViewModel> msgs = getMsgList(MsgType.私信);
            ViewBag.msgType = MsgType.私信;
            return View(msgs);
        }
        public ActionResult MsgLike()
        {
            List<MsgViewModel> msgs = getMsgList(MsgType.赞);
            ViewBag.msgType = MsgType.赞;
            return View(msgs);
        }
        public ActionResult MsgCommentAlert()
        {
            List<MsgViewModel> msgs = getMsgList(MsgType.评论);
            ViewBag.msgType = MsgType.评论;
            return View(msgs);
        }
        public List<MsgViewModel> getMsgList(MsgType msgType)
        {
            List<MsgViewModel> msgs = db.Mesg.ToList().Select(m =>
                new MsgViewModel()
                {
                    NID = m.NID,
                    CreateTime = m.CreateTime,
                    Detail = m.Detail,
                    FromUID = m.FromUID,
                    Photo = UserManager.FindById(m.FromUID).Photo,
                    FromName = UserManager.FindById(m.FromUID).RealName,
                    userType = UserManager.GetRoles(m.FromUID).First(),
                    msgType = m.msgType,
                    sendInfo = db.MassMeg.Where(s => s.NID == m.NID).ToList().Select(s =>
                        new SendInfo()
                        {
                            NID = m.NID,
                            ReceiveId = s.ToUID,
                            ReceiveName = UserManager.FindById(s.ToUID).RealName,
                            userType = UserManager.GetRoles(s.ToUID).First(),
                        }).ToList()
                }
            ).ToList();
            msgs = msgs.Where(m => m.msgType == msgType).OrderByDescending(m=>m.CreateTime).ToList();
            return msgs;
       }
        public ActionResult DeleteMany(string Id,MsgType msgType)
        {
            string[] ids = Id.Split('|');
            foreach (string id in ids)
            {
                if (db.Mesg.Where(m => m.NID.Equals(id)).Count() > 0)
                {
                    Mesg notice = db.Mesg.Where(m => m.NID.Equals(id)).First();
                    if(notice == null)
                    {
                        return new HttpNotFoundResult();
                    }
                    db.Mesg.Remove(notice);
                }

            }
            db.SaveChanges();
            return RedirectToAction("Index",new { msgType = msgType });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_contextManger != null)
                {
                    _contextManger.Dispose();
                    _contextManger = null;
                }
            }

            base.Dispose(disposing);
        }

        #region 初始化
        private ApplicationUserManager _userManager;
        public ApplicationDbContext _contextManger;
        public ApplicationDbContext db
        {
            get
            {
                return _contextManger ?? HttpContext.GetOwinContext().Get<ApplicationDbContext>();
            }
            private set
            {
                _contextManger = value;
            }
        }
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }  
            private set
            {
                _userManager = value;
            }
        }
        #endregion
    }
}