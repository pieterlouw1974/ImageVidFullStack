using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageVidFullStack.Models
{
    public partial class VideoModel
    {
        public string ContentType { get; set; }
        public string Filename { get; set; }

        public byte[] Data { get; set; }

    }


}
