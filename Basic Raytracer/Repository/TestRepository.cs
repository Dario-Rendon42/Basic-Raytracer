using Basic_Raytracer.Models;
using Basic_Raytracer.Shapes;
using MathNet.Spatial.Euclidean;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Basic_Raytracer.Repository
{
    public class TestRepository : IRepository
    {
        private IList<Scene> Scenes;
        private IList<ShapeTypes> shapeTypes;
        public TestRepository()
        {
            Scenes = new List<Scene>();
            shapeTypes = new List<ShapeTypes>();
            var scene = new Scene()
            {
                ID = 1,
                Name = "Test Scene",
                Shapes = new List<IShape>(),
                Cameras = new List<Camera>(),
                Lights = new List<Light>()
            };
            var plane = new Shapes.Plane()
            {
                ID = 1,
                Name = "Plane 1",
                Scene = scene,
                Color = Color.White,
                Origin = new Point3D(0, 0, 100),
                Normal = new Vector3D(0, 0, 1),
            };
            var circle = new Shapes.Circle()
            {
                ID = 2,
                Name = "Circle 1",
                Scene = scene,
                Color = Color.Red,
                Origin = new Point3D(0, 0, 90),
                Normal = new Vector3D(0, 1, .5),
                Radius = 20
            };
            var circle2 = new Shapes.Circle()
            {
                ID = 3,
                Name = "Circle 2",
                Scene = scene,
                Color = Color.Blue,
                Origin = new Point3D(0, 0, 90),
                Normal = new Vector3D(1, 0, -.5),
                Radius = 20
            };
            var camera = new Camera()
            {
                ID = 1,
                Scene = scene,
                Origin = new Point3D(0, 0, 0),
                Subject = new Point3D(0, 0, 1),
                FOV = 90
            };
            var light = new Light()
            {
                ID = 1,
                Intensity = 100,
                LightColor = Color.FromArgb(175, 150, 100),
                Origin = new Point3D(30, -30, 50)
            };
            scene.Shapes.Add(plane);
            scene.Shapes.Add(circle);
            scene.Shapes.Add(circle2);
            scene.Cameras.Add(camera);
            scene.ActiveCamera = camera;
            scene.Lights.Add(light);
            Scenes.Add(scene);
        }
        public IList<Camera> GetSceneCameras(int sceneId)
        {
            var scene = Scenes.FirstOrDefault(x => x.ID == sceneId);
            return scene.Cameras;
        }

        public IList<Scene> GetScenes()
        {
            return Scenes;
        }

        public IList<IShape> GetSceneShapes(int sceneId)
        {
            var scene = Scenes.FirstOrDefault(x => x.ID == sceneId);
            return scene.Shapes;
        }

        public IList<ShapeTypes> GetShapeTypes()
        {
            return shapeTypes;
        }
    }
}
