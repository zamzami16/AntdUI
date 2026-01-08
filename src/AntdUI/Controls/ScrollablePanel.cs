// Copyright (C) Tom <17379620>. All Rights Reserved.
// AntdUI WinForm Library | Licensed under Apache-2.0 License
// Gitee: https://gitee.com/AntdUI/AntdUI
// GitHub: https://github.com/AntdUI/AntdUI
// GitCode: https://gitcode.com/AntdUI/AntdUI

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AntdUI
{
    /// <summary>
    /// ScrollablePanel - Panel with scrollbar support
    /// </summary>
    /// <remarks>A panel control that supports automatic scrollbars when content exceeds visible area.</remarks>
    [Description("ScrollablePanel - Panel with scrollbar support")]
    [ToolboxItem(true)]
    [DefaultProperty("AutoScroll")]
    [Designer(typeof(IControlDesigner))]
    public class ScrollablePanel : Panel
    {
        bool autoscroll = false;
        /// <summary>
        /// Whether to show scrollbar
        /// </summary>
        [Description("Whether to show scrollbar"), Category("Appearance"), DefaultValue(false)]
        public bool AutoScroll
        {
            get => autoscroll;
            set
            {
                if (autoscroll == value) return;
                autoscroll = value;
                if (autoscroll) ScrollBar = new ScrollBar(this, true, true);
                else ScrollBar = null;
                if (IsHandleCreated) IOnSizeChanged();
                OnPropertyChanged(nameof(AutoScroll));
            }
        }

        /// <summary>
        /// Scrollbar instance
        /// </summary>
        [Browsable(false)]
        public ScrollBar? ScrollBar;

        public override Rectangle DisplayRectangle
        {
            get
            {
                var rect = ClientRectangle.DeflateRect(Padding);
                if (ScrollBar != null && ScrollBar.Show)
                {
                    if (ScrollBar.EnabledY) rect.Width -= ScrollBar.SIZE;
                    if (ScrollBar.EnabledX) rect.Height -= ScrollBar.SIZE;
                }
                return rect;
            }
        }

        protected override void OnDraw(DrawEventArgs e)
        {
            base.OnDraw(e);
            var g = e.Canvas;
            ScrollBar?.Paint(g, ColorScheme);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            var rect = ClientRectangle;
            base.OnSizeChanged(e);
            if (rect.Width == 0 || rect.Height == 0) return;
            ScrollBar?.SizeChange(rect);
        }

        #region Mouse Events

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (ScrollBar != null && ScrollBar.MouseDown(e.X, e.Y)) { OnTouchDown(e.X, e.Y); return; }
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (ScrollBar != null && ScrollBar.MouseMove(e.X, e.Y) && OnTouchMove(e.X, e.Y)) return;
            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            ScrollBar?.MouseUp();
            OnTouchUp();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            ScrollBar?.Leave();
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            ScrollBar?.Leave();
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            ScrollBar?.MouseWheel(e);
            base.OnMouseWheel(e);
        }

        #endregion

        #region Touch Scroll

        protected override bool OnTouchScrollX(int value)
        {
            if (ScrollBar != null && ScrollBar.EnabledX) return ScrollBar.MouseWheelXCore(value);
            return false;
        }

        protected override bool OnTouchScrollY(int value)
        {
            if (ScrollBar != null && ScrollBar.EnabledY) return ScrollBar.MouseWheelYCore(value);
            return false;
        }

        #endregion

        #region Control Focus Events

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            e.Control!.GotFocus += Control_GotFocus;
        }

        protected override void OnControlRemoved(ControlEventArgs e)
        {
            base.OnControlRemoved(e);
            e.Control!.GotFocus -= Control_GotFocus;
        }

        private void Control_GotFocus(object? sender, EventArgs e)
        {
            if (sender is Control control) ScrollControlIntoView(control);
        }

        #endregion

        #region Scroll Control Into View

        /// <summary>
        /// Scrolls the specified control into view
        /// </summary>
        /// <param name="activeControl">The control to scroll into view</param>
        public void ScrollControlIntoView(Control activeControl)
        {
            if (ScrollBar == null) return;
            if (ScrollBar.Show)
            {
                Rectangle clientRect = ClientRectangle, controlRect = activeControl.Bounds;
                
                // Handle vertical scrolling
                if (ScrollBar.EnabledY)
                {
                    if (controlRect.Top < clientRect.Top) 
                        ScrollBar.ValueY = Math.Max(0, ScrollBar.ValueY + controlRect.Top - clientRect.Top);
                    else if (controlRect.Bottom > clientRect.Bottom) 
                        ScrollBar.ValueY = Math.Min(ScrollBar.MaxY, ScrollBar.ValueY + controlRect.Bottom - clientRect.Bottom);
                }
                
                // Handle horizontal scrolling
                if (ScrollBar.EnabledX)
                {
                    if (controlRect.Left < clientRect.Left) 
                        ScrollBar.ValueX = Math.Max(0, ScrollBar.ValueX + controlRect.Left - clientRect.Left);
                    else if (controlRect.Right > clientRect.Right) 
                        ScrollBar.ValueX = Math.Min(ScrollBar.MaxX, ScrollBar.ValueX + controlRect.Right - clientRect.Right);
                }
            }
        }

        #endregion

        #region Dispose

        protected override void Dispose(bool disposing)
        {
            foreach (Control c in Controls) c.GotFocus -= Control_GotFocus;
            ScrollBar?.Dispose();
            base.Dispose(disposing);
        }

        #endregion
    }
}
