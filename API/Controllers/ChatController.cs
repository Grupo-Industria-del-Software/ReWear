using Application.DTOs.Messages;
using Application.Interfaces.Chat;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChatController: ControllerBase
{
    private   readonly IChatService _chatService;

    public ChatController(IChatService chatService)
    {
        _chatService = chatService;
    }
    
    [HttpPost("create")]
    public async Task<IActionResult> CreateChat([FromQuery] int productId, [FromQuery] int buyerId)
    {
        var chat = await _chatService.CreateChatAsync(productId, buyerId);
        return Ok(chat);
    }
    
    [HttpGet("{userId}")]
    public async Task<IActionResult> GetChats(int userId)
    {
        var chats = await _chatService.GetChatsForUserAsync(userId);
        return Ok(chats);
    }
    
    [HttpPost("message")]
    public async Task<IActionResult> SendMessage([FromBody] MessageRequestDto messageDto)
    {
        var message = await _chatService.SendMessageAsync(messageDto);
        return Ok(message);
    }
    
    [HttpGet("messages/{chatId}")]
    public async Task<IActionResult> GetMessages(int chatId)
    {
        var messages = await _chatService.GetMessagesAsync(chatId);
        return Ok(messages);
    }
}