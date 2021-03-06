using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

/*
 * If LogoForm is used as Splash screen before any other form, the ending form thread will cause a lost of the focus.
 * To avoid these call "this.Activate()" on the mainForm's Loading event.
 */
/*
 * Si el LogoForm es usado como imagen de inicio o splash antes que cualquier otro form, al terminar el hilo de este se
 * perdera el foco sobre el proceso. Para evitar esto se debe llamar al metodo "this.Activate()" en el evento Loading
 * del mainForm.
 */

public class LogoForm : IDisposable
{
    #region IDisposable Members

    public void Dispose()
    {
        Dispose(true);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
            GC.SuppressFinalize(this);
    }

    #endregion

    public LogoForm(int fadeTime, int showTime, double fps, Bitmap logo, bool waitFor)
    {
        this.caller(fadeTime, showTime, fps, logo);

        if (waitFor)
            Thread.Sleep(fadeTime + showTime);
    }

    private void caller(int fadeTime, int showTime, double fps, Bitmap logo)
    {
        ThreadStart work = delegate
        {
            creator(fadeTime, showTime, fps, logo);
        };

        thread = new Thread(work);
        thread.Name = "LogoForm";
        thread.Start();
    }

    private void creator(int fadeTime, int showTime, double fps, Bitmap logo)
    {
        LogoFormObject logoForm = new LogoFormObject(fadeTime, showTime, fps, logo);
    }

    private Thread thread;
}

public class LogoFormObject : PerPixelAlphaForm
{
    //Builder
    public LogoFormObject(int fadeTime, int showTime, double fps, Bitmap logo)
    {
        this._fps = fps;
        this.ShowInTaskbar = false;
        this.TopMost = true;
        this.bitmap = logo;

        this._fadeTime = fadeTime;
        this._showTime = showTime;

        this.DrawLogo();

        return;
    }

    //Le decimos a windows que lo dibuje
    protected override void WndProc(ref Message m)
    {
        if (m.Msg == 0x0084 /*WM_NCHITTEST*/)
        {
            m.Result = (IntPtr)2;	// HTCLIENT
            return;
        }
        base.WndProc(ref m);
    }

    //Cargamos una imagen
    public void DrawLogo()
    {
        bool shown = false;
        try
        {
            //Carga
            this.SetBitmap(this.bitmap, 0);

            //Establece posicion y Muestra
            this.SetTopLevel(true);
            this.TopMost = true;
            this.Show();
            this.Top = (Screen.PrimaryScreen.WorkingArea.Height / 2) - (this.Height / 2);
            this.Left = (Screen.PrimaryScreen.WorkingArea.Width / 2) - (this.Width / 2);

            //Muestra con transaperencia
            shown = true;
            int interval = (int)((double)(1 / _fps) * 1000);
            int timer = 0;
            while (timer <= this._fadeTime)
            {
                this.SetBitmap(this.bitmap, (byte)(timer * 255 / this._fadeTime));
                timer += interval;
                Thread.Sleep(interval);
            }
            timer = 0;
            while (timer <= this._showTime)
            {
                timer += interval;
                Thread.Sleep(interval);
            }
        }
        catch
        {
            //Error
        }
        finally
        {
            if (shown)
            {
                this.Close();
                this.Dispose();
            }
            Thread.CurrentThread.Abort();
        }
    }

    private double _fps;
    private int _fadeTime;
    private int _showTime;
    private Bitmap bitmap;
}

class Win32
{
    public enum Bool
    {
        False = 0,
        True
    };


    [StructLayout(LayoutKind.Sequential)]
    public struct Point
    {
        public Int32 x;
        public Int32 y;

        public Point(Int32 x, Int32 y) { this.x = x; this.y = y; }
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct Size
    {
        public Int32 cx;
        public Int32 cy;

        public Size(Int32 cx, Int32 cy) { this.cx = cx; this.cy = cy; }
    }


    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct ARGB
    {
        public byte Blue;
        public byte Green;
        public byte Red;
        public byte Alpha;
    }


    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct BLENDFUNCTION
    {
        public byte BlendOp;
        public byte BlendFlags;
        public byte SourceConstantAlpha;
        public byte AlphaFormat;
    }


    public const Int32 ULW_COLORKEY = 0x00000001;
    public const Int32 ULW_ALPHA = 0x00000002;
    public const Int32 ULW_OPAQUE = 0x00000004;

    public const byte AC_SRC_OVER = 0x00;
    public const byte AC_SRC_ALPHA = 0x01;


    [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
    public static extern Bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref Point pptDst, ref Size psize, IntPtr hdcSrc, ref Point pprSrc, Int32 crKey, ref BLENDFUNCTION pblend, Int32 dwFlags);

    [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
    public static extern IntPtr GetDC(IntPtr hWnd);

    [DllImport("user32.dll", ExactSpelling = true)]
    public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

    [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
    public static extern IntPtr CreateCompatibleDC(IntPtr hDC);

    [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
    public static extern Bool DeleteDC(IntPtr hdc);

    [DllImport("gdi32.dll", ExactSpelling = true)]
    public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);

    [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
    public static extern Bool DeleteObject(IntPtr hObject);
}

public class PerPixelAlphaForm : Form
{
    public PerPixelAlphaForm()
    {
        FormBorderStyle = FormBorderStyle.None;
        StartPosition = FormStartPosition.CenterScreen;
    }

    public void SetBitmap(Bitmap bitmap)
    {
        SetBitmap(bitmap, 255);
    }

    public void SetBitmap(Bitmap bitmap, byte opacity)
    {
        if (bitmap.PixelFormat != PixelFormat.Format32bppArgb)
            throw new ApplicationException("The bitmap must be 32ppp with alpha-channel.");

        IntPtr screenDc = Win32.GetDC(IntPtr.Zero);
        IntPtr memDc = Win32.CreateCompatibleDC(screenDc);
        IntPtr hBitmap = IntPtr.Zero;
        IntPtr oldBitmap = IntPtr.Zero;

        try
        {
            hBitmap = bitmap.GetHbitmap(Color.FromArgb(0));
            oldBitmap = Win32.SelectObject(memDc, hBitmap);

            Win32.Size size = new Win32.Size(bitmap.Width, bitmap.Height);
            Win32.Point pointSource = new Win32.Point(0, 0);
            Win32.Point topPos = new Win32.Point(Left, Top);
            Win32.BLENDFUNCTION blend = new Win32.BLENDFUNCTION();
            blend.BlendOp = Win32.AC_SRC_OVER;
            blend.BlendFlags = 0;
            blend.SourceConstantAlpha = opacity;
            blend.AlphaFormat = Win32.AC_SRC_ALPHA;

            Win32.UpdateLayeredWindow(Handle, screenDc, ref topPos, ref size, memDc, ref pointSource, 0, ref blend, Win32.ULW_ALPHA);
        }
        finally
        {
            Win32.ReleaseDC(IntPtr.Zero, screenDc);
            if (hBitmap != IntPtr.Zero)
            {
                Win32.SelectObject(memDc, oldBitmap);
                Win32.DeleteObject(hBitmap);
            }
            Win32.DeleteDC(memDc);
        }
    }


    protected override CreateParams CreateParams
    {
        get
        {
            CreateParams cp = base.CreateParams;
            cp.ExStyle |= 0x00080000;
            return cp;
        }
    }
}
