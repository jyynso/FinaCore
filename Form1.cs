using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinaCore
{
    public partial class LoginWindow : Form
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            roundedBtn(loginBtn, 5);

            roundedPanel(panelUsername, 5);
            roundedPanel(panelPassword, 5);

            labelWelcome.BringToFront();



        }



        private void roundedBtn(Button button, int radius)
        {
            //from claude sonnet :D
            //method for rounded corners sa buttons
            //pwede remove kung ayaw nyo

            if (button.Height < radius * 2) radius = button.Height / 2;
            if (button.Width < radius * 2) radius = button.Width / 2;

            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(0, 0, radius * 2, radius * 2, 180, 90);
            path.AddLine(radius, 0, button.Width - radius, 0);
            path.AddArc(button.Width - radius * 2, 0, radius * 2, radius * 2, 270, 90);
            path.AddLine(button.Width, radius, button.Width, button.Height - radius);
            path.AddArc(button.Width - radius * 2, button.Height - radius * 2, radius * 2, radius * 2, 0, 90);
            path.AddLine(button.Width - radius, button.Height, radius, button.Height);
            path.AddArc(0, button.Height - radius * 2, radius * 2, radius * 2, 90, 90);
            path.CloseFigure();

            button.Region = new Region(path);

        }

        private void roundedPanel(Panel panel, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(0, 0, radius * 2, radius * 2, 180, 90);
            path.AddLine(radius, 0, panel.Width - radius, 0);
            path.AddArc(panel.Width - radius * 2, 0, radius * 2, radius * 2, 270, 90);
            path.AddLine(panel.Width, radius, panel.Width, panel.Height - radius);
            path.AddArc(panel.Width - radius * 2, panel.Height - radius * 2, radius * 2, radius * 2, 0, 90);
            path.AddLine(panel.Width - radius, panel.Height, radius, panel.Height);
            path.AddArc(0, panel.Height - radius * 2, radius * 2, radius * 2, 90, 90);
            path.CloseFigure();

            panel.Region = new Region(path);
        }

        
    }
}
