using AssignmentTask_Api.Models.Enums;

namespace AssignmentTask_Api.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public RoomType RoomType { get; set; }
        public int NumberOfAdults { get; set; }
        public int NumberOfChildern { get; set; }
    }
}
