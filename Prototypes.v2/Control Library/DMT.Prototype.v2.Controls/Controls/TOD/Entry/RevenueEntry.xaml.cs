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
            qrCode.DateQR = new DateTime(2020, 6, 16, 18, 50, 11);
            qrCode.ApprovalCode = "25478454";
            qrCode.Qty = 80;
            qrCodes.Add(qrCode);

            qrCode = new Models.QRCodeEntry();
            qrCode.DateQR = new DateTime(2020, 6, 16, 23, 15, 24);
            qrCode.ApprovalCode = "12547899";
            qrCode.Qty = 110;
            qrCodes.Add(qrCode);

            qrCode = new Models.QRCodeEntry();
            qrCode.DateQR = new DateTime(2020, 6, 17, 12, 1, 47);
            qrCode.ApprovalCode = "97845671";
            qrCode.Qty = 80;
            qrCodes.Add(qrCode);

            qrcodeEntry.Setup(qrCodes,"3","270");

        }

        private void EMV()
        {
            List<Models.EMV> emvs = new List<Models.EMV>();
            Models.EMV emv;

            emv = new Models.EMV();
            emv.DateQR = new DateTime(2020, 6, 16, 18, 50, 11);
            emv.ApprovalCode = "26587498";
            emv.Qty = 80;
            emvs.Add(emv);

            emv = new Models.EMV();
            emv.DateQR = new DateTime(2020, 6, 16, 23, 15, 24);
            emv.ApprovalCode = "65874254";
            emv.Qty = 110;
            emvs.Add(emv);

            emv = new Models.EMV();
            emv.DateQR = new DateTime(2020, 6, 17, 12, 1, 47);
            emv.ApprovalCode = "57487487";
            emv.Qty = 110;
            emvs.Add(emv);

            emv = new Models.EMV();
            emv.DateQR = new DateTime(2020, 6, 17, 23, 15, 24);
            emv.ApprovalCode = "97458742";
            emv.Qty = 80;
            emvs.Add(emv);

            emv = new Models.EMV();
            emv.DateQR = new DateTime(2020, 6, 18, 12, 1, 47);
            emv.ApprovalCode = "13542741";
            emv.Qty = 110;
            emvs.Add(emv);

            emvEntry.Setup(emvs,"5","490");

        }
    }
}
