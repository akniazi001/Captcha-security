using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace password
{
    class graphicsave
    {
       
             string text;
           // int uper_x;
            //int uper_y;
            //int lower_x;
            //int lowe_y;
            RectangleF RECFT;
            PointF[] f;
            int angle;
                
            public graphicsave(string name, RectangleF Rctf, PointF[] f, int Angle )
            {
                this.text= name;
                this.RECFT = Rctf;
                this.f = f;
                this.angle = Angle;
            }

            public string txt
            {
                get { return text; }
                set { text = value; }
            }
            public RectangleF rectf
            {
                get { return RECFT;}
                set { RECFT= value;}
            
            }
            public PointF[] pts
            {
                get { return f; }
                set { f = value; }

            }
            public int Angle
            {
                get { return angle; }
                set { angle = value; }
            }


        }
    
}
