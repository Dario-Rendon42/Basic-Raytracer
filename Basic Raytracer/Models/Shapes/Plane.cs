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
        public Vector3D Normal { get; set; }
        public (double?, Vector3D?) CalculateIntersection(Ray3D ray)
        {
            // https://www.scratchapixel.com/lessons/3d-basic-rendering/minimal-ray-tracer-rendering-simple-shapes/ray-plane-and-ray-disk-intersection
            var denom = ray.Direction.DotProduct(Normal);
            // if ray dot normal is close enough to zero, then no intersection, otherwise find out if collision with ray line is behind or in  front of ray start
            if (Math.Abs(denom) > 1e-6) // TODO: put margin of error in settings file
            {
                var v = Origin.ToVector3D() - ray.ThroughPoint.ToVector3D();
                var t = v.DotProduct(Normal) / denom;
                if (t >= 0)
                {
                    return (t, Normal);
                }
                return (null, null);
            }
            return (null, null);
        }
    }
}
