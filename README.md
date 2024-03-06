# Bash.UnstructuredIO.Client

### Unofficial .NET SDK for the Unstructured API

This is an unofficial .NET client for the [Unstructured API](https://unstructured-io.github.io/unstructured/api.html). Refer to [Official Unstructured API Docs](https://github.com/Unstructured-IO/unstructured-api) to understand about the project and steps to use the hosted service or deploy your own instance using Docker.

## Getting started

### Install from NuGet

Install package [`Bash.UnstructuredIO.Client` from Nuget](https://www.nuget.org/packages/Bash.UnstructuredIO.Client/).  Here's how via command line:

```powershell
Install-Package Bash.UnstructuredIO.Client
```

## SDK Example Usage

The ```UnstructuredClient``` class can be used both by dependency injection or directly instantiating it wherever required. The first parameter is the server URL of the Unstructured instance. It can either be set to the official hosted API or your own instance. The seond one is the **api-key** which is **optional** and can be omitted.

### Using Dependency Injection
```csharp
builder.Services.AddSingleton<IUnstructuredClient>(
    new UnstructuredClient("http://localhost:8000", "my-key-123")
);
```

### Directly Instantiating the client

```csharp
var unstructuredClient = new UnstructuredClient("http://localhost:8000", "my-key-123");
```

## Usage

The ```PartitionAsync``` method returns a ```ApiResponse``` object that has the parameters of ```Data```, ```Message``` and ```StatusCode```.

1. The ```Data``` property is a list of ```Elements``` that have been extracted from the document.
2. The ```Message``` and ```StatusCode``` properties return a message if the extraction was successful or not.


### Simple Example
```csharp
var filePath = "SampleFiles\\lorem_ipsum.docx";            
var result = await _unstructuredClient.PartitionAsync(filePath, CancellationToken.None);
var elements = result.Data;

foreach (var element in elements)
{
   Console.WriteLine(element.Text);
}
```

### Additional Extraction Options
See the [api parameters](https://unstructured-io.github.io/unstructured/apis/api_parameters.html) page for all available ```Extraction Options```.

```csharp
var options = new ExtractionOptions()
{
    Strategy = UnstructuredConstants.Strategy.HighResolution,
    Coordinates = true
};
         
var result = await unstructuredClient.PartitionAsync(filePath, options, CancellationToken.None);
```

### Unstructured Constants

The ```UnstructuredConstants``` contains a set of constants that can be used in the SDK.

## Maturity

This SDK is in beta, and there may be breaking changes between versions without a major version update. Therefore, we recommend pinning usage to a specific package version. This way, you can install the same version each time without breaking changes unless you are intentionally looking for the latest version.

## Contributions

This was a project aimed at learning how NuGet packages can be created along with the itch of doing some .NET stuff besides work. Contributions are very welcome and needed. It is not probably following the best practices so willing to learn whoever contributes to do a code review!

## License

This project is licensed under the **MIT License** - see the LICENSE.txt file for details.