using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using CaptureProxy;
using Win32Proxy;

namespace SimpleWindowCapture
{
    public partial class MainForm : Form
    {
        private readonly SynchronizationContext _syncContext;
        private CaptureHelper _captureHelper;

        public MainForm()
        {
            InitializeComponent();

            _syncContext = SynchronizationContext.Current;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            TopMost = true;
            MinimumSize = new Size(Width, Height);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            buttonStop.Enabled = false;

            comboBoxType.Items.Add("DibSection");
            comboBoxType.Items.Add("PrintWindow");
            comboBoxType.SelectedIndex = 0;

            comboBoxPicture.Items.Add("Zoom");
            comboBoxPicture.Items.Add("StretchImage");
            comboBoxPicture.SelectedIndex = 0;

            checkBoxTopMost.Checked = TopMost;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            RemoveCapture();
        }

        private void RemoveCapture()
        {
            _captureHelper?.Stop();
            _captureHelper = null;
        }

        private void AddCapture(IntPtr handle)
        {
            _captureHelper = new CaptureHelper();
            _captureHelper.CaptureDone += OnCaptureDone;
            var captureType = comboBoxType.SelectedIndex == 0
                ? CaptureType.CreateDibSection
                : CaptureType.PrintWindow;
            _captureHelper.Start(Guid.NewGuid().ToString(), handle, captureType);
        }

        private void OnCaptureDone(string captureName, IntPtr bitmapPtr, Win32Types.BitmapInfo bitmapInfo)
        {
            try
            {
                var image = Image.FromHbitmap(bitmapPtr);
                _syncContext.Post(OnCaptureDone1SafePost, image);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void OnCaptureDone1SafePost(object state)
        {
            var image = pictureBox.Image;
            pictureBox.Image = (Bitmap)state;
            image?.Dispose();
        }

        private void checkBoxTopMost_Click(object sender, EventArgs e)
        {
            TopMost = checkBoxTopMost.Checked;
        }

        private void buttonHandle_Click(object sender, EventArgs e)
        {
            int handle;
            try
            {
                handle = int.Parse(textBox_Handle.Text.Trim());
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }

            AddCapture(new IntPtr(handle));
            EnableStart(false);
        }

        private void buttonTitle_Click(object sender, EventArgs e)
        {
            var hWnd = Win32Funcs.FindWindowWrapper(null, textBox_Title.Text.Trim());
            if (string.IsNullOrEmpty(textBox_Title.Text) || hWnd.Equals(IntPtr.Zero))
            {
                MessageBox.Show("无效的窗口标题");
                return;
            }

            AddCapture(hWnd);
            EnableStart(false);
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            RemoveCapture();
            EnableStart(true);
        }

        private void EnableStart(bool enable)
        {
            buttonHandle.Enabled = enable;
            buttonTitle.Enabled = enable;
            buttonStop.Enabled = !enable;
        }

        private void comboBoxPicture_SelectedIndexChanged(object sender, EventArgs e)
        {
            var curSel = comboBoxPicture.SelectedIndex;
            switch (curSel)
            {
                case 0:
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    break;
                case 1:
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    break;
            }
        }
    }
}
