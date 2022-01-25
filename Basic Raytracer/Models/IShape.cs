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

        public float IntersectionPoint(Ray3D ray);

        public Color Draw(Ray3D ray)
        {
            return Color;
        }
    }
}