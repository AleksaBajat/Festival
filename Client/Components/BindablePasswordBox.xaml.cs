using System.Windows;
using System.Windows.Controls;

namespace Client.Components
{
    public partial class BindablePasswordBox : UserControl
    {
        private bool _isPasswordChanging = false;
        
        public static readonly DependencyProperty PasswordProperty = 
            DependencyProperty.Register("Password", typeof(string),
                typeof(BindablePasswordBox), new PropertyMetadata(string.Empty, PasswordPropertyChanged));

        private static void PasswordPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is BindablePasswordBox passBox)
            {
                passBox.UpdatePassword();
            }
        }

        private void UpdatePassword()
        {
            if(_isPasswordChanging == false)
                PassBox.Password = Password;
        }

        public string Password
        {
            get => (string) GetValue(PasswordProperty);

            set => SetValue(PasswordProperty,value);
        }
        
        public BindablePasswordBox()
        {
            InitializeComponent();
        }

        private void PassBox_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            _isPasswordChanging = true;
            Password = PassBox.Password;
            _isPasswordChanging = false;
        }
    }
}