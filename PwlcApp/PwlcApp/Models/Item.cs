﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PwlcApp.Models
{
    public class Item
    {
        [Key]
        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
    }
}