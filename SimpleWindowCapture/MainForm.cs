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
        private string _captureId;
        private CaptureHelper _captureHelper;
        private readonly SynchronizationContext _syncContext;

        public MainForm()
        {
            InitializeComponent();

            _captureId = Guid.NewGuid().ToString();
            _syncContext = SynchronizationContext.Current;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            comboBox_Type.Items.Add("DibSection");
            comboBox_Type.Items.Add("PrintWindow");
            comboBox_Type.SelectedIndex = 0;
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
            var captureType = comboBox_Type.SelectedIndex == 0
                ? CaptureType.CreateDibSection
                : CaptureType.PrintWindow;
            _captureHelper.Start(_captureId, handle, captureType);
        }

        private void OnCaptureDone(string captureName, IntPtr bitmapPtr, Win32Types.BitmapInfo bitmapInfo)
        {
            var image = Image.FromHbitmap(bitmapPtr);
            _syncContext.Post(OnCaptureDone1SafePost, image);
        }

        private void OnCaptureDone1SafePost(object state)
        {
            var image = pictureBox.Image;
            pictureBox.Image = (Bitmap)state;
            image?.Dispose();
        }

        private void buttonHandle_Click(object sender, EventArgs e)
        {
            if (_captureHelper != null)
            {
                RemoveCapture();
                return;
            }

            var handle = 0;
            if (int.TryParse(textBox_Handle.Text, out handle))
            {
                AddCapture(new IntPtr(handle));
            }
            else
            {
                MessageBox.Show("输入句柄不合法");
            }
        }

        private void button_title_Click(object sender, EventArgs e)
        {
            if (_captureHelper != null)
            {
                RemoveCapture();
                return;
            }

            var hWnd = Win32Funcs.FindWindowWrapper(null, textBox_Title.Text);
            if (hWnd.Equals(IntPtr.Zero))
            {
                MessageBox.Show("无效的窗口标题");
                return;
            }

            AddCapture(hWnd);
        }
    }
}
