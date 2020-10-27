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
    public partial class FormPlaneConfig : Form
    {
        Vehicle plane = null;

        public event Action<Vehicle> addPlane;

        public FormPlaneConfig()
        {
            InitializeComponent();

            buttonCancel.Click += (object sender, EventArgs e) => { Close(); };
        }

        private void DrawPlane()
        {
            if (plane != null)
            {
                Bitmap bmp = new Bitmap(pictureBoxPlane.Width, pictureBoxPlane.Height);
                Graphics gr = Graphics.FromImage(bmp);
                plane.SetPosition(5, 15, pictureBoxPlane.Width, pictureBoxPlane.Height);
                plane.DrawTransport(gr);
                pictureBoxPlane.Image = bmp;
            }
        }

        //Не используется
        //public void AddEvent(Action<Vehicle> ev)
        //{
        //    if (addPlane == null)
        //    {
        //        addPlane = new Action<Vehicle>(ev);
        //    }
        //    else
        //    {
        //        addPlane += ev;
        //    }
        //}

        private void labelPlane_MouseDown(object sender, MouseEventArgs e)
        {
            labelPlane.DoDragDrop(labelPlane.Text, DragDropEffects.Move | DragDropEffects.Copy);
        }

        private void labelWaterPlane_MouseDown(object sender, MouseEventArgs e)
        {
            labelWaterPlane.DoDragDrop(labelWaterPlane.Text, DragDropEffects.Move | DragDropEffects.Copy);
        }

        private void panelPlane_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void panelPlane_DragDrop(object sender, DragEventArgs e)
        {
            switch (e.Data.GetData(DataFormats.Text).ToString())
            {
                case "Обычный самолет":
                    plane = new Plane((int)numericUpDownSpeed.Value,(int)numericUpDownWeight.Value, Color.White);
                    break;
                case "Гидросамолет":
                    plane = new WaterPlane((int)numericUpDownSpeed.Value, (int)numericUpDownWeight.Value, Color.White, Color.Black,
                        checkBoxStar.Checked, checkBoxWing.Checked, checkBoxFloater.Checked);
                    break;
            }
            DrawPlane();
        }

        private void panelColor_MouseDown(object sender, MouseEventArgs e)
        {
            ((Panel)sender).DoDragDrop(((Panel)sender).BackColor.Name, DragDropEffects.Move | DragDropEffects.Copy);
        }

        private void labelBaseColor_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text.ToString()))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }


        private void labelBaseColor_DragDrop(object sender, DragEventArgs e)
        {
            if (plane != null)
            {
                plane.SetMainColor(Color.FromName(e.Data.GetData(DataFormats.Text).ToString()));
                DrawPlane();
            }
        }

        private void labelDopColor_DragDrop(object sender, DragEventArgs e)
        {
            if (plane is WaterPlane && plane != null) 
            {
                (plane as WaterPlane).SetDopColor(Color.FromName(e.Data.GetData(DataFormats.Text).ToString()));
                DrawPlane();
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            addPlane?.Invoke(plane);
            Close();
        }
    }
}
