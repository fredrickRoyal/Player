using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Player.Threads
{
    class FaceRecognizerThread:ThreadSuperClass
    {
        Rectangle[] all_detected_faces;
        public FaceRecognizerThread(Rectangle[] all_detected_faces):base()
        {
        
        }

        public override void DoWork()
        {
            while (running) 
            {
                GetAllPerpertrators();
                TryToRecognizePerpertratorsInCurrentFrame();
            }
        }

        private void TryToRecognizePerpertratorsInCurrentFrame()
        {
            
        }

        private void GetAllPerpertrators()
        {
            
        }

        public override bool RequestStop()
        {
            return base.RequestStop();
        }
    }
}
