// Copyright (C) Tom <17379620>. All Rights Reserved.
// AntdUI WinForm Library | Licensed under Apache-2.0 License
// Gitee: https://gitee.com/AntdUI/AntdUI
// GitHub: https://github.com/AntdUI/AntdUI
// GitCode: https://gitcode.com/AntdUI/AntdUI

namespace Demo.Controls;

partial class ScrollablePanel
{
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        panelBase = new AntdUI.Panel();
        SuspendLayout();
        // 
        // panelBase
        // 
        panelBase.AutoScroll = true;
        panelBase.Dock = System.Windows.Forms.DockStyle.Fill;
        panelBase.Location = new System.Drawing.Point(0, 0);
        panelBase.Name = "panelBase";
        panelBase.Size = new System.Drawing.Size(682, 427);
        panelBase.TabIndex = 0;
        panelBase.Text = "panel1";
        // 
        // ScrollabelPanel
        // 
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
        Controls.Add(panelBase);
        Name = "ScrollabelPanel";
        Size = new System.Drawing.Size(682, 427);
        ResumeLayout(false);
    }

    #endregion

    private AntdUI.Panel panelBase;
}
