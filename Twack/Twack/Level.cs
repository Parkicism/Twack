using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//By Dylan & Thomas - Level
namespace Twack
{
    public partial class Level : Form
    {
        //Variables and Declarations

        Image _charImg;                                 //30x30 pixels - \Twack\bin\Debug
        double _angle = 0;                              //Angle of image to mouse position

        Point mPos;                                     //Mouse Position

        Point charLocation;                             //Loaction of character; used for movement
        Boolean up, down, left, right, sprint;           //Movement Booleans
        int charSpeed = 5, charSprint = 8, stamina = 8; //Character Speed
        int charLives = 3;                              //Number of lives

        double bulletSpeed = 2.0;                       //Bullet Speed       

        Boolean shoot = false;                          //Shooting Boolean
        //double bulletRise, bulletRun;                 //Rise and Run of the Bullet for firing mechanics
        double[] rise = new double[16];
        double[] run = new double[16];

        //int bulletNum = 0;                            //bullet Number
        PictureBox[] Bullet = new PictureBox[16];       //Array of Bullets
        int created = 0;                                //Counts the amount of bullets created
        int ammoLeft = 45;                              //Bullets left in other clips
        Boolean reloading = false;

        PictureBox[] Wall = new PictureBox[27];         //Array of Walls
        PictureBox[] Door = new PictureBox[8];          //Array of Doors

        PictureBox[] Enemy = new PictureBox[15];        //Array of Enemies        
        Boolean[] Chase = new Boolean[15];              //Array of Booleans for enemies to chase pbChar
        double[] rise2 = new double[15];                //Array of Rise and Run for chasing of pbChar
        double[] run2 = new Double[15];
        Boolean[] Dead = new Boolean[15];               //Array of Booleans for dead enemies
        double enemySpeed = 2.0;

        PictureBox[] Regi = new PictureBox[8];          //Array of Regions
        Point[] rndmove = new Point[15];                 //Array of Random Points

        Random Rnd = new Random();

        public Level()
        {
            InitializeComponent();
        }


        private void Level_Load(object sender, EventArgs e)
        {
            _charImg = Image.FromFile("char.png");      //Loads the character image (30x30)
            pbChar.Top = 15;
            pbChar.Left = 88;

            lblOOA.Hide();

            //foreach (var v in this.Controls)
            //{
            //    if (v.GetType() == typeof(PictureBox))
            //    {
            //        PictureBox pb = (PictureBox)v;

            //        if (pb.Name.IndexOf("pbWall") > -1)
            //        {
            //            int x = 0;
            //            Wall[x] = pb;
            //            x++;
            //        }
            //    }
            //}
            //|| pb.Name.IndexOf("pbPlant") > -1 || pb.Name.IndexOf("pbTable") > -1

            //Efficient Method generated a lot of lag, this "wall of text" is the best code that works
            Wall[0] = pbWall0;
            Wall[1] = pbWall1;
            Wall[2] = pbWall2;
            Wall[3] = pbWall3;
            Wall[4] = pbWall4;
            Wall[5] = pbWall5;
            Wall[6] = pbWall6;
            Wall[7] = pbWall7;
            Wall[8] = pbWall8;
            Wall[9] = pbWall9;
            Wall[10] = pbWall10;
            Wall[11] = pbWall11;
            Wall[12] = pbWall12;
            Wall[13] = pbWall13;
            Wall[14] = pbWall14;
            Wall[15] = pbWall15;
            Wall[16] = pbWall16;
            Wall[17] = pbWall17;
            Wall[18] = pbWall18;
            Wall[19] = pbWall19;
            Wall[20] = pbWall20;
            Wall[21] = pbWall21;
            Wall[22] = pbPlant;
            Wall[23] = pbPlant1;
            Wall[24] = pbPlant2;
            Wall[25] = pbTable0;
            Wall[26] = pbTable1;

            Door[0] = pbDoor0;
            Door[1] = pbDoor1;
            Door[2] = pbDoor2;
            Door[3] = pbDoor3;
            Door[4] = pbDoor4;
            Door[5] = pbDoor5;
            Door[6] = pbDoor6;

            Enemy[0] = pbEnemy0;
            Enemy[1] = pbEnemy1;
            Enemy[2] = pbEnemy2;
            Enemy[3] = pbEnemy3;
            Enemy[4] = pbEnemy4;
            Enemy[5] = pbEnemy5;
            Enemy[6] = pbEnemy6;
            Enemy[7] = pbEnemy7;
            Enemy[8] = pbEnemy8;
            Enemy[9] = pbEnemy9;
            Enemy[10] = pbEnemy10;
            Enemy[11] = pbEnemy11;
            Enemy[12] = pbEnemy12;
            Enemy[13] = pbEnemy13;
            Enemy[14] = pbEnemy14;

            Regi[0] = pbRegion0;
            Regi[1] = pbRegion1;
            Regi[2] = pbRegion2;
            Regi[3] = pbRegion3;
            Regi[4] = pbRegion4;
            Regi[5] = pbRegion5;
            Regi[6] = pbRegion6;
            Regi[7] = pbRegion7;

            lblReload.Hide();

        }

