# Nullforce.Api.DeviantArt.JsonModels

A C# wrapper for DeviantArt JSON models

|||
----------------------|---
**Build**             | [![Build Status](https://dev.azure.com/nullforce-public/ApiClients/_apis/build/status/Nullforce.Api.DeviantArt.JsonModels?branchName=master)](https://dev.azure.com/nullforce-public/ApiClients/_build/latest?definitionId=5&branchName=master)
**NuGet**             | ![Nuget](https://img.shields.io/nuget/v/Nullforce.Api.DeviantArt.JsonModels.svg)
**NuGet (prerelease)**| ![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/Nullforce.Api.DeviantArt.JsonModels.svg)


## Usage Example

An example using [Flurl.Http](https://flurl.dev/):

Install the `Nullforce.Api.DeviantArt.JsonModels` package from NuGet (allow prerelease as needed).

```csharp
using Flurl;
using Flurl.Http;
using Nullforce.Api.DeviantArt.JsonModels;

...

var uri = "https://www.deviantart.com/api/v1/oauth2/placebo";

var result = await uri.WithOAuthBearerToken(accessToken).GetJsonAsync<PlaceboJson>();
```
