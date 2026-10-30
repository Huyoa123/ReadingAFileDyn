
using System;
using System.IO;
using System.Windows.Forms;

namespace CreatingTextFile
{
    public partial class FrmOpenTextFile : Form
    {
        public FrmOpenTextFile()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory =
                Environment.GetFolderPath(
                    Environment.SpecialFolder.MyDocuments);

            openFileDialog1.Title = "Find Text File";
            openFileDialog1.Filter =
                "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog1.DefaultExt = "txt";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.Multiselect = false;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    lvShowText.Items.Clear();
                    lvShowText.View = View.List;

                    using (StreamReader reader =
                        new StreamReader(openFileDialog1.FileName))
                    {
                        string line;

                        while ((line = reader.ReadLine()) != null)
                        {
                            lvShowText.Items.Add(line);
                        }
                    }
                }
                catch (IOException ex)
                {
                    MessageBox.Show(
                        "Error reading file: " + ex.Message,
                        "File Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show(
                        "You do not have permission to read this file.",
                        "Access Denied",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
        }

        private void btnViewRecords_Click(object sender, EventArgs e)
        {
            FrmStudentRecord studentRecord = new FrmStudentRecord();

            studentRecord.Show();
            this.Hide();
        }

        private void FrmOpenTextFile_Load(object sender, EventArgs e)
        {

        }
    }
}
