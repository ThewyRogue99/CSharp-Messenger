using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using OpenCvSharp;

namespace VideoClass
{
    public class VideoHandle
    {
        public Image frame;
        VideoCapture capture = new VideoCapture();

        public void GetFrames(VideoCapType type, int camIndex = 0)
        {
            if (type == VideoCapType.TYPE_SCREEN)
            {
                Bitmap captureBitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);
                Rectangle captureRectangle = Screen.AllScreens[0].Bounds;
                Graphics captureGraphics = Graphics.FromImage(captureBitmap);
                captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);
                captureGraphics.Dispose();
                if (frame != null)
                    frame.Dispose();
                frame = new Bitmap(captureBitmap);
                captureBitmap.Dispose();
            }
            else if (type == VideoCapType.TYPE_WEBCAM)
            {
                capture.Open(camIndex);
                Mat mat = capture.RetrieveMat();
                MemoryStream memstream = mat.ToMemoryStream();
                if (mat != null)
                    mat.Dispose();
                Image img = Image.FromStream(memstream);
                memstream.Close();
                if (img != null)
                {
                    if (frame != null)
                        frame.Dispose();
                    frame = new Bitmap((Image)img.Clone());
                    img.Dispose();
                }
            }
        }
    }

    public enum VideoCapType
    {
        TYPE_SCREEN,
        TYPE_WEBCAM
    }
}
