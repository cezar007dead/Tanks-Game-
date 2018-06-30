using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Media;

namespace Tanks
{
    class Object
    {
        public static List<PictureBox> Mas_L = new List<PictureBox>();
        public static List<PictureBox> Tnaks = new List<PictureBox>();
        int X; // кордината которая используеться как точка местоположения обьекта 
        int Y; // кордината которая используеться как точка местоположения обьекта 
        int hight;
        int length;
        Form1 f;
        public virtual void Create(int x, int y, int h, int l, Form1 g)
        {
            f = g;
            PictureBox L_obj = new PictureBox();
            L_obj.Size = new System.Drawing.Size(h, l);
            L_obj.Left = x;
            L_obj.Top = y;            
            L_obj.BackColor = System.Drawing.Color.Red;
            L_obj.BackgroundImage = Image.FromFile("Wall.png");
            Mas_L.Add(L_obj);
            f.Controls.Add(Mas_L[Mas_L.Count-1]);
        }

        
    }
    class Bullet : Object
    {
        static int sum_tanks = 1;
        Form1 f;
        int x = 0;
        int y = 0;
        //public static List<PictureBox> Bullets = new List<PictureBox>();
        PictureBox Bullets = new PictureBox();
        public override void Create(int x, int y, int h, int l, Form1 g)
        {
            f = g;
            PictureBox L_obj = new PictureBox();
            L_obj.Size = new System.Drawing.Size(h, l);
            L_obj.Left = x;
            L_obj.Top = y;
            L_obj.BackgroundImage = Image.FromFile("Bullet.png");
            Bullets=L_obj;
            f.Controls.Add(Bullets);
        }

        private void Destroy()
        {
            f.Controls.Remove(Bullets);
        }

        Timer t;
        public void Shoot(string s, int speed)
        {
            switch(s)
            {
                case "Up": y = -speed; Bullets.BackgroundImage = Image.FromFile("Bullet_U.png"); break;
                case "Down": y = speed; Bullets.BackgroundImage = Image.FromFile("Bullet_D.png"); break;
                case "Left": x = -speed; Bullets.BackgroundImage = Image.FromFile("Bullet_L.png"); break;
                case "Right": x = speed; Bullets.BackgroundImage = Image.FromFile("Bullet_R.png"); break;

            }
            t = new Timer();
            t.Enabled = true;
            t.Interval = 1;
            t.Tick += new System.EventHandler(_Time);           
        }
        static bool flag = true;
        static SoundPlayer sp;
        public void _Time(object sender, EventArgs e)
        {
            for (int i = 0; i < Mas_L.Count; i++)
            {
                if (Mas_L[i].Left == Bullets.Left + x && Mas_L[i].Top == Bullets.Top + y)
                {
                    Destroy();
                    t.Stop();
                    GC.Collect();
                    return;
                }                
            }
            for (int i = 0; i < Tnaks.Count; i++)
            {
                if (Tnaks[i].Left == Bullets.Left + x && Tnaks[i].Top == Bullets.Top + y)
                {
                   
                    sp = new SoundPlayer("Vzirv.wav");
                    sp.Play();
                    Destroy();
                    t.Stop();
                    GC.Collect();
                    Tnaks[i].Visible = false;
                    sum_tanks--;
                    Tnaks.RemoveAt(i);
                    if (i == 0 && flag )
                    {
                        sp = new SoundPlayer("lose.wav");
                        sp.Play();
                        flag = false;
                        MessageBox.Show("Вы проиграли! (=_=)");
                        Application.Restart();
                        Application.Exit();
                    }
                    else
                    {
                        if (Tnaks.Count == 1 && flag)
                        {
                            sp = new SoundPlayer("victory.wav");
                            sp.Play();
                            flag = false;
                            MessageBox.Show("Победа!╰(▔∀▔)╯");
                            Application.Restart();
                            Application.Exit();
                        }
                    }
                    return;
                }
            }
            Bullets.Left += x;
            Bullets.Top += y;            
        }
    }
    class Tank : Object
    {
        Form1 f;
        int X_spawn;
        int Y_spawn;
        public override void Create(int x, int y, int h, int l, Form1 g)
        {
            X_spawn = x;
            Y_spawn = y;
            f = g;
            PictureBox L_obj = new PictureBox();
            L_obj.Size = new System.Drawing.Size(h, l);
            L_obj.Left = x;
            L_obj.Top = y;
            L_obj.BackColor = System.Drawing.Color.Blue;
            Tnaks.Add(L_obj);
            f.Controls.Add(Tnaks[0]);
        }

