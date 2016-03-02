using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//By Dylan & Thomas - Launcher
namespace Twack
{
    public partial class Launcher : Form
    {
        public Launcher()
        {
            InitializeComponent();
        }

        private void pbPlay_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Get to the stairs before they get you!");
            MessageBox.Show("How to play? Use WASD to move, Mouse Click to shoot and hold Shift to Sprint!");
            Level mapForm = new Level();        //Create new instance of the level class
            mapForm.Show();                     //Opens Map Form

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Credits creditForm = new Credits();
            creditForm.Show();
        }


      
    }
}
