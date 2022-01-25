using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basic_Raytracer.Repository
{
    public interface IRepository
    {
        public IList<Models.Camera> GetSceneCameras(int sceneId);
        public IList<Models.Scene> GetScenes();
        public IList<Models.IShape> GetSceneShapes(int sceneId);
        public IList<Models.ShapeTypes> GetShapeTypes();
    }
}
