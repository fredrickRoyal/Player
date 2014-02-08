Imports System.Windows.Forms

Imports Emgu.CV.UI

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Player



'''<summary>
'''This is a test class for VideoFromFileGrabberThreadTest and is intended
'''to contain all VideoFromFileGrabberThreadTest Unit Tests
'''</summary>
<TestClass()> _
Public Class VideoFromFileGrabberThreadTest


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
    '''A test for VideoFromFileGrabberThread Constructor
    '''</summary>
    <TestMethod()> _
    Public Sub VideoFromFileGrabberThreadConstructorTest()
        Dim file_name As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim image_box As ImageBox = Nothing ' TODO: Initialize to an appropriate value
        Dim picture_box As PictureBox = Nothing ' TODO: Initialize to an appropriate value
        Dim target As VideoFromFileGrabberThread = New VideoFromFileGrabberThread(file_name, image_box, picture_box)
        Assert.Inconclusive("TODO: Implement code to verify target")
    End Sub

    '''<summary>
    '''A test for AddNextFrameToQueueForProcessing
    '''</summary>
    <TestMethod(), _
     DeploymentItem("Player.exe")> _
    Public Sub AddNextFrameToQueueForProcessingTest()
        Dim param0 As PrivateObject = Nothing ' TODO: Initialize to an appropriate value
        Dim target As VideoFromFileGrabberThread_Accessor = New VideoFromFileGrabberThread_Accessor(param0) ' TODO: Initialize to an appropriate value
        target.AddNextFrameToQueueForProcessing()
        Assert.Inconclusive("A method that does not return a value cannot be verified.")
    End Sub

    '''<summary>
    '''A test for DoWork
    '''</summary>
    <TestMethod()> _
    Public Sub DoWorkTest()
        Dim file_name As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim image_box As ImageBox = Nothing ' TODO: Initialize to an appropriate value
        Dim picture_box As PictureBox = Nothing ' TODO: Initialize to an appropriate value
        Dim target As VideoFromFileGrabberThread = New VideoFromFileGrabberThread(file_name, image_box, picture_box) ' TODO: Initialize to an appropriate value
        target.DoWork()
        Assert.Inconclusive("A method that does not return a value cannot be verified.")
    End Sub

    '''<summary>
    '''A test for RequestStop
    '''</summary>
    <TestMethod()> _
    Public Sub RequestStopTest()
        Dim file_name As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim image_box As ImageBox = Nothing ' TODO: Initialize to an appropriate value
        Dim picture_box As PictureBox = Nothing ' TODO: Initialize to an appropriate value
        Dim target As VideoFromFileGrabberThread = New VideoFromFileGrabberThread(file_name, image_box, picture_box) ' TODO: Initialize to an appropriate value
        target.RequestStop()
        Assert.Inconclusive("A method that does not return a value cannot be verified.")
    End Sub

    '''<summary>
    '''A test for StartFaceDetectingThread
    '''</summary>
    <TestMethod(), _
     DeploymentItem("Player.exe")> _
    Public Sub StartFaceDetectingThreadTest()
        Dim param0 As PrivateObject = Nothing ' TODO: Initialize to an appropriate value
        Dim target As VideoFromFileGrabberThread_Accessor = New VideoFromFileGrabberThread_Accessor(param0) ' TODO: Initialize to an appropriate value
        target.StartFaceDetectingThread()
        Assert.Inconclusive("A method that does not return a value cannot be verified.")
    End Sub

    '''<summary>
    '''A test for StartProcessingThreads
    '''</summary>
    <TestMethod(), _
     DeploymentItem("Player.exe")> _
    Public Sub StartProcessingThreadsTest()
        Dim param0 As PrivateObject = Nothing ' TODO: Initialize to an appropriate value
        Dim target As VideoFromFileGrabberThread_Accessor = New VideoFromFileGrabberThread_Accessor(param0) ' TODO: Initialize to an appropriate value
        target.StartProcessingThreads()
        Assert.Inconclusive("A method that does not return a value cannot be verified.")
    End Sub

    '''<summary>
    '''A test for StartVideoUpdaterThread
    '''</summary>
    <TestMethod(), _
     DeploymentItem("Player.exe")> _
    Public Sub StartVideoUpdaterThreadTest()
        Dim param0 As PrivateObject = Nothing ' TODO: Initialize to an appropriate value
        Dim target As VideoFromFileGrabberThread_Accessor = New VideoFromFileGrabberThread_Accessor(param0) ' TODO: Initialize to an appropriate value
        target.StartVideoUpdaterThread()
        Assert.Inconclusive("A method that does not return a value cannot be verified.")
    End Sub
End Class
