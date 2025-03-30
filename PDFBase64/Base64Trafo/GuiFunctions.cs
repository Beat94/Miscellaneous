using Base64Trafo.DataModels;
using System.CodeDom;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Windows.Forms.VisualStyles;

namespace Base64Trafo;

public partial class Form1
{
    FileType fileTypeModel;
    string filepath = string.Empty;
    string openFileDialogFilter = string.Empty;

    #region UI-Wide Functions
    void CloseFunction(object sender, EventArgs e)
    {
        Application.Exit();
    }
    void ToClipboard(object sender, EventArgs e)
    {
        Clipboard.Clear();

        if (tabControl1.SelectedIndex == 0)
        {
            // File -> Base64           
            string path = string.Empty;

            // Value loading from interface
            if (!string.IsNullOrEmpty(filepath) || !string.IsNullOrEmpty(FileLocation.Text))
            {
                path = FileLocation.Text ?? filepath;
            }
            else
            {
                MessageBox.Show($"{nameof(filepath)} and Inputbox are empty, please choose file");
                return;
            }

            // check if path to document and documentending is in
            // filetype.json - if not throw 
            bool isCorrectFiletype = false;

            string FileEndingUIFunc(string? x = null)
            {
                List<string> xList = new();
                xList = x.Split('.').ToList();
                return $".{xList.ElementAt(xList.Count - 1)}";
            }

            string fileedingUI = FileEndingUIFunc(path);

            foreach (Filetypes filetypes in fileTypeModel.Filetypes)
            {
                string fileendingJson = filetypes.Fileending.TrimStart('*');

                if (fileedingUI.Equals(fileendingJson))
                {
                    isCorrectFiletype = true;
                    break;
                }
            }

            if (isCorrectFiletype == false)
            {
                MessageBox.Show("Invalid filetype.");
                return;
            }

            // load file => string Base64 to clipboard
            Clipboard.SetText(loadFileToBase64(path));
        }
        else
        {
            // Base64 -> File
            // Clipboard.SetText("Index 2");

            // check if Base64 Textbox is filled and some filetype are choosen
            if (string.IsNullOrEmpty(Base64Input.Text)
                || Filetype.SelectedIndex == 0)
            {
                MessageBox.Show("No Base64 Code and/or Filetype selected");
                return;
            }

            byte[] dataObj = Convert.FromBase64String(Base64Input.Text);
            // put 'File' to Clipboard
            Clipboard.SetData(fileTypeModel.Filetypes[Filetype.SelectedIndex - 1].Formatbezeichner, dataObj);

            /*
            MemoryStream ms = new MemoryStream();
            ms.Write(Convert.FromBase64String(Base64Input.Text), 0, Convert.FromBase64String(Base64Input.Text).Length);

            Clipboard.SetData($"ClipboardFile{fileTypeFromDropdown}", ms);
            */
        }
    }

    #endregion

    #region Startup Functions
    void LoadFileTypeModel()
    {
        this.fileTypeModel = JsonSerializer.Deserialize<FileType>(File.ReadAllText(".\\Data\\filetype.json"));
        List<Filetypes> fileTypesList = fileTypeModel.Filetypes.ToList();

        foreach (Filetypes fileTypes in fileTypesList)
        {
            if (!string.IsNullOrEmpty(this.openFileDialogFilter))
            {
                this.openFileDialogFilter += "|";
            }

            this.openFileDialogFilter += $"{fileTypes.Name} ({fileTypes.Fileending})|{fileTypes.Fileending}";
        }
    }
    void FillComboBox()
    {

        List<string> filetypesNameList = new();
        filetypesNameList.Add(string.Empty);

        foreach (Filetypes filetyp in this.fileTypeModel.Filetypes)
        {
            filetypesNameList.Add(filetyp.Name);
        }

        Filetype.DataSource = filetypesNameList;
    }
    #endregion

    #region Tab1 Functions
    public void OpenFileToEncrypt(object sender, EventArgs e)
    {
        using (OpenFileDialog openFileDialog = new())
        {
            openFileDialog.Filter = openFileDialogFilter;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filepath = openFileDialog.FileName;
            }
        }

        FileLocation.Text = filepath;
    }

    public string loadFileToBase64(string link) => 
        Convert.ToBase64String(File.ReadAllBytes(link));
    #endregion

    #region Tab2 Functions
    /// <summary>
    /// Checks if string is Base64 standard otherwise correct it with a '=' in the end
    /// </summary>
    /// <param name="input">Input string</param>
    /// <returns></returns>
    public string checkIfBase64IsCorrect(string input)
    {
        if (!input.EndsWith('='))
        {
            input += "=";
        }

        return input;
    }
    #endregion
}
