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

        private void buttonSetPlane_Click(object sender, EventArgs e)
        {
            var formPlaneConfig = new FormPlaneConfig();
            formPlaneConfig.AddEvent(AddPlane);
            formPlaneConfig.Show();
        }

        private void AddPlane(Vehicle plane)
        {
            if (plane != null && listBoxAerodrome.SelectedIndex > -1)
            {
                if ((aerodromeCollection[listBoxAerodrome.SelectedItem.ToString()]) + plane)
                {
                    Draw();
                }
                else
                {
                    MessageBox.Show("Самолет не удалось поставить");
                }
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (aerodromeCollection.SaveData(saveFileDialog.FileName))
                {
                    MessageBox.Show("Сохранение прошло успешно", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Не сохранилось", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (aerodromeCollection.LoadData(openFileDialog.FileName))
                {
                    MessageBox.Show("Загрузили", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ReloadLevels();
                    Draw();
                }
                else
                {
                    MessageBox.Show("Не загрузили", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
