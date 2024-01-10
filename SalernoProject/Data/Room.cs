namespace SalernoProject.Data
{
    public class Room
    {
        public string RoomId { get; set; }
        public List<Participant> Participants { get; set; } = new List<Participant>();
        public VideoFile CurrentVideo { get; set; }
    }
}
