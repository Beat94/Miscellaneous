Add-Type -AssemblyName System.Windows.Forms;

Function encode($Link)
{
    return $output;
}

Function decode($Input, $OutputLink)
{

}

Function UserInterfaceEncoding()
{
    # open File
}

Function UserInterfaceDecoding()
{
    "Decoding GUI"
    # Insert String into
    $FormDecode = New-Object Windows.Forms.Form;

    $TextBoxInput = New-Object Windows.Forms.TextBox;
    $TextBoxInput.Location = New-Object System.Drawing.Point(10,40)
    $TextBoxInput.Size = New-Object System.Drawing.Size(260,20)

    $FormDecode.Controls.add($TextBoxInput);

    $FormDecode.ShowDialog();

    decode($FileInput, $FileLocation);
}

Function UserInterfaceMain()
{
    $Form = New-Object Windows.Forms.Form;
    $Form.Text = "PDF Base64 En- and Decoder";

    $Button = New-Object Windows.Forms.Button;
    $Button.Text = "Decoding";
    $Button.Add_Click({UserInterfaceDecoding});

    $form.Controls.add($Button);
    $Form.ShowDialog();
}


UserInterfaceMain;