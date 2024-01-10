﻿using Microsoft.AspNetCore.SignalR;
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

        public async Task PlayAudio(string roomId, int seconds)
        {
            // Broadcast the PlayAudio event to all clients in the group
            await Clients.Group(roomId).SendAsync("PlayAudio", seconds);
        }

    }
}