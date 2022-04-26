using MathNet.Spatial.Euclidean;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Basic_Raytracer.Models.Shapes
{
    public class Sphere : IShape
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Scene Scene { get; set; }
        public Point3D Origin { get; set; }
        public Color Color { get; set; }

        // Aditional Shpere specific properties

        public double Radius { get; set; }

        public (double?, Vector3D?) CalculateIntersection(Ray3D ray)
        {
            // https://www.lighthouse3d.com/tutorials/maths/ray-sphere-intersection/
            var relativeOrigin = Origin - ray.ThroughPoint.ToVector3D();
            var projectionDist = ray.Direction.DotProduct(relativeOrigin.ToVector3D());
            var intersectionMidPoint = ray.ThroughPoint + ray.Direction.ScaleBy(projectionDist);
            var originToIntersectDist = Origin.DistanceTo(intersectionMidPoint);
            if(projectionDist > 0) // center of sphere is in front of ray start
            {
                if (originToIntersectDist >= Radius) // counting tangent as no hit for simplicity
                {
                    return (null, null);
                }
            } else // center of sphere is behind or on ray start
            {
                var originToThroughPointDist = Origin.DistanceTo(ray.ThroughPoint);
                if (originToThroughPointDist >= Radius) // an intersection is still possible if ray start is inside of sphere
                {
                    return (null, null);
                }
            }

            var normal = intersectionMidPoint - Origin;

            // pythagorean theorem to find possible intersections
            // A^2 + B^2 = C^2
            // A = √(C^2 - B^2)
            var projectionToIntersectionDist = Math.Sqrt(Math.Pow(Radius, 2) - Math.Pow(originToIntersectDist, 2));
            var lowerIntersectDist = projectionDist - projectionToIntersectionDist;
            if (lowerIntersectDist > 0)
            {
                return (lowerIntersectDist, normal);
            }
            var higherIntersectDist = projectionDist + projectionToIntersectionDist;
            return (higherIntersectDist, normal);
        }
    }
}
