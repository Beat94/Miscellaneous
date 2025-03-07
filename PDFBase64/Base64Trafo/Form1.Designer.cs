namespace Base64Trafo
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            button3 = new Button();
            FileLocation = new TextBox();
            label1 = new Label();
            tabPage2 = new TabPage();
            label3 = new Label();
            Filetype = new ComboBox();
            label2 = new Label();
            Base64Input = new TextBox();
            button1 = new Button();
            button2 = new Button();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(776, 379);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(button3);
            tabPage1.Controls.Add(FileLocation);
            tabPage1.Controls.Add(label1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(768, 351);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "File -> Base64";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(668, 21);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 2;
            button3.Text = "Open";
            button3.UseVisualStyleBackColor = true;
            button3.Click += OpenFileToEncrypt;
            // 
            // FileLocation
            // 
            FileLocation.Location = new Point(124, 22);
            FileLocation.Margin = new Padding(2);
            FileLocation.Name = "FileLocation";
            FileLocation.Size = new Size(522, 23);
            FileLocation.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 25);
            label1.Name = "label1";
            label1.Size = new Size(79, 15);
            label1.TabIndex = 0;
            label1.Text = "File-Location:";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(label3);
            tabPage2.Controls.Add(Filetype);
            tabPage2.Controls.Add(label2);
            tabPage2.Controls.Add(Base64Input);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(768, 351);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Base64 -> File";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 73);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 3;
            label3.Text = "Filetype:";
            // 
            // Filetype
            // 
            Filetype.FormattingEnabled = true;
            Filetype.Location = new Point(120, 70);
            Filetype.Name = "Filetype";
            Filetype.Size = new Size(233, 23);
            Filetype.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 28);
            label2.Name = "label2";
            label2.Size = new Size(79, 15);
            label2.TabIndex = 1;
            label2.Text = "Base64-Code:";
            // 
            // Base64Input
            // 
            Base64Input.Location = new Point(120, 25);
            Base64Input.Name = "Base64Input";
            Base64Input.Size = new Size(594, 23);
            Base64Input.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(709, 406);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "Close";
            button1.UseVisualStyleBackColor = true;
            button1.Click += CloseFunction;
            // 
            // button2
            // 
            button2.AccessibleName = "ToClipboard";
            button2.Location = new Point(620, 406);
            button2.Name = "button2";
            button2.Size = new Size(83, 23);
            button2.TabIndex = 0;
            button2.Text = "To Clipboard";
            button2.UseVisualStyleBackColor = true;
            button2.Click += ToClipboard;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "Base64 Transfomer";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ResumeLayout(false);
            LoadFileTypeModel();
            FillComboBox();
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button button1;
        private Button button2;
        private Label label1;
        private Button button3;
        private TextBox FileLocation;
        private Label label2;
        private TextBox Base64Input;
        private Label label3;
        private ComboBox Filetype;
    }
}
