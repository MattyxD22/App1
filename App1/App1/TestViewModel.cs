using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    class TestViewModel : BaseViewModel
    {
        //IHubProxy _hub;
        HubConnection hubConnection;

        public TestViewModel()
        {
            SendMessageCommand = new Command(async () => { await Connect(); });


            //string url = @"http://localhost:8000/signalr";
            //var hubConnection = new HubConnection(url);
            //_hub = hubConnection.CreateHubProxy("Hub");
            //hubConnection.Start().Wait();







            //// localhost for UWP/iOS or special IP for Android
            //var ip = "localhost";
            //if (Device.RuntimePlatform == Device.Android)
            //    ip = "10.0.2.2";

            //hubConnection = new HubConnectionBuilder()
            //    .WithUrl($"http://{ip}:44379/chatHub")
            //    .Build();


            //hubConnection.On<string>("CodeUnit", (customerID) =>
            //{

            //    //Console.WriteLine($"Message has been sent: {inputString}");
            //    Result = customerID;
            //    _Messages.Add(new DebugMessages() { Message = customerID, User = "" });

            //    //Messages.Add(new Message() { Username = user, Text = $"{user} has joined the chat", IsSystemMessage = true, Date = DateTime.Now });
            //});

            //hubConnection.On<string, string>("Echo", (user, message) =>
            //{
            //    //Console.WriteLine(user + " " + message);

            //    _Messages.Add( new DebugMessages() { Message = message, User = user });
            //});

            //hubConnection.On<string>("TestIvoke", (message) =>
            //    {
            //    Console.WriteLine($"Test invoked: {message}");
            //});

            //hubConnection.On<string>("JoinChat", (ID) =>
            //{
            //    Console.WriteLine($"joined: {ID}");
            //    _Messages.Add(new DebugMessages { Message = ID, User = "" });

            //});

            //hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
            //{
            //    Console.WriteLine(message + " " + message);
            //    _Messages.Add(new DebugMessages() { Message = message, User = user });

            //});

        }


        //#region -- Bindings --
        //private string messages;

        //public string Messages
        //{
        //    get { return messages; }
        //    set { messages = value; OnPropertyChanged(); }
        //}

        //private string result;

        //public string Result
        //{
        //    get { return result; }
        //    set { result = value; OnPropertyChanged(); }
        //}

        private string inputID;

        public string InputID
        {
            get { return inputID; }
            set { inputID = value; OnPropertyChanged(); }
        }

        //private ObservableCollection<DebugMessages> _messages;

        //public ObservableCollection<DebugMessages> _Messages
        //{
        //    get { return _messages; }
        //    set { _messages = value; OnPropertyChanged(); }
        //}


        //#endregion

        public Command SendMessageCommand { get; }

        //public Command SendMessageCommand => new Command(async () =>
        //{

        //    //InputID = Int32.Parse(Messages);
        //    Console.WriteLine(InputID);

        //    await hubConnection.InvokeAsync("JoinChat", InputID);
        //    await TestMethod(InputID);
        //    await hubConnection.StopAsync();
        //    //await hubConnection.InvokeAsync("BroadcastMessage", "Mathias", "Test");
        //});

        async Task Connect()
        {
            try
            {
                hubConnection = new HubConnectionBuilder()
                .WithUrl($"http://10.0.2.2:5000/Hubs")
                .Build();

                await hubConnection.StartAsync();
                await hubConnection.InvokeAsync("Echo", "mig", "test");
                Console.WriteLine("Is connected");

                hubConnection.On<string, string>("RecieveMessage", (user, message) => {
                    Console.WriteLine(user + " " + message);
                });

            }
            catch (Exception e)
            {
                Console.WriteLine("ConnectMethod Error: " + e.Message);

            }
        }

        async Task TestMethod(string ID)
        {
            string message = "Message";
            string user = "mig";
            //await Connect();
            try
            {

                //await hubConnection.InvokeAsync("Echo", user, message);
                //foreach (var item in _Messages)
                //{
                //    Console.WriteLine(item.Message);
                //}

                //await hubConnection.InvokeAsync("JoinChat", ID);
                //foreach (var item in _Messages)
                //{
                //    Console.WriteLine(item.Message);
                //    Console.WriteLine(item.User);
                //}

                //await hubConnection.InvokeAsync("SendMessage", "Test", "Test");

                //await hubConnection.InvokeAsync("SendMessage", ID);
                //foreach (var item in _Messages)
                //{
                //    Console.WriteLine(item.User);
                //    Console.WriteLine(item.Message);
                //}

                //await hubConnection.InvokeAsync("JoinChat", ID);

                //foreach (var item in _Messages)
                //{
                //    Console.WriteLine(item.Message);
                //    Console.WriteLine(item.User);
                //}

                hubConnection = new HubConnectionBuilder()
                .WithUrl($"http://10.0.2.2:44334/Hubs")
                .Build();


                await hubConnection.StartAsync();
                Console.WriteLine("Is Connected");


            }
            catch (Exception e)
            {

                Console.WriteLine("TestMethod Error: " + e.Message);
            }


            //await hubConnection.InvokeAsync("CodeUnit", ID);

        }
    }
}
