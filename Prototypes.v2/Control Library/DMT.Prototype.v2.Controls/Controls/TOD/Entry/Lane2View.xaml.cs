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
    /// Interaction logic for Lane2View.xaml
    /// </summary>
    public partial class Lane2View : UserControl
    {
        public Lane2View()
        {
            InitializeComponent();
        }

        public void Setup(List<Models.Lane> lanes) 
        {
            listView.ItemsSource = lanes;
        }
    }
}
