﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinaCore
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }

        private void Client_Load(object sender, EventArgs e)
        {
            LoginWindow.roundedBtn(btnLogout, 11);
            LoginWindow.roundedBtn(btn, 11);
            LoginWindow.roundedBtn(btn1, 11);
            LoginWindow.roundedBtn(btnAddClient, 11);
            LoginWindow.roundedBtn(btnInvoice, 11);
            LoginWindow.roundedBtn(btnSOA, 11);
            Dashboard.roundedPictureBox(pictureBoxLogo, 5);

        }
    }
}
