using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StoreManagerResource.UC
{
    /// <summary>
    /// Interaction logic for HTextBox.xaml
    /// </summary>
    public partial class HTextBox : TextBox, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        public HTextBox()
        {
            InitializeComponent();
        }



        public string _PlaceHolder
        {
            get { return (string)GetValue(_PlaceHolderProperty); }
            set { SetValue(_PlaceHolderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for _PlaceHolder.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty _PlaceHolderProperty =
            DependencyProperty.Register("_PlaceHolder", typeof(string), typeof(HTextBox), new PropertyMetadata(string.Empty));



        public Visibility _PlaceHolderVisibility
        {
            get { return (Visibility)GetValue(_PlaceHolderVisibilityProperty); }
            set { SetValue(_PlaceHolderVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for _PlaceHolderVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty _PlaceHolderVisibilityProperty =
            DependencyProperty.Register("_PlaceHolderVisibility", typeof(Visibility), typeof(HTextBox), new PropertyMetadata(Visibility.Visible));




        public string _CaptionText
        {
            get { return (string)GetValue(_CaptionTextProperty); }
            set { SetValue(_CaptionTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for _CaptionText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty _CaptionTextProperty =
            DependencyProperty.Register("_CaptionText", typeof(string), typeof(HTextBox), new FrameworkPropertyMetadata(string.Empty, new PropertyChangedCallback(OnFirstTextChanged)));

        private static void OnFirstTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((HTextBox)d)._CaptionVisibility = string.IsNullOrWhiteSpace(e.NewValue.ToString()) ? Visibility.Collapsed : Visibility.Visible;
        }

        public Visibility _CaptionVisibility
        {
            get { return (Visibility)GetValue(_CaptionVisibilityProperty); }
            set { SetValue(_CaptionVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for _CaptionVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty _CaptionVisibilityProperty =
            DependencyProperty.Register("_CaptionVisibility", typeof(Visibility), typeof(HTextBox), new PropertyMetadata(Visibility.Collapsed));

        public int _CaptionHeight
        {
            get { return (int)GetValue(_CaptionHeightProperty); }
            set { SetValue(_CaptionHeightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for _CaptionHeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty _CaptionHeightProperty =
            DependencyProperty.Register("_CaptionHeight", typeof(int), typeof(HTextBox), new PropertyMetadata(20));

        public SolidColorBrush _CaptionForeground
        {
            get { return (SolidColorBrush)GetValue(_CaptionForegroundProperty); }
            set { SetValue(_CaptionForegroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for _CaptionForeground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty _CaptionForegroundProperty =
            DependencyProperty.Register("_CaptionForeground", typeof(SolidColorBrush), typeof(HTextBox), new PropertyMetadata(MyApp.Color.Caption));

        

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            _PlaceHolderVisibility = Visibility.Collapsed;
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.Text))
            {
                _PlaceHolderVisibility = Visibility.Visible;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.Text) == false)
            {
                _PlaceHolderVisibility = Visibility.Collapsed;
            }
        }
    }
}
