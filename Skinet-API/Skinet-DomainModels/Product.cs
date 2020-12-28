﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Skinet_DomainModels
{
    public class Product  :BaseEntity
    {
        
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public ProductType ProductType { get; set; }
        public int ProductTypeID { get; set; }
        public ProductBrand ProductBrand { get; set; }
        public int ProductBrandID { get; set; }

    }
}
