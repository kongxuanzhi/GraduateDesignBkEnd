﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateDesignBk.Models
{
    public class Mesg
    {
        public Mesg() //消息
        {
            this.CreateTime = DateTime.Now;
            NID = Guid.NewGuid().ToString();
        }
        [Key]
        [StringLength(128)]
        public string NID { get; set; }

        public DateTime CreateTime { get; set; }

        [StringLength(500)]
        public string Detail { get; set; }

        [StringLength(128)]
        public string FromUID { get; set; }

        public MsgType msgType { get; set; }
    }
    public enum MsgType
    {
        赞,
        评论,
        私信,
        通知
    }
}