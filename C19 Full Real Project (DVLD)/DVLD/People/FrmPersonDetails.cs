using System;
using System.Windows.Forms;

namespace DVLD
{
    public partial class FrmPersonDetails : Form
    {
        private int _PersonID;
        private string NationalNo;
        public FrmPersonDetails()
        {
            InitializeComponent();
        }
        public FrmPersonDetails(int PersonID)
        {
            InitializeComponent();
            this._PersonID = PersonID;
            ctrlPersonCard1.LoadPersonInfo(PersonID);
        }
        public FrmPersonDetails(string NationalNo)
        {
            InitializeComponent();
            this.NationalNo = NationalNo;
            ctrlPersonCard1.LoadPersonInfo(NationalNo);
        }

        private void FrmPersonDetails_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
