using System;
using System.Collections.Generic;

namespace Basic_Raytracer.ViewModels
{
    public class ShapeTypesVM
    {
        public IEnumerable<(int ID, string ShapeName)> ShapeTypes { get; set; }
    }
}