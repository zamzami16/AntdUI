// Copyright (C) zamzami16. All Rights Reserved.
// AntdUI WinForm Library | Licensed under Apache-2.0 License

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TableAutoWidthRepro.Models;

namespace TableAutoWidthRepro
{
    public class MainForm : AntdUI.BaseForm
    {
        private AntdUI.Table table;
        private Panel topPanel;
        private AntdUI.Button btnReload;
        private AntdUI.Button btnToggleWidth;
        private Label lblWidthPixel;
        private bool _isNarrow = false;
        private const int WideWidth = 1100;
        private const int NarrowWidth = 650;

        public MainForm()
        {
            Text = "AntdUI Table — Auto Width Repro (NOTE: Width=auto, MinWidth=100, MaxWidth=300)";
            ClientSize = new Size(WideWidth, 600);
            StartPosition = FormStartPosition.CenterScreen;

            BuildTopPanel();
            BuildTable();

            LoadData();
        }

        private void BuildTopPanel()
        {
            topPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 48,
                Padding = new Padding(8, 8, 8, 4)
            };

            btnReload = new AntdUI.Button
            {
                Text = "Reload Data",
                Width = 110,
                Height = 32,
                Location = new Point(8, 8)
            };
            btnReload.Click += (s, e) => LoadData();

            btnToggleWidth = new AntdUI.Button
            {
                Text = "Toggle Form Width (narrow/wide)",
                Width = 230,
                Height = 32,
                Location = new Point(126, 8)
            };
            btnToggleWidth.Click += (s, e) => ToggleWidth();

            lblWidthPixel = new Label
            {
                Text = "NOTE WidthPixel: (pending)",
                AutoSize = true,
                Location = new Point(364, 14),
                Font = new Font("Segoe UI", 9.5f)
            };

            topPanel.Controls.Add(btnReload);
            topPanel.Controls.Add(btnToggleWidth);
            topPanel.Controls.Add(lblWidthPixel);

            Controls.Add(topPanel);
        }

        private void BuildTable()
        {
            table = new AntdUI.Table
            {
                Dock = DockStyle.Fill,
                Bordered = true,
                Columns = new AntdUI.ColumnCollection
                {
                    new AntdUI.Column("NO",      "NO",      AntdUI.ColumnAlign.Center) { Width = "60"  },
                    new AntdUI.Column("NAME",    "NAME")    { Width = "160" },
                    new AntdUI.Column("ADDRESS", "ADDRESS") { Width = "220" },
                    new AntdUI.Column("NOTE",    "NOTE")
                    {
                        Width    = "auto",
                        MinWidth = "100",
                        MaxWidth = "300"
                    },
                }
            };

            Controls.Add(table);
        }

        private void LoadData()
        {
            table.DataSource = GenerateData();
            BeginInvoke(UpdateDebugLabel);
        }

        private void ToggleWidth()
        {
            _isNarrow = !_isNarrow;
            Width = _isNarrow ? NarrowWidth : WideWidth;
        }

        private void UpdateDebugLabel()
        {
            // Find the NOTE column and read its computed WidthPixel
            if (table.Columns == null) return;
            foreach (var col in table.Columns)
            {
                if (col.Key == "NOTE")
                {
                    lblWidthPixel.Text =
                        $"NOTE WidthPixel: {col.WidthPixel}px  |  " +
                        $"Form ClientWidth: {ClientSize.Width}px";
                    return;
                }
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            BeginInvoke(UpdateDebugLabel);
        }

        protected override void OnResizeEnd(EventArgs e)
        {
            base.OnResizeEnd(e);
            BeginInvoke(UpdateDebugLabel);
        }

        // ---------------------------------------------------------------
        // Data generation
        // NOTE strings are tuned so measured auto-width is ~250–290 px,
        // which is > MinWidth(100) and < MaxWidth(300).
        // ---------------------------------------------------------------
        private static List<User> GenerateData()
        {
            var names = new[] {
                "Alice Johnson", "Bob Smith", "Carol White", "Dave Brown", "Eve Davis",
                "Frank Wilson", "Grace Lee", "Henry Taylor", "Irene Martin", "Jack Anderson"
            };
            var cities = new[] {
                "Jakarta", "Surabaya", "Bandung", "Medan", "Semarang",
                "Makassar", "Palembang", "Tangerang", "Depok", "Bekasi"
            };
            var departments = new[] {
                "Engineering", "Marketing", "Finance", "HR", "Operations"
            };

            // Mid-length NOTE strings: with a ~12px-per-char font they produce
            // roughly 250–290 px, staying under MaxWidth=300 but above MinWidth=100.
            var notes = new[] {
                "Review quarterly financial performance and prepare summary report",
                "Coordinate with design team regarding UI component specifications",
                "Update project documentation and share with stakeholders",
                "Follow up on client feedback from last week's demonstration",
                "Schedule sync meeting to discuss deployment pipeline issues",
                "Analyze user behavior data and prepare recommendation deck",
                "Prepare onboarding materials for the new engineering hires",
                "Submit expense claims for the regional conference attendance",
                "Complete code review for the payment module pull request",
                "Draft communication plan for the upcoming product launch event",
            };

            var data = new List<User>(100);
            var rnd = new Random(42);
            for (int i = 0; i < 100; i++)
            {
                data.Add(new User
                {
                    NO         = i + 1,
                    NAME       = names[i % names.Length],
                    ADDRESS    = $"{100 + i} {cities[i % cities.Length]} Street, Block {(char)('A' + i % 10)}",
                    NOTE       = notes[i % notes.Length],
                    EMAIL      = $"user{i + 1:D3}@example.com",
                    PHONE      = $"+62-{800_000_000 + rnd.Next(99_999_999):D9}",
                    CREATED_AT = DateTime.Today.AddDays(-rnd.Next(365)),
                    IS_ACTIVE  = rnd.Next(2) == 1,
                    DEPARTMENT = departments[i % departments.Length],
                    CITY       = cities[i % cities.Length],
                });
            }
            return data;
        }
    }
}
