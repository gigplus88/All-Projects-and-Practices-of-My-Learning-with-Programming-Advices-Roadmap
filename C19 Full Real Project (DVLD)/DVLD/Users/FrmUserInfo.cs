using System;
using System.Windows.Forms;

namespace DVLD.Users
{
    public partial class FrmUserInfo : Form
    {
        private int _UserID;
        private string _UserName;
        public FrmUserInfo(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
        }
        public FrmUserInfo(string UseerName)
        {
            InitializeComponent();
            this._UserName = UseerName;
        }

        private void FrmUserInfo_Load(object sender, EventArgs e)
        {
            ctrlUserCard1.LoadUserInfo(_UserID);
        }
        public void LoadUserCard(string UserName)
        {
            ctrlUserCard1.LoadUserInfo(UserName);
        }

        private void btnCloseManagePeople_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
