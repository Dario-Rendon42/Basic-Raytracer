using Basic_Raytracer.Models;
using MathNet.Spatial.Euclidean;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Basic_Raytracer.Shapes
{
    public class Plane : IShape
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Scene Scene { get; set; }
        public Point3D Origin { get; set; }
        public Color Color { get; set; }

        // Aditional Plane specific properties
        public Point3D Normal { get; set; } // 
        public float IntersectionPoint(Ray3D ray)
        {
            throw new NotImplementedException();
        }
    }
}
