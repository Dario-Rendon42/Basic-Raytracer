using Basic_Raytracer.Models;
using MathNet.Spatial.Euclidean;

namespace Basic_Raytracer.ViewModels
{
    public class CameraVM
    {
        public int ID { get; set; }
        public SceneVM Scene { get; set; }
        public Point3D Origin { get; set; }
        public Point3D Subject { get; set; }
        public double FOV { get; set; }
    }
}