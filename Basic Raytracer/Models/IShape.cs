using MathNet.Spatial.Euclidean;
using System.Drawing;

namespace Basic_Raytracer.Models
{
    public interface IShape
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Scene Scene { get; set; }
        public Point3D Origin { get; set; }

        public Color Color { get; set; }

        // returns null if there is no intersections or infinite intersections
        // returns the distance to the closest intersection between the object and the ray start and the normal of the intersection
        public (double?, Vector3D?) CalculateIntersection(Ray3D ray);
    }
}