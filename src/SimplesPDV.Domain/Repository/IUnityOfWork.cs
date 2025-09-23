namespace SimplesPDV.Domain.Repository;

public interface IUnityOfWork
{
    Task Commit();
}