        private void bufferPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            mPos = e.Location;
            CalcAngle();
            bufferPanel1.Refresh();
        }
        private void bufferPanel1_Paint(object sender, PaintEventArgs e)                    //This code is done whenever bufferPanel1 is refreshed
        {
            e.Graphics.TranslateTransform(charLocation.X, charLocation.Y);                  //Translation code (location of char)
            e.Graphics.RotateTransform((float)_angle);                                      //Angle of char
            e.Graphics.DrawImage(_charImg, -(_charImg.Width) / 2, -(_charImg.Height) / 2);  //Placing image and centering it
            e.Graphics.ResetTransform();                                                    //Reset
          
        }
        public void CalcAngle()
        {
            double x1 = charLocation.X;//char
            double y1 = charLocation.Y;//char
            double x2 = mPos.X;
            double y2 = mPos.Y;
            _angle = Angle(x1, y1, x2, y2);             //Takes the function and returns the angle from the mouse position
        }
        public double Angle(double px1, double py1, double px2, double py2)             //This function returns the angle from the mouse position
        {

            double pxRes = px2 - px1;
            double pyRes = py2 - py1;
            double angle = 0.0;

            if (pxRes == 0.0)
            {
                if (pxRes == 0.0)
                    angle = 0.0;
                else if (pyRes > 0.0) angle = System.Math.PI / 2.0;
                else
                    angle = System.Math.PI * 3.0 / 2.0;
            }
            else if (pyRes == 0.0)
            {
                if (pxRes > 0.0)
                    angle = 0.0;

                else
                    angle = System.Math.PI;
            }

            else
            {
                if (pxRes < 0.0)
                    angle = System.Math.Atan(pyRes / pxRes) + System.Math.PI;
                else if (pyRes < 0.0) angle = System.Math.Atan(pyRes / pxRes) + (2 * System.Math.PI);
                else
                    angle = System.Math.Atan(pyRes / pxRes);
            }


            angle = angle * 180 / System.Math.PI; return angle;
        }
        private void Level_KeyDown(object sender, KeyEventArgs e)
        {
            //if the buttons are pressed, the booleans for the movement becomes true
            if (e.KeyCode == Keys.W)
            {
                up = true;
            }
            if (e.KeyCode == Keys.S)
            {
                down = true;
            }
            if (e.KeyCode == Keys.A)
            {
                left = true;
            }
            if (e.KeyCode == Keys.D)
            {
                right = true;
            }
            if (e.KeyCode == Keys.ShiftKey)
            {
                sprint = true;
            }

            CalcAngle();
            bufferPanel1.Refresh();
        }
        private void Level_KeyUp(object sender, KeyEventArgs e)
        {
            //if the buttons are released, the booleans for the movement becomes false
            if (e.KeyCode == Keys.W)
            {
                up = false;
            }
            if (e.KeyCode == Keys.S)
            {
                down = false;
            }
            if (e.KeyCode == Keys.A)
            {
                left = false;
            }
            if (e.KeyCode == Keys.D)
            {
                right = false;
            }
            if (e.KeyCode == Keys.ShiftKey)
            {
                sprint = false;
            }
            CalcAngle();
            bufferPanel1.Refresh();
        }

