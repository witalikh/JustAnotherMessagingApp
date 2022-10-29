using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net.WebSockets;

using MessangerApp.Helpers.Common;
using MessangerApp.DataAccess.Messages.Interfaces;

namespace MessangerApp.Controllers.Messages;

[Route("messages/")]
public class MessagesCotroller : ControllerBase
{
    private IMessageDataAccessProvider _messageService;
    private IMapper _mapper;
    private readonly AppSettings _appSettings;

    public MessagesCotroller(
        IMessageDataAccessProvider messageService,
        IMapper mapper,
        IOptions<AppSettings> appSettings)
    {
        _messageService = messageService;
        _mapper = mapper;
        _appSettings = appSettings.Value;
    }

	private static async Task Echo(WebSocket webSocket)
	{
		var buffer = new byte[1024 * 4];
		var receiveResult = await webSocket.ReceiveAsync(
			new ArraySegment<byte>(buffer), CancellationToken.None);

		while (!receiveResult.CloseStatus.HasValue)
		{
			await webSocket.SendAsync(
				new ArraySegment<byte>(buffer, 0, receiveResult.Count),
				receiveResult.MessageType,
				receiveResult.EndOfMessage,
				CancellationToken.None);

			receiveResult = await webSocket.ReceiveAsync(
				new ArraySegment<byte>(buffer), CancellationToken.None);
		}

		await webSocket.CloseAsync(
			receiveResult.CloseStatus.Value,
			receiveResult.CloseStatusDescription,
			CancellationToken.None);
	}

    [HttpGet("list")]
    public async Task Get()
    {
        if (HttpContext.WebSockets.IsWebSocketRequest)
        {
            using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
			await Echo(webSocket);
        }
        else
        {
            HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
        }
    }

    [HttpGet("index")]
    public ContentResult Index()
    {
		string baseDir = AppDomain.CurrentDomain.BaseDirectory;
		var path = Directory.GetParent(baseDir).Parent.Parent.Parent.FullName;
		var html = System.IO.File.ReadAllText(path + "/Pages/Messages.html");
		return base.Content(html, "text/html");
    }
}
