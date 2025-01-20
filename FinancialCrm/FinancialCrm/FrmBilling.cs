﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinancialCrm.Models;

namespace FinancialCrm
{
    public partial class FrmBilling : Form
    {
        public FrmBilling()
        {
            InitializeComponent();
        }
        FinansialCrmDbEntities db = new FinansialCrmDbEntities();
        private void FormBilling_Load(object sender, EventArgs e)
        {
            var values = db.Bills.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnBillList_Click(object sender, EventArgs e)
        {
            var values = db.Bills.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnCreateBill_Click(object sender, EventArgs e)
        {
            string title= txtBillTitle.Text;
            decimal amount = decimal.Parse(txtBillAmount.Text);
            string period = txtBillPeriod.Text;

            Bills bills = new Bills();
            bills.BillTitle = title;
            bills.BillAmount = amount;
            bills.BillPeriod = period;
            db.Bills.Add(bills);
            db.SaveChanges();
            MessageBox.Show("Ödeme Başarılı Bir Şekilde Sisteme Eklendi", "Ödeme & Faturalar",MessageBoxButtons.OK,MessageBoxIcon.Information);
            var values = db.Bills.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnRemoveBill_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtBillId.Text);
            var removeValue=db.Bills.Find(id);
            db.Bills.Remove(removeValue);
            db.SaveChanges();
            MessageBox.Show("Ödeme Başarılı Bir Şekilde Sisteme Silindi", "Ödeme & Faturalar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            var values = db.Bills.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnUpdateBill_Click(object sender, EventArgs e)
        {
            string title = txtBillTitle.Text;
            decimal amount = decimal.Parse(txtBillAmount.Text);
            string period = txtBillPeriod.Text;
            int id = int.Parse(txtBillId.Text);

            var values=db.Bills.Find(id);

            values.BillTitle = title;
            values.BillAmount = amount;
            values.BillPeriod = period;
            
            db.SaveChanges();
            MessageBox.Show("Ödeme Başarılı Bir Şekilde Sisteme Güncellendi", "Ödeme & Faturalar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            var values2 = db.Bills.ToList();
            dataGridView1.DataSource = values2;
        }

        private void btnBanksForm_Click(object sender, EventArgs e)
        {
            FrmBanks frm = new FrmBanks();
            frm.Show();
            this.Hide();
        }

        private void btnCategorie_Click(object sender, EventArgs e)
        {
            FrmCategorie frmCategorie = new FrmCategorie();
            frmCategorie.Show();
            this.Hide();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            FrmDashboard frmDashboard = new FrmDashboard();
            frmDashboard.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Çıkmak istediğinizden emin misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit(); // Uygulamayı kapat
            }
        }
    }
}
