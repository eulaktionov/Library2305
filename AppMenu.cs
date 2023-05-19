using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library2305
{
    public enum AppForm
    {
        Authors,
        Books,
        Readers,
        Records
    }
    internal class AppMenu : MenuStrip
    {
        public Action<AppForm>? Open { get; init; }
        public Action? Save { get; init; }
        public Action? Exit { get; init; }

        public AppMenu() => Items.AddRange(new ToolStripItem[]
        {
            new ToolStripMenuItem("&Readers", null, new ToolStripItem[]
            {
                new ToolStripMenuItem("&Records", null,
                    (s, e) => Open?.Invoke(AppForm.Records)),
                new ToolStripMenuItem("&Readers", null,
                    (s, e) => Open?.Invoke(AppForm.Readers)),
                new ToolStripSeparator(),
                new ToolStripMenuItem("&Save", null,
                    (s, e) => Save?.Invoke(), Keys.Control | Keys.S),
                new ToolStripSeparator(),
                new ToolStripMenuItem("&Exit", null,
                    (s, e) => Exit?.Invoke())
            }),
            new ToolStripMenuItem("&Books", null, new ToolStripItem[]
            {
                new ToolStripMenuItem("&Authors", null,
                    (s, e) => Open?.Invoke(AppForm.Authors)),
                new ToolStripMenuItem("&Books", null,
                    (s, e) => Open?.Invoke(AppForm.Books))
            })
        });
    }
}
