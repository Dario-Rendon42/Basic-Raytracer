using MathNet.Spatial.Euclidean;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Basic_Raytracer.Models
{
    public class Scene
    {
        
        public int ID { get; set; }
        public string Name { get; set; }
        public IList<IShape> Shapes { get; set; }
        public IList<Camera> Cameras { get; set; }
        public Camera ActiveCamera { get; set; }
        public Color DrawRay(Ray3D ray)
        {
            float closestDist = float.PositiveInfinity;
            IShape closestShape = null;
            foreach(var shape in Shapes)
            {
                var dist = shape.IntersectionPoint(ray);

                if (dist < closestDist)
                {
                    closestShape = shape;
                    closestDist = dist;
                }
            }
            Color outColor = closestShape is null ? Color.Black : closestShape.Draw(ray);
            return outColor;
        }
    }
}