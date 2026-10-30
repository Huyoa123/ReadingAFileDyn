
using System;
using System.IO;
using System.Windows.Forms;

namespace LabStream
{
    public partial class FrmFileName : Form
    {
        public static string SetFileName = string.Empty;

        public FrmFileName()
        {
            InitializeComponent();
        }

        private void btnOkay_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = txtFileName.Text.Trim();

                if (string.IsNullOrWhiteSpace(fileName))
                {
                    MessageBox.Show(
                        "Please enter a file name.",
                        "Input Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    txtFileName.Focus();
                    return;
                }

                // Check for invalid characters in the file name.
                if (fileName.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
                {
                    MessageBox.Show(
                        "The file name contains invalid characters.",
                        "Invalid File Name",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    txtFileName.Focus();
                    return;
                }

                // Add .txt extension if it is not already present.
                string proposedFileName = fileName.EndsWith(
                    ".txt",
                    StringComparison.OrdinalIgnoreCase
                ) ? fileName : fileName + ".txt";

                string docPath = Environment.GetFolderPath(
                    Environment.SpecialFolder.MyDocuments
                );

                string fullPath = Path.Combine(docPath, proposedFileName);

                if (File.Exists(fullPath))
                {
                    MessageBox.Show(
                        "A file with this name already exists. Please choose another name.",
                        "File Already Exists",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    txtFileName.Focus();
                    txtFileName.SelectAll();
                    return;
                }

                SetFileName = proposedFileName;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Input Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void FrmFileName_Load(object sender, EventArgs e)
        {
            txtFileName.Focus();
        }

        private void txtFileName_TextChanged(object sender, EventArgs e)
        {
            // Runs when the file name changes.
        }
    }
}
