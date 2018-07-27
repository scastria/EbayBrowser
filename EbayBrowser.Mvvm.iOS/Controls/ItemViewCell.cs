using System;
using System.Collections.Generic;
using Foundation;
using MvvmCross.Binding.Bindings;
using MvvmCross.Platforms.Ios.Binding.Views;
using UIKit;
using FFImageLoading.Cross;

namespace EbayBrowser.Mvvm.iOS.Controls
{
    public class ItemViewCell : MvxStandardTableViewCell
    {
        public const int MARGIN = 10;
        public const float IMAGE_WIDTH = 0.2f;

        public string Title {
            get { return (_titleL.Text); }
            set { _titleL.Text = value; }
        }
        public string Price {
            get { return (_priceL.Text); }
            set { _priceL.Text = value; }
        }
        public string GalleryImageUrl {
            get { return (_imageV.ImagePath); }
            set { _imageV.ImagePath = value; }
        }

        private UILabel _titleL = null;
        private UILabel _priceL = null;
        private MvxCachedImageView _imageV = null;

        public ItemViewCell(IEnumerable<MvxBindingDescription> bindingDescriptions, NSString cellId, UITableViewCellAccessory cellAccessory = UITableViewCellAccessory.None) : base(bindingDescriptions, UITableViewCellStyle.Subtitle, cellId, cellAccessory)
        {
            CreateUI();
        }

        private void CreateUI()
        {
            SeparatorInset = UIEdgeInsets.Zero;
            _imageV = new MvxCachedImageView {
                TranslatesAutoresizingMaskIntoConstraints = false,
                ContentMode = UIViewContentMode.ScaleAspectFit
            };
            ContentView.AddSubview(_imageV);
            ContentView.AddConstraint(NSLayoutConstraint.Create(_imageV, NSLayoutAttribute.Left, NSLayoutRelation.Equal, ContentView, NSLayoutAttribute.Left, 1, 0));
            ContentView.AddConstraint(NSLayoutConstraint.Create(_imageV, NSLayoutAttribute.Top, NSLayoutRelation.Equal, ContentView, NSLayoutAttribute.Top, 1, 0));
            ContentView.AddConstraint(NSLayoutConstraint.Create(_imageV, NSLayoutAttribute.Bottom, NSLayoutRelation.Equal, ContentView, NSLayoutAttribute.Bottom, 1, 0));
            ContentView.AddConstraint(NSLayoutConstraint.Create(_imageV, NSLayoutAttribute.Width, NSLayoutRelation.Equal, ContentView, NSLayoutAttribute.Width, IMAGE_WIDTH, 0));
            _priceL = new UILabel {
                TranslatesAutoresizingMaskIntoConstraints = false,
                Font = UIFont.BoldSystemFontOfSize(12),
                TextAlignment = UITextAlignment.Right
            };
            _priceL.SetContentHuggingPriority((float)UILayoutPriority.Required, UILayoutConstraintAxis.Vertical);
            ContentView.AddSubview(_priceL);
            ContentView.AddConstraint(NSLayoutConstraint.Create(_priceL, NSLayoutAttribute.Left, NSLayoutRelation.Equal, _imageV, NSLayoutAttribute.Right, 1, MARGIN));
            ContentView.AddConstraint(NSLayoutConstraint.Create(_priceL, NSLayoutAttribute.Right, NSLayoutRelation.Equal, ContentView, NSLayoutAttribute.Right, 1, -MARGIN));
            ContentView.AddConstraint(NSLayoutConstraint.Create(_priceL, NSLayoutAttribute.Bottom, NSLayoutRelation.Equal, ContentView, NSLayoutAttribute.Bottom, 1, -MARGIN));
            _titleL = new UILabel {
                TranslatesAutoresizingMaskIntoConstraints = false,
                Lines = 0
            };
            ContentView.AddSubview(_titleL);
            ContentView.AddConstraint(NSLayoutConstraint.Create(_titleL, NSLayoutAttribute.Left, NSLayoutRelation.Equal, _imageV, NSLayoutAttribute.Right, 1, MARGIN));
            ContentView.AddConstraint(NSLayoutConstraint.Create(_titleL, NSLayoutAttribute.Top, NSLayoutRelation.Equal, ContentView, NSLayoutAttribute.Top, 1, MARGIN));
            ContentView.AddConstraint(NSLayoutConstraint.Create(_titleL, NSLayoutAttribute.Right, NSLayoutRelation.Equal, ContentView, NSLayoutAttribute.Right, 1, -MARGIN));
            ContentView.AddConstraint(NSLayoutConstraint.Create(_titleL, NSLayoutAttribute.Bottom, NSLayoutRelation.Equal, _priceL, NSLayoutAttribute.Top, 1, -MARGIN));
        }
    }
}
