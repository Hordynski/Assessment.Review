﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assessment.Review.Models
{
    public class Product
    {
        public int ID { get; set; }
        public int ItemID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}