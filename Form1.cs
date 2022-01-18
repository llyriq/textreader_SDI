using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace textreader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string filename;

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName == String.Empty) return;
            try
            {
                filename = openFileDialog1.FileName;
                var rd = new System.IO.StreamReader(
                openFileDialog1.FileName, Encoding.GetEncoding(1251));
                textBox1.Text = rd.ReadToEnd();
                rd.Close();
            }
            catch (System.IO.FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message + "\nНет такого файла",
                         "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                     "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = openFileDialog1.FileName;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var wr = new System.IO.StreamWriter(
                    saveFileDialog1.FileName, false,
                                        System.Text.Encoding.GetEncoding(1251));
                    wr.Write(textBox1.Text);
                    wr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Clear();
            openFileDialog1.Filter =
                     "Текстовые файлы (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.Filter =
                     "Текстовые файлы (*.txt)|*.txt|All files (*.*)|*.*";
        }

        private void сохранитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                var wr = new System.IO.StreamWriter(
                filename, false,
                                    System.Text.Encoding.GetEncoding(1251));
                wr.Write(textBox1.Text);
                wr.Close();
            }
            catch (Exception ex)
            { // отчет о других ошибках
                MessageBox.Show(ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
