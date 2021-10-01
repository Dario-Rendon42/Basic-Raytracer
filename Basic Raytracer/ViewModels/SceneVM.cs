using MathNet.Spatial.Euclidean;
using System.Collections.Generic;

namespace Basic_Raytracer.ViewModels
{
    public class SceneVM
    {
        public Point3D CameraLocation { get; set; }
        public Point3D CameraDirection { get; set; }
        public IEnumerable<ShapeVM> ObjectsInScene { get; set; }
    }
}