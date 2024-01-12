using Microsoft.AspNetCore.SignalR;

namespace SalernoProject.Hubs
{
    public class AnimeHub : Hub
    {
        private static Dictionary<string, List<string>> rooms = new Dictionary<string, List<string>>();

        public async Task CreateRoom(string roomName)
        {
            // Create a new room
            rooms[roomName] = new List<string> { Context.ConnectionId };

            // Notify the client who created the room
            await Clients.Caller.SendAsync("RoomCreated");
        }

        public async Task JoinRoom(string roomName)
        {
            // Check if the room exists
            if (rooms.ContainsKey(roomName))
            {
                // Add the player to the room
                rooms[roomName].Add(Context.ConnectionId);

                // Notify only the clients in the specific room about the new player
                await Clients.Group(roomName).SendAsync("PlayerJoined");

                // Add the player to the SignalR group for further targeted communication
                await Groups.AddToGroupAsync(Context.ConnectionId, roomName);
            }
            else
            {
                // Handle the case where the room doesn't exist
                await Clients.Caller.SendAsync("RoomNotFound");
            }
        }
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
