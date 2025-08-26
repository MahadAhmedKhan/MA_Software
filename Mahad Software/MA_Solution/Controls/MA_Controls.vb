Imports System.CodeDom
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Windows.Forms


Public Class MA_Controls

    Public ds As New Data.DataSet
    Public conn As SqlConnection = New SqlConnection(connectionString)
    Private Shared ReadOnly connectionString As String = "Server=mahad\MAHADSQL19;Database=SamiClothing21082025;Trusted_Connection=True;"

    ' 🔹 Function to get an open SqlConnection
    Public Shared Function GetConnection() As SqlConnection
        Dim conn As New SqlConnection(connectionString)
        Try
            conn.Open()
            Return conn
        Catch ex As Exception
            MessageBox.Show("❌ Connection Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function

    'Query Execution Function
    Public Function GetDeta(ByVal Sql As String, ByVal tablename As String, ByVal ds As Data.DataSet)
        Using conn As New SqlConnection(connectionString)
            conn.Open()
            Using da As New SqlDataAdapter(Sql, conn)
                If ds.Tables.Contains(tablename) Then
                    ds.Tables(tablename).Clear()
                End If
                da.Fill(ds, tablename)
            End Using
        End Using
    End Function
    'comobobox Fill Function
    Public Function Fillcombobox(ByVal Query As String, ByVal tablename As String, cmb As ComboBox, ByVal displayMember As String, ByVal valueMember As String)
        Try
            Using conn As New SqlConnection(connectionString)
                Dim cmd As New SqlCommand(Query, conn)
                Dim da As New SqlDataAdapter(cmd)
                Dim ds As New DataSet(tablename)
                da.Fill(ds, tablename)

                cmb.DataSource = ds.Tables(tablename)
                cmb.DisplayMember = displayMember
                cmb.ValueMember = valueMember
            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function


    Public Function ExecuteNonQuery(ByVal sql As String) As Integer
        Try
            Dim cmd As New SqlCommand(sql, conn)
            Dim rows As Integer = cmd.ExecuteNonQuery
            Return rows

        Catch ex As Exception
            MessageBox.Show(ex.Message, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally

        End Try
    End Function

    Public Function add(frm As Form, ByVal tablename As String, ByVal cm As CurrencyManager)
        Dim column As New List(Of String)
        Dim values As New List(Of String)

        For Each ctrl As Control In frm.Controls
            If TypeOf ctrl Is TextBox Then
                Dim txt As TextBox = CType(ctrl, TextBox)
                If txt.Tag IsNot Nothing Then
                    column.Add(txt.Tag.ToString())
                    values.Add("'" + txt.Text.Replace("'", "''") + "'")
                End If


            ElseIf TypeOf ctrl Is ComboBox Then
                Dim cmb As ComboBox = CType(ctrl, ComboBox)
                If cmb.Tag IsNot Nothing Then
                    column.Add(cmb.Tag.ToString())
                    If cmb.SelectedValue Or cmb.SelectedItem Or cmb.Text IsNot Nothing Then
                        values.Add("'" + cmb.SelectedValue.ToString().Replace("'", "''") + "'")
                    End If
                End If

            ElseIf TypeOf ctrl Is DateTimePicker Then
                Dim dtp As DateTimePicker = CType(ctrl, DateTimePicker)
                If dtp.Tag IsNot Nothing Then
                    column.Add(dtp.Tag.ToString())
                    values.Add("'" + dtp.Value.ToString("dd-MM-yyyy HH:mm:ss") + "'")
                End If

            ElseIf TypeOf ctrl Is RadioButton Then
                Dim rdo As RadioButton = CType(ctrl, RadioButton)
                If rdo.Tag IsNot Nothing Then
                    column.Add(rdo.Tag.ToString)
                    values.Add("1")
                End If

            ElseIf TypeOf Ctrl Is CheckBox Then
                Dim chk As CheckBox = CType(ctrl, CheckBox)
                If chk.Tag IsNot Nothing Then
                    column.Add(chk.Tag.ToString)
                    values.Add(If(chk.Checked, "1", "0"))
                End If
            End If
        Next

        Dim sql As String = $"INSERT INTO {tablename} ({String.Join(",", column)}) VALUES ({String.Join(",", values)})"
        Dim result As Integer = ExecuteNonQuery(sql)
        If result > 0 Then
            MessageBox.Show("Record Inserted Successfully", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cm.Refresh()
            result = True
        Else
            MessageBox.Show("Failed to Insert Record", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
            result = False
        End If
    End Function

End Class

