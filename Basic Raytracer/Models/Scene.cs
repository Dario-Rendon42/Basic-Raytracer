using MathNet.Spatial.Euclidean;
using System;
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
        public IList<Light> Lights { get; set; }
        public IList<Camera> Cameras { get; set; }
        public Camera ActiveCamera { get; set; }

        // TODO: Add reflective materials
        public Color DrawRay(Ray3D ray)
        {
            double closestDist = double.PositiveInfinity;
            IShape closestShape = null;
            foreach (var shape in Shapes)
            {
                var (dist, _) = shape.CalculateIntersection(ray);
                // check if there is a collision at all
                if (dist is not null && dist < closestDist)
                {
                    closestShape = shape;
                    closestDist = (double)dist;
                }
            }
            // subtracting a small distance prevents surfaces from creating shadows on themselves due to collision checking for lights starting from slightly behind the surface
            // this is due to floating point errors
            closestDist -= 1e-6;
            Color outColor;
            // TODO: change background color to settings file
            if (closestShape is null)
            {
                // ray hit nothing, paint background color
                outColor = Color.Black;
            }
            else
            {
                // ray hit something, calculate light/shadows, reflections,
                outColor = Color.Black; // Default color if no light hits this point/ light intensity is too low at this point
                var intersectionPoint = ray.ThroughPoint + ray.Direction.ScaleBy(closestDist);
                // https://www.scratchapixel.com/lessons/3d-basic-rendering/introduction-to-shading/shading-spherical-light
                // first calculate light color
                foreach (var light in Lights)
                {
                    var lightRay = new Ray3D(intersectionPoint, light.Origin.ToVector3D() - intersectionPoint.ToVector3D()); // ray from intersection point to light origin
                    var lightDist = intersectionPoint.DistanceTo(light.Origin);
                    var addLight = true;
                    foreach (var shape in Shapes)
                    {
                        var (dist, _) = shape.CalculateIntersection(lightRay);
                        if (dist is not null && dist < lightDist)
                        {
                            addLight = false;
                            break;
                        }
                    }
                    if (addLight)
                    {
                        // There are no shapes that intersect the ray from point to light that are between the point and the light
                        // Light hits this point, add light color based on intensity
                        //var lightIntensity = light.Intensity / (4 * Math.PI * Math.Pow(lightDist, 2)); 
                        var lightIntensity = light.Intensity / (Math.Pow(lightDist, 1.25)); // Adjusting denominator to my liking so light intensity doesn't fall off as hard
                        if (lightIntensity > 1e-6) // TODO: put epsilon in settings file
                        {
                            var lightR = outColor.R + (int)(lightIntensity * light.LightColor.R);
                            var lightG = outColor.G + (int)(lightIntensity * light.LightColor.G);
                            var lightB = outColor.B + (int)(lightIntensity * light.LightColor.B);
                            lightR = Math.Max(0, Math.Min(lightR, 255));
                            lightG = Math.Max(0, Math.Min(lightG, 255));
                            lightB = Math.Max(0, Math.Min(lightB, 255));
                            outColor = Color.FromArgb(lightR, lightG, lightB);
                        }
                    }
                }
                // then calculate how that affects the surface hit
                var r = outColor.R * closestShape.Color.R / 255;
                var g = outColor.G * closestShape.Color.G / 255;
                var b = outColor.B * closestShape.Color.B / 255;
                r = Math.Max(0, Math.Min(r, 255));
                g = Math.Max(0, Math.Min(g, 255));
                b = Math.Max(0, Math.Min(b, 255));
                outColor = Color.FromArgb(r, g, b);
            }
            return outColor;
        }
    }
}