        private void tmrAnim_Tick(object sender, EventArgs e)
        {
            //if up is true and pbChar.top is greather than Form's 0 pos, then allow to move          
            if (up == true && sprint == true && stamina >= 1 && pbChar.Top > 0)
            {
                pbChar.Top -= charSprint;
            }
            else if (up == true && pbChar.Top > 0)
            {
                pbChar.Top -= charSpeed;
            }
            //same thing for the following codes kind of

            if (down == true && sprint == true && stamina >= 1 && pbChar.Bottom < this.Height)
            {
                pbChar.Top += charSprint;
            }
            else if (down == true && pbChar.Bottom < this.Height)
            {
                pbChar.Top += charSpeed;
            }
            //===

            if (left == true && sprint == true && stamina >= 1 && pbChar.Left > 0)
            {
                pbChar.Left -= charSprint;
            }
            else if (left == true && pbChar.Left > 0)
            {
                pbChar.Left -= charSpeed;
            }
            //===
            if (right == true && sprint == true && stamina >= 1 && pbChar.Right < this.Width)
            {
                pbChar.Left += charSprint;
            }
            else if (right == true && pbChar.Right < this.Width)
            {
                pbChar.Left += charSpeed;
            }
            charLocation.X = pbChar.Left + pbChar.Width / 2;            //Centres the Character around the code
            charLocation.Y = pbChar.Top + pbChar.Height / 2;


            for (int x = 0; x <= 27; x++)           //Collision Code for Walls & Plants & Tables
            {
                try         //Try Catch Statement for exceptions
                {
                    if (pbChar.Bounds.IntersectsWith(Wall[x].Bounds))           //Checks if any of the terrain is interacting with the character
                    {

                        if (left == true & sprint == true & stamina >= 1 & pbChar.Left <= Wall[x].Right & pbChar.Left > Wall[x].Left)
                        {
                            pbChar.Left += charSprint;
                        }
                        else if (left == true & pbChar.Left <= Wall[x].Right & pbChar.Left > Wall[x].Left)       //If you're moving left, and pbChar collides with a wall it will counter it
                        {
                            pbChar.Left += charSpeed;
                        }
                        //===

                        if (right == true & sprint == true & stamina >= 1 & pbChar.Right >= Wall[x].Left & pbChar.Right <= Wall[x].Right)
                        {
                            pbChar.Left -= charSprint;
                        }
                        else if (right == true & pbChar.Right >= Wall[x].Left & pbChar.Right <= Wall[x].Right)   //same with right,
                        {
                            pbChar.Left -= charSpeed;
                        }
                        //===

                        if (down == true & sprint == true & stamina >= 1 & pbChar.Bottom >= Wall[x].Top & pbChar.Bottom <= Wall[x].Bottom)
                        {
                            pbChar.Top -= charSprint;
                        }
                        else if (down == true & pbChar.Bottom >= Wall[x].Top & pbChar.Bottom <= Wall[x].Bottom)  //down,
                        {
                            pbChar.Top -= charSpeed;
                        }
                        //===

                        if (up == true & sprint == true & stamina >= 1 & pbChar.Top <= Wall[x].Bottom & pbChar.Top >= Wall[x].Top)
                        {
                            pbChar.Top += charSprint;
                        }
                        else if (up == true & pbChar.Top <= Wall[x].Bottom & pbChar.Top >= Wall[x].Top)          //and up.
                        {
                            pbChar.Top += charSpeed;
                        }
                    }
                    ////Collision Code for Bullets, similar to pbChar. Makes Game very laggy.
                    for (int y = 0; y <= created; y++)
                    {
                        if (Bullet[y].Bounds.IntersectsWith(Wall[x].Bounds))
                        {
                            Bullet[y].Dispose();
                            //Bullet[y].Hide();
                            rise[y] = 0;
                            run[y] = 0;
                        }
                    }
                }
                catch { }             

            }            
            for (int y = 0; y <= 6; y++)                //Collision code with the doors
            {
                try
                {
                    if (pbChar.Bounds.IntersectsWith(Door[y].Bounds))       //When the char intersects with a door it moves it either 50 pixels up or left
                    {
                        if (left == true & pbChar.Left <= Door[y].Right & pbChar.Left > Door[y].Left)
                        {
                            if (Door[y].Size == new Size(10, 50))           //Checks dimensions to see which orientation the door is situated, this is portrait
                            {
                                Door[y].Top = Door[y].Top - 50;
                            }

                            if (Door[y].Size == new Size(50, 10))           //and this is landscape.
                            {
                                Door[y].Left = Door[y].Left - 50;
                            }
                        }
                        if (right == true & pbChar.Right >= Door[y].Left & pbChar.Right <= Door[y].Right)
                        {
                            if (Door[y].Size == new Size(10, 50))
                            {
                                Door[y].Top = Door[y].Top - 50;
                            }

                            if (Door[y].Size == new Size(50, 10))
                            {
                                Door[y].Left = Door[y].Left - 50;
                            }
                        }
                        if (down == true & pbChar.Bottom >= Door[y].Top & pbChar.Bottom <= Door[y].Bottom)
                        {
                            if (Door[y].Size == new Size(10, 50))
                            {
                                Door[y].Top = Door[y].Top - 50;
                            }

                            if (Door[y].Size == new Size(50, 10))
                            {
                                Door[y].Left = Door[y].Left - 50;
                            }
                        }
                        if (up == true & pbChar.Top <= Door[y].Bottom & pbChar.Top >= Door[y].Top)
                        {
                            if (Door[y].Size == new Size(10, 50))
                            {
                                Door[y].Top = Door[y].Top - 50;
                            }

                            if (Door[y].Size == new Size(50, 10))
                            {
                                Door[y].Left = Door[y].Left - 50;
                            }
                        }
                    }
                }
                catch { }
            }
            //Bullet Movement Code
            if (shoot == true)      //Enables when a bullet is fired
            {
                for (int x = 0; x < created; x++)
                {
                    if (Bullet[x].Location.Y >= 0 && Bullet[x].Location.X >= 0 && Bullet[x].Location.Y <= 620 && Bullet[x].Location.X <= 810)              //Checks whether the bullet is in the game
                    {


                        double bulletLocY = Convert.ToDouble(Bullet[x].Location.Y);
                        double bulletLocX = Convert.ToDouble(Bullet[x].Location.X);
                        double BulletTop = (bulletLocY) - (rise[x] * bulletSpeed) / 50.0;
                        double BulletLeft = (bulletLocX) + (run[x] * bulletSpeed) / 50.0;


                        Bullet[x].Top = Convert.ToInt32(BulletTop);
                        Bullet[x].Left = Convert.ToInt32(BulletLeft);
                    }
                    else
                    {
                        Bullet[x].Hide();
                        rise[x] = 0;
                        run[x] = 0;
                    }
                }
            }

            //Bullet Collision with Enemies           


            for (int x = 0; x < 15; x++)
            {
                for (int y = 0; y < created; y++)
                {
                    if (Bullet[y].Bounds.IntersectsWith(Enemy[x].Bounds))           //When Bullet intersects with an Enemy
                    {
                        Dead[x] = true;                                             //Dead is set to true
                        Enemy[x].BackColor = Color.Black;                           //Enemy is turned black
                        Bullet[y].Hide();                                           //Bullet is Hidden
                        rise[y] = 0;                                                //Bullet Stops
                        run[y] = 0;
                        Bullet[y].Location = new Point(-10, -10);
                    }
                }

                if (Chase[x] == true)
                {
                    if (Dead[x] == false)
                    {
                        rise2[x] = Convert.ToDouble(Enemy[x].Location.Y) - Convert.ToDouble(pbChar.Location.Y);
                        run2[x] = Convert.ToDouble(pbChar.Location.X) - Convert.ToDouble(Enemy[x].Location.X);
                        double EnemyLocY = Convert.ToDouble(Enemy[x].Location.Y);
                        double EnemyLocX = Convert.ToDouble(Enemy[x].Location.X);
                        double EnemyTop = (EnemyLocY) - (rise2[x] * enemySpeed) / 30.0;
                        double EnemyLeft = (EnemyLocX) + (run2[x] * enemySpeed) / 30.0;


                        Enemy[x].Top = Convert.ToInt32(EnemyTop);
                        Enemy[x].Left = Convert.ToInt32(EnemyLeft);
                    }

                }
                else
                {
                    //Attempt at reseting the position of the enemies after one dies
                    //Also tried to make them constantly moving to a random position
                    //if (Enemy[x].Bounds.IntersectsWith(Regi[0].Bounds))
                    //{
                        //rndmove[0].Y = Rnd.Next(Regi[0].Location.Y, (Regi[0].Location.Y + Regi[0].Height - Enemy[x].Height));
                        //rndmove[0].X = Rnd.Next(Regi[0].Location.X, (Regi[0].Location.X + Regi[0].Width - Enemy[x].Width));

                        //rise2[x] = Convert.ToDouble(Enemy[x].Location.Y) - Convert.ToDouble(rndmove[0].Y);
                        //run2[x] = Convert.ToDouble(rndmove[0].X) - Convert.ToDouble(Enemy[x].Location.X);
                        //double EnemyLocY = Convert.ToDouble(Enemy[x].Location.Y);
                        //double EnemyLocX = Convert.ToDouble(Enemy[x].Location.X);
                        //double EnemyTop = (EnemyLocY) - (rise2[x] * enemySpeed) / 80.0;
                        //double EnemyLeft = (EnemyLocX) + (run2[x] * enemySpeed) / 80.0;



                        //Enemy[x].Top = Convert.ToInt32(EnemyTop);
                        //Enemy[x].Left = Convert.ToInt32(EnemyLeft);
                    //}
                    //if (Enemy[x].Bounds.IntersectsWith(Regi[1].Bounds))
                    //{
                    //    rise2[x] = Convert.ToDouble(Enemy[x].Location.Y) - Convert.ToDouble(457);
                    //    run2[x] = Convert.ToDouble(198) - Convert.ToDouble(Enemy[x].Location.X);
                    //    double EnemyLocY = Convert.ToDouble(Enemy[x].Location.Y);
                    //    double EnemyLocX = Convert.ToDouble(Enemy[x].Location.X);
                    //    double EnemyTop = (EnemyLocY) - (rise2[x] * enemySpeed) / 80.0;
                    //    double EnemyLeft = (EnemyLocX) + (run2[x] * enemySpeed) / 80.0;



                    //    Enemy[x].Top = Convert.ToInt32(EnemyTop);
                    //    Enemy[x].Left = Convert.ToInt32(EnemyLeft);
                    //}
                    //if (Enemy[x].Bounds.IntersectsWith(Regi[2].Bounds))
                    //{
                    //    rise2[x] = Convert.ToDouble(Enemy[x].Location.Y) - Convert.ToDouble(12);
                    //    run2[x] = Convert.ToDouble(251) - Convert.ToDouble(Enemy[x].Location.X);
                    //    double EnemyLocY = Convert.ToDouble(Enemy[x].Location.Y);
                    //    double EnemyLocX = Convert.ToDouble(Enemy[x].Location.X);
                    //    double EnemyTop = (EnemyLocY) - (rise2[x] * enemySpeed) / 80.0;
                    //    double EnemyLeft = (EnemyLocX) + (run2[x] * enemySpeed) / 80.0;



                    //    Enemy[x].Top = Convert.ToInt32(EnemyTop);
                    //    Enemy[x].Left = Convert.ToInt32(EnemyLeft);
                    //}
                    //if (Enemy[x].Bounds.IntersectsWith(Regi[3].Bounds))
                    //{
                    //    rise2[x] = Convert.ToDouble(Enemy[x].Location.Y) - Convert.ToDouble(532);
                    //    run2[x] = Convert.ToDouble(24) - Convert.ToDouble(Enemy[x].Location.X);
                    //    double EnemyLocY = Convert.ToDouble(Enemy[x].Location.Y);
                    //    double EnemyLocX = Convert.ToDouble(Enemy[x].Location.X);
                    //    double EnemyTop = (EnemyLocY) - (rise2[x] * enemySpeed) / 80.0;
                    //    double EnemyLeft = (EnemyLocX) + (run2[x] * enemySpeed) / 80.0;



                    //    Enemy[x].Top = Convert.ToInt32(EnemyTop);
                    //    Enemy[x].Left = Convert.ToInt32(EnemyLeft);
                    //}
                    //if (Enemy[x].Bounds.IntersectsWith(Regi[4].Bounds))
                    //{
                    //    rise2[x] = Convert.ToDouble(Enemy[x].Location.Y) - Convert.ToDouble(603);
                    //    run2[x] = Convert.ToDouble(198) - Convert.ToDouble(Enemy[x].Location.X);
                    //    double EnemyLocY = Convert.ToDouble(Enemy[x].Location.Y);
                    //    double EnemyLocX = Convert.ToDouble(Enemy[x].Location.X);
                    //    double EnemyTop = (EnemyLocY) - (rise2[x] * enemySpeed) / 80.0;
                    //    double EnemyLeft = (EnemyLocX) + (run2[x] * enemySpeed) / 80.0;



                    //    Enemy[x].Top = Convert.ToInt32(EnemyTop);
                    //    Enemy[x].Left = Convert.ToInt32(EnemyLeft);
                    //}
                    //if (Enemy[x].Bounds.IntersectsWith(Regi[5].Bounds))
                    //{
                    //    rise2[x] = Convert.ToDouble(Enemy[x].Location.Y) - Convert.ToDouble(400);
                    //    run2[x] = Convert.ToDouble(251) - Convert.ToDouble(Enemy[x].Location.X);
                    //    double EnemyLocY = Convert.ToDouble(Enemy[x].Location.Y);
                    //    double EnemyLocX = Convert.ToDouble(Enemy[x].Location.X);
                    //    double EnemyTop = (EnemyLocY) - (rise2[x] * enemySpeed) / 80.0;
                    //    double EnemyLeft = (EnemyLocX) + (run2[x] * enemySpeed) / 80.0;



                    //    Enemy[x].Top = Convert.ToInt32(EnemyTop);
                    //    Enemy[x].Left = Convert.ToInt32(EnemyLeft);
                    //}
                    //if (Enemy[x].Bounds.IntersectsWith(Regi[6].Bounds))
                    //{
                    //    rise2[x] = Convert.ToDouble(Enemy[x].Location.Y) - Convert.ToDouble(474);
                    //    run2[x] = Convert.ToDouble(492) - Convert.ToDouble(Enemy[x].Location.X);
                    //    double EnemyLocY = Convert.ToDouble(Enemy[x].Location.Y);
                    //    double EnemyLocX = Convert.ToDouble(Enemy[x].Location.X);
                    //    double EnemyTop = (EnemyLocY) - (rise2[x] * enemySpeed) / 80.0;
                    //    double EnemyLeft = (EnemyLocX) + (run2[x] * enemySpeed) / 80.0;



                    //    Enemy[x].Top = Convert.ToInt32(EnemyTop);
                    //    Enemy[x].Left = Convert.ToInt32(EnemyLeft);
                    //}
                    //if (Enemy[x].Bounds.IntersectsWith(Regi[7].Bounds))
                    //{
                    //    rise2[x] = Convert.ToDouble(Enemy[x].Location.Y) - Convert.ToDouble(164);
                    //    run2[x] = Convert.ToDouble(325) - Convert.ToDouble(Enemy[x].Location.X);
                    //    double EnemyLocY = Convert.ToDouble(Enemy[x].Location.Y);
                    //    double EnemyLocX = Convert.ToDouble(Enemy[x].Location.X);
                    //    double EnemyTop = (EnemyLocY) - (rise2[x] * enemySpeed) / 80.0;
                    //    double EnemyLeft = (EnemyLocX) + (run2[x] * enemySpeed) / 80.0;



                    //    Enemy[x].Top = Convert.ToInt32(EnemyTop);
                    //    Enemy[x].Left = Convert.ToInt32(EnemyLeft);
                    //}
                }           
                
                if (pbChar.Bounds.IntersectsWith(Enemy[x].Bounds) && Dead[x] == false)
                {
                    Chase[x] = false;
                    pbChar.Top = 15;
                    pbChar.Left = 88;
                    charLives--;

                    if (charLives == 2)
                    {
                        pbLives2.Hide();
                    }
                    if (charLives == 1)
                    {
                        pbLives1.Hide();
                    }
                    if (charLives == 0)
                    {
                        pbLives0.Hide();
                        MessageBox.Show("YOU LOSE!");
                    }
                }
            }

            if (pbChar.Location != new Point(15, 88))
            {
                if (pbChar.Bounds.IntersectsWith(Regi[0].Bounds))
                {
                    Chase[0] = true;
                }
                if (pbChar.Bounds.IntersectsWith(Regi[1].Bounds))
                {
                    Chase[1] = true;
                }
                if (pbChar.Bounds.IntersectsWith(Regi[2].Bounds))
                {
                    Chase[2] = true;
                    Chase[3] = true;
                }
                if (pbChar.Bounds.IntersectsWith(Regi[3].Bounds))
                {
                    Chase[4] = true;
                    Chase[5] = true;
                }
                if (pbChar.Bounds.IntersectsWith(Regi[4].Bounds))
                {
                    Chase[6] = true;
                    Chase[7] = true;
                    Chase[8] = true;
                }
                if (pbChar.Bounds.IntersectsWith(Regi[5].Bounds))
                {
                    Chase[9] = true;
                    Chase[10] = true;
                }
                if (pbChar.Bounds.IntersectsWith(Regi[6].Bounds))
                {
                    Chase[11] = true;
                    Chase[12] = true;
                }
                if (pbChar.Bounds.IntersectsWith(Regi[7].Bounds))
                {
                    Chase[13] = true;
                    Chase[14] = true;
                }
            }
            if (pbChar.Bounds.IntersectsWith(pbElevator.Bounds))
            {
                {
                    tmrAnim.Stop();
                    tmrReload.Stop();
                    tmrSprint.Stop();
                    MessageBox.Show("Your score is too terrible to display. Try harder next time.");
                }
            }



            if (stamina < 0) // the stamina can not be lower than 0
                stamina = 0;
            if (stamina > 8) // the stamina can not be greater than 8
                stamina = 8;

            CalcAngle();
            bufferPanel1.Refresh();

        }

