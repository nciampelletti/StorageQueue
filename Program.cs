using Azure.Storage.Queues;

string connectionstring = "";
string qname = "appqueue";

SendMessage("Test message 1");
SendMessage("Test message 2");

void SendMessage(string message)
{
	QueueClient queueClient = new QueueClient(connectionstring, qname);

	if (queueClient.Exists())
	{
		queueClient.SendMessage(message);
		Console.WriteLine("Message has been sent");
	}

}
