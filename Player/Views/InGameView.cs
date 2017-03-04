using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;
using System.IO;
using Player.Interfaces;

namespace Player
{
    public partial class InGameView : Form, IInGameView
    {
        public InGameView()
        {
            InitializeComponent();
            this.CenterToScreen();

            
        }

        private void InGame_Load(object sender, EventArgs e)
        {
            
        }

    }
}
