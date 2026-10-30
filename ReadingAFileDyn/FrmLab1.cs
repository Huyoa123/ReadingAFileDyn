using LabStream;
using ReadingAFileDyn;
using System;
using System.IO;
using System.Windows.Forms;

namespace LabStream
{
    public partial class FrmLab1 : Form
    {
        public FrmLab1()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            FrmFileName frmFileName = new FrmFileName();

            if (frmFileName.ShowDialog() == DialogResult.OK)
            {
                string getInput = txtInput.Text;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, FrmFileName.SetFileName)))
                {
                    outputFile.WriteLine(getInput);
                }

                MessageBox.Show("File created successfully in My Documents.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FrmLab1_Load(object sender, EventArgs e)
        {

        }
    }
}