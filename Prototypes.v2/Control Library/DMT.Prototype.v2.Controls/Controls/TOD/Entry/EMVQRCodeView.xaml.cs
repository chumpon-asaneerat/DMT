﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DMT.Controls
{
    /// <summary>
    /// Interaction logic for LaneView.xaml
    /// </summary>
    public partial class EMVQRCodeView : UserControl
    {
        public EMVQRCodeView()
        {
            InitializeComponent();
        }

        public void Setup(List<Models.EMVQRCode> lanes) 
        {
            listView.ItemsSource = lanes;
        }
    }
}
