using Player;
using NUnit.Framework;
using System;
using Emgu.CV.UI;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.Structure;

namespace OurUnitTests
{
    
    
    /// <summary>
    ///This is a test class for VideoDisplayUpdaterThreadTest and is intended
    ///to contain all VideoDisplayUpdaterThreadTest Unit Tests
    ///</summary>
    [TestFixture()]
    public class VideoDisplayUpdaterThreadTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for VideoDisplayUpdaterThread Constructor
        ///</summary>
        [Test()]
        public void VideoDisplayUpdaterThreadConstructorTest()
        {
            ImageBox video_display = null; // TODO: Initialize to an appropriate value
            VideoDisplayUpdaterThread target = new VideoDisplayUpdaterThread(video_display);
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for DisplayNextFrame
        ///</summary>
        [Test()]       
        public void DisplayNextFrameTest()
        {
            MainProgram.FRAMES_TO_BE_PROCESSED.Enqueue(new Image<Bgr, byte>(FaceTest.FILE_NAME));
            VideoDisplayUpdaterThread target = new VideoDisplayUpdaterThread(new ImageBox()); // TODO: Initialize to an appropriate value
            bool sucess=target.DisplayNextFrame();
            Assert.IsTrue(sucess);
        }

        /// <summary>
        ///A test for DoWork
        ///</summary>
        [Test()]
        public void DoWorkTest()
        {   
            MainProgram.FRAMES_TO_BE_PROCESSED.Enqueue(new Image<Bgr, byte>(FaceTest.FILE_NAME));
            MainProgram.DETECTED_FACES_DATASTORE.Enqueue(new Player.Entities.Face("",new Rectangle(),new Image<Bgr,byte>(FaceTest.FILE_NAME)));
            ImageBox video_display = new ImageBox(); // TODO: Initialize to an appropriate value
            VideoDisplayUpdaterThread target = new VideoDisplayUpdaterThread(video_display); // TODO: Initialize to an appropriate value
            bool sucess=target.DisplayNextFrame();
            sucess=target.DrawRectanglesAroundFaces();
            //sucess=target.GetAllFacesFromQueue();
            if (sucess)
            {
                Assert.Pass();
            }
            else 
            {
                Assert.Fail();
            }
            
        }

        /// <summary>
        ///A test for DrawRectanglesAroundFaces
        ///</summary>
        [Test()]
        public void DrawRectanglesAroundFacesTest()
        {
            MainProgram.FRAMES_TO_BE_PROCESSED.Enqueue(new Image<Bgr, byte>(FaceTest.FILE_NAME));
            MainProgram.DETECTED_FACES_DATASTORE.Enqueue(new Player.Entities.Face("",new Rectangle(),new Image<Bgr,byte>(FaceTest.FILE_NAME)));
            VideoDisplayUpdaterThread target = new VideoDisplayUpdaterThread(new ImageBox()); // TODO: Initialize to an appropriate value
            bool sucess=target.DrawRectanglesAroundFaces();
            Assert.IsTrue(sucess);
        }

        /// <summary>
        ///A test for GetAllFacesFromQueue
        ///</summary>
        [Test()]
        public void GetAllFacesFromQueueTest()
        {
            VideoDisplayUpdaterThread target = new VideoDisplayUpdaterThread(new ImageBox()); // TODO: Initialize to an appropriate value
            target.GetAllFacesFromQueue();
            //Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for RequestStop
        ///</summary>
        [Test()]
        public void RequestStopTest()
        {
            ImageBox video_display = null; // TODO: Initialize to an appropriate value
            VideoDisplayUpdaterThread target = new VideoDisplayUpdaterThread(video_display); // TODO: Initialize to an appropriate value
            bool sucess=target.RequestStop();
            Assert.IsTrue(sucess);
        }
    }
}
