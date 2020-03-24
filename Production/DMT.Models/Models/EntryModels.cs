#region Using

using System;
using System.ComponentModel;
using NLib;

#endregion

namespace DMT.Models
{
	#region BagEntry

	/// <summary>
	/// The BagEntry Class.
	/// </summary>
	public class BagEntry : INotifyPropertyChanged
	{
		#region Internal Variables

		private string _desc = "";
		private string _bagNo = "";
		private int _BHT1 = 0;
		private int _BHT2 = 0;
		private int _BHT5 = 0;
		private int _BHT10c = 0;
		private int _BHT10b = 0;
		private int _BHT20 = 0;
		private int _BHT50 = 0;
		private int _BHT100 = 0;
		private int _BHT500 = 0;
		private int _BHT1000 = 0;
		private decimal _BHTTotal = 0;

		#endregion

		#region Constructor and Destructor

		/// <summary>
		/// Constructor.
		/// </summary>
		public BagEntry() : base() { }
		/// <summary>
		/// Destructor.
		/// </summary>
		~BagEntry() { }

		#endregion

		#region Private Methods

		private void CalcTotal()
		{
			decimal total = 0;
			total += _BHT1 * 1;
			total += _BHT2 * 2;
			total += _BHT5 * 5;
			total += _BHT10c * 10;
			total += _BHT10b * 10;
			total += _BHT20 * 20;
			total += _BHT50 * 50;
			total += _BHT100 * 100;
			total += _BHT500 * 500;
			total += _BHT1000 * 1000;

			_BHTTotal = total;
			// Raise event.
			PropertyChanged.Call(this, new PropertyChangedEventArgs("BHTTotal"));
		}

		#endregion

		#region Public Properties

