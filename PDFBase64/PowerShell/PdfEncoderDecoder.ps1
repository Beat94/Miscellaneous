Add-Type -AssemblyName System.Windows.Forms;

Function encode($Link)
{
    return $output;
}

Function decode($Input, $OutputLink)
{
    "Input: " + $Input
    "OutputLink: " + $OutputLink
}

Function UserInterfaceEncoding()
{
    # open File
}

Function UserInterfaceDecoding()
{
    "Decoding GUI"
    $SaveLink = "Save"
    # Insert String into
    $FormDecode = New-Object Windows.Forms.Form;
    $FormDecode.Text = "Decoding UI";
    $FormDecode.Size = New-Object System.Drawing.Size(370, 170);

    $TextBoxInput = New-Object Windows.Forms.TextBox;
    $TextBoxInput.Location = New-Object System.Drawing.Point(80,10);
    $TextBoxInput.Size = New-Object System.Drawing.Size(260,20);

    $InputLabel = New-Object Windows.Forms.Label;
    $InputLabel.Text = "Input-String:";
    $InputLabel.Location = New-Object System.Drawing.Point((10, 10));

    $SaveButton = New-Object Windows.Forms.Button;
    $SaveButton.Text = "Speicherort";
    $SaveButton.Location = New-Object System.Drawing.Point((10, 50));
    $SaveButton.Add_Click({
        # https://www.reddit.com/r/PowerShell/comments/6bag66/trying_to_use_a_save_as_gui_screen/
        $dialog = New-Object System.Windows.Forms.SaveFileDialog
        $dialog.filter = "PDF Files (*.pdf)|*.pdf"
        $SaveLink = $dialog.ShowDialog()
        $SaveLink
    });

    $NextButton = New-Object Windows.Forms.Button;
    $NextButton.Text = "Decode";
    $NextButton.Location = New-Object System.Drawing.Point((10, 90));
    $NextButton.Add_Click({
        $TextBoxInput.Text
        $SaveLink.Text
        decode($TextBoxInput.Text,$SaveLink.Text)
    });

    $FormDecode.Controls.add($TextBoxInput);
    $FormDecode.Controls.add($NextButton);
    $FormDecode.Controls.add($InputLabel);
    $FormDecode.Controls.add($SaveButton);

    $FormDecode.add_shown({$FormDecode.Activate()})
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


#UserInterfaceMain;
UserInterfaceDecoding;