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
        private readonly AerodromeCollection aerodromeCollection;

        public FormAerodrome()
        {
            InitializeComponent();
            aerodromeCollection = new AerodromeCollection(pictureBoxAerodrome.Width, pictureBoxAerodrome.Height);
            Draw();
        }

        private void ReloadLevels()
        {
            int index = listBoxAerodrome.SelectedIndex;

            listBoxAerodrome.Items.Clear();
            for (int i = 0; i < aerodromeCollection.Keys.Count; i++)
            {
                listBoxAerodrome.Items.Add(aerodromeCollection.Keys[i]);
            }

            if (listBoxAerodrome.Items.Count > 0 && (index == -1 || index >= listBoxAerodrome.Items.Count))
            {
                listBoxAerodrome.SelectedIndex = 0;
            }
            else if (listBoxAerodrome.Items.Count > 0 && index > -1 && index < listBoxAerodrome.Items.Count)
            {
                listBoxAerodrome.SelectedIndex = index;
            }
        }


        private void Draw()
        {
            if (listBoxAerodrome.SelectedIndex > -1)
            {
                Bitmap bmp = new Bitmap(pictureBoxAerodrome.Width, pictureBoxAerodrome.Height);
                Graphics gr = Graphics.FromImage(bmp);
                aerodromeCollection[listBoxAerodrome.SelectedItem.ToString()].Draw(gr);
                pictureBoxAerodrome.Image = bmp;

            }
        }

        private void buttonAddAerodrome_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxNewLevelName.Text))
            {
                MessageBox.Show("Введите название аэродрома", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            aerodromeCollection.AddAerodrome(textBoxNewLevelName.Text);
            ReloadLevels();
            textBoxNewLevelName.Text = "";
        }

        private void buttonDeleteAerodrome_Click(object sender, EventArgs e)
        {
            if (listBoxAerodrome.SelectedIndex > -1)
            {
                if (MessageBox.Show($"Удалить аэродром { listBoxAerodrome.SelectedItem.ToString()}?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    aerodromeCollection.DelAerodrome(listBoxAerodrome.SelectedItem.ToString());
                    ReloadLevels();
                }
            }
        }

        private void buttonLandPlane_Click(object sender, EventArgs e)
        {           
            if (listBoxAerodrome.SelectedIndex > -1)
            {
                ColorDialog dialog = new ColorDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var plane = new Plane(100, 1000, dialog.Color);
                    if (aerodromeCollection[listBoxAerodrome.SelectedItem.ToString()] + plane)
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

        private void buttonLandWaterplane_Click(object sender, EventArgs e)
        {      
            if (listBoxAerodrome.SelectedIndex > -1)
            {
                ColorDialog dialog = new ColorDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    ColorDialog dialogDop = new ColorDialog();
                    if (dialogDop.ShowDialog() == DialogResult.OK)
                    {
                        var plane = new WaterPlane(100, 1000, dialog.Color, dialogDop.Color, true, true, true);
                        if (aerodromeCollection[listBoxAerodrome.SelectedItem.ToString()] + plane)
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
        }

        private void buttonTakePlane_Click(object sender, EventArgs e)
        {
            if (listBoxAerodrome.SelectedIndex > -1 && maskedTextBox.Text != "")
            {
                var plane = aerodromeCollection[listBoxAerodrome.SelectedItem.ToString()] - Convert.ToInt32(maskedTextBox.Text);
                if (plane != null)
                {
                    FormPlane form = new FormPlane();
                    form.SetPlane(plane);

                    form.ShowDialog();
                }
                Draw();
            }

        }

        private void listBoxAerodrome_SelectedIndexChanged(object sender, EventArgs e)
        {
            Draw();
        }
    }
}
