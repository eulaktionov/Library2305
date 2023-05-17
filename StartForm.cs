using static Library2305.Properties.Resources;

namespace Library2305
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
            Load += (s, e) => Start();
            FormClosed += (s, e) => End();
        }

        void Start()
        {
            (Text, Icon) = (AppTitle, AppIcon);
            IsMdiContainer = true;
            WindowState = FormWindowState.Maximized;
        }

        void End()
        {

        }
    }
}