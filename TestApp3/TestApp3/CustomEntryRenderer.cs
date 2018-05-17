using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms.Platform.Android;

namespace TestApp3
{
    public class CustomEntryRenderer : EntryRenderer
    {
        public CustomEntryRenderer(Context context) : base(context)
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null && e.NewElement != null)
            {
                var entry = e.NewElement;
                if (Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Lollipop)
                    Control.BackgroundTintList = ColorStateList.ValueOf(entry.TextColor.ToAndroid());
                else
                    Control.Background.SetColorFilter(entry.TextColor.ToAndroid(), PorterDuff.Mode.SrcAtop);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == "TextColor")
            {
                var entry = (Xamarin.Forms.Entry)sender;
                if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
                    Control.BackgroundTintList = ColorStateList.ValueOf(entry.TextColor.ToAndroid());
                else
                    Control.Background.SetColorFilter(entry.TextColor.ToAndroid(), PorterDuff.Mode.SrcAtop);
            }
        }
    }
}
