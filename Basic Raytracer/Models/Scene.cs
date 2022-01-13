using MathNet.Spatial.Euclidean;
using System.Collections.Generic;
using System.Drawing;

namespace Basic_Raytracer.Models
{
    public class Scene
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public IEnumerable<IShape> Shapes { get; set; }
        public IEnumerable<Camera> Cameras { get; set; }
        public Camera ActiveCamera { get; set; }
        public Color DrawRay(Ray3D ray)
        {
            float? closestDist = null;
            IShape? closestShape = null;
            foreach(var s in Shapes)
            {
                var d = s.IntersectionPoint(ray);

                if (closestDist is null || d < closestDist)
                {
                    closestShape = s;
                    closestDist = d;
                }
            }
            Color outColor = closestShape is null ? Color.Black : closestShape.Draw(ray);
            return outColor;
        }
    }
}