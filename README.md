# Slack Models
[![Actions Status](https://github.com/ZenExtensions/slack-models/workflows/.NET%20Core%20Publish/badge.svg)](https://github.com/ZenExtensions/slack-models/actions) [![Current Version](https://img.shields.io/badge/Version-1.1.1-brightgreen?logo=nuget&labelColor=30363D)](./CHANGELOG.md#111---2023-01-26)

# Overview

## Installing
You can add the package to your project using dotnet core CLI
```bash
dotnet add package ZenExtensions.Slack.Models
```
or by package manager console in Visual Studio
```bash
Install-Package ZenExtensions.Slack.Models
```
Please refer to [Changelog](./CHANGELOG.md) for changes between versions.

## Usage

```csharp
using ZenExtensions.Slack.Models;

Message message = new (
    Text: "This is a sample message"
)

Attachment attachment = new (
    Text: "This is a sample attachment",
    Color: "#008BFF"
)
    .AddField(
        title = "Environment",
        value = "Testing",
        short = true
    )
    .AddField(
        new Field(Title: "Description", Value:"This is a sample long field", Short: false)
    );

message.AddAttachment(attachment);
```

You can either send message directly to an endpoint.

```csharp
using ZenExtensions.Slack.Models;
using ZenExtensions.Slack.Models.Http;

Message message = new (
    Text:"This is a sample message"
);

try
{
    await message.SendAsync(endpoint: "www.example.com");
}
catch(System.Net.Http.HttpRequestException ex)
{
    // Handle message exception
}

```

Or to the SlashRequest
```csharp
using ZenExtensions.Slack.Models;
using ZenExtensions.Slack.Models.Http;

Message message = new (
    Text:"This is a sample message"
);

SlashRequest request = new(
    ResponseUrl: "www.example.com"
);

try
{
    await request.SendAsync(message);
}
catch(System.Net.Http.HttpRequestException ex)
{
    // Handle message exception
}

```