using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ULMSWinFormsApp.Models;

namespace ULMSWinFormsApp.Forms
{
    public partial class FrmMarksCapture : Form
    {
        public FrmMarksCapture()
        {
            InitializeComponent();
        }

        private void btnCalculateResults_Click(object sender, EventArgs e)
        {
           
            // VALIDATION
            if (string.IsNullOrWhiteSpace(txtMarkStudentId.Text) ||
                string.IsNullOrWhiteSpace(txtMarkStudentName.Text) ||
                string.IsNullOrWhiteSpace(txtSubject1.Text) ||
                string.IsNullOrWhiteSpace(txtSubject2.Text) ||
                string.IsNullOrWhiteSpace(txtSubject3.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            
            // SAFE CONVERSION
            double s1, s2, s3;

            if (!double.TryParse(txtSubject1.Text, out s1) ||
                !double.TryParse(txtSubject2.Text, out s2) ||
                !double.TryParse(txtSubject3.Text, out s3))
            {
                MessageBox.Show("Please enter valid numeric marks.");
                return;
            }

            
            // CREATE RECORD
            MarkRecord record = new MarkRecord();

            record.StudentId = txtMarkStudentId.Text;
            record.StudentName = txtMarkStudentName.Text;
            record.Subject1 = s1;
            record.Subject2 = s2;
            record.Subject3 = s3;

            
            // CORRECT AVERAGE CALCULATION
            record.Average = (record.Subject1 + record.Subject2 + record.Subject3) / 3;

            // RESULT LOGIC
            record.ResultStatus = record.Average >= 50 ? "PASS" : "FAIL";

            
            // OUTPUT
            txtMarksOutput.Text =
                "Marks processed successfully!" + Environment.NewLine +
                "------------------------" + Environment.NewLine +
                "Student ID: " + record.StudentId + Environment.NewLine +
                "Student Name: " + record.StudentName + Environment.NewLine +
                "Subject 1: " + record.Subject1 + Environment.NewLine +
                "Subject 2: " + record.Subject2 + Environment.NewLine +
                "Subject 3: " + record.Subject3 + Environment.NewLine +
                "Average: " + record.Average + Environment.NewLine +
                "Final Result: " + record.ResultStatus;
        }

        private void btnClearMarks_Click(object sender, EventArgs e)
        {
            txtMarkStudentId.Clear();
            txtMarkStudentName.Clear();
            txtSubject1.Clear();
            txtSubject2.Clear();
            txtSubject3.Clear();
            txtMarksOutput.Clear();
            txtMarkStudentId.Focus();
        }

        private void btnBackMarks_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMarksOutput_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmMarksCapture_Load(object sender, EventArgs e)
        {

        }
    }
}
