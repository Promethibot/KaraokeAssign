Public Class Form1
    Private _decSong As Decimal = 2.99D
    Private _decRoom As Decimal = 8.99D

    Private Function ValidateInput() As Boolean
        Dim intNumber As Integer
        Dim blnValid As Boolean = False

        Try
            intNumber = Convert.ToInt32(tbxInput.Text)

            If intNumber > 0D Then
                blnValid = True
                Return blnValid
            End If

        Catch Exception As FormatException
            MsgBox("Please enter a valid amount.", , "Real Numbers, Please!")
        Catch Exception As OverflowException
            MsgBox("Please enter a reasonable amount.", , "What are you doing?")
        Catch Exception As SystemException
            MsgBox("Sorry, that doesn't seem right. Please enter a valid value.", , "?!")
        End Try
        tbxInput.Focus()
        tbxInput.Clear()

        Return blnValid
    End Function

    Private Function RetSongCost(ByVal intpass As Integer) As Decimal
        Dim decPassCost As Decimal
        decPassCost = intpass * _decSong

        Return decPassCost
    End Function

    Private Function RetRoomCost(ByVal intticket As Integer) As Decimal
        Dim decTicketCost As Decimal
        decTicketCost = intticket * _decRoom

        Return decTicketCost
    End Function

    Private Sub cbxList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxList.SelectedIndexChanged
        If (cbxList.SelectedIndex = 0) Then
            lblDisplay.Text = "     Number of Karaoke songs:"
            lblDisplay.Visible = True
            tbxInput.Visible = True

            btnClear.Enabled = True
            tbxInput.Focus()
        Else
            lblDisplay.Text = "Hourly rental of Karaoke Room:"
            lblDisplay.Visible = True
            tbxInput.Visible = True

            btnClear.Enabled = True
            tbxInput.Focus()
        End If
    End Sub

    Private Sub ClearForm()
        lblDisplay.Visible = False
        lblCost.Visible = False
        btnCost.Enabled = False
        tbxInput.Visible = False
        tbxInput.Clear()
        cbxList.Text = "Customize your night with..."
        btnClear.Enabled = False
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearForm()
    End Sub

    Private Sub tbxInput_TextChanged(sender As Object, e As EventArgs) Handles tbxInput.TextChanged
        If (tbxInput.TextLength > 0) Then
            btnCost.Enabled = True
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ClearForm()
    End Sub

    Private Sub btnCost_Click(sender As Object, e As EventArgs) Handles btnCost.Click
        Dim blnAmountValid = False
        Dim intValue As Integer
        Dim decTotal As Decimal

        blnAmountValid = ValidateInput()

        If blnAmountValid Then
            intValue = Convert.ToInt32(tbxInput.Text)
            If (cbxList.SelectedIndex = 0) Then
                decTotal = RetSongCost(intValue)
            Else
                decTotal = RetRoomCost(intValue)
            End If

            lblCost.Text = "Total Cost: $" + decTotal.ToString("N2")
            lblCost.Visible = True
        End If

    End Sub
End Class
