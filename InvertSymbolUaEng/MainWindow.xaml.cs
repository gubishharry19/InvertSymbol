using System;
using System.Windows;
using System.Windows.Forms;

namespace InvertSymbolUaEng
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal NotifyIcon notifyIcon;
        private ContextMenu contextMenu;
        private MenuItem menuItem;
        public MainWindow()
        {
            InitializeComponent();
            new Present(this);
            WindowState = (WindowState)FormWindowState.Minimized;
            ShowInTaskbar = false;
            notifyIcon = new NotifyIcon(); // Declaration 
            contextMenu = new ContextMenu();
            menuItem = new MenuItem();
            // Initialize contextMenu
            contextMenu.MenuItems.AddRange(
                        new MenuItem[] { menuItem });
            // Initialize menuItem
            menuItem.Index = 0;
            menuItem.Text = "Exit";
            menuItem.Click += new System.EventHandler(menuItem1_Click);

            //Initialize notifyIcon
            notifyIcon.Visible = true;
            notifyIcon.ContextMenu = contextMenu;
            notifyIcon.Icon = new System.Drawing.Icon("../../NotifyIcon.ico"); // Shown Icon 
        }

        private void menuItem1_Click(object Sender, EventArgs e)
        {
            // Close the form, which closes the application.
            this.Close();
        }

        private void ShowForm()
        {
            base.Show();
            base.WindowState = 0;
        }

        public event EventHandler ActionConvert = null;
        private void Button_Click_Convert(object sender, RoutedEventArgs e)
        {
            ActionConvert.Invoke(sender, e);
        }
    }
}
