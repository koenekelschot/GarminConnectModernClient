# Garmin Connect Modern Client for .NET

This is a basic client for Garmin Connect that supports searching for activities and exporting activities.

Based on https://github.com/LarsAndreasEk/GarminConnectClient

## Installation

Just build it from source

## Usage

```csharp
var sessionService = new GarminSessionService();
var ssoClient = new GarminSsoClient(sessionService);
var connectClient = new GarminConnectClient(sessionService);
var connector = new GarminConnectConnector(ssoClient, connectClient, sessionService);

_ = await connector.LoginAsync("username", "********");
var result = await connector.FindAllActivitiesAsync();
_ = await connector.LogoutAsync();
```
