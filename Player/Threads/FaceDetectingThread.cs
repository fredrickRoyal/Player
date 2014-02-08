using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Diagnostics;
using System.Drawing;
using Emgu.CV.UI;
using System.Windows.Forms;
using Player.Entities;
using Accord.Vision.Tracking;

namespace Player.Threads
{
    class FaceDetectingThread : ThreadSuperClass
    {
        private Image<Bgr, byte> current_frame;
        private const String HAARCASCADE_PROFILE_FACE_FILE_PATH = "C:\\Emgu\\emgucv-windows-x86 2.2.1.1150\\opencv\\data\\haarcascades\\haarcascade_profileface.xml";
        private const String HAARCASCADE_FRONTAL_FACE_FILE_PATH = "C:\\Emgu\\emgucv-windows-x86 2.2.1.1150\\opencv\\data\\haarcascades\\haarcascade_frontalface_alt.xml";

        private HaarCascade frontal_face_haarcascade;
        bool sucessfull;




        public FaceDetectingThread()
            : base()
        {
            frontal_face_haarcascade = new HaarCascade(HAARCASCADE_FRONTAL_FACE_FILE_PATH);
            running=true;
        }

        public override void DoWork()
        {
            while (running)
            {
                try
                {
                    sucessfull= MainProgram.FRAMES_TO_BE_PROCESSED.TryDequeue(out current_frame);
                    if (sucessfull)
                    {
                        DetectFacesInFrame();
                        current_frame = null;
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message+"In FACE DETECTOR");
                }
            }

        }


        //DETECT THE FACES IN THE FRAME INORDER TO ADD THEM TO A BAL FACE DATASTORE
        private void DetectFacesInFrame()
        {
        
            Debug.WriteLine("Detecting Faces");
            Rectangle[] detected_faces = CameraManager.DetectFacesInFrame(current_frame, frontal_face_haarcascade);
            if(detected_faces!=null)
            {
                if (detected_faces.Length != 0)
                {
                    Face[] faces = MainProgram.DETECTED_FACES_DATASTORE.ToArray();
                    bool sucess;
                    //FOR EACH FACE DETECTED WE WILL ONLY ADD IT TO THE DATASTORE IF ITS NOT AMONG THE FACES ALREADY BEING TRACKED
                    for (int i = 0; i < detected_faces.Length; i++)
                    {
                        bool face_is_found = false;

                        for (int j = 0; j < faces.Length; j++)
                        {
                            if (faces[j].GetCurrentPositionOfFace(current_frame, out sucess).IntersectsWith(detected_faces[i]))
                            {
                                Debug.WriteLine("OLD FACE FOUND");
                                face_is_found = true;
                                break;
                            }
                        }

                        if (!face_is_found)
                        {
                            Debug.WriteLine("NEW FACE FOUND");
                            Face a_face = new Face("No Name", detected_faces[i], current_frame);
                            MainProgram.DETECTED_FACES_DATASTORE.Enqueue(a_face);
                        }

                    }
                }
            }
            else
            {
                Debug.Write("No face found");
            }
      }

        public override bool RequestStop()
        {
            base.RequestStop();
            return true;
        }
    }
}
