using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace password
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {

        }
        string pass;
        string txt;
        protected int checkusername_Exist()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=NIAZI-PC;Initial Catalog=graphicalpassword;Integrated Security=True");
            conn.Open();
             int a = 0;
            SqlCommand cmd = new SqlCommand("SELECT * FROM gpasswordtest where Email='" + txtusername.Text + "'", conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
               pass = reader["Password"].ToString();
                txt = reader["InputText"].ToString();
                cmd.Connection = conn;       
                a = 1;
            }
            conn.Close();
            return a;
          }
        private void txtusername_Leave(object sender, EventArgs e)
        {
            if (checkusername_Exist() != 1)
            {
              MessageBox.Show("please check user name and enter interger value in specific key text-box");
                
            }
            else 
            {
                drawimage(txt);
            }
        }
        public string Generate(char[] str)
        {
            Random RNG = new Random();
            string s = "";
            int index = RNG.Next(str.Length);
         
            str = str.Distinct().ToArray();
            char[] chars = str.ToArray();
           

            int lenght = str.Count();
            for (   int i = 0; i < lenght; i++)
            {       
                    s += chars[(i+index)%lenght].ToString();
            }
            return s;
        }
        List<string> list_substr = new List<string>();
        private void drawimage(string str)
        {
           string txt = Generate(str.ToCharArray());
            int strcount = txt.Count();
            int counter = 0;
            List<string> list_substr = new List<string>();
            for (int i = 0; i < txt.Length; i += 10)
            {
                counter++;
                if ((i + 10) < txt.Length)
                    list_substr.Add(txt.Substring(i, 10));
                else
                    list_substr.Add(txt.Substring(i));
            }
            int height = counter * 70;
            int width;
            if (txt.Count() > 10)
            {
                width = (10) * 70;
            }
            else { width = (txt.Count()) * 70; }
            try
            {
                Bitmap bm = MakeCaptchaImge(txt, 75, 75, width, height);
                
                Random RNG = new Random();
               /// double distort = RNG.Next(3, 6) * (RNG.Next(10) == 1 ? 1 : -1);

               ////  Copy the image so that we're always using the original for source color
                //using (Bitmap copy = (Bitmap)bm.Clone())
                //{
                //    for (int y = 0; y < height; y++)
                //    {
                //        for (int x = 0; x < width; x++)
                //        {
                //            // Adds a simple wave
                //            int newX = (int)(x + (distort * Math.Sin(Math.PI * y / 55.0)));
                //            int newY = (int)(y + (distort * Math.Cos(Math.PI * x / 44.0)));
                //            if (newX < 0 || newX >= width) newX = 0;
                //            if (newY < 0 || newY >= height) newY = 0;
                //           // bm.SetPixel(x, y, copy.GetPixel(newX, newY));
                //        }
                //    }

                //}
                bm.Save("E:\\My Data folder _ Use me\\MS Computer Engineering\\password_with2dcaptcha\\password\\Image\\bhm.jpg");
                Bitmap loadbm = new Bitmap("E:\\My Data folder _ Use me\\MS Computer Engineering\\password_with2dcaptcha\\password\\Image\\bhm.jpg");
                imgRegster1.Image = loadbm;
            }
            catch(Exception x){}
            }

        private string[] SplitByLength(string s, int d)
        {
            List<string> stringList = new List<string>();
            if (s.Length <= d) stringList.Add(s);
            else
            {
                int x = 0;
                for (; (x + d) < s.Length; x += d)
                {
                    stringList.Add(s.Substring(x, d));
                }
                stringList.Add(s.Substring(x));
            }
            return stringList.ToArray();
        }
        // Make a captcha image 
        float font_size; 
        private Bitmap MakeCaptchaImge(string txt, int min_size, int max_size, int wid, int hgt)
        {
            // Make the bitmap and associated Graphics object.
            Bitmap bm = new Bitmap("E:\\My Data folder _ Use me\\MS Computer Engineering\\password_with2dcaptcha\\password\\Image\\grass.jpg");

          //  Bitmap bm = new Bitmap(wid, hgt);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.SmoothingMode = SmoothingMode.HighQuality;

                RectangleF rectf = new RectangleF(0, 0, wid, hgt);
              //  gr.FillRectangle(Brushes.White, rectf);
               // gr.FillRectangle(Brushes.Transparent, rectf);
                Random rnd = new Random();
               
                  //  bm.MakeTransparent( Color.White );
               
            ///each character rectangle area
                int dvdend = rnd.Next(7, 7);
                string[] result = SplitByLength(txt, dvdend);
                int new_hgt1 = 41;
                    //(int)(hgt / (result.Length));
                int new_hgt = 0;
                int count = 0;
                int ch_wid = 0;
              
                foreach (string str in result)
                {
                    // See how much room is available for each character.
                    ch_wid = 41;
                    new_hgt = new_hgt1 * count;
                    count++;
                    
                    for (int i = 0; i < str.Length; i++)
                    {
                      
                        font_size = rnd.Next(min_size, max_size);
                         using (Font the_font = new Font("Franklin Gothic Demi", font_size, FontStyle.Bold))
                        {
                            if (i <4)
                            {
                                new_hgt = new_hgt + 12;
                            }
                            else { new_hgt = new_hgt -12; }
                            DrawCharacter(str.Substring(i, 1), gr, the_font, i * ch_wid, new_hgt, ch_wid, wid, new_hgt1);

                        }
                    }
                }
                /////end the boady of making room charactars..
            }

            return bm;
        }
        // Draw a deformed character at this position.
        private int PreviousAngle = 0;
        List<graphicsave> AuthList = new List<graphicsave>();
        public void DrawCharacter(string txt, Graphics gr, Font the_font, int X, int y, int ch_wid, int wid, int hgt)
        {
            
            Random rnd = new Random();
            StringFormat string_format = new StringFormat();
            string_format.Alignment = StringAlignment.Center;
            string_format.LineAlignment = StringAlignment.Center;
            RectangleF rectf = new RectangleF(X, y, ch_wid, hgt);
            int strheight = hgt;

            using (GraphicsPath graphics_path = new GraphicsPath())
            {
                graphics_path.AddString(txt, the_font.FontFamily, (int)(FontStyle.Regular), the_font.Size, rectf, string_format);
                //// Make change alfabets parameters.
                
                /// make randomwraping
                
                int rp = rnd.Next(5,5);
                 PointF[] pts = {
                    new PointF((float)(X + rnd.Next(rp)), (float)(y+ rnd.Next(rp))),
                    new PointF((float)(X + ch_wid - rnd.Next(rp)), (float)(y+rnd.Next(rp))),
                    new PointF((float)(X + rnd.Next(rp)), (float)(y+ hgt - rnd.Next(rp) )),
                     new PointF((float)(X + ch_wid - rnd.Next(rp)), (float)(y+ hgt - rnd.Next(rp)))
                     };
                Matrix mat = new Matrix();
                graphics_path.Warp(pts, rectf, mat, WarpMode.Perspective, 0);
                float dx = (float)(X + ch_wid / 2);
                float dy = (float)(y + hgt / 2);
                gr.TranslateTransform(-dx, -dy, MatrixOrder.Append);
                int angle = PreviousAngle;
                Random rd = new Random();
                int ang = rd.Next(30, 32);
                 do
                {
                    angle = rnd.Next(-ang, ang);
                } while (Math.Abs(angle - PreviousAngle) < ang);
                PreviousAngle = angle;
                gr.RotateTransform(angle, MatrixOrder.Append);
                AuthList.Add(new graphicsave(txt, rectf, pts, angle));
                gr.TranslateTransform(dx, dy, MatrixOrder.Append);
                var r =  Brushes.PaleGoldenrod;
                
                
                gr.FillPath(r, graphics_path);
                gr.ResetTransform();

            }
        }


        public string for_child = "";
        string returnstring = "", realpassword;
        private void imgRegster1_MouseClick(object sender, MouseEventArgs e)
        {
           
               int x = e.X;
               int y = e.Y;
               returnstring = txtpassowrd.Text;
               for (int i = 0; i < AuthList.Count; i++)
               {
                   PointF[] RF = AuthList[i].pts;
                   try
                   {
                       if (RF[0].X < (float)(x) && RF[0].Y < (float)(y) && RF[1].X > (float)(x) && RF[1].Y < (float)(y) && RF[2].X < (float)(x) && RF[2].Y > (float)(y) && RF[3].X > (float)(x) && RF[3].Y > (float)(y))
                       {

                           if (PointInTriangle(x, y, RF[0], RF[1], RF[2]) == true)
                           {
                               returnstring += AuthList[i].txt;
                               realpassword += AuthList[i].txt;
                              // realpassword += AuthList[(i + Convert.ToInt32(txtkey.Text)) % (AuthList.Count)].txt;
                               txtpassowrd.Text = returnstring;
                               for_child = AuthList[i].txt;
                               break;
                           }

                           else if (PointInTriangle(x, y, RF[1], RF[2], RF[3]) == true)
                           {
                               returnstring += AuthList[i].txt;
                               //realpassword += AuthList[(i + Convert.ToInt32(txtkey.Text)) % (AuthList.Count)].txt;
                               txtpassowrd.Text = returnstring;
                               realpassword += AuthList[i].txt;
                               for_child = AuthList[i].txt;
                               break;
                           }

                       }
                   }
                   catch (Exception ex) { }
               }
           }
        float sign(int X, int Y, PointF p2, PointF p3)
        {
            float pointv= (X - p3.X) * (p2.Y - p3.Y) - (p2.X - p3.X) * (Y - p3.Y);
            return pointv;

        }

        bool PointInTriangle(int x, int y, PointF v1, PointF v2, PointF v3)
        {
            bool b1, b2, b3;
            b1 = sign(x,y, v1, v2) < 0.0f;
            b2 = sign(x,y, v2, v3) < 0.0f;
            b3 = sign(x,y, v3, v1) < 0.0f;
            return ((b1 == b2) && (b2 == b3));
        }
       
        private void btnlogin_Click(object sender, EventArgs e)
        {
            Registration rg = new Registration();
         realpassword= rg.encrypted_function(realpassword);
            if (pass ==realpassword )
            {
                successlogin ins = new successlogin();
                ins.MdiParent = this.MdiParent;
                this.Hide();
                ins.ShowDialog();
            }
            else { MessageBox.Show("password is incorrect"); }
        }
        private void btnregister_Click(object sender, EventArgs e)
        {
            
            Registration ins = new Registration();
            ins.MdiParent = this.MdiParent;
            this.Hide();
            ins.ShowDialog();
        }
        private void btncancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnrest_Click(object sender, EventArgs e)
        {
            txtpassowrd.Text = "";
        }

        private void imgRegster1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            //if (for_child != "")
            //{
                // registerchild1 frm = new registerchild1(for_child);
                Pattern frm = new Pattern();
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
                txtpassowrd.Text += frm.returnstring;
                realpassword+= frm.orginal;
                for_child = "";
                // txtpasswrd1.Text+= orginalchildgrid;
                frm.Close();
           // }
        }    




    }
}
