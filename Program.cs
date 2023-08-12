using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using System.Windows.Markup;

string connectionstring = "";
string qname = "appqueue";

//SendMessage("Test message 1");
//SendMessage("Test message 2");

PickMessage();

void PickMessage()
{
	QueueClient queueClient = new QueueClient(connectionstring, qname);
	int maxMessage = 10;

	PeekedMessage[] peekedMessages = queueClient.PeekMessages(maxMessage);

	Console.WriteLine("The messages in the queue are: ");

	foreach(var message in peekedMessages)
	{
		Console.WriteLine(message.Body);
	}

 }

void SendMessage(string message)
{
	QueueClient queueClient = new QueueClient(connectionstring, qname);

	if (queueClient.Exists())
	{
		queueClient.SendMessage(message);
		Console.WriteLine("Message has been sent");
	}

}