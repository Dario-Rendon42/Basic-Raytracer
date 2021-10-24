using MathNet.Spatial.Euclidean;
using System.Drawing;

namespace Basic_Raytracer.ViewModels
{
    public interface IShapeVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public SceneVM Scene { get; set; }
        public Point3D Origin { get; set; }

        public Color Color { get; set; }

        public Point3D IntersectionPoint(Ray3D ray);

        public void Draw();
    }
}