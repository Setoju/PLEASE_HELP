using System.Drawing;
using System.Security.Policy;
using System.Media;
using System.Diagnostics.Metrics;

namespace PLEASE_HELP
{
    public partial class Form1 : Form
    {        
        public Form1()
        {
            InitializeComponent();                        
        }                
        private void button1_Click(object sender, EventArgs e)
        {
            DrawingEllipse();
            DrawingCube();
            DrawingHeptagon();
            DrawingCircleSector();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            DrawingPC();
        }

        private void button3_Click(object sender, EventArgs e)
        {                     
            Random rnd = new Random();
            x1 = rnd.Next(300, 400);
            x2 = rnd.Next(200, 300);
            y = rnd.Next(200, 300);              
            timer1.Interval = 10;
            timer1.Start();            
        }
        private void button4_Click(object sender, EventArgs e)
        {
            y1 = 170;
            y2 = 191;
            timer2.Interval = 10;
            timer2.Start();    
            SoundPlayer spl = new SoundPlayer(@"C:\Users\Setoju\Downloads\Faint.wav");
            spl.Play();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();            
            SoundPlayer spl = new SoundPlayer();
            spl.Stop();
            timer1.Stop();
            timer2.Stop();
        }

        public void DrawingEllipse()
        {                        
            Random rnd = new Random();
                        
            Rectangle rect = new Rectangle(rnd.Next(80, 500), rnd.Next(30, 250), rnd.Next(40, 50), rnd.Next(50, 80));
            Graphics g = pictureBox1.CreateGraphics();

            g.FillEllipse(Brushes.Red, rect);
        }
        public void DrawingCube()
        {            
            Graphics g = pictureBox1.CreateGraphics();
            Random rnd = new Random();

            int size = rnd.Next(50, 80);            
            int skew = 20;
            Point Org = new Point(rnd.Next(80, 500), rnd.Next(30, 200));                        
            Rectangle R = new Rectangle(Org.X, Org.Y, size, size);
            Point[] topCube;
            topCube = new Point[]{
                new Point(Org.X, Org.Y),
                new Point(Org.X + skew, Org.Y - skew),
                new Point(Org.X + size + skew, Org.Y - skew),
                new Point(Org.X + size, Org.Y)};            
            g.FillPolygon(Brushes.LightBlue, topCube);
            
            Point[] rightCube;
            rightCube = new Point[]{
                new Point(Org.X + size, Org.Y),
                new Point(Org.X + size + skew, Org.Y - skew),
                new Point(Org.X + size + skew, Org.Y + size - skew),
                new Point(Org.X + size , Org.Y + size)};
            g.FillPolygon(Brushes.AliceBlue, rightCube);

            g.FillRectangle(Brushes.LightSkyBlue, R);            
        }       
        public void DrawingHeptagon()
        {
            Graphics g = pictureBox1.CreateGraphics();
            Random rnd = new Random();

            var x_0 = rnd.Next(80, 500);
            var y_0 = rnd.Next(40, 200);

            var shape = new PointF[7];

            var r = rnd.Next(30, 50);
            
            for (int a = 0; a < 7; a++)
            {
                shape[a] = new PointF(
                    x_0 + r * (float)Math.Cos(a * 52 * Math.PI / 180f),
                    y_0 + r * (float)Math.Sin(a * 52 * Math.PI / 180f));
            }

            g.FillPolygon(Brushes.Brown, shape);
        }
        public void DrawingCircleSector()
        {
            Graphics g = pictureBox1.CreateGraphics();
            Random rnd = new Random();
            
            int x = rnd.Next(60, 400);
            int y = rnd.Next(40, 100);
            g.DrawArc(Pens.Coral, x, y, 100, 100, 0, 60);
            Point p1 = new Point(x+40, y+50);
            Point p2 = new Point(x+100, y+50);
            Point p3 = new Point(x+75, y+92);
            g.DrawLine(Pens.Coral, p1, p2);
            g.DrawLine(Pens.Coral, p1, p3);            
        }
        public void DrawingPC()
        {
            Graphics g = pictureBox1.CreateGraphics();
            Random rnd = new Random();

            int size = rnd.Next(50, 70);
            int skew = 30;
            Point Org = new Point(rnd.Next(80, 500), rnd.Next(30, 200));
            Rectangle topPart = new Rectangle(Org.X, Org.Y, size, size);
            g.FillRectangle(Brushes.Black, topPart);

            Rectangle screen = new Rectangle(Org.X + 2, Org.Y + 2, size - 4, size - 4);
            g.FillRectangle(Brushes.WhiteSmoke, screen);

            Point[] downPart;
            downPart = new Point[]{
                new Point(Org.X, Org.Y+ size),
                new Point(Org.X - skew, Org.Y + skew + size),
                new Point(Org.X + size - skew, Org.Y + skew + size),
                new Point(Org.X + size, Org.Y+size)};
            g.FillPolygon(Brushes.DarkGray, downPart);

            Point[] keyboard;
            keyboard = new Point[]{
                new Point(Org.X + 2, Org.Y + size + 5),
                new Point(Org.X - skew + 12, Org.Y + skew + size - 5),
                new Point(Org.X + size - skew - 2, Org.Y + skew + size - 5),
                new Point(Org.X + size - 12, Org.Y+size + 5)};
            g.FillPolygon(Brushes.DarkGreen, keyboard);
        }              
        public int x1 = 0;
        public int x2 = 0;
        public int y = 0;                
        public int counter1 = 0;
        public int counter2 = 200;        
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);

