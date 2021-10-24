using Basic_Raytracer.Models;
using Basic_Raytracer.ViewModels;
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

        public RaytraceController(ILogger<RaytraceController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Adds a supported shape to the active scene
        /// </summary>
        /// <param name="shape"></param>
        /// <returns></returns>
        [HttpPost]
        public IShapeVM AddShapeToScene(IShapeVM shape)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes a shape from the active scene
        /// </summary>
        /// <param name="ID">The ID of the shape to delete</param>
        /// <returns></returns>
        [HttpDelete]
        public IShapeVM DeleteShapeFromScene(int ID)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all valid shape types
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<ShapeTypesVM> GetShapeTypes()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all objects in the active scene
        /// </summary>
        /// <returns>A list of </returns>
        [HttpGet]
        public SceneVM GetScene()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Renders the scene as an image
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public Bitmap DrawScene()
        {
            throw new NotImplementedException();
        }
    }
}
