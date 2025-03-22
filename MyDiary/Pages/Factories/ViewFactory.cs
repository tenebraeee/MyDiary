namespace MyDiary.Pages
{
    internal class ViewFactory : IViewFactory
    {
        private readonly IServiceProvider _serviceProvider;


        public ViewFactory(
                IServiceProvider serviceProvider
            )
        {
            _serviceProvider = serviceProvider;
        }


        public T? Get<T>() where T : IView
        {
            return _serviceProvider.GetService<T>();
        }
    }
}
