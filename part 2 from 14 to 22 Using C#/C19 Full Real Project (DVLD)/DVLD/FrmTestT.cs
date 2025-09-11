using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DVLD
{
    public partial class FrmTest : Form
    {

        public int PersonID
        {
            get { return _PersonID; }
        }

        private int _PersonID;
        public FrmTest(int PersonID)
        {
            InitializeComponent();
            this._PersonID = PersonID;
            //CheckedAddedPerson(_PersonID);
            //lblPersonID.Text = PersonID.ToString();

        }

        private void personCard1_Load(object sender, EventArgs e)
        {

        }
        public void validPersonID()
        {
            string input = txtPersonID.Text;

            while (true)
            {
                // Check if input is a valid numeric value
                if (Regex.IsMatch(input, @"^\d+$"))
                {
                    break;

                }
                else
                {

                }
            }
        }

        private void FrmTest_Load(object sender, EventArgs e)
        {

        }

        public void CheckedAddedPerson()
        {
            //if (ctrlAddEditPerson1.OperationMode == 0 )
            //{

            //testUserControl1.DataBack += testUserControl1_DataBack;
            //}

        }
        private void Form2_DataBack(object sender, int PersonID)
        {
            lblPersonID.Text = PersonID.ToString();
            txtPersonID.Text =  PersonID.ToString();
        }
        private void testUserControl1_Load(object sender, EventArgs e)
        {

        }

        private void testUserControl1_DataBack(object sender, int PersonID)
        {
            lblPersonID.Text = PersonID.ToString();

        }

        private void txtPersonID_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }

        private void txtPersonID_TextChanged(object sender, EventArgs e)
        {
            //validPersonID();

        }

        private void txtPersonID_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
