using DVLD.Global_Classes;
using DVLD.Properties;
using DVLD_Business;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace DVLD
{
    public partial class ctrlAddEditPerson : UserControl
    {
        public delegate void DataBackEventHandler(object sender, int PersonID);
        public event DataBackEventHandler DataBack;

        private static clsPerson _Person = new clsPerson();
        public string input = "";
        private int _PersonID = -1;
        public enum enMode
        {
            AddNew = 0,
            Update = 1
        };
        public enMode Mode = enMode.AddNew;
        public int PersonID
        {
            get { return _PersonID; }
        }
        public ctrlAddEditPerson()
        {
            InitializeComponent();
            cbCountry.SelectedIndex = cbCountry.FindString("Morocco");

        }

        public void ErrorProvider(TextBox TextBoxType, string Message, CancelEventArgs e)
        {
            e.Cancel = true;
            errorProvider1.SetError(TextBoxType, Message);
        }
        public void ErrorProviderToCancel(TextBox TextBoxType, CancelEventArgs e)
        {
            e.Cancel = false;
            errorProvider1.SetError(TextBoxType, "");
        }

        private void ValidateEmptyNumberTextBox(object sender, CancelEventArgs e)
        {
            // First: set AutoValidate property of your Form to EnableAllowFocusChange in designer 
            TextBox Temp = ((TextBox)sender);
            if (string.IsNullOrEmpty(Temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(Temp, "This field is required!");
                return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(Temp, null);
            }

            if (clsValidation.ValidateInteger(Temp.Text.Trim()))
            {
                e.Cancel = false;
                errorProvider1.SetError(Temp, null);

            }
            else
            {
                e.Cancel = true;
                errorProvider1.SetError(Temp, "You should enter a number");
            }
        }

        private void ValidateEmptyStringTextBox(object sender, CancelEventArgs e)
        {
            TextBox Temp = ((TextBox)sender);
            if (string.IsNullOrEmpty(Temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(Temp, "This field is required!");
                return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(Temp, null);
            }

            if (int.TryParse(Temp.Text.Trim(), out int Value))
            {
                e.Cancel = true;
                errorProvider1.SetError(Temp, "You should enter a string");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(Temp, null);
            }
        }

        private void ValidateStringTextBox(object sender, CancelEventArgs e)
        {
            // First: set AutoValidate property of your Form to EnableAllowFocusChange in designer 
            TextBox Temp = ((TextBox)sender);

            if (int.TryParse(Temp.Text.Trim(), out int Value))
            {
                e.Cancel = true;
                errorProvider1.SetError(Temp, "You should enter a string");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(Temp, null);
            }
        }

        private void ctrlAddEditPerson_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            //dateTimePicker1.MaxDate = now.AddYears(-18);
            dateTimePicker1.Value = now.AddYears(-18);
        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            input = txtNationalNo.Text.Trim();

            if (input != "" && !int.TryParse(input, out int result))
            {
                _Person = clsPerson.Find(input);
                if (_Person != null)
                {
                    errorProvider1.SetError(txtNationalNo, "Natioanl Number is used for another Person!");
                    e.Cancel = true;
                }
                else
                {
                    errorProvider1.SetError(txtNationalNo, "");
                    e.Cancel = false;
                }
            }
            else if (txtNationalNo.Text != "" && int.TryParse(input, out int result2))
            {
                errorProvider1.SetError(txtNationalNo, "Your National Number is wrong");
                e.Cancel = true;
            }
            else if (txtNationalNo.Text == "")
            {
                errorProvider1.SetError(txtNationalNo, "This Field is Required");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtNationalNo, "");
                e.Cancel = false;
            }
        }


        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            pbPersonImage.Image = Resources.User_Male2;
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            pbPersonImage.Image = Resources.Female_User2;

        }



        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            string Email = txtEmail.Text.Trim();
            if (!string.IsNullOrEmpty(Email) && !clsValidation.ValidateEmail(Email))
            {

                errorProvider1.SetError(txtEmail, "Invalid Email Address Format");
                e.Cancel = true;

            }
            else
            {

                errorProvider1.SetError(txtEmail, "");
                e.Cancel = false;

            }

        }

        public DataTable PeopleDataTable = new DataTable();
        public DataView PeopleDataView = new DataView();
        public void FillCbCountry()
        {
            PeopleDataView = clsCountry.GetAllCountries().DefaultView;

            cbCountry.Items.Clear();

            for (int i = 0; i < PeopleDataView.Count; i++)
            {
                cbCountry.Items.Add(PeopleDataView[i][0]);
            }
        }

        private void cbCountry_Click(object sender, EventArgs e)
        {
            FillCbCountry();
        }


        string SourceFileName = "", DestFilePath = "";
        private void SaveImage()
        {
            openFileDialog1.InitialDirectory = "C:\\Users\\PC\\Downloads";
            openFileDialog1.Title = "Open";
            openFileDialog1.DefaultExt = "img";
            openFileDialog1.Filter = "All Files(*.*)|*.* | Image Files(*.jpg; *.jpeg; *.png; *.bmp; *.gif)|*.jpg; *.jpeg; *.png; *.bmp; *.gif"; //Description|FilePattern|Description|FilePattern|...
            openFileDialog1.FilterIndex = 2;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                SourceFileName = openFileDialog1.FileName;
                DestFilePath = "C:\\DVLD_People_Images";

                pbPersonImage.Image = Image.FromFile(SourceFileName);
                llblRemove.Visible = true;

                // Copy this Image in DVLD_People_Images Folder 
                if (!Directory.Exists(DestFilePath))
                {
                    Directory.CreateDirectory(DestFilePath); // Create folder if it doesn't exist
                }


                string extension = Path.GetExtension(SourceFileName), NewFileName = Guid.NewGuid().ToString() + extension;


                // Combine the destination folder with the source file name (with GUID)
                string destinationFilePath = Path.Combine(DestFilePath, NewFileName);
                try
                {
                    File.Copy(SourceFileName, destinationFilePath, true); // 'true' to overwrite if it exists
                    MessageBox.Show("File copied successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error copying file: {SourceFileName}");
                }
            }
        }

        private void llblSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SaveImage();
        }

        private void _AddPerson(object sender)
        {
            clsPerson _Person = new clsPerson();
            _Person.FirstName = txtFirstName.Text;
            _Person.SecondName = txtSecondName.Text;
            _Person.ThirdName = txtThirdName.Text;
            _Person.LastName = txtLastName.Text;
            _Person.NationalNo = txtNationalNo.Text;
            _Person.DateOfBirth = dateTimePicker1.Value;
            if (rbMale.Checked)
            {
                _Person.Gendor = 0;
            }
            else
            {
                _Person.Gendor = 1;

            }
            _Person.Email = txtEmail.Text;
            _Person.Phone = txtPhone.Text;
            _Person.NationalityCountryID = clsCountry.Find(cbCountry.Text).CountryID;
            _Person.Address = txtAddress.Text;
            _Person.ImagePath = SourceFileName;

            if (_Person.Save())
            {
                _PersonID = _Person.PersonID;

                MessageBox.Show($"{_Person.PersonID} Added Successfully", "Adding Person", MessageBoxButtons.OK, MessageBoxIcon.Information);

                FrmAddEditPersonInfo frm = new FrmAddEditPersonInfo(_PersonID);
                DataBack?.Invoke(sender, _PersonID);

                //_ClearDataForAddPage();
                //RefreshDataClient();
            }
            else
            {
                MessageBox.Show($"Error  to Add {_Person.FirstName}  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void _UpdatePerson()
        {
            clsPerson _Person = clsPerson.Find(txtNationalNo.Text);
            _Person.FirstName = txtFirstName.Text;
            _Person.SecondName = txtSecondName.Text;
            _Person.ThirdName = txtThirdName.Text;
            _Person.LastName = txtLastName.Text;
            _Person.NationalNo = txtNationalNo.Text;
            _Person.DateOfBirth = dateTimePicker1.Value;
            if (rbMale.Checked)
            {
                _Person.Gendor = 0;
            }
            else
            {
                _Person.Gendor = 1;

            }
            _Person.Email = txtEmail.Text;
            _Person.Phone = txtPhone.Text;
            _Person.NationalityCountryID = clsCountry.Find(cbCountry.Text).CountryID;
            _Person.Address = txtAddress.Text;
            _Person.ImagePath = SourceFileName;
            //Mode = enMode.Update;
            clsPerson.Mode = clsPerson.enMode.Update;

            if (_Person.Save())
            {
                MessageBox.Show($"{_Person.PersonID} Updated Successfully", "Update Person", MessageBoxButtons.OK);
                _PersonID = _Person.PersonID;
            }
            else
            {
                MessageBox.Show($"Error  to Add {_Person.FirstName}  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (clsPerson.Mode == clsPerson.enMode.AddNew)
            {
                _AddPerson(sender);
            }
            else
            {
                _UpdatePerson();
            }
        }
        enum enMFindMode { BeforeFill, AfterFill };
        enMFindMode FindMode = enMFindMode.BeforeFill;
        public void CheckGender()
        {
            if (_Person.Gendor == 0)
            {
                rbMale.Checked = true;
                pbGendorImage.Image = Resources.employee_17986056;
            }
            else
            {
                rbFemale.Checked = true;
                pbGendorImage.Image = Resources.people_15676106;
            }
        }
        public void _FillBoxes(int PersonID)
        {
            _Person = clsPerson.Find(PersonID);

            if (_Person == null)
            {
                return;
            }
            if (FindMode == enMFindMode.BeforeFill)
            {
                txtFirstName.Text = _Person.FirstName;
                txtSecondName.Text = _Person.SecondName;
                txtThirdName.Text = _Person.ThirdName;
                txtLastName.Text = _Person.LastName;
                txtNationalNo.Text = _Person.NationalNo;
                dateTimePicker1.Value = _Person.DateOfBirth;
                CheckGender();
                txtEmail.Text = _Person.Email;
                txtPhone.Text = _Person.Phone;
                cbCountry.Text = "";
                cbCountry.Text = clsCountry.Find(_Person.NationalityCountryID).CountryName;
                txtAddress.Text = _Person.Address;
                if (_Person.ImagePath != "")
                {
                    pbPersonImage.Load(_Person.ImagePath);
                    llblRemove.Visible = true;

                }
                else
                {
                    CheckGender();
                }
                FindMode = enMFindMode.AfterFill;
            }
            else
            {
                _UpdatePerson();
            }


        }

        private void llblRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonImage.Image = null;

            if (rbMale.Checked)
            {
                pbPersonImage.Image = Resources.User_Male2;
            }
            else
            {
                pbPersonImage.Image = Resources.Female_User2;

            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            Form FrmAddEditPersonInfo = this.FindForm(); // It get the Current Form

            FrmAddEditUser frm = new FrmAddEditUser(_PersonID);

            DataBack?.Invoke(sender, _PersonID);

            if (FrmAddEditPersonInfo != null)
            {
                FrmAddEditPersonInfo.Close();
            }
        }

        public void UpdatePersonFromContext(int PersonID)
        {
            clsPerson.Mode = clsPerson.enMode.Update;
            _FillBoxes(PersonID);

        }
    }
}
