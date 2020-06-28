using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace WindowsFormsApp2
{
    static class Shadow
    {
        public static List<Bitmap> shadowObjectBitmaps = new List<Bitmap>();

        public static List<Bitmap> GetShadowObjectBitmaps()
        {
            return shadowObjectBitmaps;
        }

        //draw to screen static colors. Shadow color will slowly change
        public static void dropShadow(object sender, PaintEventArgs e)
        {
            ContainerControl con = (ContainerControl)sender;
            int numOfShadowChanges = 5;//how big shadow is
            int shadowColorStart = 74;//how much the shadow diffence will start at. The edge of the shadow
            int colorDifference = 11;//change in the color of the shadow at each change. Darkens as you move closer to panel
            Color[] shadow = new Color[numOfShadowChanges];
            Color backgroundColor = Form.ActiveForm.BackColor;

            for (int i = 0; i < numOfShadowChanges; i++)
            {
                int r, g, b;

                if ((shadowColorStart - (i * colorDifference)) < 0)
                {
                    r = backgroundColor.R;
                    g = backgroundColor.G;
                    b = backgroundColor.B;
                }
                else
                {
                    r = backgroundColor.R - (shadowColorStart - (i * colorDifference));
                    g = backgroundColor.G - (shadowColorStart - (i * colorDifference));
                    b = backgroundColor.B - (shadowColorStart - (i * colorDifference));
                }

                //Check if color is above 0
                if (r < 0)
                    r = 0;
                if (g < 0)
                    g = 0;
                if (b < 0)
                    b = 0;

                shadow[i] = Color.FromArgb(r, g, b);
            }

            Pen pen = new Pen(shadow[0]);
            using (pen)
            {
                foreach (Control p in con.Controls)
                {
                    if (p.GetType() == typeof(Panel))
                    {
                        //Process pixels
                        Point pt = p.Location;
                        pt.Y += p.Height;
                        for (var sp = 0; sp < numOfShadowChanges; sp++)
                        {
                            pen.Color = shadow[sp];
                            e.Graphics.DrawLine(pen, pt.X + sp, pt.Y, pt.X + p.Width - 1 + sp, pt.Y);
                            e.Graphics.DrawLine(pen, p.Right + sp, p.Top + sp, p.Right + sp, p.Bottom + sp);
                            //e.Graphics.DrawLine(pen, pt.X, pt.Y, pt.X + p.Width - 1, pt.Y);
                            pt.Y++;
                        }
                    }
                }
            }
        }

        //draw to screen as pixels are set
        public static void dropShadowNonStatic(object sender, PaintEventArgs e)
        {
            ContainerControl con = (ContainerControl)sender;
            int numOfShadowChanges = 5;//how big shadow is
            int alpha = 150;

            int shadowColorStart = 74;//how much the shadow diffence will start at. The edge of the shadow
            int colorDifference = 11;//change in the color of the shadow at each change. Darkens as you move closer to panel

            foreach (Control p in con.Controls)
            {
                if (p.GetType() == typeof(Panel))
                {
                    //Process pixels
                    Console.WriteLine("p.right: " + p.Right);
                    for (int x = p.Right; x < numOfShadowChanges + p.Right; x++)
                    {
                        for (int y = p.Top; y < numOfShadowChanges + p.Bottom; y++)
                        {
                            //Brush brush = new SolidBrush(Color.FromArgb(color.A,color.R - ac, color.G - ac, color.B - ac));
                            Brush brush = new SolidBrush(Color.FromArgb(alpha, 0, 0, 0));
                            e.Graphics.FillRectangle(brush, x, y, 1, 1);
                        }
                    }
                }
            }
        }

        //Sets pixels all at once then draw to screen
        public static void dropShadowBitmap(object sender, PaintEventArgs e)
        {
            ContainerControl con = (ContainerControl)sender;
            int xOffset = 5;
            int yOffset = 7;
            int alpha = 100;

            foreach (Control control in con.Controls)
            {
                if (control.GetType() == typeof(Panel))
                {
                    //Process pixels
                    Bitmap bitmap = new Bitmap(Form.ActiveForm.ClientSize.Width, Form.ActiveForm.ClientSize.Height);
                    //right bar
                    for (int x = control.Right; x < xOffset + control.Right; x++)
                    {
                        for (int y = control.Top + yOffset; y < yOffset + control.Bottom; y++)
                            bitmap.SetPixel(x, y, Color.FromArgb(alpha, 0, 0, 0));
                    }
                    //bot bar
                    for (int x = control.Left + xOffset; x < xOffset + control.Right; x++)
                    {
                        for (int y = control.Bottom; y < yOffset + control.Bottom; y++)
                            bitmap.SetPixel(x, y, Color.FromArgb(alpha, 0, 0, 0));
                    }
                    //Console.WriteLine("Draw call");
                    shadowObjectBitmaps.Add(bitmap);
                    e.Graphics.DrawImage(bitmap, 0, 0);
                }
            }
        }

    }
}
