using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.CV.UI;
using Emgu.CV.CvEnum;
using System.Threading;
using System.Diagnostics;
using System.Collections.Concurrent;
using Player.Entities;
using Player.Threads;

namespace Player
{
    public partial class MainProgram : Form
    {


        private const String SELECT_VIDEO_MESSAGE = "Please Select a Video file";
        private const String LOAD_CAMERA_FOOTAGE_MESSAGE = "You Are Loading Footage From Your camera!!";
        private const String FILE_FILTER = "All files (*.*)|*.*";
        public static ConcurrentQueue<Image<Bgr, byte>> FRAMES_TO_BE_PROCESSED = new ConcurrentQueue<Image<Bgr, byte>>();
        public static ConcurrentQueue<Image<Bgr, byte>> FRAMES_TO_BE_DISPLAYED = new ConcurrentQueue<Image<Bgr, byte>>();
        public static ConcurrentQueue<Face> DETECTED_FACES_DATASTORE = new ConcurrentQueue<Face>();
        VideoDisplayUpdaterThread video_updater;
        FaceDetectingThread face_detector;



        //CONSTRUCTOR
        public MainProgram()
        {
            InitializeComponent();
        }

        //STARTS A CONTINUOUS RUNNING THREAD TO GRAB FRAMES FROM THE CAMERA IN THE BACKGROUND
        private void StartCameraOutputGrabberThread()
        {

            CameraOutputGrabberThread cam_output = new CameraOutputGrabberThread(video_frame);
            Thread camera_output_grabber_thread = new Thread(cam_output.DoWork);
            camera_output_grabber_thread.Name = "Camera Thread";
            //camera_output_grabber_thread.Priority = ThreadPriority.Highest;
            camera_output_grabber_thread.IsBackground = true;
            camera_output_grabber_thread.Start();
            Debug.WriteLine("Starting camera output thread");
            while (!camera_output_grabber_thread.IsAlive) ;
            Debug.WriteLine("Camera Output Thread is alive");
        }


        //STARTS A CONTINUOUS RUNNING THREAD TO GRAB FRAMES FROM THE VIDEO FILE IN THE BACKGROUND
        private void StartVideoFileGrabberThread(String file_name)
        {
            VideoFromFileGrabberThread video_from_file_grabber = new VideoFromFileGrabberThread(file_name, video_frame, pictureBox1);
            Thread video_from_file_grabber_thread = new Thread(video_from_file_grabber.DoWork);
            video_from_file_grabber_thread.Name = "FILE GRABBER THREAD";
            video_from_file_grabber_thread.IsBackground = true;
            video_from_file_grabber_thread.Priority = ThreadPriority.AboveNormal;
            video_from_file_grabber_thread.Start();
            Debug.WriteLine("Starting Video Output Thread for " + file_name);
            while (!video_from_file_grabber_thread.IsAlive) ;
            Debug.WriteLine("Video Output Thread is alive");
        }





        private void start_Click(object sender, EventArgs e)
        {
            /*
             * 1-Check if the user has selected to capture video from the camera.
             * 2-read from the default camera.
             * 3-display video footage with Capture() contructor that loads the default installed camera..
             * 
             * else;
             * 5-load video file with OpenFileDialog.
             * 4-display video footage with Capture('file_name') constructor
             */

            ReleaseResources();

            try
            {
                if (load_camera.Checked == true)
                {
                    MessageBox.Show(LOAD_CAMERA_FOOTAGE_MESSAGE);
                    StartCameraOutputGrabberThread();
                    StartVideoDisplayUpdaterThread();
                    StartFaceDetectingThread();

                }
                else
                {

                    String file_name = LoadVideoFromFile();
                    if (file_name == String.Empty)
                    {
                        MessageBox.Show(SELECT_VIDEO_MESSAGE);
                    }
                    else
                    {
                        StartVideoFileGrabberThread(file_name);
                        StartVideoDisplayUpdaterThread();
                        StartFaceDetectingThread();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                ReleaseResources();
            }
        }

        //STARTS THREAD TO DETECT FACES IN FRAME OFF THE MAIN THREAD
        public bool StartFaceDetectingThread()
        {
            face_detector = new FaceDetectingThread();
            Thread face_detecting_thread = new Thread(face_detector.DoWork);
            face_detecting_thread.Name = "FACE_DETECTOR";
            face_detecting_thread.IsBackground = true;
            face_detecting_thread.Priority = ThreadPriority.Lowest;
            face_detecting_thread.Start();
            while (!face_detecting_thread.IsAlive) ;
            return true;
        }


        private void StartVideoDisplayUpdaterThread()
        {
            video_updater = new VideoDisplayUpdaterThread(video_frame);
            Thread video_updater_thread = new Thread(video_updater.DoWork);
            video_updater_thread.Name = "VIDEO_UPDATER";
            video_updater_thread.Priority = ThreadPriority.Highest;
            video_updater_thread.IsBackground = true;
            video_updater_thread.Start();
            Debug.WriteLine("Starting video updater thread");
            while (!video_updater_thread.IsAlive) ;
            Debug.WriteLine("Video Updater Thread is alive");
        }




        /* this method will load a recorded Video  file of any format from a given file Path*/
        private String LoadVideoFromFile()
        {
            String file_name = string.Empty;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = FILE_FILTER;

            dialog.Title = SELECT_VIDEO_MESSAGE;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                file_name = dialog.FileName;
            }
            return file_name;
        }


        private void ReleaseObjects(object sender, FormClosedEventArgs e)
        {
            ThreadSuperClass.running = false;
        }

        private void MainProgram_Load(object sender, EventArgs e)
        {

        }

        private void video_frame_Click(object sender, EventArgs e)
        {

        }

        /*TO RESET ALL DATA STRUCTURES AND THE MAIN THREADS*/
        public void ReleaseResources()
        {
            try
            {
                FRAMES_TO_BE_PROCESSED = new ConcurrentQueue<Image<Bgr, byte>>();
                FRAMES_TO_BE_DISPLAYED = new ConcurrentQueue<Image<Bgr, byte>>();
                DETECTED_FACES_DATASTORE = new ConcurrentQueue<Face>();
                ReleaseObjects(null, null);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (play.Text.Equals("Pause"))
                {
                    video_updater.PauseVideo();
                    play.Text = "Play";
                }
                else
                {
                    video_updater.ResumeVideo();
                    play.Text = "Pause";
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }

        private void stop_Click(object sender, EventArgs e)
        {
            try
            {
                video_updater.PauseVideo();
                video_updater.RequestStop();
                video_updater.RequestStop();
                video_updater.RequestStop();
                DisableButtons();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public void DisableButtons() 
        {
            play.Enabled = false;
        }

        public void EnableButtons()
        {
            play.Enabled = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void load_camera_CheckedChanged(object sender, EventArgs e)
        {

        }


    }


}
