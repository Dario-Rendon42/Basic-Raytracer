using MathNet.Spatial.Euclidean;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basic_Raytracer.Tables
{
    public class Camera
    {
        public int ID { get; set; }
        public Scene scene { get; set; }
        public double OriginX { get; set; }
        public double OriginY { get; set; }
        public double OriginZ { get; set; }
        public double SubjectX { get; set; }
        public double SubjectY { get; set; }
        public double SubjectZ { get; set; }
        public double FOV { get; set; }
    }
}
