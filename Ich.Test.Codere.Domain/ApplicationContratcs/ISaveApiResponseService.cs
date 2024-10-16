namespace Ich.Test.Codere.Domain.ApplicationContratcs
{
    public interface ISaveApiResponseService
    {
        Task Execute(int id, CancellationToken cancellationToken);
    }
}