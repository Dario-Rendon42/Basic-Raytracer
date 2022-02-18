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
            };
            var plane = new Shapes.Plane()
            {
                ID = 1,
                Name = "Plane 1",
                Scene = scene,
                Color = Color.Blue,
                Origin = new Point3D(10, 0, 0),
                Normal = new Vector3D(1, 0, 0),
            };
            var circle = new Shapes.Circle()
            {
                ID = 2,
                Name = "Circle 1",
                Scene = scene,
                Color = Color.Red,
                Origin = new Point3D(0, 0, 30),
                Normal = new Vector3D(1, 0, 1),
                Radius = 20
            };
            var camera = new Camera()
            {
                ID = 1,
                Scene = scene,
                Origin = new Point3D(0, 0, 0),
                Subject = new Point3D(0, 0, 1),
                FOV = 120
            };
            scene.Shapes.Add(plane);
            scene.Shapes.Add(circle);
            scene.Cameras.Add(camera);
            scene.ActiveCamera = camera;
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
