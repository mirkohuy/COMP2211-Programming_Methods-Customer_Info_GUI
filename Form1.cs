// COMP 2211_SW1 - Programming Methods (Winter 2019 Sharma)
// Assignment 5 Question 4
// Huy Mirko T007005586 Jan 2023

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace assn5q4._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            // variable to track if the fields are valid and complete
            Boolean fieldsOK = true;

            // create instance if Customer class
            Customer newCustomer= new Customer();

            // process name data
            if(nameField.Text == null)
            {
                fieldsOK = false;
            }
            else if(nameField.Text.Any(char.IsDigit))
            {
                fieldsOK = false;
            }
            else
            {
                newCustomer.name = nameField.Text;
            }

            // process address data
            if(addressField.Text == null)
            {
                fieldsOK = false;
            }
            else
            {
                newCustomer.address = addressField.Text;
            }

            // process phone data
            if(phoneField.Text == null)
            {
                fieldsOK = false;
            }
            else
            {
                newCustomer.phone = phoneField.Text;
            }

            // process ID info
            if(idField.Text == null)
            {
                fieldsOK = false;
            }
            else if(!(Regex.IsMatch(idField.Text, @"^\d+$")))
            {
                fieldsOK = false;
            }
            else
            {
                newCustomer.id = int.Parse(idField.Text);
            }
            
            // process mailing list selection
            if(listMenu.SelectedItem.ToString() == "Yes")
            {
                newCustomer.mailingList = true;
            }
            else
            {
                newCustomer.mailingList = false;
            }

            // check if fields are OK and if so, update info
            if(fieldsOK == true)
            {
                update(newCustomer);
            }
            else
            {
                MessageBox.Show("There was a problem with the data provided. Please check and try again.", "Error");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // method to update customer object variables
        void update(Customer customer)
        {
            nameLabel.Text = customer.name;
            addressLabel.Text = customer.address;
            phoneLabel.Text = customer.phone;
            idLabel.Text = customer.id.ToString();

            if (customer.mailingList == true)
            {
                listLabel.Text = "Customer is on the mailing list";
            }
            else
            {
                listLabel.Text = "Customer is not on the mailing list";
            }
        }
    }

    // person class
    public class Person
    {
        public String name;
        public String address;
        public String phone;
    }

    // customer class, extends person
    public class Customer : Person
    {
        public int id;
        public Boolean mailingList;
    }
}
