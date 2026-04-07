// Copyright (C) zamzami16. All Rights Reserved.
// AntdUI WinForm Library | Licensed under Apache-2.0 License

using System;
using System.Windows.Forms;

namespace TableAutoWidthRepro
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}
