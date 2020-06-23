using System;
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
using System.Collections;

namespace DMT.Controls
{
    /// <summary>
    /// Interaction logic for LaneView.xaml
    /// </summary>
    public partial class LoginList2View : UserControl
    {
        public LoginList2View()
        {
            InitializeComponent();
        }

        private string staffId = string.Empty;

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
                            if (((Models.Lane)(listView.CurrentCell.Item)).StaffId != null)
                            {
                                staffId = ((Models.Lane)(listView.CurrentCell.Item)).StaffId;

                                SelectData(staffId);
                            }
                        }
                    }
                }
                else
                {
                    staffId = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SelectData(string staffId)
        {
            try
            {
                List<Models.LaneDetail> lanes = new List<Models.LaneDetail>();
                Models.LaneDetail lane;

                if (!string.IsNullOrEmpty(staffId))
                {
                    if (staffId == "14077")
                    {
                        lane = new Models.LaneDetail();
                        lane.Begin = new DateTime(2020, 6, 16, 08, 00, 00);
                        lane.StaffId = "14077";
                        lane.JobNo = "14004";
                        lane.LaneId = 1;
                        lanes.Add(lane);
                    }
                    else if (staffId == "14055")
                    {
                        lane = new Models.LaneDetail();
                        lane.Begin = new DateTime(2020, 6, 16, 01, 50, 11);
                        lane.End = new DateTime(2020, 6, 16, 08, 00, 11);
                        lane.StaffId = "14055";
                        lane.JobNo = "14524";
                        lane.LaneId = 1;
                        lane.DateTOD = new DateTime(2020, 6, 16, 10, 00, 11);
                        lanes.Add(lane);

                        lane = new Models.LaneDetail();
                        lane.Begin = new DateTime(2020, 6, 16, 08, 11, 10);
                        lane.End = new DateTime(2020, 6, 16, 10, 00, 20);
                        lane.StaffId = "14055";
                        lane.JobNo = "57484";
                        lane.LaneId = 1;
                        lane.DateTOD = new DateTime(2020, 6, 16, 10, 00, 00);
                        lanes.Add(lane);

                        lane = new Models.LaneDetail();
                        lane.Begin = new DateTime(2020, 6, 16, 11, 01, 10);
                        lane.End = new DateTime(2020, 6, 16, 22, 00, 20);
                        lane.StaffId = "14055";
                        lane.JobNo = "14535";
                        lane.LaneId = 2;
                        lanes.Add(lane);
                    }
                    else if (staffId == "14147")
                    {
                        lane = new Models.LaneDetail();
                        lane.Begin = new DateTime(2020, 6, 17, 00, 50, 11);
                        lane.End = new DateTime(2020, 6, 17, 06, 00, 11);
                        lane.StaffId = "14147";
                        lane.JobNo = "54524";
                        lane.LaneId = 3;
                        lane.DateTOD = new DateTime(2020, 6, 17, 10, 00, 11);
                        lanes.Add(lane);

                        lane = new Models.LaneDetail();
                        lane.Begin = new DateTime(2020, 6, 17, 10, 15, 24);
                        lane.End = new DateTime(2020, 6, 17, 18, 20, 20);
                        lane.StaffId = "14147";
                        lane.JobNo = "55484";
                        lane.LaneId = 4;
                        lanes.Add(lane);

                        lane = new Models.LaneDetail();
                        lane.Begin = new DateTime(2020, 6, 17, 19, 01, 10);
                        lane.End = new DateTime(2020, 6, 18, 01, 00, 20);
                        lane.StaffId = "14147";
                        lane.JobNo = "34535";
                        lane.LaneId = 5;
                        lanes.Add(lane);
                    }
                    else if (staffId == "12562")
                    {
                        lane = new Models.LaneDetail();
                        lane.Begin = new DateTime(2020, 6, 17, 12, 01, 47);
                        lane.End = new DateTime(2020, 6, 17, 23, 00, 00);
                        lane.StaffId = "12562";
                        lane.JobNo = "24524";
                        lane.LaneId = 2;
                        lanes.Add(lane);

                    }

                    listViewUse.ItemsSource = lanes;
                }
                else
                {
                    listViewUse.ItemsSource = lanes;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        public void Setup(List<Models.Lane> lanes) 
        {
            listView.ItemsSource = lanes;
            staffId = string.Empty;
        }
    }
}
