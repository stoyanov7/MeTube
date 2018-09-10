namespace MeTube.Services.Contracts
{
    using Models;

    public interface ITubeService
    {
        void Add(Tube tube);

        Tube FindById(int id);

        void Save();
    }
}