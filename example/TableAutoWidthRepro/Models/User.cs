// Copyright (C) zamzami16. All Rights Reserved.
// AntdUI WinForm Library | Licensed under Apache-2.0 License

using System;

namespace TableAutoWidthRepro.Models
{
    public class User
    {
        public int NO { get; set; }
        public string NAME { get; set; } = string.Empty;
        public string ADDRESS { get; set; } = string.Empty;
        public string NOTE { get; set; } = string.Empty;
        public string EMAIL { get; set; } = string.Empty;
        public string PHONE { get; set; } = string.Empty;
        public DateTime CREATED_AT { get; set; }
        public bool IS_ACTIVE { get; set; }
        public string DEPARTMENT { get; set; } = string.Empty;
        public string CITY { get; set; } = string.Empty;
    }
}
