using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateDesignBk.Models.ViewsModel
{
    public class MsgViewModel
    {
        public MsgViewModel()
        {
        }
        public string NID { get; set; }
        [Display(Name = "信息内容")]
        public string  Detail { get; set; }
        [Display(Name = "发送时间")]
        public DateTime CreateTime { get; set; }
        public MsgType msgType { get; set; }

        [Display(Name = "发送人")]
        public string  FromUID { get; set; }
        public string  FromName { get; set; }
        public string Photo { get; set; }
        public string userType { get; set; }
        public List<SendInfo> sendInfo { get; set; }
    }
    
    public class SendInfo
    {
        public string NID {get; set; }
        public string ReceiveName { get; set; } //接受人姓名
        public string ReceiveId { get; set; } //接收人Id
        public string userType { get; set; }

    }
}
