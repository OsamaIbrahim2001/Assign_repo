using AssignmentTask_Api.Models.Enums;

namespace AssignmentTask_Api.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public int NationalId { get; set; }
        public int PhoneNumber { get; set; }
        public HotelBranch HotelBranch { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NumberOfRooms { get; set; }
        public int Salary { get; set; }
        public bool IsAlreadyBooked { get; set; }
        public List<Room> Rooms { get; set; } = new List<Room>();
    }
}
