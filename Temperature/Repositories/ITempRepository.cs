using Temperature.Models;
namespace Temperature.Repositories
{
    public interface ITempRepository
    {
        Temperatures Add(Temperatures newTemp);
        Temperatures Delete(int Id);
        List<Temperatures> GetAll();
        Temperatures GetById(int Id);

    }
}
