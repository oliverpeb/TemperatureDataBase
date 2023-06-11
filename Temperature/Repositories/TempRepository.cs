using Temperature.Models;

namespace Temperature.Repositories
{
    public class TempRepository : ITempRepository
    {
        public int _nextId;
        public List<Temperatures> _data;

        public TempRepository()
        {
            _nextId = 1;
            _data = new List<Temperatures>()
            {
                new Temperatures { Id = _nextId++, RoomNumber = "1ABC", Temperature = 25, Day = "Monday" },
                new Temperatures { Id = _nextId++, RoomNumber = "2ABC", Temperature = 20, Day = "Tuesday" },
                new Temperatures { Id = _nextId++, RoomNumber = "3ABC", Temperature = 15, Day = "Wednesday" },
            };
        }
        public List<Temperatures> GetAll()
        {
            return new List<Temperatures>(_data);
        }

        public Temperatures? GetById(int id)
        {
            return _data.Find(x => x.Id == id);
        }

        public Temperatures Add(Temperatures newTemp)
        {
            if (newTemp == null)
            {
                throw new ArgumentNullException(nameof(newTemp), "Temp cannot be null");
            }
            newTemp.Id = _nextId++;
            _data.Add(newTemp);
            return newTemp;
        }

        public Temperatures? Delete(int id)
        {
            Temperatures foundTemp = GetById(id);
            if (foundTemp != null)
            {
                _data.Remove(foundTemp);
            }
            return foundTemp;
        }


    }
}
