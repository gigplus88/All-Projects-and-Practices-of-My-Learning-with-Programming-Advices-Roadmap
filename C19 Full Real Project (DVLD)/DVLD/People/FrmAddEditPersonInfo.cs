using DVLD_Business;
using System.Windows.Forms;


namespace DVLD
{
    public partial class FrmAddEditPersonInfo : Form
    {
        static private int _PersonID;
        private clsPerson _Person;
        public string input = "";


        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        public enum enGendor { Male = 0, Female = 1 };


        public delegate void DataBackEventHandler(object sender, int PersonID);
        public event DataBackEventHandler DataBack;

        public FrmAddEditPersonInfo()
        {
            InitializeComponent();


        }
        public FrmAddEditPersonInfo(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
            _Mode = enMode.Update;

        }

        private void ctrlAddEditPerson1_DataBack(object sender, int PersonID)
        {
            _PersonID = PersonID;
            lblPersonID.Text = _PersonID.ToString();
        }

        //public void ErrorProvider(TextBox TextBoxType, string Message, CancelEventArgs e)
        //{
        //    e.Cancel = true;
        //    errorProvider1.SetError(TextBoxType, Message);
        //}
        //public void ErrorProviderToCancel(TextBox TextBoxType, CancelEventArgs e)
        //{
        //    e.Cancel = false;
        //    errorProvider1.SetError(TextBoxType, "");
        //}

        //private void txtEmail_Validating(object sender, CancelEventArgs e)
        //{
        //    string Email = txtEmail.Text.Trim();
        //    if (!string.IsNullOrEmpty(Email))
        //    {
        //        if (!clsValidation.ValidateEmail(Email))
        //        {
        //            ErrorProvider(txtEmail, "Invalid Email Address Format", e);
        //            return;
        //        }
        //        else
        //        {
        //            ErrorProviderToCancel(txtEmail, e);
        //        }
        //    }
        //    else
        //    {
        //        return;
        //    }

        //}
        //private void ValidateStringTextBox(object sender, CancelEventArgs e)
        //{
        //    // First: set AutoValidate property of your Form to EnableAllowFocusChange in designer 
        //    TextBox Temp = ((TextBox)sender);

        //    if (int.TryParse(Temp.Text.Trim(), out int Value))
        //    {
        //        e.Cancel = true;
        //        errorProvider1.SetError(Temp, "You should enter a string");
        //    }
        //    else
        //    {
        //        e.Cancel = false;
        //        errorProvider1.SetError(Temp, null);
        //    }
        //}
        //private void ValidateEmptyNumberTextBox(object sender, CancelEventArgs e)
        //{
        //    // First: set AutoValidate property of your Form to EnableAllowFocusChange in designer 
        //    TextBox Temp = ((TextBox)sender);
        //    if (string.IsNullOrEmpty(Temp.Text.Trim()))
        //    {
        //        e.Cancel = true;
        //        errorProvider1.SetError(Temp, "This field is required!");
        //    }
        //    else
        //    {
        //        //e.Cancel = false;
        //        errorProvider1.SetError(Temp, null);
        //    }

        //    if (int.TryParse(Temp.Text.Trim(), out int Value))
        //    {
        //        e.Cancel = false;
        //        errorProvider1.SetError(Temp, null);

        //    }
        //    else
        //    {
        //        e.Cancel = true;
        //        errorProvider1.SetError(Temp, "You should enter a Number");
        //    }
        //}
        //private void ValidateEmptyStringTextBox(object sender, CancelEventArgs e)
        //{
        //    // First: set AutoValidate property of your Form to EnableAllowFocusChange in designer 
        //    TextBox Temp = ((TextBox)sender);
        //    if (string.IsNullOrEmpty(Temp.Text.Trim()))
        //    {
        //        e.Cancel = true;
        //        errorProvider1.SetError(Temp, "This field is required!");
        //        return;
        //    }
        //    else
        //    {
        //        e.Cancel = false;
        //        errorProvider1.SetError(Temp, null);
        //    }

        //    if (int.TryParse(Temp.Text.Trim() , out int Value))
        //    {
        //        e.Cancel = true;
        //        errorProvider1.SetError(Temp, "You should enter a string");
        //    }
        //    else
        //    {
        //        e.Cancel = false;
        //        errorProvider1.SetError(Temp, null);
        //    }
        //}
        //private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        //{
        //    input = txtNationalNo.Text.Trim();

