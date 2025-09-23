namespace SimplesPDV.Infrastructure;

public class UnityOfWork : Domain.Repository.IUnityOfWork
{
    public Task Commit()
    {
        throw new NotImplementedException();
    }
}