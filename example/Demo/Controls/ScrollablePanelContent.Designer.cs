// Copyright (C) Tom <17379620>. All Rights Reserved.
// AntdUI WinForm Library | Licensed under Apache-2.0 License
// Gitee: https://gitee.com/AntdUI/AntdUI
// GitHub: https://github.com/AntdUI/AntdUI
// GitCode: https://gitcode.com/AntdUI/AntdUI

namespace Demo.Controls;

partial class ScrollablePanelContent
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
        label1 = new AntdUI.Label();
        label2 = new AntdUI.Label();
        SuspendLayout();
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(3, 3);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(75, 23);
        label1.TabIndex = 0;
        label1.Text = "label1";
        // 
        // label2
        // 
        label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        label2.Location = new System.Drawing.Point(1842, 1054);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(75, 23);
        label2.TabIndex = 1;
        label2.Text = "label2";
        // 
        // ScrollabelPanelContent
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        Controls.Add(label2);
        Controls.Add(label1);
        Name = "ScrollabelPanelContent";
        Size = new System.Drawing.Size(1920, 1080);
        ResumeLayout(false);
    }

    #endregion

    private AntdUI.Label label1;
    private AntdUI.Label label2;
}