        //    if (input != "" && !int.TryParse(input, out int Result))
        //    {
        //        _Person = clsPerson.Find(input);
        //        if (_Person != null)
        //        {
        //            ErrorProvider(txtNationalNo, "Natioanl Number is used for another Person!", e);

        //        }
        //        else
        //        {
        //            ErrorProviderToCancel(txtNationalNo, e);
        //        }
        //    }
        //    else if (txtNationalNo.Text != "" && int.TryParse(input, out int Result1))
        //    {
        //        ErrorProvider(txtNationalNo, "You should enter a words", e);
        //    }
        //    else
        //    {
        //        ErrorProvider(txtNationalNo, "Required", e);

        //    }
        //}

        //private void _FillCountriesInComoboBox()
        //{
        //    DataTable CountriesDt = clsCountry.GetAllCountries();

        //    foreach (DataRow row in CountriesDt.Rows)
        //    {
        //        cbCountry.Items.Add(row["CountryName"]);
        //    }
        //}
        //private void _ResetDefaultValues()
        //{
        //    //this will initialize the reset the defaule values
        //    _FillCountriesInComoboBox();

        //    if (_Mode == enMode.AddNew)
        //    {
        //        _Person = new clsPerson();
        //        lblTitle.Text = "Add New Person";
        //    }

        //    if (rbMale.Checked)
        //        pbGendorImage.Image = Resources.User_Male2;
        //    else
        //        pbGendorImage.Image = Resources.Female_User2;

        //    DateTime dt = DateTime.Now;

        //    dateTimePicker1.MaxDate = dt.AddYears(-18);

        //    dateTimePicker1.Value = dateTimePicker1.MaxDate;

        //    dateTimePicker1.MinDate = dt.AddYears(-100);

        //    llblRemove.Visible = (pbPersonImage.ImageLocation != null);

        //    cbCountry.SelectedIndex = cbCountry.FindString("Morocco");

        //    txtFirstName.Text = "";
        //    txtSecondName.Text = "";
        //    txtThirdName.Text = "";
        //    txtLastName.Text = "";
        //    txtNationalNo.Text = "";
        //    rbMale.Checked = true;
        //    txtPhone.Text = "";
        //    txtEmail.Text = "";
        //    txtAddress.Text = "";


        //}
        //public void CheckGender()
        //{
        //    if (_Person.Gendor == 0)
        //    {
        //        rbMale.Checked = true;
        //        pbGendorImage.Image = Resources.employee_17986056;
        //    }
        //    else
        //    {
        //        rbFemale.Checked = true;
        //        pbGendorImage.Image = Resources.people_15676106;
        //    }
        //}
        //void _LoadData()
        //{
        //    _Person = clsPerson.Find(_PersonID);

        //    if (_Person == null)
        //    {
        //        MessageBox.Show("No Person with ID = " + _PersonID, "Person Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //        this.Close();
        //        return;
        //    }


        //    txtFirstName.Text = _Person.FirstName;
        //    txtSecondName.Text = _Person.SecondName;
        //    txtThirdName.Text = _Person.ThirdName;
        //    txtLastName.Text = _Person.LastName;
        //    txtNationalNo.Text = _Person.NationalNo;
        //    txtPhone.Text = _Person.Phone;
        //    txtEmail.Text = _Person.Email;
        //    txtAddress.Text = _Person.Address;

        //    if (_Person.ImagePath != "")
        //    {
        //        pbPersonImage.Load(_Person.ImagePath);

        //    }
        //    else
        //    {
        //        CheckGender();
        //    }

        //    cbCountry.SelectedIndex = cbCountry.FindString(_Person.CountryInfo.CountryName);
        //    llblRemove.Visible = (_Person.ImagePath != "");
        //}
        //private void AddEditPersonInfo_Load(object sender, EventArgs e)
        //{
        //   _ResetDefaultValues();

        //    if (_Mode==enMode.Update)
        //        _LoadData();
        //}


        //private void ctrlAddEditPerson1_DataBack(object sender, int PersonID)
        //{
        //    lblPersonID.Text = _PersonID.ToString();
        //    DataBack?.Invoke(this, _PersonID);
        //}
        //public void UpdatePerson(int PersonID)
        //{
        //    lblTitle.Text =  "Update Person";
        //    lblPersonID.Text = PersonID.ToString();
        //    //ctrlAddEditPerson1.UpdatePersonFromContext(PersonID);
        //}
        //public void DeletePerson(int PersonID)
        //{
        //    clsPerson.DeletePerson(PersonID);
        //}

