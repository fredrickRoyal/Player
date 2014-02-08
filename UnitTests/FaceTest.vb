Imports Accord.Vision.Tracking

Imports Emgu.CV

Imports Emgu.CV.Structure

Imports System.Drawing

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Player.Entities



'''<summary>
'''This is a test class for FaceTest and is intended
'''to contain all FaceTest Unit Tests
'''</summary>
<TestClass()> _
Public Class FaceTest


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
    '''A test for Face Constructor
    '''</summary>
    <TestMethod()> _
    Public Sub FaceConstructorTest()
        Dim name As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim face_rect As Rectangle = New Rectangle() ' TODO: Initialize to an appropriate value
        Dim image As Image(Of Bgr, Byte) = Nothing ' TODO: Initialize to an appropriate value
        Dim target As Face = New Face(name, face_rect, image)
        Assert.Inconclusive("TODO: Implement code to verify target")
    End Sub

    '''<summary>
    '''A test for GetCurrentPositionOfFace
    '''</summary>
    <TestMethod()> _
    Public Sub GetCurrentPositionOfFaceTest()
        Dim name As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim face_rect As Rectangle = New Rectangle() ' TODO: Initialize to an appropriate value
        Dim image As Image(Of Bgr, Byte) = Nothing ' TODO: Initialize to an appropriate value
        Dim target As Face = New Face(name, face_rect, image) ' TODO: Initialize to an appropriate value
        Dim current_frame As Image(Of Bgr, Byte) = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As Rectangle = New Rectangle() ' TODO: Initialize to an appropriate value
        Dim actual As Rectangle
        actual = target.GetCurrentPositionOfFace(current_frame)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for GetRectangle
    '''</summary>
    <TestMethod()> _
    Public Sub GetRectangleTest()
        Dim name As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim face_rect As Rectangle = New Rectangle() ' TODO: Initialize to an appropriate value
        Dim image As Image(Of Bgr, Byte) = Nothing ' TODO: Initialize to an appropriate value
        Dim target As Face = New Face(name, face_rect, image) ' TODO: Initialize to an appropriate value
        Dim expected As Rectangle = New Rectangle() ' TODO: Initialize to an appropriate value
        Dim actual As Rectangle
        actual = target.GetRectangle
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for InitializeTracker
    '''</summary>
    <TestMethod()> _
    Public Sub InitializeTrackerTest()
        Dim name As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim face_rect As Rectangle = New Rectangle() ' TODO: Initialize to an appropriate value
        Dim image As Image(Of Bgr, Byte) = Nothing ' TODO: Initialize to an appropriate value
        Dim target As Face = New Face(name, face_rect, image) ' TODO: Initialize to an appropriate value
        Dim image1 As Image(Of Bgr, Byte) = Nothing ' TODO: Initialize to an appropriate value
        target.InitializeTracker(image1)
        Assert.Inconclusive("A method that does not return a value cannot be verified.")
    End Sub

    '''<summary>
    '''A test for face_rectangle
    '''</summary>
    <TestMethod(), _
     DeploymentItem("Player.exe")> _
    Public Sub face_rectangleTest()
        Dim param0 As PrivateObject = Nothing ' TODO: Initialize to an appropriate value
        Dim target As Face_Accessor = New Face_Accessor(param0) ' TODO: Initialize to an appropriate value
        Dim expected As Rectangle = New Rectangle() ' TODO: Initialize to an appropriate value
        Dim actual As Rectangle
        target.face_rectangle = expected
        actual = target.face_rectangle
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for face_tracker
    '''</summary>
    <TestMethod(), _
     DeploymentItem("Player.exe")> _
    Public Sub face_trackerTest()
        Dim param0 As PrivateObject = Nothing ' TODO: Initialize to an appropriate value
        Dim target As Face_Accessor = New Face_Accessor(param0) ' TODO: Initialize to an appropriate value
        Dim expected As Camshift = Nothing ' TODO: Initialize to an appropriate value
        Dim actual As Camshift
        target.face_tracker = expected
        actual = target.face_tracker
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for name
    '''</summary>
    <TestMethod(), _
     DeploymentItem("Player.exe")> _
    Public Sub nameTest()
        Dim param0 As PrivateObject = Nothing ' TODO: Initialize to an appropriate value
        Dim target As Face_Accessor = New Face_Accessor(param0) ' TODO: Initialize to an appropriate value
        Dim expected As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim actual As String
        target.name = expected
        actual = target.name
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub
End Class
