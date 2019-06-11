using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace capture
{
    public partial class Form1 : Form
    {

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        bool beginMove = false;//初始化鼠标位置
        int currentXPosition;
        int currentYPosition;


        private const int CS_DropSHADOW = 0x20000;
        private const int GCL_STYLE = (-26);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SetClassLong(IntPtr hwnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClassLong(IntPtr hwnd, int nIndex);
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.Red;
            this.TransparencyKey = Color.Red;
            SetClassLong(this.Handle, GCL_STYLE, GetClassLong(this.Handle, GCL_STYLE) | CS_DropSHADOW);
        }

        private void CaptureMethod()
        {
            panel1.Visible = false;
            Bitmap bit = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);
            Graphics g = Graphics.FromImage(bit);
            g.CopyFromScreen(new Point(this.Location.X + 1, this.Location.Y + (this.Height - this.ClientRectangle.Height) + 1), new Point(0, 0), bit.Size);

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

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                beginMove = true;
                currentXPosition = MousePosition.X;//鼠标的x坐标为当前窗体左上角x坐标
                currentYPosition = MousePosition.Y;//鼠标的y坐标为当前窗体左上角y坐标
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (beginMove)
            {
                this.Left += MousePosition.X - currentXPosition;//根据鼠标x坐标确定窗体的左边坐标x
                this.Top += MousePosition.Y - currentYPosition;//根据鼠标的y坐标窗体的顶部，即Y坐标
                currentXPosition = MousePosition.X;
                currentYPosition = MousePosition.Y;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                currentXPosition = 0; //设置初始状态
                currentYPosition = 0;
                beginMove = false;
            }
        }

        const int Guying_HTLEFT = 10;
        const int Guying_HTRIGHT = 11;
        const int Guying_HTTOP = 12;
        const int Guying_HTTOPLEFT = 13;
        const int Guying_HTTOPRIGHT = 14;
        const int Guying_HTBOTTOM = 15;
        const int Guying_HTBOTTOMLEFT = 0x10;
        const int Guying_HTBOTTOMRIGHT = 17;

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x0084:
                    base.WndProc(ref m);
                    Point vPoint = new Point((int)m.LParam & 0xFFFF,
                        (int)m.LParam >> 16 & 0xFFFF);
                    vPoint = PointToClient(vPoint);
                    if (vPoint.X <= 5)
                        if (vPoint.Y <= 5)
                            m.Result = (IntPtr)Guying_HTTOPLEFT;
                        else if (vPoint.Y >= ClientSize.Height - 5)
                            m.Result = (IntPtr)Guying_HTBOTTOMLEFT;
                        else m.Result = (IntPtr)Guying_HTLEFT;
                    else if (vPoint.X >= ClientSize.Width - 5)
                        if (vPoint.Y <= 5)
                            m.Result = (IntPtr)Guying_HTTOPRIGHT;
                        else if (vPoint.Y >= ClientSize.Height - 5)
                            m.Result = (IntPtr)Guying_HTBOTTOMRIGHT;
                        else m.Result = (IntPtr)Guying_HTRIGHT;
                    else if (vPoint.Y <= 5)
                        m.Result = (IntPtr)Guying_HTTOP;
                    else if (vPoint.Y >= ClientSize.Height - 5)
                        m.Result = (IntPtr)Guying_HTBOTTOM;
                    break;
                case 0x0201:                //鼠标左键按下的消息 
                    m.Msg = 0x00A1;         //更改消息为非客户区按下鼠标 
                    m.LParam = IntPtr.Zero; //默认值 
                    m.WParam = new IntPtr(2);//鼠标放在标题栏内 
                    base.WndProc(ref m);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        bool panelvisible = true;

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            int WM_KEYDOWN = 256;
            int WM_SYSKEYDOWN = 260;
            if (msg.Msg == WM_KEYDOWN | msg.Msg == WM_SYSKEYDOWN)
            {
                switch (keyData)
                {
                    // Esc to close
                    case Keys.Escape:
                        this.Close();
                        break;
                    case Keys.Space:
                        CaptureMethod();
                        break;
                    case Keys.Enter:
                        panel1.Visible = !panelvisible;
                        panelvisible = !panelvisible;
                        break;
                }
            }
            return false;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Rectangle myRectangle = new Rectangle(0, 0, this.Width, this.Height);
            //ControlPaint.DrawBorder(e.Graphics, myRectangle, Color.Blue, ButtonBorderStyle.Solid);//画个边框 
            ControlPaint.DrawBorder(e.Graphics, myRectangle,
                Color.Black, 1, ButtonBorderStyle.Solid,
                Color.Black, 1, ButtonBorderStyle.Solid,
                Color.Transparent, 1, ButtonBorderStyle.Solid,
                Color.Transparent, 1, ButtonBorderStyle.Solid
            );
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lbTips1.Text = "Press \"Space\" to screenshot";
            lbTips2.Text = "Press \"Esc\" to exit";
            lbTips3.Text = "Press \"Enter\" to show/hide the tips";
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            panel1.Location = new Point(this.Width / 2 - panel1.Width / 2, this.Height / 2 - panel1.Height / 2);
        }
    }
}
