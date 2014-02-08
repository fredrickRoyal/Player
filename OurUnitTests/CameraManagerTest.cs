using Player;
using NUnit.Framework;
using System;
using Emgu.CV.Structure;
using Emgu.CV;
using System.Drawing;
using Emgu.CV.UI;
using System.Diagnostics;

namespace OurUnitTests
{
    
    
    /// <summary>
    ///This is a test class for CameraManagerTest and is intended
    ///to contain all CameraManagerTest Unit Tests
    ///</summary>
    [TestFixture()]
    public class CameraManagerTest
    {


        private TestContext testContextInstance;
        private const String HAARCASCADE_FRONTAL_FACE_FILE_PATH = "C:\\Emgu\\emgucv-windows-x86 2.2.1.1150\\opencv\\data\\haarcascades\\haarcascade_frontalface_alt.xml";

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
        ///A test for CameraManager Constructor
        ///</summary>
        [Test()]
        public void CameraManagerConstructorTest()
        {
            CameraManager target = new CameraManager();
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for DetectFacesInFrame
        ///</summary>
        [Test()]
        public void DetectFacesInFrameTest()
        {
            Image<Bgr, byte> current_frame = new Image<Bgr, byte>(@"E:\PHOTOS\sis.jpg"); 
            HaarCascade haarcascade = new HaarCascade(HAARCASCADE_FRONTAL_FACE_FILE_PATH);

            Rectangle[] actual;
            actual = CameraManager.DetectFacesInFrame(current_frame, haarcascade);
            int expected = 1;
            Assert.AreEqual(expected, actual.Length);
            
        }

        [Test()]
        public void DetectFacesInFrameTest_WrongInputExceptionThrown()
        {
            Image<Bgr, byte> current_frame = null;
            HaarCascade haarcascade = null; 
            Assert.Throws<NullReferenceException>(()=> CameraManager.DetectFacesInFrame(current_frame, haarcascade));

        }

        [Test()]
        public void RectangleIntersectionTest() 
        {
            Rectangle rect_1 = new Rectangle(10, 10, 10, 10);
            Rectangle rect_2 = new Rectangle(11, 11, 5, 5);
            bool sucess = rect_1.IntersectsWith(rect_2);
            Assert.IsTrue(sucess);
        }

        /// <summary>
        ///A test for DrawShapeAroundDetectedFaces
        ///</summary>
        [Test()]
        public void DrawShapeAroundDetectedFacesTest()
        {
            Rectangle rectangle_of_detected_face = new Rectangle(5,5,5,5); // TODO: Initialize to an appropriate value
            Image<Bgr, byte> current_frame = new Image<Bgr, byte>(@"E:\PHOTOS\fred.jpg"); // TODO: Initialize to an appropriate value
            //Image<Bgr, byte> expected = null; // TODO: Initialize to an appropriate value
            Image<Bgr, byte> actual;
            bool sucess ;
            actual = CameraManager.DrawShapeAroundDetectedFaces(rectangle_of_detected_face, current_frame,out sucess);
            Assert.IsTrue(sucess);
        }

        [Test()]
        public void DrawShapeAroundDetectedFacesTest_WrongInputExceptionThrown()
        {
            Rectangle rectangle_of_detected_face = new Rectangle(); // TODO: Initialize to an appropriate value
            Image<Bgr, byte> current_frame = null; // TODO: Initialize to an appropriate value
            bool sucess;
            Assert.Throws<NullReferenceException>(()=>CameraManager.DrawShapeAroundDetectedFaces(rectangle_of_detected_face, current_frame, out sucess));
        }

        /// <summary>
        ///A test for GetCurrentFrame
        ///</summary>
        [Test()]
        public void GetCurrentFrameTest()
        {
            Capture capture = new Capture(@"C:\Users\Royal\Desktop\Nkujukira\video.AVI");
            ImageBox image_box = new ImageBox(); 
            image_box.Height = 50;
            image_box.Width = 50;
            Image<Bgr, byte> actual;
            actual = CameraManager.GetCurrentFrame(capture, image_box);
            Assert.IsNotNull(actual);
        }

        [Test()]
        public void GetCurrentFrameTest_WrongInputExceptionThrown()
        {
            Capture capture = null;
            ImageBox image_box = null; 
            Image<Bgr, byte> actual;
            Assert.Throws<NullReferenceException>(() => actual = CameraManager.GetCurrentFrame(capture, image_box));
        }
    }
}
