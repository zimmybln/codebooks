Class MainWindow 

    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles Button1.Click
        VisualStateManager.GoToState(display, "State1", True)
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles Button2.Click
        VisualStateManager.GoToState(display, "State2", True)
    End Sub
End Class
