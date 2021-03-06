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
using System.Windows.Shapes;

namespace DMT.Windows.TOD.Job
{
    /// <summary>
    /// Interaction logic for EOJWindow.xaml
    /// </summary>
    public partial class EOJWindow : Window
    {
        public EOJWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtDate.Text = DateTime.Now.ToThaiDateString();
            txtTime.Text = DateTime.Now.ToThaiTimeString();
            txtShiftId.Text = (null != this.Job) ? this.Job.ShiftId.ToString() : string.Empty;
        }

        private void cmdOK_Click(object sender, RoutedEventArgs e)
        {
            if (null != this.Job)
            {
                this.Job.EndJob();
            }
            DialogResult = true;
        }

        private void cmdCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        public Models.Job Job { get; set; }
    }
}
