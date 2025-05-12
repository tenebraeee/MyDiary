namespace MyDiary.Pages
{
    public interface IViewFactory
    {
        T? Get<T>() where T : IView;
    }
}