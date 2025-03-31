using Microsoft.AspNetCore.SignalR;

namespace API.Hubs;

public class ChatHub:Hub
{
    // El método SendMessage es llamado por el cliente para enviar un mensaje a un grupo (chat)
    public async Task SendMessage(string chatId, string senderName, string message)
    {
        // Enviar el mensaje a todos los clientes conectados en el grupo
        await Clients.Group(chatId).SendAsync("ReceiveMessage", senderName, message);
    }

// Cuando un cliente se conecta a un chat, se une al grupo identificado por chatId
    public async Task JoinChat(string chatId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, chatId);
    }

    public async Task LeaveChat(string chatId)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, chatId);
    }   
}