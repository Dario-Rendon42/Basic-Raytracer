using MathNet.Spatial.Euclidean;
using System;
using System.Drawing;

namespace Basic_Raytracer.Models
{
    public class Camera
    {
        public int ID { get; set; }
        public Scene Scene { get; set; }
        public Point3D Origin { get; set; } = new Point3D(0, 0, 0); // Default camera origin at origin
        public Point3D Subject { get; set; } = new Point3D(0, 0, 1); // Default camera subject is pointing straight up
        public Vector3D CameraVector => Subject.ToVector3D() - Origin.ToVector3D();
        public double FOV { get; set; } = 90;
        public Bitmap Draw(int width, int height)
        {

            Bitmap bitmap = new(width, height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            // Calculating origin ray for specific pixel
            // Untransformed origin ray starts at origin, is then transformed to wherever the camera is located based on 
            /*
             *           |\
             *           |  \
             *           |    \
             *  wlength  |      \
             *           | FOV/2  \
             *           |          \
             *           |--width/2--|
             * 
             * to get length use tan(FOV/2) * width/2
             * this gives coordinates for furthest point
             */

            var wlength = Math.Tan(FOV/2) * width/2; // only calculating FOV for width
                                                     // having individual FOVs for width and height currently not supported

            for (int x = 0; x < width; x++)
            {
                var xpos = x - (width / 2); // Determine wether pixel is on left/right side of screen
                for (int y = 0; y < height; y++)
                {
                    var ypos = (height / 2) - y; // Determine wether pixel is in top/bottom of screen
                                                 // Note that coordinates for the Bitmap class begin on the top left

                    var v = new Vector3D(xpos, ypos, wlength);
                    var r = new Ray3D(Origin, v); // TODO: enable transform to camera position and direction
                                                                // currently static at origin looking stright up
                    var c = Scene.DrawRay(r) ;
                    bitmap.SetPixel(x, y, c);
                }
            }
            return bitmap;
        }
    }
}