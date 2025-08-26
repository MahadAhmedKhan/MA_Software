Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class frm_EmployeeEntry
    Dim cm As CurrencyManager

    Private Sub Query()
        cn.GetDeta("Select * from " + Me.Tag, "pay_emp_info", cn.ds)
        cm = Me.BindingContext(cn.ds.Tables(Me.Tag))
    End Sub

    Private Sub frm_EmployeeEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cn.Fillcombobox("select id , depart_desc from pay_emp_department", "department", cmbDepart, "depart_desc", "id")
        cn.Fillcombobox("select id , desig_desc from pay_emp_designation", "designation", cmbDesig, "desig_desc", "id")
        cn.Fillcombobox("select id , shift_desc from pay_emp_shift", "shift", cmbshift, "shift_desc", "id")
        cn.Fillcombobox("select id , type_desc from pay_emp_type", "employeetype", cmbtype, "type_desc", "id")
        cn.Fillcombobox("select id ,  country_desc  from _country", "country", CmbCountry, "country_desc", "id")
        cn.Fillcombobox("select id  , city_desc from _city", "city", cmbcity, "city_desc", "id")
        Query()
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        'If BtnAdd.Text = "&Add" Then
        '    BtnAdd.Text = "&Save"
        'ElseIf BtnAdd.Text = "&Save" Then
        '    Dim str As String = "insert into pay_emp_info(code  ,_name , f_name , email , dob , cnic , gander , doj , address , phone  , Depart_ID , Desig_ID , Country_ID , City_ID , Emp_Type_ID , Shift_ID) " &
        '                        "values ('" & txtcode.Text & "' , '" & txtname.Text & "' , '" & txtfname.Text & "' , '" & txtemail.Text & "' , '" & DOB.Value & "' , '" & txtcnic.Text & "' , " &
        '                        "'" & If(radiomale.Checked, "Male", "Female") & "' , '" & DOJ.Value & "' , '" & txtaddress.Text & "' , '" & txtphone.Text & "' , '" & cmbDepart.SelectedValue & "' , " &
        '                        "'" & cmbDesig.SelectedValue & "' , '" & CmbCountry.SelectedValue & "' , '" & cmbcity.SelectedValue & "' , '" & cmbtype.SelectedValue & "' , '" & cmbshift.SelectedValue & "')"
        '    cmd = New SqlCommand(str, conn)
        '    cmd.ExecuteNonQuery()
        '    MessageBox.Show("Insert Record Successfully", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        'dim str as string = "delete from pay_emp_info where code = '" + txtcode.text + "' "
        'cmd = new sqlcommand(str, conn)
        'cmd.executenonquery()
    End Sub

    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        'If BtnEdit.Text = "&Edit" Then
        '    BtnEdit.Text = "&Update"
        '    Dim str As String = "update pay_emp_info set code = '" & txtcode.Text & "' , _name = '" & txtname.Text & "' , f_name = '" & txtfname.Text & "' , dob = '" & DOB.Value & "', cnic = '" & txtcnic.Text & "' , gander = '" & IIf(radiomale.Checked = True, "Male", "Femail") & "' , 
        '     doj = '" & DOJ.Value & "' , address = '" & txtaddress.Text & "' , phone = '" & txtphone.Text & "' , Depart_ID = '" & cmbDepart.SelectedValue & "', Desig_ID = '" & cmbDesig.SelectedValue & "' , Country_ID = '" & CmbCountry.SelectedValue & "' , 
        '     City_ID = '" & cmbcity.SelectedValue & "' , Emp_Type_ID = '" & cmbtype.SelectedValue & "' , Shift_ID = '" & cmbshift.SelectedValue & "' where code = '" + txtcode.Text + "'"
        '    cmd = New SqlCommand(str, conn)
        '    cmd.ExecuteNonQuery()
        '    MessageBox.Show("Record Update Successfully", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

        'End If
    End Sub


End Class