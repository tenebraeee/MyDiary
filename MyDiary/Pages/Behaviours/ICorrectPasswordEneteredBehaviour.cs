namespace MyDiary.Pages.Behaviours
{
    public interface ICorrectPasswordEneteredBehaviour
    {
        Task Execute(CancellationToken token = default);
    }
}