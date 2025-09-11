using DVLD.Test;
using DVLD_Business;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD
{
    public partial class FrmListTestType : Form
    {
        private static DataTable _dtAllTestTypes;
        public FrmListTestType()
        {
            InitializeComponent();
        }
        private void _RenameColumns()
        {
            if (dgvTestTypes.Rows.Count > 0)
            {
                dgvTestTypes.Columns[0].HeaderText = "ID";
                dgvTestTypes.Columns[0].Width = 120;

                dgvTestTypes.Columns[1].HeaderText = "Title";
                dgvTestTypes.Columns[1].Width = 200;

                dgvTestTypes.Columns[2].HeaderText = "Descriptions";
                dgvTestTypes.Columns[2].Width = 400;

                dgvTestTypes.Columns[3].HeaderText = "Fees";
                dgvTestTypes.Columns[3].Width = 100;
            }
        }
        private void _RefreshData()
        {
            _dtAllTestTypes = clsTestType.GetAllTestTypes();

            dgvTestTypes.DataSource = _dtAllTestTypes;
            lblNumberOfTestTypes.Text = _dtAllTestTypes.Rows.Count.ToString();

            _RenameColumns();
        }
        private void FrmListTestType_Load(object sender, EventArgs e)
        {
            _RefreshData();
        }
        private void editTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUpateTestType frm = new FrmUpateTestType((clsTestType.enTestType)dgvTestTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            FrmListTestType_Load(null, null);
        }

        private void btnCloseManageTestTypesList_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
