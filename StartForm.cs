using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics;

using static Library2305.Properties.Resources;
using Microsoft.EntityFrameworkCore;

namespace Library2305
{
    public partial class StartForm : System.Windows.Forms.Form
    {
        AppMenu? menu;
        readonly Data? data;

        public StartForm()
        {
            InitializeComponent();

            data = new ContextFactory().CreateDbContext(Array.Empty<string>());
            data?.Authors.Load();
            data?.Books.Load();
            data?.Readers.Load();
            data?.Records.Load();

            Load += (s, e) => Start();
            FormClosed += (s, e) => End();
        }

        void Start()
        {
            (Text, Icon) = (AppTitle, AppIcon);
            MakeMenu();
            IsMdiContainer = true;
            //WindowState = FormWindowState.Maximized;
        }

        void MakeMenu()
        {
            menu = new()
            {
                Open = OpenInnerForm,
                Save = Save,
                Exit = () => Close()
            };
            Controls.Add(menu);
        }

        void OpenInnerForm(AppForm id)
        {
            DataForm? form = MdiChildren?
                .Select(f => f as DataForm)
                .FirstOrDefault(f => f!.Id == id);

            if(form == null)
            {
                form = new(id, data);
                form.MdiParent = this;
                form.Show();
            }

            if(form.WindowState == FormWindowState.Minimized)
            {
                form.WindowState = FormWindowState.Normal;
            }
            form.Activate();
        }

        void Save()
        {
            Debug.WriteLine("Save data!");
            data?.SaveChanges();
        }

        void End()
        {
            Save();
        }
    }
}