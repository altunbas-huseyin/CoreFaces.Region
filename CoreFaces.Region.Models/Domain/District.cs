using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFaces.Region.Models.Domain
{
    public class District : EntityBase
    {
        public int CityId { get; set; }
        public string Title { get; set; } = "";
    }
}