        //private void btnCancel_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //}
        //private bool _HandlePersonImage()
        //{

        //    //_Person.ImagePath contains the old Image, we check if it changed then we copy the new image
        //    if (_Person.ImagePath != pbPersonImage.ImageLocation)
        //    {
        //        if (_Person.ImagePath != "")
        //        {
        //            //first we delete the old image from the folder in case there is any.

        //            try
        //            {
        //                File.Delete(_Person.ImagePath);
        //            }
        //            catch (IOException)
        //            {
        //                // We could not delete the file.
        //                //log it later   
        //            }
        //        }

        //        if (pbPersonImage.ImageLocation != null)
        //        {
        //            //then we copy the new image to the image folder after we rename it
        //            string SourceImageFile = pbPersonImage.ImageLocation.ToString();

        //            if (clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
        //            {
        //                pbPersonImage.ImageLocation = SourceImageFile;
        //                return true;
        //            }
        //            else
        //            {
        //                MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                return false;
        //            }
        //        }

        //    }
        //    return true;
        //}
        //private void btnSave_Click(object sender, EventArgs e)
        //{
        //    //if (!this.ValidateChildren())
        //    //{
        //    //    //Here we dont continue becuase the form is not valid
        //    //    MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the error", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    //    return;
        //    //}
        //    if (_Person == null)
        //        _Person = new clsPerson();

        //    if (!_HandlePersonImage())
        //        return;


        //    _Person.FirstName = txtFirstName.Text;
        //    _Person.SecondName = txtSecondName.Text;
        //    _Person.ThirdName = txtThirdName.Text;
        //    _Person.LastName = txtLastName.Text;
        //    _Person.NationalNo = txtNationalNo.Text;
        //    _Person.DateOfBirth = dateTimePicker1.Value;
        //    if (rbMale.Checked)
        //    {
        //        _Person.Gendor = (short)enGendor.Male;
        //    }
        //    else
        //    {
        //        _Person.Gendor = (short)enGendor.Female;

        //    }
        //    _Person.Email = txtEmail.Text;
        //    _Person.Phone = txtPhone.Text;
        //    _Person.NationalityCountryID = clsCountry.Find(cbCountry.Text).CountryID  ; 
        //    _Person.Address = txtAddress.Text;

        //    if (pbPersonImage.ImageLocation != null)
        //        _Person.ImagePath = pbPersonImage.ImageLocation;
        //    else
        //        _Person.ImagePath = "";

        //    if (_Person.Save())
        //    {
        //        lblPersonID.Text = _Person.PersonID.ToString();
        //        //change form mode to update.
        //        _Mode = enMode.Update;
        //        lblTitle.Text = "Update Person";

        //        MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);


        //        // Trigger the event to send data back to the caller form.
        //        DataBack?.Invoke(this, _Person.PersonID);
        //    }
        //    else
        //        MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //}

        //private void rbMale_Click(object sender, EventArgs e)
        //{
        //    if (pbPersonImage.ImageLocation == null)
        //        pbPersonImage.Image  = Resources.User_Male2;
        //}

        //private void rbFemale_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (pbPersonImage.ImageLocation == null)
        //        pbPersonImage.Image  = Resources.Female_User2;
        //}

        //private void llblRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    pbPersonImage.Image = null;

        //    if (rbMale.Checked)
        //    {
        //        pbPersonImage.Image  = Resources.User_Male2;
        //    }
        //    else
        //    {
        //        pbPersonImage.Image  = Resources.Female_User2;

        //    }
        //    llblRemove.Visible =false;
        //}

        //private void llblSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    if (openFileDialog1.ShowDialog() == DialogResult.OK)
        //    {
        //        openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
        //        openFileDialog1.DefaultExt = "img";
        //        openFileDialog1.Title = "Open";
        //        openFileDialog1.FilterIndex = 1;
        //        openFileDialog1.RestoreDirectory = true;

        //        string selectedFilePath = openFileDialog1.FileName;
        //        pbPersonImage.Load(selectedFilePath);
        //        llblRemove.Visible = true;
        //    }

        //}

        //private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
        //    {
        //        e.Handled = true;
        //    }
        //}
    }
}
