// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace iosBeaconSample
{
	[Register ("iosBeaconSampleViewController")]
	partial class iosBeaconSampleViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel detailsLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel subTitleLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel titleLabel { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (detailsLabel != null) {
				detailsLabel.Dispose ();
				detailsLabel = null;
			}
			if (subTitleLabel != null) {
				subTitleLabel.Dispose ();
				subTitleLabel = null;
			}
			if (titleLabel != null) {
				titleLabel.Dispose ();
				titleLabel = null;
			}
		}
	}
}
