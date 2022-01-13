using Basic_Raytracer.Repository;
using Basic_Raytracer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Basic_Raytracer.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class RaytraceController : ControllerBase
    {
        private readonly ILogger<RaytraceController> _logger;
        private readonly IRepository _repo;

        public RaytraceController(ILogger<RaytraceController> logger, IRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        /// <summary>
        /// Adds a supported shape to the active scene
        /// </summary>
        /// <param name="shape"></param>
        /// <returns></returns>
        [HttpPost]
        public IShape AddShapeToScene(IShape shape)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes a shape from the active scene
        /// </summary>
        /// <param name="ID">The ID of the shape to delete</param>
        /// <returns></returns>
        [HttpDelete]
        public IShape DeleteShapeFromScene(int ID)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all valid shape types
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<ShapeTypes> GetShapeTypes()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all objects in the active scene
        /// </summary>
        /// <returns>A list of </returns>
        [HttpGet]
        public Scene GetScene()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Renders the scene as an image
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult DrawScene(int width = 255, int height = 255)
        {
            var camera = GetScene().ActiveCamera;
            Bitmap bitmap = camera.Draw(width, height);

            //System.IO.MemoryStream ms = new System.IO.MemoryStream();
            //bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            //var f = File(ms, "image/jpg");
            //return f;
            bitmap.Save("C:\\Users\\Dario Rendon\\Pictures\\out.png");
            var image = System.IO.File.OpenRead("C:\\Users\\Dario Rendon\\Pictures\\out.png");
            return File(image, "image/png");
        }
    }
}
