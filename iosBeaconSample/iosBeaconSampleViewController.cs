using System;
using System.Drawing;
using MonoTouch.CoreLocation;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace iosBeaconSample
{
	public partial class iosBeaconSampleViewController : UIViewController
	{
		NSUuid UUID = new NSUuid("2F234454-CF6D-4A0F-ADF2-F4911BA9FFA6");
		ushort major = 100;
		string regionIdentifier = "DemoRegion";
		CLLocationManager locationMgr;
		public iosBeaconSampleViewController (IntPtr handle) : base (handle)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		#region View lifecycle

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			var beaconRegion = new CLBeaconRegion (UUID, major, regionIdentifier);
			beaconRegion.NotifyEntryStateOnDisplay = true;
			beaconRegion.NotifyOnEntry = true;
			beaconRegion.NotifyOnExit = true;

			locationMgr = new CLLocationManager ();

			locationMgr.RegionEntered += (object sender, CLRegionEventArgs e) => {
				if (e.Region.Identifier == regionIdentifier)
				{
					UILocalNotification notification = new UILocalNotification () { AlertBody = "Beacon Located" };
					UIApplication.SharedApplication.PresentLocationNotificationNow (notification);
					titleLabel.Text = "Found Beacon!";
				}
			};

			locationMgr.RegionLeft += (object sender, CLRegionEventArgs e) => {
				if (e.Region.Identifier == regionIdentifier)
				{
					titleLabel.Text = "Lost Beacon :(";
				}
			};

			locationMgr.DidRangeBeacons += (object sender, CLRegionBeaconsRangedEventArgs e) => {
				if (e.Beacons.Length > 0)
				{
					var beacon = e.Beacons[0];
					subTitleLabel.Text = e.Beacons[0].Proximity.ToString();
					detailsLabel.Text = "Strength: " + beacon.Rssi + " Distance: " + beacon.Accuracy.ToString();
				}
			};

			locationMgr.StartMonitoring (beaconRegion);
			locationMgr.StartRangingBeacons (beaconRegion);

		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
		}

		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
		}

		public override void ViewDidDisappear (bool animated)
		{
			base.ViewDidDisappear (animated);
		}

		#endregion
	}
}