		public string Description
		{
			get { return _desc; }
			set
			{
				if (_desc != value)
				{
					_desc = value;
					// Raise event.
					PropertyChanged.Call(this, new PropertyChangedEventArgs("Description"));
				}
			}
		}
		/// <summary>
		/// Gets or sets bag number.
		/// </summary>
		public string BagNo
		{
			get { return _bagNo;  }
			set
			{
				if (_bagNo != value)
				{
					_bagNo = value;
					// Raise event.
					PropertyChanged.Call(this, new PropertyChangedEventArgs("BagNo"));
				}
			}
		}
		/// <summary>
		/// Gets or sets number of 1 baht coin.
		/// </summary>
		public int BHT1
		{
			get { return _BHT1; }
			set
			{
				if (_BHT1 != value)
				{
					_BHT1 = value;
					CalcTotal();
					// Raise event.
					PropertyChanged.Call(this, new PropertyChangedEventArgs("BHT1"));
				}
			}
		}
		/// <summary>
		/// Gets or sets number of 2 baht coin.
		/// </summary>
		public int BHT2
		{
			get { return _BHT2; }
			set
			{
				if (_BHT2 != value)
				{
					_BHT2 = value;
					CalcTotal();
					// Raise event.
					PropertyChanged.Call(this, new PropertyChangedEventArgs("BHT2"));
				}
			}
		}
		/// <summary>
		/// Gets or sets number of 5 baht coin.
		/// </summary>
		public int BHT5
		{
			get { return _BHT5; }
			set
			{
				if (_BHT5 != value)
				{
					_BHT5 = value;
					CalcTotal();
					// Raise event.
					PropertyChanged.Call(this, new PropertyChangedEventArgs("BHT5"));
				}
			}
		}
		/// <summary>
		/// Gets or sets number of 10 baht coin.
		/// </summary>
		public int BHT10c
		{
			get { return _BHT10c; }
			set
			{
				if (_BHT10c != value)
				{
					_BHT10c = value;
					CalcTotal();
					// Raise event.
					PropertyChanged.Call(this, new PropertyChangedEventArgs("BHT10c"));
				}
			}
		}
		/// <summary>
		/// Gets or sets number of 10 baht bill.
		/// </summary>
		public int BHT10b
		{
			get { return _BHT10b; }
			set
			{
				if (_BHT10b != value)
				{
					_BHT10b = value;
					CalcTotal();
					// Raise event.
					PropertyChanged.Call(this, new PropertyChangedEventArgs("BHT10b"));
				}
			}
		}
		/// <summary>
		/// Gets or sets number of 20 baht bill.
		/// </summary>
		public int BHT20
		{
			get { return _BHT20; }
			set
			{
				if (_BHT20 != value)
				{
					_BHT20 = value;
					CalcTotal();
					// Raise event.
					PropertyChanged.Call(this, new PropertyChangedEventArgs("BHT20"));
				}
			}
		}
		/// <summary>
		/// Gets or sets number of 50 baht bill.
		/// </summary>
		public int BHT50
		{
			get { return _BHT50; }
			set
			{
				if (_BHT50 != value)
				{
					_BHT50 = value;
					CalcTotal();
					// Raise event.
					PropertyChanged.Call(this, new PropertyChangedEventArgs("BHT50"));
				}
			}
		}
		/// <summary>
		/// Gets or sets number of 100 baht bill.
		/// </summary>
		public int BHT100
		{
			get { return _BHT100; }
			set
			{
				if (_BHT100 != value)
				{
					_BHT100 = value;
					CalcTotal();
					// Raise event.
					PropertyChanged.Call(this, new PropertyChangedEventArgs("BHT100"));
				}
			}
		}
		/// <summary>
		/// Gets or sets number of 500 baht bill.
		/// </summary>
		public int BHT500
		{
			get { return _BHT500; }
			set
			{
				if (_BHT500 != value)
				{
					_BHT500 = value;
					CalcTotal();
					// Raise event.
					PropertyChanged.Call(this, new PropertyChangedEventArgs("BHT500"));
				}
			}
		}
		/// <summary>
		/// Gets or sets number of 1000 baht bill.
		/// </summary>
		public int BHT1000
		{
			get { return _BHT1000; }
			set
			{
				if (_BHT1000 != value)
				{
					_BHT1000 = value;
					CalcTotal();
					// Raise event.
					PropertyChanged.Call(this, new PropertyChangedEventArgs("BHT1000"));
				}
			}
		}
		/// <summary>
		/// Gets or sets total value in baht.
		/// </summary>
		public decimal BHTTotal 
		{
			get { return _BHTTotal; }
			set { } 
		}

		#endregion

		#region Public Events

		/// <summary>
		/// The PropertyChanged event.
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		#endregion
	}

	#endregion

	#region RevenueEntry

	/// <summary>
	/// The RevenueEntry class.
	/// </summary>
	public class RevenueEntry : INotifyPropertyChanged
	{
		#region Internal Variables

		private BagEntry _traffic = null;
		private BagEntry _coupon = null;
		private BagEntry _other = null;
		private decimal _grandTotal = 0;

		#endregion

		#region Constructor and Destructor

		/// <summary>
		/// Constructor.
		/// </summary>
		public RevenueEntry() : base()
		{
			_traffic = new BagEntry();
			_traffic.Description = "ค่าผ่านทาง";
			_traffic.PropertyChanged += _traffic_PropertyChanged;
			_coupon = new BagEntry();
			_coupon.Description = "คูปอง";
			_coupon.PropertyChanged += _coupon_PropertyChanged;
			_other = new BagEntry();
			_other.Description = "รายได้อื่น";
			_other.PropertyChanged += _other_PropertyChanged;
		}
		/// <summary>
		/// Destructor.
		/// </summary>
		~RevenueEntry()
		{
			_other.PropertyChanged -= _other_PropertyChanged;
			_other = null;
			_coupon.PropertyChanged -= _coupon_PropertyChanged;
			_coupon = null;
			_traffic.PropertyChanged -= _traffic_PropertyChanged;
			_traffic = null;
		}

