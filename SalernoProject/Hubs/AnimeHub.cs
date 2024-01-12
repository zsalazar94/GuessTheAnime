using Microsoft.AspNetCore.SignalR;
using SalernoProject.Data;

namespace SalernoProject.Hubs
{
    public class AnimeHub : Hub
    {
        private static Dictionary<string, List<string>> rooms = new Dictionary<string, List<string>>();

        public async Task CreateRoom(string roomName)
        {
            // Create a new room
            rooms[roomName] = new List<string> { Context.ConnectionId };

            await Groups.AddToGroupAsync(Context.ConnectionId, roomName);

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

        public async Task SetFilter(string roomName, List<string> selectedAnimes)
        {
            await Clients.Group(roomName).SendAsync("RecieveFilter", selectedAnimes);

        }
        public async Task SendVideo(string roomName, int videoIndex)
        {
            await Clients.Group(roomName).SendAsync("RecieveVideo", videoIndex);

        }

        public async Task PlayAudio(string roomName, int seconds)
        {
            await Clients.Group(roomName).SendAsync("PlayAudio", seconds);

        }

        public async Task PlayVideo(string roomName)
        {
            await Clients.Group(roomName).SendAsync("PlayVideo");

        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            // Identify the room the disconnected player belongs to
            var room = rooms.FirstOrDefault(pair => pair.Value.Contains(Context.ConnectionId));

            if (room.Key != null)
            {
                // Remove the player from the room
                rooms[room.Key].Remove(Context.ConnectionId);

                // Notify remaining players in the room about the player leaving
                await Clients.Group(room.Key).SendAsync("PlayerLeft");

                // Remove the player from the SignalR group
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, room.Key);
            }

            await base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
