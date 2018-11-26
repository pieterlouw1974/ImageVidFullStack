using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageVidFullStack.Models
{
    public partial class VideoList
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string Contenttype { get; set; }
    }
}
