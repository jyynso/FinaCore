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
    public partial class Transactions : Form
    {
        public Transactions()
        {
            InitializeComponent();
        }

        private void Transactions_Load(object sender, EventArgs e)
        {
            Dashboard.roundedPictureBox(pictureBoxLogo, 5);
            LoginWindow.roundedBtn(btnLogout, 11);
        }
    }
}
