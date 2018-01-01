using System;
using Xamarin.Forms;

namespace MVVMFormsApp.Controls
{
    public class RoundLabel : Label
    {
        //public static readonly BindableProperty BorderColorProperty = BindableProperty.Create<RoundLabel, Color>(p => p.BorderColor, Color.Transparent);
        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(RoundLabel), Color.Transparent);

        //public static readonly BindableProperty BorderWidthProperty = BindableProperty.Create<RoundLabel, float>(p => p.BorderWidth, 0);
        public static readonly BindableProperty BorderWidthProperty = BindableProperty.Create(nameof(BorderWidth), typeof(float), typeof(RoundLabel), default(float));


        //public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create<RoundLabel, float>(p => p.CornerRadius, 0);
        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(nameof(CornerRadius), typeof(float), typeof(RoundLabel), default(float));

        //public static readonly BindableProperty HiddenValueProperty = BindableProperty.Create<RoundLabel, string>(p => p.HiddenValue, null);
        public static readonly BindableProperty HiddenValueProperty = BindableProperty.Create(nameof(HiddenValue), typeof(string), typeof(RoundLabel), default(string));

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            UpdateVisible();
        }

        public Color BorderColor
        {
            get
            {
                return (Color)GetValue(BorderColorProperty);
            }
            set
            {
                SetValue(BorderColorProperty, value);
            }
        }

        public float BorderWidth
        {
            get
            {
                return (float)GetValue(BorderWidthProperty);
            }
            set
            {
                SetValue(BorderWidthProperty, value);
            }
        }

        public float CornerRadius
        {
            get
            {
                return (float)GetValue(CornerRadiusProperty);
            }
            set
            {
                SetValue(CornerRadiusProperty, value);
            }
        }

        public string HiddenValue
        {
            get
            {
                return (string)GetValue(HiddenValueProperty);
            }
            set
            {
                SetValue(HiddenValueProperty, value);
                UpdateVisible();
            }
        }

        private void UpdateVisible()
        {
            if (String.IsNullOrEmpty(Text) || Text != HiddenValue)
            {
                IsVisible = true;
                return;
            }

            IsVisible = false;
        }
    }
}