        public void TankMove(string direction, int Size,int index) // движение танка
        {
            int size = Size;
            int x = Tnaks[index].Left;
            int y = Tnaks[index].Top;
            switch (direction)
            {
                case "R":
                    if (test(40, "R", index) == true)
                    {
                        Tnaks[index].Left = x + size; x += size; //f.Controls.Add(Tnaks[index]);
                    }
                    break;

                case "L":
                    if (test(40, "L", index) == true)
                    {
                        Tnaks[index].Left = x - size; x -= size; //f.Controls.Add(Tnaks[index]);
                    }
                    break;

                case "D":
                    if (test(40, "D", index) == true)
                    {
                        Tnaks[index].Top = y + size; y += size;// f.Controls.Add(Tnaks[index]);
                    }
                    break;

                case "W":
                    if (test(40, "W", index) == true)
                    {
                        Tnaks[index].Top = y - size; y -= size;// f.Controls.Add(Tnaks[index]);
                    }
                    break;
            }
        }


        public bool test( int Size ,string s, int index)  // Метод проверяющий на наличие стены на пути
        {
            switch (s)
            {
                case "R":
                    for (int i = 0; i < Mas_L.Count; i++) //поменять количество
                    {
                        if (Mas_L[i].Left == Tnaks[index].Left + Size && Mas_L[i].Top == Tnaks[index].Top)
                        {
                            return false;
                        }
                    }
                    for (int i = 0; i < Tnaks.Count; i++) //поменять количество
                    {
                        if (Tnaks[i].Left == Tnaks[index].Left + Size && Tnaks[i].Top == Tnaks[index].Top)
                        {
                            return false;
                        }
                    }
                    break;

                case "L":
                    for (int i = 0; i < Mas_L.Count; i++) //поменять количество
                    {
                        if (Mas_L[i].Left == Tnaks[index].Left - Size && Mas_L[i].Top == Tnaks[index].Top)
                        {
                            return false;
                        }
                    }
                    for (int i = 0; i < Tnaks.Count; i++) //поменять количество
                    {
                        if (Tnaks[i].Left == Tnaks[index].Left - Size && Tnaks[i].Top == Tnaks[index].Top)
                        {
                            return false;
                        }
                    }
                    break;

                case "D":
                    for (int i = 0; i < Mas_L.Count; i++) //поменять количество
                    {
                        if (Mas_L[i].Left == Tnaks[index].Left && Mas_L[i].Top == Tnaks[index].Top + Size)
                        {
                            return false;
                        }
                    }
                    for (int i = 0; i < Tnaks.Count; i++) //поменять количество
                    {
                        if (Tnaks[i].Left == Tnaks[index].Left && Tnaks[i].Top == Tnaks[index].Top + Size)
                        {
                            return false;
                        }
                    }
                    break;

                case "W":
                    for (int i = 0; i < Mas_L.Count; i++) //поменять количество
                    {
                        if (Mas_L[i].Left == Tnaks[index].Left && Mas_L[i].Top == Tnaks[index].Top - Size)
                        {
                            return false;
                        }
                    }
                    for (int i = 0; i < Tnaks.Count; i++) //поменять количество
                    {
                        if (Tnaks[i].Left == Tnaks[index].Left && Tnaks[i].Top == Tnaks[index].Top - Size)
                        {
                            return false;
                        }
                    }
                    break;
            }
            return true;
        }
    }
}
