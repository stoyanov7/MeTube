namespace MeTube.Services
{
    using Contracts;
    using Data;
    using Models;

    public class TubeService : ITubeService
    {
        private readonly MeTubeContext context;

        public TubeService(MeTubeContext context)
        {
            this.context = context;
        }

        public void Add(Tube tube)
        {
            this.context.Tubes.Add(tube);
            this.context.SaveChanges();
        }

        public Tube FindById(int id) => this.context.Tubes.Find(id);

        public void Save() => this.context.SaveChanges();
    }
}