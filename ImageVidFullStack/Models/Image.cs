using System;
using System.Collections.Generic;

namespace ImageVidFullStack.Models
{
    public partial class Image
    {
        public int Id { get; set; }
        public int CatId { get; set; }
        public int SubCatId { get; set; }
        public string Name { get; set; }
        public string Ext { get; set; }
        public int Size { get; set; }
        public string Data { get; set; }
    }
}
