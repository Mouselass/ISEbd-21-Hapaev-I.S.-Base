﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seaplane
{
    public partial class FormPlane : Form
    {
        private ITransport plane;

        public FormPlane()
        {
            InitializeComponent();
        }

        public void SetPlane(ITransport plane)
        {
            this.plane = plane;
            Draw();
        }

        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxPlane.Width, pictureBoxPlane.Height);
            Graphics gr = Graphics.FromImage(bmp);
            plane?.DrawTransport(gr);
            pictureBoxPlane.Image = bmp;
        }
      
        private void buttonMove_Click(object sender, EventArgs e)
        {
            string name = (sender as Button).Name;
            switch (name)
            {
                case "buttonUp":
                    plane?.MoveTransport(Direction.Up);
                    break;
                case "buttonDown":
                    plane?.MoveTransport(Direction.Down);
                    break;
                case "buttonLeft":
                    plane?.MoveTransport(Direction.Left);
                    break;
                case "buttonRight":
                    plane?.MoveTransport(Direction.Right);
                    break;
            }
            Draw();
        }
    }
}
