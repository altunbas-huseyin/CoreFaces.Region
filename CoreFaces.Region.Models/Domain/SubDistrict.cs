using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFaces.Region.Models.Domain
{
    public class SubDistrict : EntityBase
    {
        public int DistrictId { get; set; }
        public string Title { get; set; }
    }
}
