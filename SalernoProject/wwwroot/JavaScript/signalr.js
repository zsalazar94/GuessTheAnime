var hubConnection = new signalR.HubConnectionBuilder()
    .withUrl("/quizHub")
    .build();

hubConnection.start().then(function () {
    console.log("SignalR Connected");
}).catch(function (err) {
    return console.error(err.toString());
});