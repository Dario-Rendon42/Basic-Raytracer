using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basic_Raytracer.Tables
{
    public class Scene
    {
        public int ID { get; set; }
        public string SceneName { get; set; }
        public List<Shape> Shapes = new();
        public List<Camera> Cameras = new();
    }
}
