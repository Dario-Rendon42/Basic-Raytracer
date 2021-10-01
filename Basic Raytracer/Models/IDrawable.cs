using MathNet.Spatial.Euclidean;
using System.Drawing;

namespace Basic_Raytracer.Models
{
    public interface IDrawable
    {
        Point3D Origin { get; set; }

        Color Color { get; set; }

        Point3D IntersectionPoint(Ray3D ray);
        
        void Draw();
    }
}