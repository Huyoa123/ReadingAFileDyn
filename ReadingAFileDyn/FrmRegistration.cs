
using CreatingTextFile;
using System;
using System.IO;
using System.Windows.Forms;

namespace LabStream
{
    public partial class FrmRegistration : Form
    {
        public FrmRegistration()
        {
            InitializeComponent();
        }


        private void btnRegister_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtStudentNo.Text) ||
                string.IsNullOrWhiteSpace(txtlastName.Text) ||
                string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(cbPrograms.Text) ||
                string.IsNullOrWhiteSpace(cbGender.Text) ||
                string.IsNullOrWhiteSpace(txtAge.Text) ||
                string.IsNullOrWhiteSpace(txtContactNo.Text))
            {
                MessageBox.Show(
                    "Please fill in all required fields before registering.",
                    "Incomplete Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }


            int age;

            if (!int.TryParse(txtAge.Text, out age) || age <= 0)
            {
                MessageBox.Show(
                    "Please enter a valid age.",
                    "Invalid Age",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtAge.Focus();
                return;
            }


            string studentNo = txtStudentNo.Text.Trim();

            foreach (char character in Path.GetInvalidFileNameChars())
            {
                if (studentNo.Contains(character.ToString()))
                {
                    MessageBox.Show(
                        "Student Number contains invalid characters.",
                        "Invalid Student Number",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtStudentNo.Focus();
                    return;
                }
            }


            string fileName = studentNo + ".txt";

            string docPath = Environment.GetFolderPath(
                Environment.SpecialFolder.MyDocuments);

            string fullPath = Path.Combine(docPath, fileName);


            string[] studentDetails = new string[]
            {
                "Student No.: " + studentNo,
                "Full Name: " + txtlastName.Text.Trim() + ", " +
                    txtFirstName.Text.Trim(),
                "Program: " + cbPrograms.Text,
                "Gender: " + cbGender.Text,
                "Age: " + age,
                "Birthday: " + dtpPicker.Value.ToString("yyyy-MM-dd"),
                "Contact No.: " + txtContactNo.Text.Trim()
            };


            try
            {
                using (StreamWriter writer = new StreamWriter(fullPath))
                {
                    foreach (string line in studentDetails)
                    {
                        writer.WriteLine(line);
                    }
                }

                MessageBox.Show(
                    "Registration details saved to " + fileName,
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error writing to file: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        private void btnStudentRecord_Click(object sender, EventArgs e)
        {
            FrmStudentRecord studentRecord = new FrmStudentRecord();
            studentRecord.Show();
            this.Hide();
        }


        private void FrmRegistration_Load(object sender, EventArgs e)
        {
        }
    }
}
