using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLog;

namespace Seaplane
{
    public partial class FormAerodrome : Form
    {
        private readonly AerodromeCollection aerodromeCollection;

        private readonly Logger logger;

        public FormAerodrome()
        {
            InitializeComponent();
            aerodromeCollection = new AerodromeCollection(pictureBoxAerodrome.Width, pictureBoxAerodrome.Height);
            logger = LogManager.GetCurrentClassLogger();
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
                logger.Warn("Не введено название аэродрома");
                return;
            }

            logger.Info($"Добавили аэродром {textBoxNewLevelName.Text}");
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
                    logger.Info($"Удалили аэродром {listBoxAerodrome.SelectedItem.ToString()}");
                    aerodromeCollection.DelAerodrome(listBoxAerodrome.SelectedItem.ToString());
                    ReloadLevels();
                }
            }
        }
       
        private void buttonTakePlane_Click(object sender, EventArgs e)
        {
            if (listBoxAerodrome.SelectedIndex > -1 && maskedTextBox.Text != "")
            {
                try
                {
                    var plane = aerodromeCollection[listBoxAerodrome.SelectedItem.ToString()] - Convert.ToInt32(maskedTextBox.Text);
                    if (plane != null)
                    {
                        FormPlane form = new FormPlane();
                        form.SetPlane(plane);
                        form.ShowDialog();

                        logger.Info($"Изъят самолет {plane} с места {maskedTextBox.Text}");
                    }
                    Draw();
                }

                catch (PlaneNotFoundException ex)
                {
                    MessageBox.Show(ex.Message, "Не найдено", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Warn("Не найдено");
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Неизвестная ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Warn("Неизвестная ошибка");
                }
            }

        }

        private void listBoxAerodrome_SelectedIndexChanged(object sender, EventArgs e)
        {
            logger.Info($"Перешли на аэродром {listBoxAerodrome.SelectedItem.ToString()}");
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
                try
                {
                    if ((aerodromeCollection[listBoxAerodrome.SelectedItem.ToString()]) + plane)
                    {
                        Draw();
                        logger.Info($"Добавлен самолет {plane}");
                    }
                    else
                    {
                        MessageBox.Show("Самолет не удалось поставить");
                        logger.Warn("Самолет не удалось поставить");
                    }

                    Draw();
                }

                catch (AerodromeOverflowException ex)
                {
                    MessageBox.Show(ex.Message, "Переполнение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Warn("Переполнение");
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Неизвестная ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Warn("Неизвестная ошибка");
                }
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    aerodromeCollection.SaveData(saveFileDialog.FileName);
                    MessageBox.Show("Сохранение прошло успешно", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    logger.Info("Сохранено в файл " + saveFileDialog.FileName);
                }

                catch (Exception ex) 
                {
                    MessageBox.Show(ex.Message, "Неизвестная ошибка при сохранении", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Warn("Неизвестная ошибка при сохранении");
                }
            }
        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    aerodromeCollection.LoadData(openFileDialog.FileName);
                    MessageBox.Show("Загрузили", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    logger.Info("Загружено из файла " + openFileDialog.FileName);
                    ReloadLevels();
                    Draw();
                    
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Неизвестная ошибка при загрузке", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Warn("Неизвестная ошибка при загрузке");
                }
            }
        }
    }
}
