using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RectangleAnalyzer.Web.Models
{
    public class RectangleViewModel
    {
        [Required]
        public float X { get; set; }
        [Required]
        public float Y { get; set; }
        [Required]
        public float Width { get; set; }
        [Required]
        public float Height { get; set; }
    }
}