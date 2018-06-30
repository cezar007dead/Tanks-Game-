using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanks
{
    public partial class Form1 : Form
    {
        public void LvlCreator(int Size)
        {
            int k = 0;
            int Sum = 0;
            int size = Size;
            int max = 800 - size;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    switch (k)
                    {
                        case 0: wall.Create(Sum, 0, size, size, this); break;
                        case 1: wall.Create(max, Sum, size, size, this); break;
                        case 2: wall.Create(max - Sum, max, size, size, this); break;
                        case 3: wall.Create(0, max - Sum, size, size, this); break;
                    }
                    Sum += size;
                }
                Sum = 0;
                k++;
            }
            Sum = size * 3;
            for (int i = 1; i <= 5; i++)
            {
                for (int j = 1; j <= 14; j++)
                {
                    wall.Create(Sum, i * 3 * size, size, size, this);
                    Sum += size;
                }
                Sum = size * 3;
            }
        }


        public void LvlCreator_2(int Size)
        {
            int k = 0;
            int Sum = 0;
            int size = Size;
            int max = 800 - size;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    switch (k)
                    {
                        case 0: wall.Create(Sum, 0, size, size, this); break;
                        case 1: wall.Create(max, Sum, size, size, this); break;
                        case 2: wall.Create(max - Sum, max, size, size, this); break;
                        case 3: wall.Create(0, max - Sum, size, size, this); break;
                    }
                    Sum += size;
                }
                Sum = 0;
                k++;
            }
            Sum = size * 3;
           
            for (int i = 1; i <= 5; i++)
            {
                for (int j = 1; j <= 14; j++)
                {
                    if (6 <= j && j <= 7)
                    {
                        Sum += size;
                    }
                    else
                    {
                        wall.Create(Sum, i * 3 * size, size, size, this);
                        Sum += size;
                    }
                }
                Sum = size * 3;
            }
            
        }


        public void LvlCreator_3(int Size)
        {
            int k = 0;
            int Sum = 0;
            int size = Size;
            int max = 800 - size;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    switch (k)
                    {
                        case 0: wall.Create(Sum, 0, size, size, this); break;
                        case 1: wall.Create(max, Sum, size, size, this); break;
                        case 2: wall.Create(max - Sum, max, size, size, this); break;
                        case 3: wall.Create(0, max - Sum, size, size, this); break;
                    }
                    Sum += size;
                }
                Sum = 0;
                k++;
            }
            Sum = size * 3;

            for (int i = 1; i <= 4; i++)
            {
               
                    for (int j = 0; j <= 13; j++)
                    {
                        if (1 < j && j < 3 || 4 < j && j < 6 || 7 < j && j < 9 || 10 < j && j < 12)
                        {
                            Sum += size;
                        }
                        else
                        {
                            wall.Create(Sum, size * (i + 2), size, size, this);
                            Sum += size;
                        }
                    }
                    Sum = size * 3;
                
            }
            for (int i = 7; i <= 10; i++)
            {

                for (int j = 0; j <= 13; j++)
                {
                    if (1 < j && j < 3 || 4 < j && j < 6 || 7 < j && j < 9 || 10 < j && j < 12)
                    {
                        Sum += size;
                    }
                    else
                    {
                        wall.Create(Sum, size * (i + 2), size, size, this);
                        Sum += size;
                    }
                }
                Sum = size * 3;

            }
            for (int i = 13; i <= 14; i++)
            {

                for (int j = 0; j <= 13; j++)
                {
                    if (1 < j && j < 3 || 4 < j && j < 6 || 7 < j && j < 9 || 10 < j && j < 12)
                    {
                        Sum += size;
                    }
                    else
                    {
                        wall.Create(Sum, size * (i + 2), size, size, this);
                        Sum += size;
                    }
                }
                Sum = size * 3;

            }

        }


        public Form1()
        {
            InitializeComponent();
        }
        SoundPlayer sp;
        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.BackgroundImage = Image.FromFile("maxresdefault.jpg");
            this.Size = new System.Drawing.Size(900, 650);
            sp = new SoundPlayer("James_Hannigan_-_Red_Alert_3_Theme_-_Soviet_March_.wav");
            sp.Play();
        }
        Bullet b;

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
            try
            {
                switch (e.KeyCode.ToString())
                {
                    case "W": d.TankMove("W", 40, 0); Object.Tnaks[0].BackgroundImage = Image.FromFile("Frendly_U.png"); break;
                    case "S": d.TankMove("D", 40, 0); Object.Tnaks[0].BackgroundImage = Image.FromFile("Frendly_D.png"); break;
                    case "A": d.TankMove("L", 40, 0); Object.Tnaks[0].BackgroundImage = Image.FromFile("Frendly_L.png"); break;
                    case "D": d.TankMove("R", 40, 0); Object.Tnaks[0].BackgroundImage = Image.FromFile("Frendly_R.png"); break;

                    case "Up":
                        b = new Bullet();
                        b.Create(Object.Tnaks[0].Left, Object.Tnaks[0].Top - 5, 40, 40, this);
                        b.Shoot("Up", 5);
                        Object.Tnaks[0].BackgroundImage = Image.FromFile("Frendly_U.png");
                        break;
                    case "Down":
                        b = new Bullet();
                        b.Create(Object.Tnaks[0].Left, Object.Tnaks[0].Top + 5, 40, 40, this);
                        b.Shoot("Down", 5);
                        Object.Tnaks[0].BackgroundImage = Image.FromFile("Frendly_D.png");
                        break;
                    case "Left":
                        b = new Bullet();
                        b.Create(Object.Tnaks[0].Left - 5, Object.Tnaks[0].Top, 40, 40, this);
                        b.Shoot("Left", 5);
                        Object.Tnaks[0].BackgroundImage = Image.FromFile("Frendly_L.png");
                        break;
                    case "Right":
                        b = new Bullet();
                        b.Create(Object.Tnaks[0].Left + 5, Object.Tnaks[0].Top, 40, 40, this);
                        b.Shoot("Right", 5);
                        Object.Tnaks[0].BackgroundImage = Image.FromFile("Frendly_R.png");
                        break;
                }
            }
            catch { }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        Object wall;
        Tank d;
        Enemy en_1;
        Enemy en_2;
        Enemy en_3;
        Enemy en_4;
        Enemy en_5;
        Thread myThread;
        private void button1_Click_1(object sender, EventArgs e)
        {
            sp.Stop();
            panel1.Visible = false;
            this.Size = new System.Drawing.Size(816, 840);
            wall = new Object();
            LvlCreator(40);
            d = new Tank();
            d.Create(400, 720, 40, 40, this);
            Object.Tnaks[0].BackgroundImage = Image.FromFile("Frendly_U.png");
            button1.Visible = false;
            button2.Visible = false;
            en_1 = new Enemy();
            en_2 = new Enemy();
            en_3 = new Enemy();
            en_1.Create(400, 40, 40, 40, this, 1);
            en_2.Create(360, 560, 40, 40, this, 2);
            en_3.Create(360, 160, 40, 40, this, 3);
            en_2.Play(1);
            en_1.Play(1);
            en_3.Play(1);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            sp.Stop();
            panel1.Visible = false;
            this.Size = new System.Drawing.Size(816, 840);
            wall = new Object();
            LvlCreator_2(40);
            d = new Tank();
            d.Create(400, 720, 40, 40, this);
            Object.Tnaks[0].BackgroundImage = Image.FromFile("Frendly_U.png");
            button1.Visible = false;
            button2.Visible = false;
            en_1 = new Enemy();
            en_2 = new Enemy();
            en_3 = new Enemy();
            en_4 = new Enemy();
            en_1.Create(400, 40, 40, 40, this, 1);
            en_2.Create(360, 560, 40, 40, this, 2);
            en_3.Create(360, 160, 40, 40, this, 3);
            en_4.Create(280, 560, 40, 40, this, 4);
            en_2.Play(1);
            en_1.Play(1);
            en_3.Play(1);
            en_4.Play(1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            sp.Stop();
            panel1.Visible = false;
            this.Size = new System.Drawing.Size(816, 840);
            wall = new Object();
            LvlCreator_3(40);
            d = new Tank();
            d.Create(400, 720, 40, 40, this);
            Object.Tnaks[0].BackgroundImage = Image.FromFile("Frendly_U.png");
            button1.Visible = false;
            button2.Visible = false;
            en_1 = new Enemy();
            en_2 = new Enemy();
            en_3 = new Enemy();
            en_4 = new Enemy();
            en_5 = new Enemy();
            en_1.Create(400, 40, 40, 40, this, 1);
            en_2.Create(360, 560, 40, 40, this, 2);
            en_3.Create(360, 280, 40, 40, this, 3);
            en_4.Create(280, 560, 40, 40, this, 4);
            en_5.Create(80, 280, 40, 40, this, 5);
            en_2.Play(1);
            en_1.Play(1);
            en_3.Play(1);
            en_4.Play(1);
            en_5.Play(1);
        }
    }
}
