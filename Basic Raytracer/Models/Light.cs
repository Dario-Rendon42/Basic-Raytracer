using MathNet.Spatial.Euclidean;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Basic_Raytracer.Models
{
    public class Light
    {
        public int ID { get; set; }
        public Color LightColor { get; set; }
        public double Intensity { get; set; }
        public Point3D Origin { get; set; }
    }
}
