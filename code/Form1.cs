using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace capture
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.Red;
            this.TransparencyKey = Color.Red;
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Space)
            {
                Bitmap bit = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);
                Graphics g = Graphics.FromImage(bit);
                g.CopyFromScreen(new Point(this.Location.X + 8, this.Location.Y + (this.Height - this.ClientRectangle.Height) - 8), new Point(0, 0), bit.Size);

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Jpg |*.jpg|Bmp |*.bmp|Gif |*.gif|Png |*.png|Wmf |*.wmf";
                saveFileDialog.FilterIndex = 0;
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.CheckPathExists = true;
                saveFileDialog.FileName = System.DateTime.Now.ToString("yyyyMMddHHmmss");
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    bit.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
        }
    }
}
