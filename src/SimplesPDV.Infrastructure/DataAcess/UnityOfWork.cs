namespace SimplesPDV.Infrastructure;

public class UnityOfWork : Domain.Repository.IUnityOfWork
{
    private readonly SimplesPDVContext _context;

    public UnityOfWork(SimplesPDVContext context)
    {
        _context = context;
    }

    public Task Commit() => _context.SaveChangesAsync();
    
}