using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

using NLib;
using NLib.Services;
using System.Collections;


namespace DMT.Pages.TA.Coupon
{
    /// <summary>
    /// Interaction logic for CouponReturnPage.xaml
    /// </summary>
    public partial class CouponReturnPage : UserControl
    {
        public CouponReturnPage()
        {
            InitializeComponent();
        }

        private string cop35 = string.Empty;
        private string copU35 = string.Empty;
        private string cop80 = string.Empty;
        private string copU80 = string.Empty;

        #region Button
        private void cmdCancel_Click(object sender, RoutedEventArgs e)
        {
            // Main Menu Page
            var page = new TA.MainMenu();
            PageContentManager.Instance.Current = page;
        }

        private void cmdOk_Click(object sender, RoutedEventArgs e)
        {
            // Main Menu Page
            var page = new TA.MainMenu();
            PageContentManager.Instance.Current = page;
        }

        private void btnNext35_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(cop35))
            {
                List<Models.CouponUser35> results35 = new List<Models.CouponUser35>();
                Models.CouponUser35 inst35 = null;

                foreach (Models.CouponUser35 row in _couponUser35)
                {
                    inst35 = new Models.CouponUser35();

                    inst35.CouponCode = row.CouponCode;
                    results35.Add(inst35);
                }

                if (results35 != null && results35.Count > 0)
                {
                    bool chkCop = true;

                    foreach (Models.CouponUser35 row in _couponUser35)
                    {
                        if (row.CouponCode == cop35)
                        {
                            chkCop = false;
                            break;
                        }
                    }

                    if (chkCop == true)
                    {
                        Models.CouponUser35 couponUser35;

                        couponUser35 = new Models.CouponUser35();
                        couponUser35.CouponCode = cop35;
                        results35.Add(couponUser35);

                    }

                    _couponUser35 = results35;
                    listViewUse.ItemsSource = _couponUser35;
                }
                else
                {
                    Models.CouponUser35 couponUser35;

                    couponUser35 = new Models.CouponUser35();
                    couponUser35.CouponCode = cop35;
                    results35.Add(couponUser35);

                    _couponUser35 = results35;

                    listViewUse.ItemsSource = _couponUser35;
                }

                List<Models.Coupon35> results = new List<Models.Coupon35>();
                Models.Coupon35 inst = null;

                foreach (Models.Coupon35 row in _coupon35)
                {
                    if (row.CouponCode != cop35)
                    {
                        inst = new Models.Coupon35();

                        inst.CouponCode = row.CouponCode;
                        results.Add(inst);
                    }
                }

                if (results != null && results.Count > 0)
                {
                    _coupon35 = results;
                    listView.ItemsSource = _coupon35;
                }
                else
                {
                    _coupon35 = new List<Models.Coupon35>();
                    listView.ItemsSource = _coupon35;
                }


                if (this.listView.SelectionMode != DataGridSelectionMode.Single) //if the Extended mode
                    this.listView.SelectedItems.Clear();
                else
                    this.listView.SelectedItem = null;

                cop35 = string.Empty;

                CalCoupon35();
            }
        }

        private void btnBack35_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(copU35))
            {
                List<Models.Coupon35> results = new List<Models.Coupon35>();
                Models.Coupon35 inst = null;

                foreach (Models.Coupon35 row in _coupon35)
                {
                    inst = new Models.Coupon35();

                    inst.CouponCode = row.CouponCode;
                    results.Add(inst);
                }

                if (results != null && results.Count > 0)
                {
                    bool chkCop = true;

                    foreach (Models.Coupon35 row in _coupon35)
                    {
                        if (row.CouponCode == copU35)
                        {
                            chkCop = false;
                            break;
                        }
                    }

                    if (chkCop == true)
                    {
                        Models.Coupon35 coupon35;

                        coupon35 = new Models.Coupon35();
                        coupon35.CouponCode = copU35;
                        results.Add(coupon35);

                    }

                    _coupon35 = results;
                    listView.ItemsSource = _coupon35;
                }
                else
                {
                    Models.Coupon35 coupon35;

                    coupon35 = new Models.Coupon35();
                    coupon35.CouponCode = copU35;
                    results.Add(coupon35);

                    _coupon35 = results;

                    listView.ItemsSource = _coupon35;
                }

                List<Models.CouponUser35> resultsUser = new List<Models.CouponUser35>();
                Models.CouponUser35 instUser = null;

                foreach (Models.CouponUser35 row in _couponUser35)
                {
                    if (row.CouponCode != copU35)
                    {
                        instUser = new Models.CouponUser35();

                        instUser.CouponCode = row.CouponCode;
                        resultsUser.Add(instUser);
                    }
                }

                if (resultsUser != null && resultsUser.Count > 0)
                {
                    _couponUser35 = resultsUser;
                    listViewUse.ItemsSource = _couponUser35;
                }
                else
                {
                    _couponUser35 = new List<Models.CouponUser35>();
                    listViewUse.ItemsSource = _couponUser35;
                }


                if (this.listViewUse.SelectionMode != DataGridSelectionMode.Single) //if the Extended mode
                    this.listViewUse.SelectedItems.Clear();
                else
                    this.listViewUse.SelectedItem = null;

                copU35 = string.Empty;

                CalCoupon35();
            }
        }

        private void btnNext80_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(cop80))
            {
                List<Models.CouponUser80> results80 = new List<Models.CouponUser80>();
                Models.CouponUser80 inst80 = null;

                foreach (Models.CouponUser80 row in _couponUser80)
                {
                    inst80 = new Models.CouponUser80();

                    inst80.CouponCode = row.CouponCode;
                    results80.Add(inst80);
                }

                if (results80 != null && results80.Count > 0)
                {
                    bool chkCop = true;

                    foreach (Models.CouponUser80 row in _couponUser80)
                    {
                        if (row.CouponCode == cop80)
                        {
                            chkCop = false;
                            break;
                        }
                    }

                    if (chkCop == true)
                    {
                        Models.CouponUser80 couponUser80;

                        couponUser80 = new Models.CouponUser80();
                        couponUser80.CouponCode = cop80;
                        results80.Add(couponUser80);

                    }

                    _couponUser80 = results80;
                    listViewUse80.ItemsSource = _couponUser80;
                }
                else
                {
                    Models.CouponUser80 couponUser80;

                    couponUser80 = new Models.CouponUser80();
                    couponUser80.CouponCode = cop80;
                    results80.Add(couponUser80);

                    _couponUser80 = results80;

                    listViewUse80.ItemsSource = _couponUser80;
                }

                List<Models.Coupon80> results = new List<Models.Coupon80>();
                Models.Coupon80 inst = null;

                foreach (Models.Coupon80 row in _coupon80)
                {
                    if (row.CouponCode != cop80)
                    {
                        inst = new Models.Coupon80();

                        inst.CouponCode = row.CouponCode;
                        results.Add(inst);
                    }
                }

                if (results != null && results.Count > 0)
                {
                    _coupon80 = results;
                    listView80.ItemsSource = _coupon80;
                }
                else
                {
                    _coupon80 = new List<Models.Coupon80>();
                    listView80.ItemsSource = _coupon80;
                }


                if (this.listView80.SelectionMode != DataGridSelectionMode.Single) //if the Extended mode
                    this.listView80.SelectedItems.Clear();
                else
                    this.listView80.SelectedItem = null;

                cop80 = string.Empty;

                CalCoupon80();
            }
        }

        private void btnBack80_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(copU80))
            {
                List<Models.Coupon80> results = new List<Models.Coupon80>();
                Models.Coupon80 inst = null;

                foreach (Models.Coupon80 row in _coupon80)
                {
                    inst = new Models.Coupon80();

                    inst.CouponCode = row.CouponCode;
                    results.Add(inst);
                }

                if (results != null && results.Count > 0)
                {
                    bool chkCop = true;

                    foreach (Models.Coupon80 row in _coupon80)
                    {
                        if (row.CouponCode == copU80)
                        {
                            chkCop = false;
                            break;
                        }
                    }

                    if (chkCop == true)
                    {
                        Models.Coupon80 coupon80;

                        coupon80 = new Models.Coupon80();
                        coupon80.CouponCode = copU80;
                        results.Add(coupon80);

                    }

                    _coupon80 = results;
                    listView80.ItemsSource = _coupon80;
                }
                else
                {
                    Models.Coupon80 coupon80;

                    coupon80 = new Models.Coupon80();
                    coupon80.CouponCode = copU80;
                    results.Add(coupon80);

                    _coupon80 = results;

                    listView80.ItemsSource = _coupon80;
                }

                List<Models.CouponUser80> resultsUser = new List<Models.CouponUser80>();
                Models.CouponUser80 instUser = null;

                foreach (Models.CouponUser80 row in _couponUser80)
                {
                    if (row.CouponCode != copU80)
                    {
                        instUser = new Models.CouponUser80();

                        instUser.CouponCode = row.CouponCode;
                        resultsUser.Add(instUser);
                    }
                }

                if (resultsUser != null && resultsUser.Count > 0)
                {
                    _couponUser80 = resultsUser;
                    listViewUse80.ItemsSource = _couponUser80;
                }
                else
                {
                    _couponUser80 = new List<Models.CouponUser80>();
                    listViewUse80.ItemsSource = _couponUser80;
                }


                if (this.listViewUse80.SelectionMode != DataGridSelectionMode.Single) //if the Extended mode
                    this.listViewUse80.SelectedItems.Clear();
                else
                    this.listViewUse80.SelectedItem = null;

                copU80 = string.Empty;

                CalCoupon80();
            }
        }
        #endregion

        #region GetDataGridRows

        public IEnumerable<DataGridRow> GetDataGridRows(DataGrid grid)
        {
            var itemsSource = grid.ItemsSource as IEnumerable;
            if (null == itemsSource) yield return null;
            foreach (var item in itemsSource)
            {
                var row = grid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                if (null != row) yield return row;
            }
        }

        #endregion

        #region Datagrid
        private void listView_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                if (listView.ItemsSource != null)
                {
                    var row_list = GetDataGridRows(listView);
                    foreach (DataGridRow single_row in row_list)
                    {
                        if (single_row.IsSelected == true)
                        {
                            if (((Models.Coupon35)(listView.CurrentCell.Item)).CouponCode != null)
                            {
                                cop35 = ((Models.Coupon35)(listView.CurrentCell.Item)).CouponCode;
                            }
                        }
                    }
                }
                else
                {
                    cop35 = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void listViewUse_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                if (listViewUse.ItemsSource != null)
                {
                    var row_list = GetDataGridRows(listViewUse);
                    foreach (DataGridRow single_row in row_list)
                    {
                        if (single_row.IsSelected == true)
                        {
                            if (((Models.CouponUser35)(listViewUse.CurrentCell.Item)).CouponCode != null)
                            {
                                copU35 = ((Models.CouponUser35)(listViewUse.CurrentCell.Item)).CouponCode;
                            }
                        }
                    }
                }
                else
                {
                    copU35 = string.Empty;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void listView80_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                if (listView80.ItemsSource != null)
                {
                    var row_list = GetDataGridRows(listView80);
                    foreach (DataGridRow single_row in row_list)
                    {
                        if (single_row.IsSelected == true)
                        {
                            if (((Models.Coupon80)(listView80.CurrentCell.Item)).CouponCode != null)
                            {
                                cop80 = ((Models.Coupon80)(listView80.CurrentCell.Item)).CouponCode;
                            }
                        }
                    }
                }
                else
                {
                    cop80 = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void listViewUse80_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                if (listViewUse80.ItemsSource != null)
                {
                    var row_list = GetDataGridRows(listViewUse80);
                    foreach (DataGridRow single_row in row_list)
                    {
                        if (single_row.IsSelected == true)
                        {
                            if (((Models.CouponUser80)(listViewUse80.CurrentCell.Item)).CouponCode != null)
                            {
                                copU80 = ((Models.CouponUser80)(listViewUse80.CurrentCell.Item)).CouponCode;
                            }
                        }
                    }
                }
                else
                {
                    copU80 = string.Empty;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion

        private void CalCoupon35()
        {
            try
            {
                if (_coupon35 != null)
                {
                  txtCoupon35.Text =  _coupon35.Count.ToString("#,##0");
                }
                else
                {
                    txtCoupon35.Text = "0";
                }

                if (_couponUser35 != null)
                {
                    txtCouponU35.Text = _couponUser35.Count.ToString("#,##0");
                }
                else
                {
                    txtCouponU35.Text = "0";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CalCoupon80()
        {
            try
            {
                if (_coupon80 != null)
                {
                    txtCoupon80.Text = _coupon80.Count.ToString("#,##0");
                }
                else
                {
                    txtCoupon80.Text = "0";
                }

                if (_couponUser80 != null)
                {
                    txtCouponU80.Text = _couponUser80.Count.ToString("#,##0");
                }
                else
                {
                    txtCouponU80.Text = "0";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private List<Models.Coupon35> _coupon35 = new List<Models.Coupon35>();
        private List<Models.Coupon80> _coupon80 = new List<Models.Coupon80>();

        private List<Models.CouponUser35> _couponUser35 = new List<Models.CouponUser35>();
        private List<Models.CouponUser80> _couponUser80 = new List<Models.CouponUser80>();
        public void Setup(List<Models.Coupon35> coupon35, List<Models.CouponUser35> couponU35, List<Models.Coupon80> coupon80, List<Models.CouponUser80> couponU80)
        {
            cop35 = string.Empty;


            _coupon35 = coupon35;
            _couponUser35 = couponU35;
            _coupon80 = coupon80;
            _couponUser80 = couponU80;

            listView.ItemsSource = _coupon35;
            listViewUse.ItemsSource = _couponUser35;
            listView80.ItemsSource = _coupon80;
            listViewUse80.ItemsSource = _couponUser80;

            CalCoupon35();
            CalCoupon80();
        }

    }
}
