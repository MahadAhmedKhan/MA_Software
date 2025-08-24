Imports System.Data.SqlClient

Public Class frm_EmployeeEntry


    Dim connectionString As String = "Server=DESKTOP-9HU6DH7;Database=MA_Solution;Trusted_Connection=True;"
    Dim conn As New SqlConnection(connectionString)
    Dim str As String
    Public cmd As New SqlCommand



    Public Shared Sub Fillcombobox(ByVal connectionString As String, ByVal Query As String, ByVal tablename As String, cmb As ComboBox, ByVal displayMember As String, ByVal valueMember As String)
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
    End Sub
    Private Sub TestConnection()

        Try
            conn.Open()
            MessageBox.Show("✅ Connection Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As SqlException
            MessageBox.Show("❌ SQL Error: " & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("❌ General Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub frm_EmployeeEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TestConnection()
        Fillcombobox(connectionString, "select id , Depart_Desc from pay_emp_department", "Department", cmbDepart, "Depart_Desc", "id")
        Fillcombobox(connectionString, "select id , Desig_desc from pay_emp_designation", "Designation", cmbDesig, "Desig_desc", "id")
        Fillcombobox(connectionString, "select id , Shift_desc from pay_emp_shift", "Shift", cmbshift, "Shift_desc", "id")
        Fillcombobox(connectionString, "select id , type_desc from pay_emp_type", "EmployeeType", cmbtype, "type_desc", "id")
        Fillcombobox(connectionString, "select id ,  Country_desc  from _Country", "Country", CmbCountry, "Country_desc", "id")
        Fillcombobox(connectionString, "select id  , City_desc from _City", "City", cmbcity, "City_desc", "id")
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        If BtnAdd.Text = "&Add" Then
            BtnAdd.Text = "&Save"
        ElseIf BtnAdd.Text = "&Save" Then
            Dim str As String = "insert into pay_emp_info(code  ,_name , f_name , email , dob , cnic , gander , doj , address , phone  , Depart_ID , Desig_ID , Country_ID , City_ID , Emp_Type_ID , Shift_ID) " &
                                "values ('" & txtcode.Text & "' , '" & txtname.Text & "' , '" & txtfname.Text & "' , '" & txtemail.Text & "' , '" & DOB.Value & "' , '" & txtcnic.Text & "' , " &
                                "'" & If(radiomale.Checked, "Male", "Female") & "' , '" & DOJ.Value & "' , '" & txtaddress.Text & "' , '" & txtphone.Text & "' , '" & cmbDepart.SelectedValue & "' , " &
                                "'" & cmbDesig.SelectedValue & "' , '" & CmbCountry.SelectedValue & "' , '" & cmbcity.SelectedValue & "' , '" & cmbtype.SelectedValue & "' , '" & cmbshift.SelectedValue & "')"
            cmd = New SqlCommand(str, conn)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Insert Record Successfully", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        Dim str As String = "Delete from pay_emp_info where code = '" + txtcode.Text + "' "
        cmd = New SqlCommand(str, conn)
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        If BtnEdit.Text = "&Edit" Then
            BtnEdit.Text = "&Update"
            Dim str As String = "update pay_emp_info set code = '" & txtcode.Text & "' , _name = '" & txtname.Text & "' , f_name = '" & txtfname.Text & "' , dob = '" & DOB.Value & "', cnic = '" & txtcnic.Text & "' , gander = '" & IIf(radiomale.Checked = True, "Male", "Femail") & "' , 
             doj = '" & DOJ.Value & "' , address = '" & txtaddress.Text & "' , phone = '" & txtphone.Text & "' , Depart_ID = '" & cmbDepart.SelectedValue & "', Desig_ID = '" & cmbDesig.SelectedValue & "' , Country_ID = '" & CmbCountry.SelectedValue & "' , 
             City_ID = '" & cmbcity.SelectedValue & "' , Emp_Type_ID = '" & cmbtype.SelectedValue & "' , Shift_ID = '" & cmbshift.SelectedValue & "' where code = '" + txtcode.Text + "'"
            cmd = New SqlCommand(str, conn)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Record Update Successfully", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If
    End Sub


    'Private Sub comboboxfill()
    'Try
    '    str = "select id , Depart_Desc from pay_emp_department"
    '    cmd = New SqlCommand(str, conn)
    '    Dim da As New SqlDataAdapter(cmd)
    '    Dim ds As New DataSet
    '    da.Fill(ds, "Departments")
    '    cmbDepart.ValueMember = "id"
    '    cmbDepart.DisplayMember = "Depart_Desc"
    '    cmbDepart.DataSource = ds.Tables("Departments")

    'Catch ex As Exception
    '    MessageBox.Show(ex.Message, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
    'End Try


    ' End Sub
End Class