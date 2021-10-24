using MathNet.Spatial.Euclidean;
using System.Collections.Generic;

namespace Basic_Raytracer.ViewModels
{
    public class SceneVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public IEnumerable<IShapeVM> Shapes { get; set; }
        public IEnumerable<CameraVM> Cameras { get; set; }
    }
}