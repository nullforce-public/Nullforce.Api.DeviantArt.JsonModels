# Nullforce.Api.DeviantArt.JsonModels

A C# wrapper for DeviantArt JSON models

|||
----------------------|---
**Build**             | TBD
**NuGet**             | TBD
**NuGet (prerelease)**| TBD


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
