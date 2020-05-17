#region Using

using System;
using System.Security.Principal;
using System.Windows;
using NLib.Services;

#endregion

using DMT.Models;

namespace DMT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        #endregion

        #region Load/Unload

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Initial Page Content Manager
            PageContentManager.Instance.ContentChanged += new EventHandler(Instance_ContentChanged);
            PageContentManager.Instance.StatusUpdated += new StatusMessageEventHandler(Instance_StatusUpdated);
            PageContentManager.Instance.OnTick += new EventHandler(Instance_OnTick);
            PageContentManager.Instance.Start();
            // Init Main Menu
            //PageContentManager.Instance.Current = new Pages.TASignInPage();

            // Test Json Code.
            System.Collections.Generic.List<X> list = X.getTests();
            string fileName = Json.LocalFile("sample.json");

            //string json = list.ToJson();
            //Console.WriteLine(json);

            if (!list.SaveToFile(fileName))
            {
                Console.WriteLine("Cannot save file.");
            }

            System.Collections.Generic.List<X> list2;
            list2 = Json.LoadFromFile<System.Collections.Generic.List<X>>(fileName);
            Console.WriteLine(list2);
            Console.WriteLine(list2.ToJson());
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            // Release Page Content Manager
            PageContentManager.Instance.Shutdown();
            PageContentManager.Instance.OnTick -= new EventHandler(Instance_OnTick);
            PageContentManager.Instance.StatusUpdated -= new StatusMessageEventHandler(Instance_StatusUpdated);
            PageContentManager.Instance.ContentChanged -= new EventHandler(Instance_ContentChanged);
        }

        #endregion

        #region Page Content Manager Handlers

        void Instance_OnTick(object sender, EventArgs e)
        {
            //UpdateTime();
            //UpdateConnectionStatus();
        }

        void Instance_StatusUpdated(object sender, StatusMessageEventArgs e)
        {
            //txtStatus.Text = e.Message;
        }

        void Instance_ContentChanged(object sender, EventArgs e)
        {
            this.container.Content = PageContentManager.Instance.Current;
        }

        #endregion
    }
}
