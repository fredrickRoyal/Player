Imports Emgu.CV.UI

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Player



'''<summary>
'''This is a test class for VideoDisplayUpdaterThreadTest and is intended
'''to contain all VideoDisplayUpdaterThreadTest Unit Tests
'''</summary>
<TestClass()> _
Public Class VideoDisplayUpdaterThreadTest


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
    '''A test for VideoDisplayUpdaterThread Constructor
    '''</summary>
    <TestMethod()> _
    Public Sub VideoDisplayUpdaterThreadConstructorTest()
        Dim video_display As ImageBox = Nothing ' TODO: Initialize to an appropriate value
        Dim target As VideoDisplayUpdaterThread = New VideoDisplayUpdaterThread(video_display)
        Assert.Inconclusive("TODO: Implement code to verify target")
    End Sub

    '''<summary>
    '''A test for DisplayNextFrame
    '''</summary>
    <TestMethod(), _
     DeploymentItem("Player.exe")> _
    Public Sub DisplayNextFrameTest()
        Dim param0 As PrivateObject = Nothing ' TODO: Initialize to an appropriate value
        Dim target As VideoDisplayUpdaterThread_Accessor = New VideoDisplayUpdaterThread_Accessor(param0) ' TODO: Initialize to an appropriate value
        target.DisplayNextFrame()
        Assert.Inconclusive("A method that does not return a value cannot be verified.")
    End Sub

    '''<summary>
    '''A test for DoWork
    '''</summary>
    <TestMethod()> _
    Public Sub DoWorkTest()
        Dim video_display As ImageBox = Nothing ' TODO: Initialize to an appropriate value
        Dim target As VideoDisplayUpdaterThread = New VideoDisplayUpdaterThread(video_display) ' TODO: Initialize to an appropriate value
        target.DoWork()
        Assert.Inconclusive("A method that does not return a value cannot be verified.")
    End Sub

    '''<summary>
    '''A test for DrawRectanglesAroundFaces
    '''</summary>
    <TestMethod(), _
     DeploymentItem("Player.exe")> _
    Public Sub DrawRectanglesAroundFacesTest()
        Dim param0 As PrivateObject = Nothing ' TODO: Initialize to an appropriate value
        Dim target As VideoDisplayUpdaterThread_Accessor = New VideoDisplayUpdaterThread_Accessor(param0) ' TODO: Initialize to an appropriate value
        target.DrawRectanglesAroundFaces()
        Assert.Inconclusive("A method that does not return a value cannot be verified.")
    End Sub

    '''<summary>
    '''A test for GetAllFacesFromQueue
    '''</summary>
    <TestMethod(), _
     DeploymentItem("Player.exe")> _
    Public Sub GetAllFacesFromQueueTest()
        Dim param0 As PrivateObject = Nothing ' TODO: Initialize to an appropriate value
        Dim target As VideoDisplayUpdaterThread_Accessor = New VideoDisplayUpdaterThread_Accessor(param0) ' TODO: Initialize to an appropriate value
        target.GetAllFacesFromQueue()
        Assert.Inconclusive("A method that does not return a value cannot be verified.")
    End Sub

    '''<summary>
    '''A test for RequestStop
    '''</summary>
    <TestMethod()> _
    Public Sub RequestStopTest()
        Dim video_display As ImageBox = Nothing ' TODO: Initialize to an appropriate value
        Dim target As VideoDisplayUpdaterThread = New VideoDisplayUpdaterThread(video_display) ' TODO: Initialize to an appropriate value
        target.RequestStop()
        Assert.Inconclusive("A method that does not return a value cannot be verified.")
    End Sub
End Class
