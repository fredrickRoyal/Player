using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Accord.Vision.Tracking;
using AForge.Imaging;
using Emgu.CV;
using Emgu.CV.Structure;

namespace Player.Entities
{
    public class Face
    {
        string name { get; set; }
        Rectangle face_rectangle { get; set; }
        Camshift face_tracker { get; set; }


        // CONSTRUCTOR 
        // NAME-NAME OF PERSON IN IMAGE
        // RECTANGLE RECTANGLE WITH PERSONS FACE
        // IMAGE FRAME CONAINING FACE OF PERSON
        public Face(string name, Rectangle face_rect, Image<Bgr, byte> image)
        {
            if (name == null || face_rect == null || image == null)
            {
                throw new NullReferenceException();
            }
            this.name = name;
            this.face_rectangle = face_rect;
            bool success;
            InitializeTracker(image, out success);
        }

        //INITIALIZES TRACKER TO TRACK A SPECIFIC OBJECT
        public void InitializeTracker(Image<Bgr, byte> image, out bool success)
        {
            try
            {
                Bitmap bitmap = image.ToBitmap();
                UnmanagedImage unmanaged_image = UnmanagedImage.FromManagedImage(bitmap);
                face_tracker = new Camshift();
                face_tracker.Reset();
                face_tracker.SearchWindow = face_rectangle;
                face_tracker.ProcessFrame(unmanaged_image);
                success = true;
            }
            catch(Exception e)
            {

                success = false;
            }
        }

        public Rectangle GetRectangle()
        {
            return face_rectangle;
        }

        //LOOKS FOR THE POSITION OF THE OBJECT ITS TRACKING IN THE CURRENT FRAME
        public Rectangle GetCurrentPositionOfFace(Image<Bgr, byte> current_frame,out bool sucess)
        {
            try
            {
                Bitmap bitmap = current_frame.ToBitmap();
                UnmanagedImage unmanaged_image = UnmanagedImage.FromManagedImage(bitmap);
                // Track the object
                face_tracker.ProcessFrame(unmanaged_image);

                // Get the object position
                var face_position = face_tracker.TrackingObject;
                face_rectangle = face_position.Rectangle;
                sucess = true;
                return face_position.Rectangle;
            }
            catch (Exception e) 
            {
                sucess = false;
                return Rectangle.Empty;
            }
        }
    }
}
