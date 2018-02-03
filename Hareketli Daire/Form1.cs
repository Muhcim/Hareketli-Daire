using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hareketli_Daire
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Thread th;
        Graphics g;
        Graphics fg;
        Bitmap btm;

        bool drawing = true;

        private void Form1_Load(object sender, EventArgs e)
        {
            btm = new Bitmap(580, 580);
            g = Graphics.FromImage(btm);
            fg = CreateGraphics();
            th = new Thread(Draw);
            th.IsBackground = true;
            th.Start();

        }
        public void Draw()
        {
            float angle = 0.0f;
            PointF org = new PointF(250, 250);
            float rad = 250;
            Pen pen = new Pen(Brushes.Azure, 3.0f);
            RectangleF area = new RectangleF(30, 30, 500, 500);
            RectangleF circle = new RectangleF(0, 0, 50, 50);


            PointF loc = PointF.Empty;
            PointF img = new PointF(20, 20);

            fg.Clear(Color.Black);

            while (drawing)
            {
                g.Clear(Color.Black);
                g.DrawEllipse(pen, area);
                loc = CirclePoint(rad, angle, org);

                circle.X = loc.X - (circle.Width / 2) + area.X;
                circle.Y = loc.Y - (circle.Height / 2) + area.Y;

                g.DrawEllipse(pen, circle);
                fg.DrawImage(btm, img);

                if (angle < 360)
                {
                    angle += 0.5f;

                }
                else
                {
                    angle = 0;

                }

            }
        }

        private PointF CirclePoint(float radius, float angleIndegrees, PointF origin)
        {
            float x = (float)(radius * Math.Cos(angleIndegrees * Math.PI / 180F)) + origin.X;
            float y = (float)(radius * Math.Sin(angleIndegrees * Math.PI / 180F)) + origin.Y;


            return new PointF(x, y);

        }
    }
}
//Önemli Math.Sin yerine istediğini yazabilirsin mesela Math. yap Noktadan Sonra  seçenekte ne çıkıyorsa sıra ile dene Güzel Efektler var