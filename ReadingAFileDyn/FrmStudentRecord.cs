
using LabStream;
using System;
using System.IO;
using System.Windows.Forms;

namespace CreatingTextFile
{
    public partial class FrmStudentRecord : Form
    {

        private string selectedFilePath = "";

        public FrmStudentRecord()
        {
            InitializeComponent();
        }


        private void btnRegister_Click(object sender, EventArgs e)
        {
            FrmRegistration registration = new FrmRegistration();
            registration.Show();
            this.Hide();
        }


        private void btnFind_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Find Student Record";
                openFileDialog.Filter = "Text Files (*.txt)|*.txt";
                openFileDialog.InitialDirectory =
                    Environment.GetFolderPath(
                        Environment.SpecialFolder.MyDocuments);

                if (openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    lvShowText.BeginUpdate();
                    lvShowText.Items.Clear();

                    using (StreamReader reader =
                        new StreamReader(openFileDialog.FileName))
                    {
                        string line;

                        while ((line = reader.ReadLine()) != null)
                        {
                            ListViewItem item = new ListViewItem(line);
                            lvShowText.Items.Add(item);
                        }
                    }


                    selectedFilePath = openFileDialog.FileName;


                    if (lvShowText.Columns.Count > 0)
                    {
                        lvShowText.Columns[0].Width = -2;
                    }
                }
                catch (Exception ex)
                {
                    selectedFilePath = "";
                    lvShowText.Items.Clear();

                    MessageBox.Show(
                        "Error reading file: " + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                finally
                {
                    lvShowText.EndUpdate();
                }
            }
        }


        private void btnUpload_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(selectedFilePath) ||
                !File.Exists(selectedFilePath) ||
                lvShowText.Items.Count == 0)
            {
                MessageBox.Show(
                    "Please click Find and select a student record first.",
                    "No Student Record",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }


            MessageBox.Show(
                "Successfully Uploaded!",
                "Upload",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);


            lvShowText.Items.Clear();
            selectedFilePath = "";
        }


        private void FrmStudentRecord_Load(object sender, EventArgs e)
        {
            lvShowText.View = View.Details;
            lvShowText.FullRowSelect = true;
            lvShowText.GridLines = true;


            if (lvShowText.Columns.Count == 0)
            {
                lvShowText.Columns.Add("Student Details", 500);
            }
            else
            {

                while (lvShowText.Columns.Count > 1)
                {
                    lvShowText.Columns.RemoveAt(
                        lvShowText.Columns.Count - 1);
                }

                lvShowText.Columns[0].Text = "Student Details";
                lvShowText.Columns[0].Width = -2;
            }
        }
    }
}
