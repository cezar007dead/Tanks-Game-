using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanks
{
    class Enemy: Tank
    {
        Bullet b;
        public void do_shot(string s, int index) // метод для стрельбы вражеского танка 
        {          
            switch (s)
            {
                case "Up":
                    b = new Bullet();
                    b.Create(Object.Tnaks[index].Left, Object.Tnaks[index].Top - 5, 40, 40, f);
                    b.Shoot("Up", 5);
                    Object.Tnaks[index].BackgroundImage = Image.FromFile("Enemy_U.png");
                    break;
                case "Down":
                    b = new Bullet();
                    b.Create(Object.Tnaks[index].Left, Object.Tnaks[index].Top + 5, 40, 40, f);
                    b.Shoot("Down", 5);
                    Object.Tnaks[index].BackgroundImage = Image.FromFile("Enemy_D.png");
                    break;
                case "Left":
                    b = new Bullet();
                    b.Create(Object.Tnaks[index].Left - 5, Object.Tnaks[index].Top, 40, 40, f);
                    b.Shoot("Left", 5);
                    Object.Tnaks[index].BackgroundImage = Image.FromFile("Enemy_L.png");
                    break;
                case "Right":
                    b = new Bullet();
                    b.Create(Object.Tnaks[index].Left + 5, Object.Tnaks[index].Top, 40, 40, f);
                    b.Shoot("Right", 5);
                    Object.Tnaks[index].BackgroundImage = Image.FromFile("Enemy_R.png");
                    break;
            }
        }
        Tank d;
        public void do_move(string s, int index) // метод для передвижения вражеского танка
        {
            switch (s)
            {
                case "W": d.TankMove("W", 40, index); Object.Tnaks[index].BackgroundImage = Image.FromFile("Enemy_U.png"); break;
                case "S": d.TankMove("D", 40, index); Object.Tnaks[index].BackgroundImage = Image.FromFile("Enemy_D.png"); break;
                case "A": d.TankMove("L", 40, index); Object.Tnaks[index].BackgroundImage = Image.FromFile("Enemy_L.png"); break;
                case "D": d.TankMove("R", 40, index); Object.Tnaks[index].BackgroundImage = Image.FromFile("Enemy_R.png"); break;
            }
        }
        Form1 f;
        int X_spawn;
        int Y_spawn;
        int n;
        int focus;
        public void Create(int x, int y, int h, int l, Form1 g,int index)
        {
            focus = 1; // направление танка
            d = new Tank();
            X_spawn = x;
            Y_spawn = y;
            f = g;
            n = index;
            PictureBox L_obj = new PictureBox();
            L_obj.Size = new System.Drawing.Size(h, l);
            L_obj.Left = x;
            L_obj.Top = y;
            L_obj.BackgroundImage = Image.FromFile("Enemy_D.png");
            Tnaks.Add(L_obj);
            f.Controls.Add(Tnaks[index]);
        }
        Timer t;
        public void Play(int H)
        {
            // do_move("D", n);
            t = new Timer();
            t.Enabled = true;
            t.Interval = 700;
            switch (H)
            {
                case 1: t.Tick += new System.EventHandler(Play_code_1); break;

            }
        }
        public void Play_code_1(object sender, EventArgs e) // интелект врага
        {
            try
            {
            
            int p = 40;// сколько блоков проверять
            int[] r = {1, 1, 1, 1};// результат  проверки сторон 
            for (int i = 1; i < 3; i++)
            {
                if (test(p*i, "W", n) == false)
                {
                    r[0] = 0;
                }
                if (test(p * i, "R", n) == false)
                {
                    r[1] = 0;
                }
                if (test(p * i, "D", n) == false)
                {
                    r[2] = 0;
                }
                if (test(p * i, "L", n) == false)
                {
                    r[3] = 0;
                }
            }
                int k = 0;
            Random ran = new Random();
                switch (focus) // движение 
                {
                    case 0:
                        while (true)
                        {
                            if (k == 100)
                            {
                                do_move("S", n);
                                break;
                            }
                            int g = ran.Next(0, 4);
                            if (r[g] == 1 && g == 3)
                            {
                                focus = 3;
                                do_move("A", n);
                                break;
                            }
                            if (r[g] == 1 && g == 0)
                            {
                                focus = 0;
                                do_move("W", n);
                                break;
                            }
                            if (r[g] == 1 && g == 1)
                            {
                                focus = 1;
                                do_move("D", n);
                                break;
                            }
                            k++;
                        }
                        break;
                    case 1:
                        while (true)
                        {
                            if (k == 100)
                            {
                                do_move("A", n);
                                break;
                            }
                            int g = ran.Next(0, 4);
                            if (r[g] == 1 && g == 0)
                            {
                                focus = 0;
                                do_move("W", n);
                                break;
                            }
                            if (r[g] == 1 && g == 1)
                            {
                                focus = 1;
                                do_move("D", n);
                                break;
                            }
                            if (r[g] == 1 && g == 2)
                            {
                                focus = 2;
                                do_move("S", n);
                                break;
                            }
                            k++;
                        }
                        break;
                    case 2:
                        while (true)
                        {
                            if (k == 100)
                            {
                                do_move("W", n);
                                break;
                            }
                            int g = ran.Next(0, 4);
                            if (r[g] == 1 && g == 1)
                            {
                                focus = 1;
                                do_move("D", n);
                                break;
                            }
                            if (r[g] == 1 && g == 2)
                            {
                                focus = 2;
                                do_move("S", n);
                                break;
                            }
                            if (r[g] == 1 && g == 3)
                            {
                                focus = 3;
                                do_move("A", n);
                                break;
                            }
                            k++;
                        }
                        break;
                    case 3:
                        if (k == 100)
                        {
                            do_move("D", n);
                            break;
                        }
                        while (true)
                        {
                            int g = ran.Next(0, 4);
                            if (r[g] == 1 && g == 2)
                            {
                                focus = 2;
                                do_move("S", n);
                                break;
                            }
                            if (r[g] == 1 && g == 3)
                            {
                                focus = 3;
                                do_move("A", n);
                                break;
                            }
                            if (r[g] == 1 && g == 0)
                            {
                                focus = 0;
                                do_move("W", n);
                                break;
                            }
                            k++;
                        }
                        break;
                }
                //bool[] flags = {true,true,true,true};
                for (int i = 1; i < 20; i++) 
                {
                    //1
                    if (Mas_L[i].Left == Tnaks[n].Left + p * i && Mas_L[i].Top == Tnaks[n].Top)
                    {
                        break;
                    }
                    if (Tnaks[0].Left == Tnaks[n].Left + p * i && Tnaks[0].Top == Tnaks[n].Top)
                    {
                        do_shot("Right", n); break;
                    }

                    //2
                    if (Mas_L[i].Left == Tnaks[n].Left - p * i && Mas_L[i].Top == Tnaks[n].Top)
                    {
                        break;
                    }
                    if (Tnaks[0].Left == Tnaks[n].Left - p * i && Tnaks[0].Top == Tnaks[n].Top)
                    {
                        do_shot("Left", n); break;
                    }

                    //3
                    if (Mas_L[i].Left == Tnaks[n].Left  && Mas_L[i].Top == Tnaks[n].Top + p * i)
                    {
                        break;
                    }
                    if (Tnaks[0].Left == Tnaks[n].Left && Tnaks[0].Top == Tnaks[n].Top + p * i)
                    {
                        do_shot("Down", n); break;
                    }
                    //4
                    if (Mas_L[i].Left == Tnaks[n].Left && Mas_L[i].Top == Tnaks[n].Top - p * i)
                    {
                        break;
                    }
                    if (Tnaks[0].Left == Tnaks[n].Left && Tnaks[0].Top == Tnaks[n].Top - p * i)
                    {
                        do_shot("Up", n); break;
                    }
                }


            }
           catch
           {
                t.Enabled = false;
                t.Stop();
            }
        }
    }
}
