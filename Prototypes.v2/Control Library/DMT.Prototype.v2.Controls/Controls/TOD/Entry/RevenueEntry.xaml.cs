using System;
using System.Collections.Generic;
using System.Windows.Controls;

using DMT;

namespace DMT.Controls
{
    /// <summary>
    /// Interaction logic for RevenueEntry.xaml
    /// </summary>
    public partial class RevenueEntry : UserControl
    {
        public RevenueEntry()
        {
            InitializeComponent();

            QRCode();
        }

        private Models.Job _job;
        private Models.RevenueEntry _entry;

        public void Setup(Models.Job job, Models.RevenueEntry entry)
        {
            _job = job;
            _entry = entry;
            if (null != _entry)
            {
                this.DataContext = _entry;
                trafficRevenue.DataContext = _entry.Traffic;
                otherRevenue.DataContext = _entry.Other;
                couponUsage.DataContext = _entry.CouponUsage;
                couponRevenue.DataContext = _entry.CouponRevenue;
            }

            QRCode();
            EMV();
        }

        private void QRCode()
        {
            List<Models.QRCodeEntry> qrCodes = new List<Models.QRCodeEntry>();
            Models.QRCodeEntry qrCode;

            qrCode = new Models.QRCodeEntry();
            qrCode.DateQR = new DateTime(2020, 3, 16, 18, 50, 11);
            qrCode.ApprovalCode = "14055";
            qrCode.Qty = 6;
            qrCodes.Add(qrCode);

            qrCode = new Models.QRCodeEntry();
            qrCode.DateQR = new DateTime(2020, 3, 16, 23, 15, 24);
            qrCode.ApprovalCode = "14147";
            qrCode.Qty = 4;
            qrCodes.Add(qrCode);

            qrCode = new Models.QRCodeEntry();
            qrCode.DateQR = new DateTime(2020, 3, 17, 12, 1, 47);
            qrCode.ApprovalCode = "12562";
            qrCode.Qty = 9;
            qrCodes.Add(qrCode);

            qrcodeEntry.Setup(qrCodes);

        }

        private void EMV()
        {
            List<Models.EMV> emvs = new List<Models.EMV>();
            Models.EMV emv;

            emv = new Models.EMV();
            emv.DateQR = new DateTime(2020, 3, 16, 18, 50, 11);
            emv.ApprovalCode = "201568";
            emv.Qty = 60;
            emvs.Add(emv);

            emv = new Models.EMV();
            emv.DateQR = new DateTime(2020, 3, 16, 23, 15, 24);
            emv.ApprovalCode = "205468";
            emv.Qty = 104;
            emvs.Add(emv);

            emv = new Models.EMV();
            emv.DateQR = new DateTime(2020, 3, 17, 12, 1, 47);
            emv.ApprovalCode = "225620";
            emv.Qty = 90;
            emvs.Add(emv);

            emvEntry.Setup(emvs);

        }
    }
}
