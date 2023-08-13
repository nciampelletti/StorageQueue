using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using Newtonsoft.Json;
using StorageQueue;
using System.Net;
using System.Text.Json.Serialization;

string connectionstring = "";
string qname = "appqueue";

SendMessage(3, "Natalia 2", "111 Bosa ave, Vancouver");
SendMessage(4, "Emy 3", "22 Bosa ave, Vancouver");

PickMessages();

void SendMessage(int id, string name, string address)
{
	QueueClient queueClient = new QueueClient(connectionstring, qname);

	if (queueClient.Exists())
	{
		Customer customer = new Customer { Id = id , Name = name, Address = address};
		queueClient.SendMessage(JsonConvert.SerializeObject(customer));
		Console.WriteLine("Message has been sent");
	}

}

void PickMessages()
{
	QueueClient queueClient = new QueueClient(connectionstring, qname);
	int maxMessage = 10;

	PeekedMessage[] peekedMessages = queueClient.PeekMessages(maxMessage);

	Console.WriteLine("The messages in the queue are: ");

	foreach (var message in peekedMessages)
	{
		Customer customer =JsonConvert.DeserializeObject<Customer>(message.Body.ToString());

		Console.WriteLine($"Customer Id: {customer.Id}");
	}

}
