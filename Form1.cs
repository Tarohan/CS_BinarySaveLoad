using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace 設定ファイルテスト
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fileName = "test.bin";
            Setting obj = new Setting(textBox1.Text);
            SaveToBinaryFile(obj, fileName);
            MessageBox.Show("パスを登録しました");
        }

        public static void SaveToBinaryFile(Object obj, string path)
        {
            FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, obj);
            fs.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string fileName = "test.bin";
            try
            {
                Setting obj = (Setting)LoadFromBinaryFile(fileName);
                textBox1.Text = obj.StringPath.ToString();
            }
            catch(FileNotFoundException)
            {
                MessageBox.Show("ファイルがありません");
            }
        }

        public static object LoadFromBinaryFile(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            BinaryFormatter f = new BinaryFormatter();
            object obj = f.Deserialize(fs);
            fs.Close();
            return obj;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }
    }
}
