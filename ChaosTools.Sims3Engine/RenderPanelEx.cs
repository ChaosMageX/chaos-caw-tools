using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Sims3.CSHost;

namespace ChaosTools.Sims3Engine
{
    /// <summary>
    /// A panel used to contain, update, and send events to 
    /// the Game Engine's rendering canvas.
    /// </summary>
    public class RenderPanelEx : Panel
    {
        private IntPtr mNativeCanvas;
        private bool mSizeUpdatesLocked;
        private const uint SWP_SHOWWINDOW = 0x40;
        private const uint WM_CHAR = 0x102;
        private const uint WM_KEYDOWN = 0x100;
        private const uint WM_KEYUP = 0x101;
        private const uint WM_MOUSEWHEEL = 0x20a;

        /// <summary>
        /// Creates a new instance of RenderPanelEx,
        /// but it is up to the user to attach it to the Game Engine's
        /// rendering canvas after the Game Engine is initialized.
        /// </summary>
        public RenderPanelEx()
        {
            this.InitializeComponent();
            base.SetStyle(ControlStyles.Selectable, true);
            base.Resize += new EventHandler(this.RenderPanelEx_Resize);
        }

        /// <summary>
        /// Retrieve the HWND pointer to the Game Engine's rendering canvas,
        /// so that it can be contained and updated in this panel.
        /// </summary>
        public void AttachToNativeCanvas()
        {
            this.mNativeCanvas = WorldWrap_GetCanvasHWND();
        }

        private void InitializeComponent()
        {
            base.SuspendLayout();
            this.AllowDrop = true;
            this.AutoSize = true;
            base.ResumeLayout(false);
        }

