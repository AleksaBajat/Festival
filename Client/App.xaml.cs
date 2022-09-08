using System.Windows;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Client.Models;
using Client.Services.Abstractions;
using Client.Services.Concretes;
using Client.State.Authentication;
using Client.Stores;
using Client.ViewModels;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private WindsorContainer _container;

        public App()
        {
            new Festival("Yolo Festival");
        }
        
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _container = new WindsorContainer();
            _container.Register(Component.For<NavigationStore>().LifestyleSingleton());
            _container.Register(Component.For<IArtistService>().ImplementedBy<ArtistService>().LifestyleSingleton());
            _container.Register(Component.For<ITimeSlotService>().ImplementedBy<TimeSlotService>().LifestyleSingleton());
            _container.Register(Component.For<IStageService>().ImplementedBy<StageService>().LifestyleSingleton());
            _container.Register(Component.For<IAuthenticateService>().ImplementedBy<AuthenticateService>().LifestyleSingleton());
            _container.Register(Component.For<INavigationService>().ImplementedBy<NavigationService>().LifestyleSingleton());
            _container.Register(Component.For<IRegisterService>().ImplementedBy<RegisterService>().LifestyleSingleton());
            _container.Register(Component.For<IAuthenticator>().ImplementedBy<Authenticator>().LifestyleSingleton());


            _container.ResolveAll<MainWindow>();

            var navigationStore = _container.Resolve<NavigationStore>();            
            
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_container.Resolve<INavigationService>())
            };

            MainWindow.Show();
        }

        

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("An unhandled exception just occurred: " + e.Exception.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            e.Handled = true;
        }
    }
}