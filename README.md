ChatSimple is a lightweight desktop chat application built with C# and Windows Forms on .NET 10. It uses plain TCP sockets (TcpListener / TcpClient), so there is no external server or third-party library.
School project (Topicos Avanzados de Programación)

How it works

Start the app and enter an IP address and port.
Click Iniciar Server and answer the prompt:
Yes: this instance becomes the server. It listens on all network interfaces, shows its own IP and port in the chat history, and accepts any number of clients.
No: this instance becomes a client. You pick a username, and it connects to the server’s IP and port and joins the room.
The server reads each client’s messages and broadcasts them to all other clients, prefixed with the sender’s name. It can also send messages itself as “Server Admin”.
Join and leave events are shown in the chat history.

Technical notes

Uses async/await for non-blocking connections, so the UI stays responsive.
Each client is handled by its own background task.
The list of connected clients is protected with a lock, and broadcasts iterate over a copy of it.
Messages are sent as newline-delimited text through StreamReader / StreamWriter.
UI updates from background tasks are marshalled safely with Invoke.

Requirements: Windows, the .NET 10 SDK, and Visual Studio 2022 or later (open ChatSimple.slnx). To chat across machines, they must be on the same network and the server’s port must be allowed through the firewall.