        /// <summary>
        /// Determines whether the specified key is a regular input key or a special
        /// key that requires preprocessing.
        /// </summary>
        /// <param name="keyData">One of the <see cref="T:System.Windows.Forms.Keys"/> values.</param>
        /// <returns>true if the specified key is a regular input key; otherwise, false.</returns>
        protected override bool IsInputKey(Keys keyData)
        {
            return true;
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.KeyDown"/> event,
        /// and sends the WM_KEYDOWN event to the Game Engine's rendering canvas.
        /// </summary>
        /// <param name="e">A <see cref="System.Windows.Forms.KeyEventArgs"/> 
        /// that contains the event data.</param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (!e.Handled)
            {
                e.Handled = (true);
                SendMessage(this.mNativeCanvas, WM_KEYDOWN, (IntPtr)((long)e.KeyCode), IntPtr.Zero);
            }
            base.OnKeyDown(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.KeyPress"/> event,
        /// and sends the WM_CHAR event to the Game Engine's rendering canvas.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.KeyPressEventArgs"/> 
        /// that contains the event data.</param>
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (!e.Handled)
            {
                e.Handled = true;
                SendMessage(this.mNativeCanvas, WM_CHAR, (IntPtr)e.KeyChar, IntPtr.Zero);
            }
            base.OnKeyPress(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.KeyUp"/> event,
        /// and sends the WM_KEYUP event to the Game Engine's rendering canvas.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.KeyEventArgs"/> 
        /// that contains the event data.</param>
        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (!e.Handled)
            {
                e.Handled = true;
                SendMessage(this.mNativeCanvas, WM_KEYUP, (IntPtr)((long)e.KeyCode), IntPtr.Zero);
            }
            base.OnKeyUp(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.LostFocus"/> event,
        /// and sends WM_KEYUP events for all critical input keys
        /// to the Game Engine's rendering canvas.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> 
        /// that contains the event data.</param>
        protected override void OnLostFocus(EventArgs e)
        {
            SendMessage(this.mNativeCanvas, WM_KEYUP, (IntPtr)0x57L, IntPtr.Zero);
            SendMessage(this.mNativeCanvas, WM_KEYUP, (IntPtr)0x41L, IntPtr.Zero);
            SendMessage(this.mNativeCanvas, WM_KEYUP, (IntPtr)0x53L, IntPtr.Zero);
            SendMessage(this.mNativeCanvas, WM_KEYUP, (IntPtr)0x44L, IntPtr.Zero);
            SendMessage(this.mNativeCanvas, WM_KEYUP, (IntPtr)0x26L, IntPtr.Zero);
            SendMessage(this.mNativeCanvas, WM_KEYUP, (IntPtr)40L, IntPtr.Zero);
            SendMessage(this.mNativeCanvas, WM_KEYUP, (IntPtr)0x25L, IntPtr.Zero);
            SendMessage(this.mNativeCanvas, WM_KEYUP, (IntPtr)0x27L, IntPtr.Zero);
            SendMessage(this.mNativeCanvas, WM_KEYUP, (IntPtr)0x51L, IntPtr.Zero);
            SendMessage(this.mNativeCanvas, WM_KEYUP, (IntPtr)90L, IntPtr.Zero);
            SendMessage(this.mNativeCanvas, WM_KEYUP, (IntPtr)70L, IntPtr.Zero);
            SendMessage(this.mNativeCanvas, WM_KEYUP, (IntPtr)0xbcL, IntPtr.Zero);
            SendMessage(this.mNativeCanvas, WM_KEYUP, (IntPtr)190L, IntPtr.Zero);
            SendMessage(this.mNativeCanvas, WM_KEYUP, (IntPtr)0xbdL, IntPtr.Zero);
            SendMessage(this.mNativeCanvas, WM_KEYUP, (IntPtr)0xbbL, IntPtr.Zero);
            SendMessage(this.mNativeCanvas, WM_KEYUP, (IntPtr)0x61L, IntPtr.Zero);
            SendMessage(this.mNativeCanvas, WM_KEYUP, (IntPtr)0x62L, IntPtr.Zero);
            SendMessage(this.mNativeCanvas, WM_KEYUP, (IntPtr)0x63L, IntPtr.Zero);
            SendMessage(this.mNativeCanvas, WM_KEYUP, (IntPtr)100L, IntPtr.Zero);
            SendMessage(this.mNativeCanvas, WM_KEYUP, (IntPtr)0x65L, IntPtr.Zero);
            SendMessage(this.mNativeCanvas, WM_KEYUP, (IntPtr)0x66L, IntPtr.Zero);
            SendMessage(this.mNativeCanvas, WM_KEYUP, (IntPtr)0x67L, IntPtr.Zero);
            SendMessage(this.mNativeCanvas, WM_KEYUP, (IntPtr)0x68L, IntPtr.Zero);
            SendMessage(this.mNativeCanvas, WM_KEYUP, (IntPtr)0x69L, IntPtr.Zero);
            SendMessage(this.mNativeCanvas, WM_KEYUP, (IntPtr)0x6dL, IntPtr.Zero);
            SendMessage(this.mNativeCanvas, WM_KEYUP, (IntPtr)0x6bL, IntPtr.Zero);
            base.OnLostFocus(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseWheel"/> event.,
        /// and sends the WM_MOUSEWHEEL event to the Game Engine's rendering canvas.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"/> 
        /// that contains the event data.</param>
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            Point point = base.PointToScreen(e.Location);
            int lo = 0;
            int wParam = this.PackMessageData(e.Delta, lo);
            int lParam = this.PackMessageData(point.Y, point.X);
            SendMessage(this.mNativeCanvas, WM_MOUSEWHEEL, (IntPtr)wParam, (IntPtr)lParam);
            base.OnMouseWheel(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize"/> event,
        /// and updates the Game Engine's rendering canvas to match 
        /// the new size and position of this RenderPanelEx.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> 
        /// that contains the event data.</param>
        /// <remarks>Uses the SetWindowPos function from user32.dll 
        /// to update the Game Engine's rendering canvas from its HWND.</remarks>
        protected override void OnResize(EventArgs e)
        {
            if ((base.ClientRectangle.Width > 0) && (base.ClientRectangle.Height > 0))
            {
                SetWindowPos(this.mNativeCanvas, IntPtr.Zero, base.ClientRectangle.Left, base.ClientRectangle.Top, base.ClientRectangle.Width, base.ClientRectangle.Height, SWP_SHOWWINDOW);
            }
            base.OnResize(e);
        }

        /// <summary>
        /// Packs the given high and low values into a single 32-bit integer
        /// formatted to be sent as the wParam or lParam of native Windows OS functions.
        /// </summary>
        /// <param name="hi">High value</param>
        /// <param name="lo">Low value</param>
        /// <returns>High and Low values packed into a 32-bit Param for native Windows OS functions.</returns>
        protected int PackMessageData(int hi, int lo)
        {
            return (int)(((hi & 0xffff) << 0x10) + (lo & 0xffff));
        }

        private void RenderPanelEx_Resize(object sender, EventArgs e)
        {
            if (!this.mSizeUpdatesLocked)
            {
                this.UpdateNativeCanvasSize();
            }
        }

        [DllImport("user32.dll")]
        private static extern bool SendMessage(IntPtr hwnd, uint msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        private void UpdateNativeCanvasSize()
        {
            Size clientSize = base.ClientSize;
            if (!clientSize.IsEmpty && this.mNativeCanvas != IntPtr.Zero && clientSize != GfxDevice.Resolution)
            {
                GfxDevice.Resolution = clientSize;
                GfxDevice.SetWindow(this.mNativeCanvas);
                GfxDevice.Reinit();
                // Fail Safe in case SetWindowPos and SetResolution
                // both fail to update the rendering canvas
                /*GfxDevice.RectInt viewport = new GfxDevice.RectInt();
                viewport.left = base.ClientRectangle.Left;
                viewport.top = base.ClientRectangle.Top;
                viewport.right = base.ClientRectangle.Right;
                viewport.bottom = base.ClientRectangle.Bottom;
                GfxDevice.SetViewport(viewport);/**/
            }
        }

        [DllImport("Sims3Common.dll")]
        private static extern IntPtr WorldWrap_GetCanvasHWND();

        /// <summary>
        /// The HWND pointer to the Game Engine's rendering canvas.
        /// </summary>
        public IntPtr NativeCanvas
        {
            get
            {
                return this.mNativeCanvas;
            }
        }

        /// <summary>
        /// Whether or not the Game Engine's Graphic Device
        /// is updated and reinitialized each time this panel is resized.
        /// </summary>
        public bool SizeUpdatesLocked
        {
            get
            {
                return this.mSizeUpdatesLocked;
            }
            set
            {
                this.mSizeUpdatesLocked = value;
                if (!value)
                {
                    this.UpdateNativeCanvasSize();
                }
            }
        }
    }
}
