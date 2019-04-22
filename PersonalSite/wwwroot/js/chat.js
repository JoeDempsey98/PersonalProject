"use strict";

let connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

document.getElementById("sendBtn").disabled = true;

connection.on("ReceiveMessage", function (userName, message) {
    let msg = message.replace(/&/g, "&amp;")
        .replace(/</g, "&lt;").replace(/>/g, "&gt;");
    let encodedMsg = userName + " says " + msg;
    let li = document.createElement("li");
    li.textContent = encodedMsg;
    document.getElementById("messagesList").appendChild(li);
});

connection.on("Join", function (message) {
    let msg = message.replace(/&/g, "&amp;")
        .replace(/</g, "&lt;").replace(/>/g, "&gt;");
    let li = document.createElement("li");
    li.textContent = msg;
    document.getElementById("messagesList").appendChild(li);
});

connection.start().then(function () {
    document.getElementById("sendBtn").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendBtn").addEventListener("click", function (event) {
    let userName = document.getElementById("userNameInput").value;
    let message = document.getElementById("messageInput").value;
    let users = document.getElementById("usersInput").value;
    let userNames = users.split(", ");
    connection.invoke("SendMessageToChatRoom", userName, userNames, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});