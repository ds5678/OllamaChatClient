using Microsoft.Extensions.AI;

IChatClient chatClient = new OllamaSharp.OllamaApiClient(new Uri("http://localhost:11434"), defaultModel: "llama3.2:1b");

List<ChatMessage> chatMessages = [new ChatMessage(ChatRole.System, "You are a helpful assistant.")];
while (true)
{
	Console.Write("You: ");
	string? input = Console.ReadLine();
	if (string.IsNullOrWhiteSpace(input))
	{
		break;
	}
	else
	{
		chatMessages.Add(new ChatMessage(ChatRole.User, input));
		Console.WriteLine();
	}

	var completion = await chatClient.CompleteAsync(chatMessages);
	var message = completion.Message;
	chatMessages.Add(message);
	Console.WriteLine($"Bot: {message.Text}");
	Console.WriteLine();
}
