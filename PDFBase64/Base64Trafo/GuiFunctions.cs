using Base64Trafo.DataModels;
using System.Text.Json;

namespace Base64Trafo;

public partial class Form1
{
    FileType fileTypeModel;
    string filepath;

    #region UI-Wide Functions
    void CloseFunction(object sender, EventArgs e)
    {
        Application.Exit();
    }
    void ToClipboard(object sender, EventArgs e)
    {
        if (tabControl1.SelectedIndex == 0)
        {
            // File -> Base64
            Clipboard.SetText("Index 1");
        }
        else
        {
            // Base64 -> File
            Clipboard.SetText("Index 2");
        }

    }
    #endregion

    #region Startup Functions
    void LoadFileTypeModel()
    {
        this.fileTypeModel = JsonSerializer.Deserialize<FileType>(File.ReadAllText(".\\Data\\filetype.json"));
    }
    void FillComboBox()
    {

        List<string> filetypesNameList = new();
        filetypesNameList.Add(string.Empty);

        foreach (Filetypes filetyp in this.fileTypeModel.Filetypes)
        {
            filetypesNameList.Add(filetyp.Name);
        }

        comboBox1.DataSource = filetypesNameList;
    }
    #endregion

    #region Tab1 Functions
    public void OpenFileToEncrypt(object sender, EventArgs e)
    {
        using (OpenFileDialog openFileDialog = new())
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filepath = openFileDialog.FileName;
            }
        }

        FileLocation.Text = filepath;
    }
    #endregion
}
