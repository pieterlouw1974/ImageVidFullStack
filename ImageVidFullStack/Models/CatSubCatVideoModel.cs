using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageVidFullStack.Models
{
    public partial class CatSubCatVideoModel
    {
        public int catid { get; set; }
        public int subcatid { get; set; }
        public string filename { get; set; }
    }
}
