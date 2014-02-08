using Player;
using NUnit.Framework;
using System;
using Emgu.CV.UI;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;

namespace OurUnitTests
{
    
    
    /// <summary>
    ///This is a test class for VideoFromFileGrabberThreadTest and is intended
    ///to contain all VideoFromFileGrabberThreadTest Unit Tests
    ///</summary>
    [TestFixture()]
    public class VideoFromFileGrabberThreadTest
    {


        private TestContext testContextInstance;
        const String FILE_NAME = @"C:\Users\Royal\Desktop\Nkujukira\video.AVI";

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
        ///A test for VideoFromFileGrabberThread Constructor
        ///</summary>
        [Test()]
        public void VideoFromFileGrabberThreadConstructorTest()
        {
            ImageBox image_box = new ImageBox(); // TODO: Initialize to an appropriate value
            PictureBox picture_box = new PictureBox(); // TODO: Initialize to an appropriate value
            VideoFromFileGrabberThread target = new VideoFromFileGrabberThread(FILE_NAME, image_box, picture_box);
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for AddNextFrameToQueueForProcessing
        ///</summary>
        [Test()]
        public void AddNextFrameToQueueForProcessingTest()
        {
            ImageBox image_box = new ImageBox();
            PictureBox picture_box = new PictureBox();
            image_box.Height = 50;
            image_box.Width = 50;
            picture_box.Height = 50;
            picture_box.Width = 50;
            VideoFromFileGrabberThread target = new VideoFromFileGrabberThread(FILE_NAME,image_box,picture_box); 
            bool sucess=target.AddNextFrameToQueueForProcessing();
            Assert.IsTrue(sucess);
        }

      

       //SINCE DOWORK JUST CALLS OTHER METHODS WE TEST THE OTHER METHODS ALL TOGETHER TO CERTIFY THAT DOWORK WORKS
        [Test()]
        public void DoWorkTest()
        {
            
            ImageBox image_box = new ImageBox(); 
            PictureBox picture_box = new ImageBox();
            image_box.Height = 50;
            image_box.Width = 50;
            picture_box.Height = 50;
            picture_box.Width = 50;
            VideoFromFileGrabberThread target = new VideoFromFileGrabberThread(FILE_NAME, image_box, picture_box);
            bool sucess = target.AddNextFrameToQueueForProcessing();
            Assert.IsTrue(sucess);
        }

        /// <summary>
        ///A test for RequestStop
        ///</summary>
        [Test()]
        public void RequestStopTest()
        {
            ImageBox image_box = new ImageBox(); // TODO: Initialize to an appropriate value
            PictureBox picture_box = new PictureBox(); 
            VideoFromFileGrabberThread target = new VideoFromFileGrabberThread(FILE_NAME, image_box, picture_box); 
            bool sucess=target.RequestStop();
            Assert.IsTrue(sucess);
        }

        


       
    }
}
