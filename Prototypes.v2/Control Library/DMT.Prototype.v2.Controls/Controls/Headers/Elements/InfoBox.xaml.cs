#region Using

using System.Windows;
using System.Windows.Controls;

#endregion

namespace DMT.Controls.Headers.Elements
{
    /// <summary>
    /// Interaction logic for InfoBox.xaml
    /// </summary>
    public partial class InfoBox : UserControl
    {
        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        public InfoBox()
        {
            InitializeComponent();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets caption text.
        /// </summary>
        public string Caption
        {
            get { return (string)GetValue(CaptionProperty); }
            set { SetValue(CaptionProperty, value); }
        }

        #endregion

        #region Public Static Properties

        /// <summary>
        /// sing a DependencyProperty as the backing store for Caption Property.
        /// </summary>
        public static readonly DependencyProperty CaptionProperty = DependencyProperty.Register("Caption", typeof(string), typeof(InfoBox), new UIPropertyMetadata(""));

        #endregion
    }
}
