 
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using System.Windows.Markup;

string connectionstring = "DefaultEndpointsProtocol=https;AccountName=appstore4040ciamp;AccountKey=583ab8LTT1/BAogvgTGIWJftkBgkNRsrp6yJJ2D0alVnlv4d6IRGaTKuzs3fNNbNoEwcAgpg0SGC+AStGevc6g==;EndpointSuffix=core.windows.net";
string qname = "appqueue";


ReceiveMessage();


void ReceiveMessage()
{
	QueueClient queueClient = new QueueClient(connectionstring, qname);
	int maxMessage = 10;

	QueueMessage[] receivedMessages = queueClient.ReceiveMessages(maxMessage);

	Console.WriteLine("The messages in the queue are: ");

	foreach (var message in receivedMessages)
	{
		Console.WriteLine(message.Body);
		queueClient.DeleteMessage(message.MessageId, message.PopReceipt);
	}

}

void PickMessage()
{
	QueueClient queueClient = new QueueClient(connectionstring, qname);
	int maxMessage = 10;

	PeekedMessage[] peekedMessages = queueClient.PeekMessages(maxMessage);

	Console.WriteLine("The messages in the queue are: ");

	foreach (var message in peekedMessages)
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