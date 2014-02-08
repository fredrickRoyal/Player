using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using System.Diagnostics;
using Player.Threads;
using System.Threading;
using System.Windows.Forms;

namespace Player
{
    class VideoFromFileGrabberThread : ThreadSuperClass
    {
        private Capture video_capture;
        public Image<Bgr, byte> current_frame { get; set; }
        private ImageBox image_box;

        private const string PROCESSING_THREAD_NAME = "image_processor";
        PictureBox picture_box;

        public VideoFromFileGrabberThread(String file_name, ImageBox image_box, PictureBox picture_box)
            : base()
        {
            video_capture = new Capture(file_name);
            this.image_box = image_box;
            this.picture_box = picture_box;
        }


        public void SetCurrentFrame(Image<Bgr, byte> image)
        {
            this.current_frame = image;
        }

        //WHILE RUNNING THIS THREAD WILL GET THE NEXT FRAME FROM THE CAMERA
        //IT WILL THEN ADD IT TO THE CONCURRENT QUEUE FOR CAMERA OUTPUT
        public override void DoWork()
        {
            try
            {
                while (running)
                {
                    AddNextFrameToQueueForProcessing();
                }
            }
            catch (Exception e)
            {
                //CATCH ANY WEIRD EXCEPTIONS HERE
                //LIKE OBJECT DISPOSED EXCEPTION
                Debug.WriteLine(e.Message + "In FILE GRABBER");
            }
        }



        //ADDS A CAPTURED FRAME TO A THREAD SAFE QUEUE FOR EASY ACESS WHEN THE FRAME IS PROCESSED BY MULTIPLE FRAMES
        public bool AddNextFrameToQueueForProcessing()
        {
            current_frame = CameraManager.GetCurrentFrame(this.video_capture, image_box);
            if (current_frame != null)
            {
            
                MainProgram.FRAMES_TO_BE_PROCESSED.Enqueue(current_frame.Clone());
                MainProgram.FRAMES_TO_BE_DISPLAYED.Enqueue(current_frame.Clone());
                return true;
            }
            return false;

        }



        //WHEN THREAD IS STOPPED WE DO SOME CLEAN UP
        //DISPOSE OF ALL CAMERA OBJECTS
        public override bool RequestStop()
        {
            running = false;
            if (current_frame != null)
                current_frame.Dispose();
            if (video_capture != null)
                video_capture.Dispose();
            return true;
        }
    }
}

