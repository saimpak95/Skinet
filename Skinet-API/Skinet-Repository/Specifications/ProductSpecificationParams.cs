using System;
using System.Collections.Generic;
using System.Text;

namespace Skinet_Repository.Specifications
{
   public class ProductSpecificationParams
    {
        private const int maxPageSize = 50;
        public int PageIndex { get; set; } = 1;
        private int pageSize = 6;
        public int PageSize {
            get => pageSize;
            set=> pageSize = (value> maxPageSize) ? maxPageSize : value; 
        }
        public int? BrandID { get; set; }
        public int? TypeID { get; set; }
        public string Sort { get; set; }
    }
}
