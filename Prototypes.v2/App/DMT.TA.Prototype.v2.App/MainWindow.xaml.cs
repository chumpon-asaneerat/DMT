#region Using

using System;
using System.Security.Principal;
using System.Windows;
using NLib.Services;

#endregion

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
            /*
            System.Collections.Generic.List<X> list = X.getTests();
            string json = list.ToJson();

            Console.WriteLine(json);

            string fileName = Json.LocalFile("sample.json");
            Json.SaveToFile(list, fileName);
            */
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

        class X
        {
            public string account { get; set; }
            public DateTime logindate { get; set; }

            public static System.Collections.Generic.List<X> getTests()
            {
                System.Collections.Generic.List<X> list = new System.Collections.Generic.List<X>();
                Random r = new Random();
                X inst;
                inst = new X();
                inst.account = "aaa";
                inst.logindate = DateTime.Now;
                list.Add(inst);
                inst = new X();
                inst.account = "bbb";
                inst.logindate = DateTime.Now.AddMilliseconds(r.Next(999));
                list.Add(inst);
                inst = new X();
                inst.account = "ccc";
                inst.logindate = DateTime.Now.AddMilliseconds(r.Next(999));
                list.Add(inst);

                return list;
            }
        }
    }
}
