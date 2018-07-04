using System;
using System.Collections.Generic;
using System.Text;

namespace Datos
{
    public class Territories
    {
        public string TerritoryID { get; set; }
        public string TerritoryDescription { get; set; }
        public int RegionID { get; set; }

        public virtual Region Region { get; set; }
    }
}
