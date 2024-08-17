using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace notepad
{   
    public partial class Form1 : Form
    {
        bool acikDosyaVarMi = false;
        bool degisiklikVarMi = false;
        string acikDosyaAdi = "";

        public void dosyaAcmaIslemleri()
        {
            // dosya açma işlemleri çok yerde kullanılacağından fonksiyon olarak yazıyoruz

            OpenFileDialog od = new OpenFileDialog();
            od.Filter = "Metin Dosyalari | *.txt;";
            DialogResult basilan = od.ShowDialog(); // acilan pencerede tıklanan seçeneği attık
            if (basilan == DialogResult.OK)
            {
                acikDosyaAdi = od.FileName;
                richTextBox1.LoadFile(acikDosyaAdi, RichTextBoxStreamType.PlainText);
                acikDosyaVarMi = true;
                degisiklikVarMi = false;
            }
        }

        public void yeniIslemleri()
        {
            richTextBox1.Clear();
            acikDosyaVarMi = false;
            degisiklikVarMi = false;
            acikDosyaAdi = "";
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void acToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (acikDosyaVarMi == false)
            {
                if (degisiklikVarMi == false)
                {
                    dosyaAcmaIslemleri();
                }
                else
                {
                    DialogResult basilan = MessageBox.Show("Kaydedilsin mi?", "Notepad", MessageBoxButtons.YesNoCancel);
                    if (basilan == DialogResult.Yes)
                    {
                        SaveFileDialog sd = new SaveFileDialog();
                        sd.Filter = "Metin Dosyalari | *.txt;";
                        DialogResult basilan2 = sd.ShowDialog();
                        if (basilan2 == DialogResult.OK)
                        {
                            richTextBox1.SaveFile(sd.FileName, RichTextBoxStreamType.PlainText);
                            dosyaAcmaIslemleri();
                        }
                    }
                    else if (basilan == DialogResult.No)
                    {
                        dosyaAcmaIslemleri();
                    }
                }
            } // if acikdosyavarmi
            else
            {
                if (degisiklikVarMi == false)
                {
                    dosyaAcmaIslemleri();
                }
                else
                {
                    DialogResult basilan = MessageBox.Show("Kaydedilsin mi?", "Notepad", MessageBoxButtons.YesNoCancel);
                    if (basilan == DialogResult.Yes)
                    {
                        richTextBox1.SaveFile(acikDosyaAdi, RichTextBoxStreamType.PlainText);
                        dosyaAcmaIslemleri();
                    }
                    else if (basilan == DialogResult.No)
                    {
                        dosyaAcmaIslemleri();
                    }
                }
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            // richtextbox da textchanged isminde event var. richtextboxa boşluk dahi
            // konsa değişiklik olacak ve degisiklikvarmi true olacak
            degisiklikVarMi = true;
        }

        private void yeniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (acikDosyaVarMi == false)
            {
                if (degisiklikVarMi == false)
                {
                    yeniIslemleri();
                }
                else
                {
                    DialogResult basilan = MessageBox.Show("Kaydedilsin mi?", "Notepad", MessageBoxButtons.YesNoCancel);
                    if (basilan == DialogResult.No)
                    {
                        yeniIslemleri();
                    }
                    else if (basilan == DialogResult.Yes)
                    {
                        SaveFileDialog sd = new SaveFileDialog();
                        sd.Filter = "Metin Dosyalari | *.txt;";
                        DialogResult basilan2 = sd.ShowDialog();
                        if (basilan2 == DialogResult.OK)
                        {
                            richTextBox1.SaveFile(sd.FileName, RichTextBoxStreamType.PlainText);
                            yeniIslemleri();
                        }
                    }
                }
            }
            else
            {
                if (degisiklikVarMi == false)
                {
                    yeniIslemleri();
                }
                else
                {
                    DialogResult basilan = MessageBox.Show("Kaydedilsin mi?", "Notepad", MessageBoxButtons.YesNoCancel);
                    if (basilan == DialogResult.No)
                    {
                        yeniIslemleri();
                    }
                    else if (basilan == DialogResult.Yes)
                    {
                        SaveFileDialog sd = new SaveFileDialog();
                        sd.Filter = "Metin Dosyalari | *.txt;";
                        DialogResult basilan2 = sd.ShowDialog();
                        if (basilan2 == DialogResult.Yes)
                        {
                            richTextBox1.SaveFile(acikDosyaAdi, RichTextBoxStreamType.PlainText);
                            yeniIslemleri();
                        }
                    }
                }
            }
        }

        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (acikDosyaVarMi == false)
            {
                SaveFileDialog sd = new SaveFileDialog();
                sd.Filter = "Metin Dosyalari | *.txt;";
                DialogResult basilan = sd.ShowDialog();
                if (basilan == DialogResult.OK)
                {
                    richTextBox1.SaveFile(sd.FileName, RichTextBoxStreamType.PlainText);

                }
            }
            else
            {
                SaveFileDialog sd = new SaveFileDialog();
                sd.Filter = "Metin Dosyalari | *.txt;";
                DialogResult basilan = sd.ShowDialog();
                if (basilan == DialogResult.OK)
                {
                    richTextBox1.SaveFile(acikDosyaAdi, RichTextBoxStreamType.PlainText);

                }
            }
        }

        private void farklıKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sd = new SaveFileDialog();
            sd.Filter = "Metin Dosyalari | *.txt;";
            DialogResult basilan = sd.ShowDialog();
            if (basilan == DialogResult.OK)
            {
                richTextBox1.SaveFile(sd.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void cikisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (degisiklikVarMi == false)
            {
                this.Close();
            }
            else
            {
                DialogResult basilan = MessageBox.Show("Kaydedilsin mi?", "Notepad", MessageBoxButtons.YesNoCancel);
                if (basilan == DialogResult.Yes)
                {
                    if (acikDosyaVarMi == false)
                    {
                        SaveFileDialog sd = new SaveFileDialog();
                        sd.Filter = "Metin Dosyalari | *.txt;";
                        DialogResult basilan2 = sd.ShowDialog();
                        if (basilan2 == DialogResult.OK)
                        {
                            richTextBox1.SaveFile(sd.FileName, RichTextBoxStreamType.PlainText);
                        }
                    }
                    else
                    {
                        SaveFileDialog sd = new SaveFileDialog();
                        sd.Filter = "Metin Dosyalari | *.txt;";
                        DialogResult basilan2 = sd.ShowDialog();
                        if (basilan2 == DialogResult.OK)
                        {
                            richTextBox1.SaveFile(acikDosyaAdi, RichTextBoxStreamType.PlainText);
                        }
                    }
                }
                else if (basilan == DialogResult.No)
                {
                    this.Close();
                }
            }
        }

        private void yazdirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            pd.ShowDialog();
        }

        private void sayfaYapisiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}