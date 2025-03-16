using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FinaCore
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            roundedPictureBox(pictureBoxLogo, 5);

            LoginWindow.roundedBtn(btnLogout, 11);
            LoginWindow.roundedBtn(btnSOA, 11);
            LoginWindow.roundedBtn(btnImportData, 11);
        }
        public static void roundedPictureBox(PictureBox pictureBox, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(0, 0, radius * 2, radius * 2, 180, 90);
            path.AddArc(pictureBox.Width - radius * 2, 0, radius * 2, radius * 2, 270, 90);
            path.AddArc(pictureBox.Width - radius * 2, pictureBox.Height - radius * 2, radius * 2, radius * 2, 0, 90);
            path.AddArc(0, pictureBox.Height - radius * 2, radius * 2, radius * 2, 90, 90);
            path.CloseFigure();

            pictureBox.Region = new Region(path);
        }
    }
}
