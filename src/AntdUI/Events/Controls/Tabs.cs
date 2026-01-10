// Copyright (C) Tom <17379620>. All Rights Reserved.
// AntdUI WinForm Library | Licensed under Apache-2.0 License
// Gitee: https://gitee.com/AntdUI/AntdUI
// GitHub: https://github.com/AntdUI/AntdUI
// GitCode: https://gitcode.com/AntdUI/AntdUI

using System.ComponentModel;
using System.Windows.Forms;

namespace AntdUI
{
    public class ClosingPageEventArgs : VEventArgs<TabPage>
    {
        public ClosingPageEventArgs(TabPage value) : base(value) { }
    }

    public delegate bool ClosingPageEventHandler(object sender, ClosingPageEventArgs e);

    /// <summary>
    /// Provides data for the SelectedIndexChanging event
    /// </summary>
    public class TabIndexChangingEventArgs : CancelEventArgs
    {
        /// <summary>
        /// Gets the current selected index before change
        /// </summary>
        public int OldIndex { get; }

        /// <summary>
        /// Gets the new index that will be selected if not cancelled
        /// </summary>
        public int NewIndex { get; }

        public TabIndexChangingEventArgs(int oldIndex, int newIndex)
        {
            OldIndex = oldIndex;
            NewIndex = newIndex;
        }
    }

    /// <summary>
    /// Represents the method that will handle the SelectedIndexChanging event
    /// </summary>
    public delegate void TabIndexChangingEventHandler(object sender, TabIndexChangingEventArgs e);

    public class TabsItemEventArgs : VMEventArgs<TabPage>
    {
        public TabsItemEventArgs(TabPage item, int index, Tabs.IStyle style, MouseEventArgs e) : base(item, e)
        {
            Index = index;
            Style = style;
        }

        public int Index { get; private set; }

        public Tabs.IStyle Style { get; private set; }

        /// <summary>
        /// 是否取消
        /// </summary>
        public bool Cancel { get; set; }

        #region 设置

        public TabsItemEventArgs SetCancel(bool value = true)
        {
            Cancel = value;
            return this;
        }

        #endregion
    }

    /// <summary>
    /// 点击事件
    /// </summary>
    public delegate void TabsItemEventHandler(object sender, TabsItemEventArgs e);
}