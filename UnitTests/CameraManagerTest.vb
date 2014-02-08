Imports Emgu.CV.UI

Imports System.Drawing

Imports Emgu.CV

Imports Emgu.CV.Structure

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Player



'''<summary>
'''This is a test class for CameraManagerTest and is intended
'''to contain all CameraManagerTest Unit Tests
'''</summary>
<TestClass()> _
Public Class CameraManagerTest


    Private testContextInstance As TestContext

    '''<summary>
    '''Gets or sets the test context which provides
    '''information about and functionality for the current test run.
    '''</summary>
    Public Property TestContext() As TestContext
        Get
            Return testContextInstance
        End Get
        Set(ByVal value As TestContext)
            testContextInstance = Value
        End Set
    End Property

#Region "Additional test attributes"
    '
    'You can use the following additional attributes as you write your tests:
    '
    'Use ClassInitialize to run code before running the first test in the class
    '<ClassInitialize()>  _
    'Public Shared Sub MyClassInitialize(ByVal testContext As TestContext)
    'End Sub
    '
    'Use ClassCleanup to run code after all tests in a class have run
    '<ClassCleanup()>  _
    'Public Shared Sub MyClassCleanup()
    'End Sub
    '
    'Use TestInitialize to run code before running each test
    '<TestInitialize()>  _
    'Public Sub MyTestInitialize()
    'End Sub
    '
    'Use TestCleanup to run code after each test has run
    '<TestCleanup()>  _
    'Public Sub MyTestCleanup()
    'End Sub
    '
#End Region


    '''<summary>
    '''A test for CameraManager Constructor
    '''</summary>
    <TestMethod()> _
    Public Sub CameraManagerConstructorTest()
        Dim target As CameraManager = New CameraManager()
        Assert.Inconclusive("TODO: Implement code to verify target")
    End Sub

    '''<summary>
    '''A test for DetectFacesInFrame
    '''</summary>
    <TestMethod()> _
    Public Sub DetectFacesInFrameTest()
        Dim current_frame As Image(Of Bgr, Byte) = Nothing ' TODO: Initialize to an appropriate value
        Dim haarcascade As HaarCascade = Nothing ' TODO: Initialize to an appropriate value
        Dim expected() As Rectangle = Nothing ' TODO: Initialize to an appropriate value
        Dim actual() As Rectangle
        actual = CameraManager.DetectFacesInFrame(current_frame, haarcascade)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for DrawShapeAroundDetectedFaces
    '''</summary>
    <TestMethod()> _
    Public Sub DrawShapeAroundDetectedFacesTest()
        Dim rectangles_of_detected_faces() As Rectangle = Nothing ' TODO: Initialize to an appropriate value
        Dim current_frame As Image(Of Bgr, Byte) = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As Image(Of Bgr, Byte) = Nothing ' TODO: Initialize to an appropriate value
        Dim actual As Image(Of Bgr, Byte)
        actual = CameraManager.DrawShapeAroundDetectedFaces(rectangles_of_detected_faces, current_frame)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for DrawShapeAroundDetectedFaces
    '''</summary>
    <TestMethod()> _
    Public Sub DrawShapeAroundDetectedFacesTest1()
        Dim rectangle_of_detected_face As Rectangle = New Rectangle() ' TODO: Initialize to an appropriate value
        Dim current_frame As Image(Of Bgr, Byte) = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As Image(Of Bgr, Byte) = Nothing ' TODO: Initialize to an appropriate value
        Dim actual As Image(Of Bgr, Byte)
        actual = CameraManager.DrawShapeAroundDetectedFaces(rectangle_of_detected_face, current_frame)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for GetCurrentFrame
    '''</summary>
    <TestMethod()> _
    Public Sub GetCurrentFrameTest()
        Dim capture As Capture = Nothing ' TODO: Initialize to an appropriate value
        Dim image_box As ImageBox = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As Image(Of Bgr, Byte) = Nothing ' TODO: Initialize to an appropriate value
        Dim actual As Image(Of Bgr, Byte)
        actual = CameraManager.GetCurrentFrame(capture, image_box)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub
End Class
