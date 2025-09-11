using DVLD_Business;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD.Applications
{
    public partial class FrmManageApplicationTypes : Form
    {
        private static DataTable _dtAllApplicationTypes;
        public FrmManageApplicationTypes()
        {
            InitializeComponent();
        }

        private void FrmManageApplicationType_Load(object sender, EventArgs e)
        {
            _RefreshData();
        }
        private void _RenameColumns()
        {
            if (dgvApplicationTypes.Rows.Count > 0)
            {
                dgvApplicationTypes.Columns[0].HeaderText = "ID";
                dgvApplicationTypes.Columns[0].Width = 110;

                dgvApplicationTypes.Columns[1].HeaderText = "Title";
                dgvApplicationTypes.Columns[1].Width = 400;

                dgvApplicationTypes.Columns[2].HeaderText = "Fees";
                dgvApplicationTypes.Columns[2].Width = 100;
            }
        }
        private void _RefreshData()
        {
            _dtAllApplicationTypes = clsApplicationType.GetAllApplicationTypes();

            dgvApplicationTypes.DataSource = _dtAllApplicationTypes;
            lblNumberOfApplicationTypes.Text = dgvApplicationTypes.Rows.Count.ToString();
            _RenameColumns();
        }

        private void btnCloseManagePeople_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUpdateApplicationType frm = new FrmUpdateApplicationType((int)dgvApplicationTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            FrmManageApplicationType_Load(null, null);
        }

    }
}
