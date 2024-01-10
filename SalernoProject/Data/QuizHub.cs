using Microsoft.AspNetCore.SignalR;
using System.Text.RegularExpressions;

namespace SalernoProject.Data
{
    public class QuizHub : Hub
    {
        // ... existing code

        public async Task JoinRoom(string roomId, string connectionId)
        {
            await Groups.AddToGroupAsync(connectionId, roomId);
            // Additional logic for broadcasting the participant list to the room
        }

        public async Task LeaveRoom(string roomId, string connectionId)
        {
            await Groups.RemoveFromGroupAsync(connectionId, roomId);
            // Additional logic for broadcasting the participant list to the room
        }

        // Additional hub methods as needed
    }
}
