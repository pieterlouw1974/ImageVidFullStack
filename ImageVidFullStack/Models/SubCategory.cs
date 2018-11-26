using System;
using System.Collections.Generic;

namespace ImageVidFullStack.Models
{
    public partial class SubCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Catid { get; set; }
    }
}
