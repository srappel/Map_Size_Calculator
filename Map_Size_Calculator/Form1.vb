Public Class CalcForm

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            'Step 1: Calculate Sqft area for lblOrigArea
            'OrigArea = (OrigBase * OrigHeight)/144
            Dim OrigArea As Double
            Dim OrigBase As Double
            Dim OrigHeight As Double

            If Not txtOrigHeight.Text = Nothing Then
                OrigHeight = txtOrigHeight.Text.Trim()
            Else
                MsgBox("Please enter an Original Height for the document!", MsgBoxStyle.OkOnly)
                Exit Sub
            End If

            If Not txtOrigBase.Text = Nothing Then
                OrigBase = txtOrigBase.Text.Trim()
            Else
                MsgBox("Please enter an Original Base for the document!", MsgBoxStyle.OkOnly)
                Exit Sub
            End If

            OrigArea = (OrigBase * OrigHeight) / 144
            lblOrigArea.Text = Math.Round(OrigArea, 3).ToString & " sq ft"

            'Step 2: define the scale factor
            Dim ScaleFactorInput As Double

            If Not txtScaleFactor.Text = Nothing Then
                ScaleFactorInput = txtScaleFactor.Text.Trim()
            Else
                MsgBox("Please enter a scale factor!", MsgBoxStyle.OkOnly)
                Exit Sub
            End If

            Dim Scalefactor As Double = ScaleFactorInput / 100

            'Step 3: Calculate the length of the height of the NewArea
            Dim NewArea As Double = Scalefactor * OrigArea

            Dim NewHeight As Double
            Dim NewBase As Double

            Dim d As Double = (OrigBase / OrigHeight) * NewArea
            NewBase = Math.Sqrt(d)
            NewHeight = NewArea / NewBase

            Dim NewHeightIn As Double = NewHeight * 12
            Dim NewBaseIn As Double = NewBase * 12

            lblNewArea.Text = Math.Round(NewArea, 3).ToString() & " sq ft"
            lblNewBase.Text = Math.Round(NewBaseIn, 3).ToString() & " in"
            lblNewHeight.Text = Math.Round(NewHeightIn, 3).ToString() & " in"
        Catch ex As Exception
            MsgBox("There was an error, likley a forbidden non-numerical character entered!" & vbCrLf & vbCrLf & ex.ToString())
            Exit Sub
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        txtOrigBase.Text = Nothing
        txtOrigHeight.Text = Nothing
        txtScaleFactor.Text = Nothing
        lblNewArea.Text = Nothing
        lblOrigArea.Text = Nothing
        lblNewBase.Text = "_____"
        lblNewHeight.Text = "_____"
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Close()
    End Sub

End Class
