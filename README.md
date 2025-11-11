# BarbezDotEu.StockTwits

An unofficial, modern, very much work-in-progress client for StockTwits APIs.

## Overview

This library provides a simple, polite client for reading public StockTwits streams (e.g. recent twits for a symbol) and mapping them to a lightweight MicroBlogEntry model used across the project.

Key points:

- Focuses on read-only public endpoints (streams).
- Built with .NET and designed to be used with dependency injection (uses `IHttpClientFactory` and `ILogger`).
- Rate-limiting is supported via the `StockTwitsConfiguration` constructor.

## Authentication

Currently this library uses StockTwits' public, unauthenticated endpoints for reads such as symbol streams. The code constructs requests to the public stream URL (for example `https://api.stocktwits.com/api/2/streams/symbol/{SYMBOL}.json`) and does not add an API key, OAuth token, or username/password by default.

## Quick start (example)

Below is a minimal example showing typical usage with dependency injection.

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var services = new ServiceCollection();
services.AddLogging(config => config.AddConsole());
services.AddHttpClient();
// register the provider and configuration however your app prefers
services.AddSingleton(new StockTwitsConfiguration(60)); // 60 calls/min
services.AddTransient<StockTwitsDataProvider>();

var sp = services.BuildServiceProvider();
var provider = sp.GetRequiredService<StockTwitsDataProvider>();
var twits = await provider.GetRecentTwits("AAPL");
// twits is IEnumerable<MicroBlogEntry>
```

If you instantiate `StockTwitsDataProvider` manually, provide an `IHttpClientFactory` and `ILogger` implementation.

## Configuration

Use `new StockTwitsConfiguration(maxCallsPerMinute)` to control rate limiting. The configuration also exposes the base stream URL and file extension used by the provider.

## ## Notes & contributions

- This project is a work in progress. If you need authenticated operations and want to contribute, open an issue or PR with the proposed API and implementation approach.
- See the code in `BarbezDotEu.StockTwits` for current behavior around request construction and mapping.

## License

This repository is licensed under the terms in `LICENSE`.
