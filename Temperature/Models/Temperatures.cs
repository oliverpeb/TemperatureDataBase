namespace Temperature.Models
{
    public class Temperatures
    { 
        public int Id { get; set; }
        
        public string RoomNumber { get; set; }

        public int Temperature { get; set; }

        public string Day { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, RoomNo: {RoomNumber}, Temp_C: {Temperature}, Day: {Day}";
        }
    }
}