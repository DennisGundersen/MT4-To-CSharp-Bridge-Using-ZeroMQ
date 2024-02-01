# MT4 To CSharp Bridge Using ZeroMQ
A prototype for connecting unmanaged code in Metatrader 4 (MQL) to managed code (C#) using modern .NET (6+) using ZeroMQ

## MQL4 Example
### Dependencies
mql-zmq https://github.com/GroM/mql-zmq

### Installation in MT4
Copy the `MQL4` directory stored in project `Pragmatic.Server.TradingCentral` into your MT4 instance's Data Folder
Start `Pragmatic.Server.TradingCentral`, compile and run EQ `HourglassTrader_v1`.

### Usage
Sending to server is done through function
`bool SendCommand(ZmqMsg& response, string& data[])`

Commands (messages to server) are structured as array of strings.
First element is the name of command to execute.
Next ones are optional and are arguments for this command. String representation should be parsable into that type.

Response is `ZmqMsg`. There's also function `ShowResponse` which displays received response.
response.getData() is a way to access returned value from server.

## Server part
Solution is divided into 4 projects.
- `Pragmatic.Server.TradingCentral` is a simple CLI acting as the server and exposing C# methods as defined in `Adapters/MethodAdapters.cs`
- `Pragmatic.Common.Entities` holds the example classes as well at examples for deserializing/serializing DTO from / to the EA
- `Pragmatic.Strategy.Hourglass.BusinessLogic` is a dummy business layer
- `Pragmatic.Strategy.Hourglass.Client` is a simple CLI acting as test against the server.
- (`HourglassTrader_v1` is a simple EA calling the server (sends and receives serialized dummy data))

### Defining commands
To execute commands from external libraries (which could be even without source code - managed dll) there's an adapter used.
Command is defined as delegate taking array of string and returning string. 
`public delegate string Cmd(string[] input)`
Argument `input` is a list of arguments for a method from an external library. 
Return value is a result from a method from an external library.

### List of commands
There're 2 types of commands base and custom (your external ones), which are held in dictionaries.
When receiving a command the server checks that this command was defined. Check order is following: base, custom.
When it finds a matching dictinary entry, it executes this command. In case there's no command with that name returns to client `ERR: Unknown command`.
