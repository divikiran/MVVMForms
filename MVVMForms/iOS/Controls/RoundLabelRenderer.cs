using System;
using MVVMFormsApp.Controls;
using MVVMFormsApp.iOS.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(RoundLabel), typeof(RoundLabelRenderer))]
namespace MVVMFormsApp.iOS.Controls
{
    public class RoundLabelRenderer : LabelRenderer
    {
        public RoundLabelRenderer()
        {
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            //          var label = Element as RoundRectLabel;

            if (e.PropertyName == RoundLabel.BackgroundColorProperty.PropertyName)
            {
                SetNeedsLayout();
                return;
            }
            if (e.PropertyName == RoundLabel.BorderColorProperty.PropertyName)
            {
                SetNeedsLayout();
                return;
            }
            if (e.PropertyName == RoundLabel.BorderWidthProperty.PropertyName)
            {
                SetNeedsLayout();
                return;
            }
            if (e.PropertyName == RoundLabel.CornerRadiusProperty.PropertyName)
            {
                SetNeedsLayout();
                return;
            }
            if (e.PropertyName == RoundLabel.HiddenValueProperty.PropertyName)
            {
                SetNeedsLayout();
                return;
            }
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            var label = Element as RoundLabel;

            Layer.BorderWidth = label.BorderWidth;
            Layer.CornerRadius = label.CornerRadius;
            Layer.BackgroundColor = label.BackgroundColor.ToCGColor();
            Layer.BorderColor = label.BorderColor.ToCGColor();
        }
    }
}
