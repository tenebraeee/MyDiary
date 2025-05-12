namespace MyDiary.Pages.Behaviours;

public class CorrectPasswordEneteredBehaviour : ICorrectPasswordEneteredBehaviour
{
    public async Task Execute(CancellationToken token = default)
    {
        await Shell.Current.GoToAsync(PageRoutes.Main);
    }
}
