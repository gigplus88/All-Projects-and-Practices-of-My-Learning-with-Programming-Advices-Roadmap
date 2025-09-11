using System;
using System.Windows.Forms;

namespace DVLD.License
{
    public partial class frmShowInternationalLicenseInfo : Form
    {
        private int _InternationalLicenseID;
        public frmShowInternationalLicenseInfo(int InternationalLicenseID)
        {
            InitializeComponent();
            this._InternationalLicenseID = InternationalLicenseID;
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmInternationalDriverInfo_Load(object sender, EventArgs e)
        {
            ctrlDriverInternationalLicenseInfo1.LoadInfo(_InternationalLicenseID);
        }
    }
}
