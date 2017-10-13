using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RF.Models
{
    [Table("OrderPartInfo", Schema = "Order")]
    public class OrderPartInfo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string TrackingNumber{get;set;}
        public string SerialNumber { get; set; }

    }
}
