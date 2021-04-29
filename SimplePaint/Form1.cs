using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Design;

namespace SimplePaint
{
    public partial class Form1 : Form
    {
        Graphics graphics;
        int x = -1;
        int y = -1;

        int shapex, shapey, shapeh, shapew;
        bool isUsingPen;

        // bools
        bool isSquare;
        bool isCircle;

        bool moving = false;
        Pen pen;

        public Form1()
        {
            InitializeComponent();
            graphics = objectPanel.CreateGraphics();
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pen = new Pen(Color.Black, 5);
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void objectPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isUsingPen == true)
            {
                if (moving && x != -1 && y != -1)
                {
                    graphics.DrawLine(pen, new Point(x, y), e.Location);
                    x = e.X;
                    y = e.Y;
                }
            }
        }

        private void objectPanel_MouseDown(object sender, MouseEventArgs e)
        {
                moving = true;
                x = e.X;
                y = e.Y;
            shapey = e.Y
            ; shapex = e.X;
        }

        private void objectPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if(isUsingPen == true)
            {
                moving = false;
                x = -1;
                y = -1;
            }
            if(isUsingPen == false)
            {
                shapeh = e.X - x;
                shapew = e.Y - y;
                Rectangle shape = new Rectangle(shapex, shapey, shapeh, shapew);
                if(isSquare == true)
                {
                    graphics.DrawRectangle(pen, shape);
                }
                if(isCircle == true)
                {
                    graphics.DrawEllipse(pen, shape);
                }
            }
        }

        private void colors_click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            pen.Color = p.BackColor;
            pictureBox13.BackColor = p.BackColor;
        }

        private void thickness_meter_changed(object sender, EventArgs e)
        {
            thikness.Text = "[" + gunaMetroTrackBar1.Value + "]";
            pen = new Pen(pictureBox13.BackColor, gunaMetroTrackBar1.Value);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            thikness.Text = "[" + gunaMetroTrackBar1.Value + "]";
        }

        private void MEANWHILE_Tick(object sender, EventArgs e)
        {
            pictureBox14.BackColor = Color.FromArgb(rgb_track_Red.Value, rgb_track_Green.Value, rg_trackblue.Value);
            trackbar_num_red.Text = rgb_track_Red.Value.ToString();
            trackbar_num_green.Text = rgb_track_Green.Value.ToString();
            trackbar_num_blue.Text = rg_trackblue.Value.ToString();
        }

        private void gunaButton4_Click(object sender, EventArgs e)
        {
            rgbpanel.Visible = false;
            pictureBox13.BackColor = pictureBox14.BackColor;
            pictureBox13.BackColor = pictureBox14.BackColor;
            pen = new Pen(pictureBox13.BackColor, gunaMetroTrackBar1.Value);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            MEANWHILE.Stop();
        }

        private void gunaImageButton1_Click(object sender, EventArgs e)
        {
            rgbpanel.Visible = true;
            MEANWHILE.Start();
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            pictureBox15.BackColor = pictureBox13.BackColor;
            fpanel.Visible = true;
            cpanel.Visible = false;
            isUsingPen = false;
        }

        private void gunaImageButton2_Click(object sender, EventArgs e)
        {

            rgbpanel.Visible = true;
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {

            rgbpanel.Visible = true;
        }

        private void gunaButton6_Click(object sender, EventArgs e)
        {
            isSquare = false;
            isCircle = true;
        }

        private void gunaButton7_Click(object sender, EventArgs e)
        {
            isCircle = false;   
            isSquare = true;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S)
            {
                MessageBox.Show("My message");
            }
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            rgbpanel.Visible = true;
            MEANWHILE.Start();
        }

        private void gunaButton5_Click(object sender, EventArgs e)
        {
            rgbpanel.Visible = false;
            MEANWHILE.Stop();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            fpanel.Visible = false;
            cpanel.Visible = true;
            isUsingPen = true;
        }
    }
}
