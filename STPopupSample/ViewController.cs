using System;

using UIKit;
using STPopup;
using CoreGraphics;

namespace STPopupSample
{
    public class ViewController : UIViewController
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.White;

            var button = new UIButton(new CGRect(20, (View.Bounds.Height / 2) - 22, View.Bounds.Width - 40, 44));
            button.Layer.CornerRadius = 5f;
            button.ClipsToBounds = true;
            button.BackgroundColor = UIColor.Orange;
            button.SetTitle("Click me!", UIControlState.Normal);
            View.AddSubview(button);

            button.TouchUpInside += Button_TouchUpInside;
        }

        void Button_TouchUpInside(object sender, EventArgs e)
        {
            // Old school
            //var vc = new PopupViewController(new CGSize(View.Bounds.Width, View.Bounds.Height - 220));
            //vc.ModalPresentationStyle = UIModalPresentationStyle.Popover;
            //vc.ModalTransitionStyle = UIModalTransitionStyle.CoverVertical;
            //PresentModalViewController(vc, true);
            //return;

            STPopupController popupController = new STPopupController(
                new PopupViewController(new CGSize(View.Bounds.Width - 40, 
                View.Bounds.Height - 420)));
            popupController.ContainerView.Layer.CornerRadius = 8f;
            popupController.NavigationBarHidden = true;
            popupController.TransitionStyle = STPopupTransitionStyle.SlideVertical;
            popupController.Style = STPopupStyle.BottomSheet;
            popupController.BackgroundView.AddGestureRecognizer(new UITapGestureRecognizer((obj) => popupController.Dismiss()));
            popupController.PresentInViewController(this);
        }
    }
}

