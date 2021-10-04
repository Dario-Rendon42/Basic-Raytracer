using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basic_Raytracer.Tables
{
    public class Shape
    {
        public int ID { get; set; }
        public string ShapeName { get; set; }
        public int ShapeTypeID { get; set; }
        public ShapeType ShapeType { get; set; }
        public int SceneID { get; set; }
        public Scene Scene { get; set; }
        public double OriginX { get; set; }
        public double OriginY { get; set; }
        public double OriginZ { get; set; }
        public int ColorRed { get; set; }
        public int ColorGreen { get; set; }
        public int ColorBlue { get; set; }

    }
}
