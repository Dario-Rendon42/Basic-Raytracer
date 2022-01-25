using Basic_Raytracer.Models;
using MathNet.Spatial.Euclidean;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Basic_Raytracer.Shapes
{
    public class Sphere : IShape
    {
        public int ID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Scene Scene { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Point3D Origin { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Color Color { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public float IntersectionPoint(Ray3D ray)
        {
            throw new NotImplementedException();
        }
    }
}
