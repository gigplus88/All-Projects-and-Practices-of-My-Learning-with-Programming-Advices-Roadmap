using DVLD_Business;
using System;
using System.Windows.Forms;

namespace DVLD.Controls
{
    public partial class ctrlUserCard : UserControl
    {
        private clsUser _User;
        private int _UserID = -1;
        private string _UseName = "";

        public int UserID
        {
            get { return _UserID; }
        }
        public ctrlUserCard()
        {
            InitializeComponent();
        }

        private void ctrlUserCard_Load(object sender, EventArgs e)
        {

        }

        public void LoadUserInfo(int UserID)
        {
            _UserID = UserID;
            _User = clsUser.Find(UserID);

            if (_User == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No User with UserID = " + UserID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillUserInfo();
        }
        // Old Solution
        public void LoadUserInfo(string UserName)
        {
            _User = clsUser.Find(UserName);

            if (_User != null)
            {
                FillUserCard();
            }

            else
            {
                MessageBox.Show("User not found");
            }
        }
        public void FillUserCard()
        {
            _UserID = _User.UserID;
            _UseName = _User.UserName;
            ctrlPersonCard1.LoadPersonInfo(_User.PersonID);
            lblUserID.Text = _User.UserID.ToString();
            lblUserName.Text = _User.UserName.ToString();
            if (_User.IsActive == true)
            {
                llblIsActive.Text = "Yes";
            }
            else
            {
                llblIsActive.Text = "No";
            }
        }
        //

        private void _FillUserInfo()
        {

            ctrlPersonCard1.LoadPersonInfo(_User.PersonID);
            lblUserID.Text = _User.UserID.ToString();
            lblUserName.Text = _User.UserName.ToString();

            if (_User.IsActive)
                llblIsActive.Text = "Yes";
            else
                llblIsActive.Text = "No";

        }

        public void ResetPersonInfo()
        {

            ctrlPersonCard1.ResetPersonInfo();
            lblUserID.Text = "[???]";
            lblUserName.Text = "[???]";
            llblIsActive.Text = "[???]";
        }
    }
}

