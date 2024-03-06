# Bash.UnstructuredIO.Client

### Unofficial .NET SDK for the Unstructured API</p>

This is a .NET client for the [Unstructured API](https://unstructured-io.github.io/unstructured/api.html). 

## Getting started

### Install from NuGet

Install package [`Bash.UnstructuredIO.Client` from Nuget](https://www.nuget.org/packages/Bash.UnstructuredIO.Client/).  Here's how via command line:

```powershell
Install-Package Bash.UnstructuredIO.Client
```

## SDK Example Usage

### Using Dependency Injection
```csharp
builder.Services.AddSingleton<IUnstructuredClient>(
    new UnstructuredClient("http://localhost:8000", "my-key-123")
);
```

### Directly Instantiating the client
```csharp
UnstructuredClient unstructuredClient = new UnstructuredClient("http://localhost:8000", "my-key-123");
```

If you are self hosting the API, or developing locally, you can change the server URL when setting up the client. The **api-key** is **optional** and can be ommited.

## Usage

```csharp
var filePath = "SampleFiles\\lorem_ipsum.docx";            
var result = await _unstructuredClient.PartitionAsync(filePath, CancellationToken.None);
var elements = result.Data;

foreach (var element in elements)
{
   Console.WriteLine(element.Text);
}
```
### Additional Parameters
See the [api parameters](https://unstructured-io.github.io/unstructured/apis/api_parameters.html) page for all available parameters.

```csharp
var options = new ExtractionOptions()
{
    Strategy = UnstructuredConstants.Strategy.HighResolution,
    Coordinates = true
};
         
var result = await unstructuredClient.PartitionAsync(filePath, options, CancellationToken.None);
```

### Maturity

This SDK is in beta, and there may be breaking changes between versions without a major version update. Therefore, we recommend pinning usage to a specific package version. This way, you can install the same version each time without breaking changes unless you are intentionally looking for the latest version.

### Contributions

This was a project aimed at learning how NuGet packages can be created alongwith the itch of doing some .NET besides work. Contributions are very welcome and needed. This is not probably following the best practices so willing to learn whoever contributes to do a code review!