        private void bufferPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (created <= 14)
            {
                lblAmmoNum.Text = (14 - created).ToString() + " / " + ammoLeft.ToString();

                Bullet[created] = new PictureBox();

                Bullet[created].Size = new Size(5, 5);
                Bullet[created].BackColor = Color.Black;
                Bullet[created].Location = new Point(pbChar.Location.X, pbChar.Location.Y);
                this.Controls.Add(Bullet[created]);
                Bullet[created].BringToFront();

                try
                {
                    rise[created] = Convert.ToDouble(pbChar.Location.Y) - Convert.ToDouble(mPos.Y);
                    run[created] = Convert.ToDouble(mPos.X) - Convert.ToDouble(pbChar.Location.X);

                }
                catch { }
                shoot = true;

                created = created + 1;
            }

            else if (created == 15)
            {
                tmrReload.Enabled = true;
                lblReload.Show();
                reloading = true;
            }



            CalcAngle();
            bufferPanel1.Refresh();
        }
        private void tmrReload_Tick(object sender, EventArgs e)
        {
            if (ammoLeft != 0)
            {
                created = 0;
                lblReload.Hide();
                tmrReload.Enabled = false;

                if (ammoLeft == 45 && reloading == true)
                {
                    ammoLeft = 30;
                    reloading = false;
                }
                if (ammoLeft == 30 && reloading == true)
                {
                    ammoLeft = 15;
                    reloading = false;
                }
                if (ammoLeft == 15 && reloading == true)
                {
                    ammoLeft = 0;
                    reloading = false;
                }
                lblAmmoNum.Text = (15).ToString() + " / " + ammoLeft.ToString();
            }
            else if (ammoLeft == 0 && created == 15)
            {
                lblAmmo.Hide();
                lblReload.Hide();
                lblAmmoNum.Hide();
                lblOOA.Show();
            }
        }
        private void tmrSprint_Tick(object sender, EventArgs e)
        {
            if (sprint == true)   // code for the stamina bar when sprint is pressed
            {
                tmrSprint.Interval = 1;
                stamina -= 1;
                if (stamina <= 8)
                    pbStamina7.BackColor = Color.White;
                if (stamina <= 7)
                    pbStamina6.BackColor = Color.White;
                if (stamina <= 6)
                    pbStamina5.BackColor = Color.White;
                if (stamina <= 5)
                    pbStamina4.BackColor = Color.White;
                if (stamina <= 4)
                    pbStamina3.BackColor = Color.White;
                if (stamina <= 3)
                    pbStamina2.BackColor = Color.White;
                if (stamina <= 2)
                    pbStamina1.BackColor = Color.White;
                if (stamina <= 1)
                    pbStamina0.BackColor = Color.White;
                tmrSprint.Interval = 400;
            }
            if (sprint == false) //code for stamina when it is released
            {
                tmrSprint.Interval = 1;
                stamina += 1;
                if (stamina >= 1)
                    pbStamina0.BackColor = Color.SteelBlue;
                if (stamina >= 2)
                    pbStamina1.BackColor = Color.SteelBlue;
                if (stamina >= 3)
                    pbStamina2.BackColor = Color.SteelBlue;
                if (stamina >= 4)
                    pbStamina3.BackColor = Color.SteelBlue;
                if (stamina >= 5)
                    pbStamina4.BackColor = Color.SteelBlue;
                if (stamina >= 6)
                    pbStamina5.BackColor = Color.SteelBlue;
                if (stamina >= 7)
                    pbStamina6.BackColor = Color.SteelBlue;
                if (stamina >= 8)
                    pbStamina7.BackColor = Color.SteelBlue;
                tmrSprint.Interval = 500;
            }
        }
        private void bufferPanel1_MouseEnter(object sender, EventArgs e)
        {
            CalcAngle();
            bufferPanel1.Refresh();
        }
        private void bufferPanel1_MouseHover(object sender, EventArgs e)
        {
            CalcAngle();
            bufferPanel1.Refresh();
        }
    }
}
