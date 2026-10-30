
using System;
using System.Windows.Forms;
using CreatingTextFile;

namespace LabStream
{
    public partial class FrmMainMenu : Form
    {
        public FrmMainMenu()
        {
            InitializeComponent();
        }

        private void btnSimple_Click(object sender, EventArgs e)
        {
            FrmLab1 frmLab1 = new FrmLab1();
            frmLab1.Show();
        }

        private void btnChallenge_Click(object sender, EventArgs e)
        {
            FrmRegistration frmRegistration = new FrmRegistration();
            frmRegistration.Show();
        }

        private void btnFileViewer_Click(object sender, EventArgs e)
        {
            FrmOpenTextFile fileViewer = new FrmOpenTextFile();
            fileViewer.Show();
        }

        private void FrmMainMenu_Load(object sender, EventArgs e)
        {
        }

        private void FrmMainMenu_Load_1(object sender, EventArgs e)
        {
        }

        private void btnSimple_Click_1(object sender, EventArgs e)
        {
        }
    }
}