            int xL = x1 - (int)Math.Round(80 * Math.Cos(counter2 * 0.05));
            int yL = y + (int)Math.Round(10 * Math.Sin(counter1 * 0.05));

            int xR = x2 + (int)Math.Round(80 * Math.Cos(counter2 * 0.05));
            int yR = y + (int)Math.Round(10 * Math.Sin(counter1 * 0.05));
            counter1++;
            counter2--;
            Point[] triangle = new Point[]
                {
                    new Point(xL, yL),
                    new Point(xR, yR),
                    new Point((x1+x2)/2, y/2),
                };
            g.FillPolygon(Brushes.Red, triangle);
            //if (x1 == check1 && x2 == check2)
            //{
            //    flag = true;
            //}
            //else if (x1 == check2 && x2 == check1)
            //{
            //    flag = false;
            //}
            //if (flag == false)
            //{
            //    x1 += 1; x2 -= 1;
            //    Point[] triangle = new Point[]
            //    {
            //        new Point(x1, y),
            //        new Point(x2, y),
            //        new Point((x1+x2)/2, y/2),
            //    };
            //    g.FillPolygon(Brushes.Red, triangle);
            //}
            //else
            //{
            //    x1 -= 1; x2 += 1;
            //    Point[] triangle = new Point[]
            //    {
            //        new Point(x1, y),
            //        new Point(x2, y),
            //        new Point((x1+x2)/2, y/2),
            //    };                
            //    g.FillPolygon(Brushes.Red, triangle);
            //}                                               
        }
        public int y1 = 0;
        public int y2 = 0;        
        public bool flagDrum = true;
        private void timer2_Tick(object sender, EventArgs e)
        {            
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);            
            int x = 300;
            int y = 200;
            Point[] rectangle = new Point[]
            {
                new Point(x, y),
                new Point(x, y + 90),
                new Point(x+10, y + 100),
                new Point(x+30, y + 110),
                new Point(x+50, y + 100),
                new Point(x+60,y+90),
                new Point(x+60, y)
            };
            g.FillPolygon(Brushes.Red, rectangle);

            Rectangle rect = new Rectangle(x, y - 10, 60, 20);
            g.FillEllipse(Brushes.DarkSlateGray, rect);
                        
            if (y1 == y - 30 && y2 == y - 9)
            {
                flagDrum = true;
            }
            else if (y1 == y - 12 && y2 == y - 27)
            {
                flagDrum = false;
            }
            if (flagDrum)
            {
                y1 += 1;
                y2 -= 1;
                Rectangle rect1 = new Rectangle(x + 10, y1, 10, 10);
                g.FillEllipse(Brushes.Gold, rect1);

                Rectangle rect2 = new Rectangle(x + 35, y2, 10, 10);
                g.FillEllipse(Brushes.Gold, rect2);

                Rectangle rect3 = new Rectangle(x + 43, y2 + 3, 40, 5);
                g.FillRectangle(Brushes.RosyBrown, rect3);

                Rectangle rect4 = new Rectangle(x - 27, y1 + 3, 40, 5);
                g.FillRectangle(Brushes.RosyBrown, rect4);
            }
            else
            {
                y1 -= 1;
                y2 += 1;
                Rectangle rect1 = new Rectangle(x + 10, y1, 10, 10);
                g.FillEllipse(Brushes.Gold, rect1);

                Rectangle rect2 = new Rectangle(x + 35, y2, 10, 10);
                g.FillEllipse(Brushes.Gold, rect2);

                Rectangle rect3 = new Rectangle(x + 43, y2 + 3, 40, 5);
                g.FillRectangle(Brushes.RosyBrown, rect3);

                Rectangle rect4 = new Rectangle(x - 27, y1 + 3, 40, 5);
                g.FillRectangle(Brushes.RosyBrown, rect4);
            }
        }
    }
}