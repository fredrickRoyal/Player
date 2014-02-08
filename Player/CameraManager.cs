using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emgu.CV;
using Emgu.CV.UI;
using Emgu.CV.Util;
using System.Drawing;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.Windows.Forms;
using System.Diagnostics;
using AForge.Imaging;
using AForge.Imaging.Filters;
using Accord.Vision.Detection;
using Accord.Vision.Detection.Cascades;

namespace Player
{
    class CameraManager
    {
        public static Color COLOR_OF_FACE_RECTANGLE = Color.Green;
        const int THICKNESS = 2;

        const double SCALE = 2.0;
        const double SCALEFACTOR = 1.2;
        const int MINIMUM_NEIGBHOURS = 2;
        const int WINDOW_SIZE = 50;


        public static Image<Bgr, byte> GetCurrentFrame(Capture capture, ImageBox image_box)
        {
            if (capture == null || image_box == null)
            {
                throw new NullReferenceException();
            }
            return capture.QueryFrame().Resize((image_box.Width), image_box.Height, Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR);

        }

        public static Rectangle[] DetectFacesInFrame(Image<Bgr, byte> current_frame, Emgu.CV.HaarCascade haarcascade)
        {
            if (current_frame == null || haarcascade == null)
            {
                throw new NullReferenceException();
            }

            try
            {
                if (current_frame != null)
                {
                    using (Image<Gray, byte> grayscale_image = current_frame.Convert<Gray, byte>())
                    {
                        grayscale_image._EqualizeHist();

                        MCvAvgComp[] detected_faces = grayscale_image.DetectHaarCascade(haarcascade, SCALEFACTOR, MINIMUM_NEIGBHOURS, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(WINDOW_SIZE, WINDOW_SIZE))[0];
                        Debug.WriteLine("NUMBER OF FACES FOUND=" + detected_faces.Length);
                        if (detected_faces.Length != 0)
                        {
                            Rectangle[] face_rectangles = new Rectangle[detected_faces.Length];

                            for (int i = 0; i < face_rectangles.Length; i++)
                            {
                                face_rectangles[i] = detected_faces[i].rect;
                            }
                            return face_rectangles;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            return null;
        }

        public static Image<Bgr, byte> DrawShapeAroundDetectedFaces(Rectangle rectangle_of_detected_face, Image<Bgr, byte> current_frame, out bool sucess)
        {
            if (current_frame == null)
            {
                throw new NullReferenceException();
            }

            if (rectangle_of_detected_face != null && current_frame != null)
            {
                current_frame.Draw(rectangle_of_detected_face, new Bgr(COLOR_OF_FACE_RECTANGLE), THICKNESS);
                sucess = true;
                return current_frame;
            }
            sucess = false;
            return current_frame;
        }

        public static Object RecognizeFacesInFrame()
        {
            //MCvTermCriteria term_criteria = new MCvTermCriteria(ContTrain, 0.001);
            return null;
            //EigenObjectRecognizer recognizer=new EigenObjectRecognizer(
        }
    }
}
