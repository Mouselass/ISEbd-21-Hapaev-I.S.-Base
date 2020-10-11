using System;
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
    public partial class FormAerodrome : Form
    {
        private readonly Aerodrome<Plane> aerodrome;

        public FormAerodrome()
        {
            InitializeComponent();
            aerodrome = new Aerodrome<Plane>(pictureBoxAerodrome.Width, pictureBoxAerodrome.Height);
            Draw();
        }

        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxAerodrome.Width, pictureBoxAerodrome.Height);
            Graphics gr = Graphics.FromImage(bmp);
            aerodrome.Draw(gr);
            pictureBoxAerodrome.Image = bmp;
        }

        private void buttonLandPlane_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var plane = new Plane(100, 1000, dialog.Color);
                if (aerodrome + plane)
                {
                    Draw();
                }
                else
                {
                    MessageBox.Show("Недостаточно мест");
                }
            }
        }

        private void buttonLandWaterplane_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ColorDialog dialogDop = new ColorDialog();
                if (dialogDop.ShowDialog() == DialogResult.OK)
                {
                    var plane = new WaterPlane(100, 1000, dialog.Color, dialogDop.Color, true, true, true);
                    if (aerodrome + plane)
                    {
                        Draw();
                    }
                    else
                    {
                        MessageBox.Show("Недостаточно мест");
                    }
                }
            }
        }

        private void buttonTakePlane_Click(object sender, EventArgs e)
        {
            if (maskedTextBox.Text != "")
            {
                var plane = aerodrome - Convert.ToInt32(maskedTextBox.Text);
                if (plane != null)
                {
                    FormPlane form = new FormPlane();
                    form.SetPlane(plane);

                    form.ShowDialog();
                }
                Draw();
            }
        }
    }
}
