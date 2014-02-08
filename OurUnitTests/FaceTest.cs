using Player.Entities;
using NUnit.Framework;
using System;
using System.Drawing;
using Emgu.CV.Structure;
using Emgu.CV;
using Accord.Vision.Tracking;

namespace OurUnitTests
{
    
    
    /// <summary>
    ///This is a test class for FaceTest and is intended
    ///to contain all FaceTest Unit Tests
    ///</summary>
    [TestFixture()]
    public class FaceTest
    {


        private TestContext testContextInstance;
        public const string FILE_NAME = @"E:\PHOTOS\sis.jpg";

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
        ///A test for Face Constructor
        ///</summary>
        [Test()]
        public void FaceConstructorTest()
        {
            string name = "No Name"; // TODO: Initialize to an appropriate value
            Rectangle face_rect = new Rectangle(); // TODO: Initialize to an appropriate value
            Image<Bgr, byte> image = new Image<Bgr, byte>(FILE_NAME); // TODO: Initialize to an appropriate value
            Face target = new Face(name, face_rect, image);
            Assert.IsNotNull(target);
            
        }

        [Test()]
        public void FaceConstructorTest_WrongParameters()
        {
            
                string name = null; // TODO: Initialize to an appropriate value
                Rectangle face_rect = new Rectangle(); // TODO: Initialize to an appropriate value
                Image<Bgr, byte> image = null; // TODO: Initialize to an appropriate value
                Assert.Throws<NullReferenceException>(() => new Face(name, face_rect, image));
        }
        
        /// <summary>
        ///A test for GetCurrentPositionOfFace
        ///</summary>
        [Test()]
        public void GetCurrentPositionOfFaceTest()
        {
            string name = "No Name"; // TODO: Initialize to an appropriate value
            Rectangle face_rect = new Rectangle();
            Image<Bgr, byte> image = new Image<Bgr, byte>(FILE_NAME);
            Face target = new Face(name, face_rect, image);
            Image<Bgr, byte> current_frame = new Image<Bgr, byte>(FILE_NAME);
            bool sucess;
            Rectangle actual = target.GetCurrentPositionOfFace(current_frame, out sucess);
            Assert.IsTrue(sucess);
        }

        [Test()]
        public void GetCurrentPositionOfFaceTest_WrongInputs()
        {
            string name = "No Name"; // TODO: Initialize to an appropriate value
            Rectangle face_rect = new Rectangle();
            Image<Bgr, byte> image = new Image<Bgr,byte>(FILE_NAME);
            Face target = new Face(name, face_rect, image);
            Image<Bgr, byte> current_frame = null;
            bool sucess;
            Rectangle actual = target.GetCurrentPositionOfFace(current_frame, out sucess);
            Assert.IsFalse(sucess);
        }

        /// <summary>
        ///A test for GetRectangle
        ///</summary>
        [Test()]
        public void GetRectangleTest()
        {
            string name = "No Name"; // TODO: Initialize to an appropriate value
            Rectangle face_rect = new Rectangle(); // TODO: Initialize to an appropriate value
            Image<Bgr, byte> image = new Image<Bgr, byte>(FILE_NAME); // TODO: Initialize to an appropriate value
            Face target = new Face(name, face_rect, image); // TODO: Initialize to an appropriate value
            Rectangle actual = target.GetRectangle();
            Assert.IsNotNull(actual);
        }
        

        /// <summary>
        ///A test for InitializeTracker
        ///</summary>
        [Test()]
        public void InitializeTrackerTest()
        {
            string name = "No Name"; // TODO: Initialize to an appropriate value
            Rectangle face_rect = new Rectangle(); // TODO: Initialize to an appropriate value
            Image<Bgr, byte> image = new Image<Bgr, byte>(FILE_NAME); // TODO: Initialize to an appropriate value
            Face target = new Face(name, face_rect, image); // TODO: Initialize to an appropriate value
            //Image<Bgr, byte> image1 = null; // TODO: Initialize to an appropriate value
            bool success;
            target.InitializeTracker(image, out success);
            Assert.IsTrue(success);
        }

        [Test()]
        public void InitializeTrackerTest_WrongInput()
        {
            string name = "No Name"; // TODO: Initialize to an appropriate value
            Rectangle face_rect = new Rectangle(); // TODO: Initialize to an appropriate value
            Image<Bgr, byte> image = new Image<Bgr,byte>(FILE_NAME); // TODO: Initialize to an appropriate value
            Face target = new Face(name, face_rect, image); // TODO: Initialize to an appropriate value
            Image<Bgr, byte> image1 = null; // TODO: Initialize to an appropriate value
            bool success;
            target.InitializeTracker(image1, out success);
            Assert.IsFalse(success);
        }

        /// <summary>
        ///A test for face_rectangle
        ///</summary>
    }
}
