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
            double closestDist = double.PositiveInfinity;
            IShape closestShape = null;
            foreach(var shape in Shapes)
            {
                var dist = shape.IntersectionDist(ray);
                // check if there is a collision at all
                if(dist is not null)
                {

                    if (dist < closestDist)
                    {
                        closestShape = shape;
                        closestDist = (double) dist;
                    }
                }
            }
            // TODO: change background color to settings file
            Color outColor = closestShape is null ? Color.Black : closestShape.Color;
            return outColor;
        }
    }
}