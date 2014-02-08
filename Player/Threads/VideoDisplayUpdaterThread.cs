using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emgu.CV.UI;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Diagnostics;
using System.Threading;
using System.Collections.Concurrent;
using Player.Entities;
using System.Threading.Tasks;
using System.Drawing;

namespace Player
{
    class VideoDisplayUpdaterThread : ThreadSuperClass
    {
        public ImageBox video_display;
        public Image<Bgr, byte> current_frame;
        bool successfull;
        public static bool video_paused = false;


        public VideoDisplayUpdaterThread(ImageBox video_display)
            : base()
        {
            this.video_display = video_display;
            running = true;


        }

        public override void DoWork()
        {
            while (running)
            {
                try
                {

                    if (!video_paused)
                    {
                        successfull = MainProgram.FRAMES_TO_BE_DISPLAYED.TryDequeue(out current_frame);
                        if (successfull)
                        {
                            GetAllFacesFromQueue();
                            DrawRectanglesAroundFaces();
                            DisplayNextFrame();
                        }
                    }

                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message + "In VIDEO UPDATERS");
                }
            }
        }

        public bool DrawRectanglesAroundFaces()
        {

            ConcurrentQueue<Face> faces = MainProgram.DETECTED_FACES_DATASTORE;
            bool sucess;

            Face[] faces_array = faces.ToArray();
            if (faces_array.Length > 0)
            {
                for (int i = 0; i < faces_array.Length; i++)
                {

                    CameraManager.DrawShapeAroundDetectedFaces(faces_array[i].GetCurrentPositionOfFace(current_frame, out sucess), current_frame, out sucess);
                }
                return true;
            }

            return false;
        }

        public bool GetAllFacesFromQueue()
        {
            return false;
        }

        public bool DisplayNextFrame()
        {

            Debug.WriteLine("Drawing video frame");
            video_display.Image = this.current_frame;
            this.current_frame = null;
            return true;
        }

        //WHEN THREAD IS STOPPED WE DO SOME CLEAN UP
        //DISPOSE OF ALL CAMERA OBJECTS
        public override bool RequestStop()
        {
            current_frame = new Image<Bgr, byte>(video_display.Width, video_display.Height, new Bgr(Color.Black));
            video_display.BackColor = Color.Black;
            video_display.Image = current_frame;
            running = false;
            return true;
        }

        public bool PauseVideo()
        {
            VideoDisplayUpdaterThread.video_paused = true;
            return true;
        }

        public bool ResumeVideo()
        {
            VideoDisplayUpdaterThread.video_paused = false;
            return true;
        }
    }
}