		#endregion

		#region Private Methods


		private void _other_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			CalcGrandTotal();
		}

		private void _coupon_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			CalcGrandTotal();
		}

		private void _traffic_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			CalcGrandTotal();			
		}

		private void CalcGrandTotal() 
		{
			decimal total = 0;

			if (null != _traffic) total += _traffic.BHTTotal;
			if (null != _coupon) total += _coupon.BHTTotal;
			if (null != _other) total += _other.BHTTotal;

			_grandTotal = total;

			PropertyChanged.Call(this, new PropertyChangedEventArgs("GrandTotal"));
		}

		#endregion

		#region Public Properties

		/// <summary>
		/// Gets Traffic bag entry.
		/// </summary>
		public BagEntry Traffic { get { return _traffic; } }
		/// <summary>
		/// Gets Coupon bag entry.
		/// </summary>
		public BagEntry Coupon { get { return _coupon; } }
		/// <summary>
		/// Gets Other bag entry.
		/// </summary>
		public BagEntry Other { get { return _other; } }

		public decimal GrandTotal 
		{
			get { return _grandTotal; }
			set { }
		}


		#endregion

		#region Public Events

		/// <summary>
		/// The PropertyChanged event.
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		#endregion
	}

	#endregion

	#region FundEntry

	/// <summary>
	/// The FundEntry Class.
	/// </summary>
	public class FundEntry : INotifyPropertyChanged
	{
		#region Internal Variables

		private string _desc = "";

		private int _BHT1 = 0;
		private int _BHT2 = 0;
		private int _BHT5 = 0;
		private int _BHT10c = 0;
		private int _BHT10b = 0;
		private int _BHT20 = 0;
		private int _BHT50 = 0;
		private int _BHT100 = 0;
		private int _BHT500 = 0;
		private int _BHT1000 = 0;
		private decimal _BHTTotal = 0;

		#endregion

		#region Constructor and Destructor

		/// <summary>
		/// Constructor.
		/// </summary>
		public FundEntry() : base()
		{
			this.Date = DateTime.MinValue;
		}
		/// <summary>
		/// Destructor.
		/// </summary>
		~FundEntry() { }

		#endregion

		#region Private Methods

		private void CalcTotal()
		{
			decimal total = 0;
			total += _BHT1 * 1;
			total += _BHT2 * 2;
			total += _BHT5 * 5;
			total += _BHT10c * 10;
			total += _BHT10b * 10;
			total += _BHT20 * 20;
			total += _BHT50 * 50;
			total += _BHT100 * 100;
			total += _BHT500 * 500;
			total += _BHT1000 * 1000;

			_BHTTotal = total;
			// Raise event.
			PropertyChanged.Call(this, new PropertyChangedEventArgs("BHTTotal"));
		}

		#endregion

		#region Public Properties

		public string Description
		{
			get { return _desc; }
			set
			{
				if (_desc != value)
				{
					_desc = value;
					// Raise event.
					PropertyChanged.Call(this, new PropertyChangedEventArgs("Description"));
				}
			}
		}
		/// <summary>
		/// Gets or sets number of 1 baht coin.
		/// </summary>
		public int BHT1
		{
			get { return _BHT1; }
			set
			{
				if (_BHT1 != value)
				{
					_BHT1 = value;
					CalcTotal();
					// Raise event.
					PropertyChanged.Call(this, new PropertyChangedEventArgs("BHT1"));
				}
			}
		}
		/// <summary>
		/// Gets or sets number of 2 baht coin.
		/// </summary>
		public int BHT2
		{
			get { return _BHT2; }
			set
			{
				if (_BHT2 != value)
				{
					_BHT2 = value;
					CalcTotal();
					// Raise event.
					PropertyChanged.Call(this, new PropertyChangedEventArgs("BHT2"));
				}
			}
		}
		/// <summary>
		/// Gets or sets number of 5 baht coin.
		/// </summary>
		public int BHT5
		{
			get { return _BHT5; }
			set
			{
				if (_BHT5 != value)
				{
					_BHT5 = value;
					CalcTotal();
					// Raise event.
					PropertyChanged.Call(this, new PropertyChangedEventArgs("BHT5"));
				}
			}
		}
		/// <summary>
		/// Gets or sets number of 10 baht coin.
		/// </summary>
		public int BHT10c
		{
			get { return _BHT10c; }
			set
			{
				if (_BHT10c != value)
				{
					_BHT10c = value;
					CalcTotal();
					// Raise event.
					PropertyChanged.Call(this, new PropertyChangedEventArgs("BHT10c"));
				}
			}
		}
		/// <summary>
		/// Gets or sets number of 10 baht bill.
		/// </summary>
		public int BHT10b
		{
			get { return _BHT10b; }
			set
			{
				if (_BHT10b != value)
				{
					_BHT10b = value;
					CalcTotal();
					// Raise event.
					PropertyChanged.Call(this, new PropertyChangedEventArgs("BHT10b"));
				}
			}
		}
		/// <summary>
		/// Gets or sets number of 20 baht bill.
		/// </summary>
		public int BHT20
		{
			get { return _BHT20; }
			set
			{
				if (_BHT20 != value)
				{
					_BHT20 = value;
					CalcTotal();
					// Raise event.
					PropertyChanged.Call(this, new PropertyChangedEventArgs("BHT20"));
				}
			}
		}
		/// <summary>
		/// Gets or sets number of 50 baht bill.
		/// </summary>
		public int BHT50
		{
			get { return _BHT50; }
			set
			{
				if (_BHT50 != value)
				{
					_BHT50 = value;
					CalcTotal();
					// Raise event.
					PropertyChanged.Call(this, new PropertyChangedEventArgs("BHT50"));
				}
			}
		}
		/// <summary>
		/// Gets or sets number of 100 baht bill.
		/// </summary>
		public int BHT100
		{
			get { return _BHT100; }
			set
			{
				if (_BHT100 != value)
				{
					_BHT100 = value;
					CalcTotal();
					// Raise event.
					PropertyChanged.Call(this, new PropertyChangedEventArgs("BHT100"));
				}
			}
		}
		/// <summary>
		/// Gets or sets number of 500 baht bill.
		/// </summary>
		public int BHT500
		{
			get { return _BHT500; }
			set
			{
				if (_BHT500 != value)
				{
					_BHT500 = value;
					CalcTotal();
					// Raise event.
					PropertyChanged.Call(this, new PropertyChangedEventArgs("BHT500"));
				}
			}
		}
		/// <summary>
		/// Gets or sets number of 1000 baht bill.
		/// </summary>
		public int BHT1000
		{
			get { return _BHT1000; }
			set
			{
				if (_BHT1000 != value)
				{
					_BHT1000 = value;
					CalcTotal();
					// Raise event.
					PropertyChanged.Call(this, new PropertyChangedEventArgs("BHT1000"));
				}
			}
		}
		/// <summary>
		/// Gets or sets total value in baht.
		/// </summary>
		public decimal BHTTotal
		{
			get { return _BHTTotal; }
			set { }
		}

		public string StaffId { get; set; }
		public DateTime Date { get; set; }
		public int Lane { get; set; }
		public string DateString
		{
			get
			{
				var ret = (this.Date == DateTime.MinValue) ? "" : this.Date.ToString("dd/MM/yyyy");
				return ret;
			}
			set { }
		}
		public string TimeString
		{
			get
			{
				var ret = (this.Date == DateTime.MinValue) ? "" : this.Date.ToString("HH:mm:ss.fff");
				return ret;
			}
			set { }
		}

		#endregion

		#region Public Events

		/// <summary>
		/// The PropertyChanged event.
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		#endregion
	}

	#endregion
}
