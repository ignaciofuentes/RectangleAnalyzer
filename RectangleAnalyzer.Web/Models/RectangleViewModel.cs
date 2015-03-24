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
        [Range(0, 999)]
        public float X { get; set; }
        [Required]
        [Range(0, 999)]
        public float Y { get; set; }
        [Required]
        [Range(1,999)]
        public float Width { get; set; }
        [Required]
        [Range(1, 999)]
        public float Height { get; set; }
    }
}