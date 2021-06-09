Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Windows.Interop
Imports System.Windows.Threading

Class MainWindow

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        Dim m = Me
        m.WindowStyle = WindowStyle.None
        m.Width = 0
        m.Height = 0
        m.Top = 0
        m.Left = 0
        m.Opacity = 0

        System.Threading.Thread.Sleep(100)
        Dim workw = GetWorkerW()
        Console.WriteLine(workw)
        SetParent((New WindowInteropHelper(m)).Handle, workw)
        MoveWindow((New WindowInteropHelper(m)).Handle, 0, 0, 1920, 1080, True)
        m.Opacity = 1

        update()
        Dim t As New Threading.DispatcherTimer
        t.Interval = TimeSpan.FromMinutes(1)
        AddHandler t.Tick, AddressOf update
        t.Start()

        updatesentence()
        Dim sentencetimer As New Threading.DispatcherTimer
        sentencetimer.Interval = TimeSpan.FromMinutes(15)
        AddHandler sentencetimer.Tick, AddressOf updatesentence
        sentencetimer.Start()

    End Sub

    Private Sub update()
        Dim t As TimeSpan = New DateTime(2021, 6, 7, 9, 0, 0) - Now
        t1.Text = t.Days
        t2.Text = t.Hours
        t3.Text = t.Minutes
    End Sub

    Private Sub updatesentence()
        Dim path = Environment.CurrentDirectory + "\ttt.txt"
        Dim sr As New StreamReader(path, Encoding.Default)
        Dim l As List(Of String) = New List(Of String)
        Do
            Dim textContent = sr.ReadLine()
            If IsNothing(textContent) Then Exit Do
            l.Add(textContent)
        Loop While True
        sr.Close()
        Dim r As Random = New Random
        Dim res = l(r.Next(l.Count - 1))

        Text0.Text = res
    End Sub

End Class
