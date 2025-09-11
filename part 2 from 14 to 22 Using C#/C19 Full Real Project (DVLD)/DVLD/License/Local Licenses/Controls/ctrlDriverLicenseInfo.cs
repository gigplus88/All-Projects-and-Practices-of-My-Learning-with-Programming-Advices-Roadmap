using DVLD.Global_Classes;
using DVLD.Properties;
using DVLD_Business;
using System.IO;
using System.Windows.Forms;



namespace DVLD.Controls
{
    public partial class ctrlDriverLicenseInfo : UserControl
    {
        private int _LicenseID;
        private clsLicense _License;
        public int LicenseID
        {
            get { return _LicenseID; }
        }

        public clsLicense SelectedLicenseInfo
        {
            get { return _License; }
        }

        public ctrlDriverLicenseInfo()
        {
            InitializeComponent();
        }

        public void ResetDefaultValue()
        {

            lblLicenseID.Text = " [?????]";
            lblIsActive.Text = " [?????]";
            lblIsDetained.Text = " [?????]";
            lblClass.Text = " [?????]";
            lblName.Text = " [?????]";
            lblNationalNo.Text = " [?????]";
            lblGendor.Text = " [?????]";
            lblDateOfBirth.Text = " [?????]";

            lblDriverID.Text = " [?????]";
            lblIssueDate.Text = " [?????]";
            lblExpirationDate.Text = " [?????]";
            lblIssueRaison.Text = " [?????]";
            lblNotes.Text = " [?????]";
            pbPersonImage.Image = Resources.Male_512;
        }
        private void _LoadPersonImage()
        {
            if (_License.DriverInfo.PersonInfo.Gendor == 0)
                pbPersonImage.Image = Resources.Male_512;
            else
                pbPersonImage.Image = Resources.Female_512;

            string ImagePath = _License.DriverInfo.PersonInfo.ImagePath;

            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    pbPersonImage.Load(ImagePath);
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        public void LoadInfo(int LicenseID)
        {
            _LicenseID = LicenseID;
            _License = clsLicense.Find(_LicenseID);
            if (_License == null)
            {
                MessageBox.Show("Could not find License ID = " + _LicenseID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _LicenseID = -1;
                return;
            }

            lblLicenseID.Text = _License.LicenseID.ToString();
            lblIsActive.Text = _License.IsActive ? "Yes" : "No";
            lblIsDetained.Text = _License.IsDetained ? "Yes" : "No";
            lblClass.Text = _License.LicenseClassInfo.ClassName;
            lblName.Text = _License.DriverInfo.PersonInfo.FullName;
            lblNationalNo.Text = _License.DriverInfo.PersonInfo.NationalNo;
            lblGendor.Text = _License.DriverInfo.PersonInfo.Gendor == 0 ? "Male" : "Female";
            lblDateOfBirth.Text = clsFormat.DateToShort(_License.DriverInfo.PersonInfo.DateOfBirth);

            lblDriverID.Text = _License.DriverID.ToString();
            lblIssueDate.Text = clsFormat.DateToShort(_License.IssueDate);
            lblExpirationDate.Text = clsFormat.DateToShort(_License.ExpirationDate);
            lblIssueRaison.Text = _License.IssueReasonText;
            lblNotes.Text = _License.Notes == "" ? "No Notes" : _License.Notes;
            _LoadPersonImage();
        }




    }
}
