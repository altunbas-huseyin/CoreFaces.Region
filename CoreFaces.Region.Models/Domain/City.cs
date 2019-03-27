using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFaces.Region.Models.Domain
{
    public class City : EntityBase
    {
        public string Title { get; set; } = "";
        public int RegionId { get; set; } = 0;
    }
}
