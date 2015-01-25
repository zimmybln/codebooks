Imports System.IO
Imports System.Xml
Imports System.Windows.Markup
Imports System.Reflection

Class MainWindow

    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        ComboBox1.Items.Clear()

        Dim asm As Assembly = GetType(ListBox).Assembly
        Dim typFrameworkElement As Type = GetType(FrameworkElement)

        Dim lst As New List(Of TypeInfo)()

        For Each t As Type In From it As Type In asm.GetTypes() Where it.IsPublic And Not it.IsAbstract Select it
            If t.IsSubclassOf(typFrameworkElement) Then
                lst.Add(New TypeInfo(t))
            End If
        Next

        ' Sortierung der Einträge
        lst.Sort(Function(x As TypeInfo, y As TypeInfo) String.Compare(x.DisplayName, y.DisplayName))
        
        lst.ForEach(Sub(x As TypeInfo) ComboBox1.Items.Add(x))

        For Each objKey As Object In Application.Current.Resources.Keys
            cboResources.Items.Add(objKey)
        Next

    End Sub

    Private Sub cmdSetStyle1_Click(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles cmdSetStyle1.Click
        ListBox1.SetResourceReference(FrameworkElement.StyleProperty, "ListBoxWithBackColorBurlyWood")
    End Sub

    Private Sub cmdSetStyle2_Click(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles cmdSetStyle2.Click

        Dim st As Style = TryFindResource("ListBoxWithBackColorCornflowerBlue")

        If st IsNot Nothing Then
            ListBox1.Style = st
        End If

    End Sub

    Private Sub OnSelectionChanged(sender As System.Object, e As System.Windows.Controls.SelectionChangedEventArgs)

        TextBlock1.Text = String.Empty

        If ComboBox1.SelectedItem Is Nothing OrElse Not TypeOf (ComboBox1.SelectedItem) Is TypeInfo Then Return

        Dim strSelectedItem As String = CType(ComboBox1.SelectedItem, TypeInfo).QualifiedTypeName

        Dim typ As Type = Type.GetType(strSelectedItem, False, True)

        If typ Is Nothing Then
            MessageBox.Show(String.Format("Der Typ {0} konnte nicht geladen werden.", strSelectedItem), "Style ermitteln", MessageBoxButton.OK, MessageBoxImage.Error)
            Return
        End If

        Dim fe As FrameworkElement = Activator.CreateInstance(typ)

        Dim objDefaultStyleKey As Object = fe.GetValue(FrameworkElement.DefaultStyleKeyProperty)

        If objDefaultStyleKey IsNot Nothing Then

            Dim st As Style = Application.Current.TryFindResource(objDefaultStyleKey)

            If st IsNot Nothing Then

                Dim sw As New StringWriter()
                Dim xw As New XmlTextWriter(sw)
                xw.Formatting = Formatting.Indented
                XamlWriter.Save(st, xw)

                TextBlock1.Text = sw.ToString()

            End If

        End If
    End Sub
End Class

Public Class TypeInfo

    Public Sub New(Type As Type)
        DisplayName = Type.Name
        QualifiedTypeName = Type.AssemblyQualifiedName
    End Sub

    Public Property DisplayName As String

    Public Property QualifiedTypeName As String
End Class
