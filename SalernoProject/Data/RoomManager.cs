namespace SalernoProject.Data
{
    public class RoomManager
    {
        private readonly Dictionary<string, Room> _rooms = new Dictionary<string, Room>();

        public Room CreateRoom()
        {
            var room = new Room { RoomId = Guid.NewGuid().ToString() };
            _rooms.Add(room.RoomId, room);
            return room;
        }

        public Room GetRoom(string roomId)
        {
            return _rooms.GetValueOrDefault(roomId);
        }

        public void JoinRoom(string roomId, Participant participant)
        {
            var room = GetRoom(roomId);
            if (room != null)
            {
                room.Participants.Add(participant);
            }
        }

        public void LeaveRoom(string roomId, string connectionId)
        {
            var room = GetRoom(roomId);
            if (room != null)
            {
                var participant = room.Participants.FirstOrDefault(p => p.ConnectionId == connectionId);
                if (participant != null)
                {
                    room.Participants.Remove(participant);
                }
            }
        }
    }
}
