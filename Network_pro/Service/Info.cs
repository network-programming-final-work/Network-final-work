using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service
{
    public class Info
    {
        public int InfoId { get; set; }
        public string InfoContent { get; set; }
        public int InfoType { get; set; }
        public DateTime FinishTime { get; set; }
        public int UserId { get; set; }
        public int InfoState { get; set; }

    }
}