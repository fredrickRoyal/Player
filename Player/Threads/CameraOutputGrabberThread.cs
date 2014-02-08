using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Collections.Concurrent;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using Emgu.CV.UI;
using Player.Threads;
using System.Drawing;

namespace Player
{
    class CameraOutputGrabberThread : ThreadSuperClass
    {

        private Capture camera_capture;
        private Image<Bgr, byte> current_frame;
        private ImageBox image_box;

        public CameraOutputGrabberThread(ImageBox image_box)
            : base()
        {
            camera_capture = new Capture();
            this.image_box = image_box;

        }


        //WHILE RUNNING THIS THREAD WILL GET THE NEXT FRAME FROM THE CAMERA
        //IT WILL THEN ADD IT TO THE CONCURRENT QUEUE FOR CAMERA OUTPUT
        public override void DoWork()
        {
            try
            {
                while (running)
                {
                    //get frame from camera
                    AddNextFrameToQueueForProcessing();
                }
            }
            catch (Exception e)
            {
                //CATCH ANY WEIRD EXCEPTIONS HERE
                //LIKE OBJECT DISPOSED EXCEPTION
                Debug.WriteLine(e.Message);
            }
        }

        private void StartProcessingFrame()
        {
            //DetectFacesInFrame();    
        }



        //ADDS A CAPTURED FRAME TO A THREAD SAFE QUEUE FOR EASY ACESS WHEN THE FRAME IS PROCESSED BY MULTIPLE FRAMES
        public bool AddNextFrameToQueueForProcessing()
        {
            current_frame = CameraManager.GetCurrentFrame(this.camera_capture, image_box);
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
            if (camera_capture != null)
                camera_capture.Dispose();
            return true;
        }
    }
}
