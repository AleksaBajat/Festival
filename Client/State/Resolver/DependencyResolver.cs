using Castle.Windsor;

namespace Client.State.Resolver
{
    public static class DependencyResolver
    {
        public static WindsorContainer Container { get; set; }

        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }
    }
}