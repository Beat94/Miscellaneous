Add-Type -AssemblyName System.Windows.Forms;

Function encode($Link)
{
    return $output;
}

Function decode($Input, $OutputLink)
{
    Write-Host "Input: " $Input.Text
    Write-Host "OutputLink: " $OutputLink.Text
}

Function UserInterfaceEncoding()
{
    # open File
}

Function UserInterfaceDecoding()
{
    "Decoding GUI"
    $SaveLink
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
        if($dialog.ShowDialog() -eq 'OK')
        {
            $SaveLink = out-file -FilePath $dialog.FileName
        }
        Write-host "First Test: " $SaveLink
    });

    $NextButton = New-Object Windows.Forms.Button;
    $NextButton.Text = "Decode";
    $NextButton.Location = New-Object System.Drawing.Point((10, 90));
    $NextButton.Add_Click({
        $tbIn = $TextBoxInput.Text
        Write-Host $tbIn
        Write-Host $SaveLink
        decode($tbIn, $SaveLink)
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
    "Main User Interface"

    $Form = New-Object Windows.Forms.Form;
    $Form.Text = "PDF Base64 En- and Decoder";

    $Button = New-Object Windows.Forms.Button;
    $Button.Text = "Decoding";
    $Button.Add_Click({UserInterfaceDecoding});

    $Button2 = New-Object Windows.Forms.Button;
    $Button2.Text = "Lolz";
    $Button2.Location = New-Object System.Drawing.Point((10, 50));
    $Button2.Add_Click({Write-Host "Dies war ein Klick"});

    $form.Controls.add($Button);
    #$form.Controls.add($Button2);
    $Form.ShowDialog();
}


UserInterfaceMain;
#UserInterfaceDecoding;