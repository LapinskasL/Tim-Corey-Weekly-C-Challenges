using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextFileChallenge
{
    public partial class ChallengeForm : Form
    {

        string fileName = "StandardDataSet.csv";

        BindingList<UserModel> users = new BindingList<UserModel>();

        public ChallengeForm()
        {
            InitializeComponent();

            WireUpDropDown();
        }

        private void WireUpDropDown()
        {
            if (File.Exists(fileName.FullFilePath()))
            {
                users = fileName.FullFilePath().GetFileData().ConvertToUserModels();
            }

            usersListBox.DataSource = users;
            usersListBox.DisplayMember = nameof(UserModel.DisplayText);
        }


        private void addUserButton_Click(object sender, EventArgs e)
        {
            UserModel user = new UserModel();

            user.FirstName = firstNameText.Text;
            user.LastName = lastNameText.Text;
            user.Age = Decimal.ToInt32(agePicker.Value);

            if (isAliveCheckbox.Checked)
            {
                user.IsAlive = true;
            }
            else
            {
                user.IsAlive = false;
            }

            users.Add(user);

            usersListBox.DataSource = users;
        }


        private void saveListButton_Click(object sender, EventArgs e)
        {
            users.SaveToUsersFile(fileName);
            MessageBox.Show("Data has been saved to " + fileName + " file.");
        }
    }
}
