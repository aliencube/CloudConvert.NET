# CloudConvert.NET #

**CloudConver.NET** provides a .NET wrapper library for [CloudConvert API](http://cloudconvert.com).


## Package Status ##

* **CloudConvert.NET** [![](https://img.shields.io/nuget/v/Aliencube.CloudConvert.NET.svg)](https://www.nuget.org/packages/Aliencube.CloudConvert.NET/) [![](https://img.shields.io/nuget/dt/Aliencube.CloudConvert.NET.svg)](https://www.nuget.org/packages/Aliencube.CloudConvert.NET/)


## Getting Started ##

**CloudConvert.NET** is easy to use. The following example code is to show how to convert a [Markdown](http://daringfireball.net/projects/markdown/) document to an [MS Word](https://products.office.com/en-us/word) one and store it to [OneDrive](https://onedrive.live.com).


### Parameters ###

Firstly, all relevant settings and parameters need to be prepared beforehand.

```csharp
var settings = ConverterSettings.CreateInstance();
var wrapper = new ConverterWrapper<MarkdownConverterOptions>(settings);
var formats = new Formats();
var input = new InputParameters()
            {
              InputFormat = formats.Document.Md,
              InputMethod = InputMethod.Download,
              Filepath = "https://raw.githubusercontent.com/aliencube/CloudConvert.NET/dev/README.md",
              Filename = "README.md",
            };
var output = new OutputParameters()
             {
               DownloadMethod = DownloadMethod.False,
               OutputStorage = OutputStorage.OneDrive,
             };
var conversion = new ConversionParameters<MarkdownConverterOptions>()
                 {
                   OutputFormat = formats.Document.Docx,
                   ConverterOptions = new MarkdownConverterOptions()
                                      {
                                        InputMarkdownSyntax = MarkdownSyntaxType.Auto
                                      },
                 };
```


### Convert ###

Once the settings and parameters are ready, just call `ConvertAsync` method to get the result.

```csharp
// Convert asynchronously
var response = await wrapper.ConvertAsync(input, output, conversion);

// Convert synchronously
var response = wrapper.ConvertAsync(input, output, conversion).Result;
```


## Settings ##

As you can see the above example codes, configuration settings needs to be instantiated first by calling:

```csharp
var settings = ConverterSettings.CreateInstance();
```

This `settings` instance comes from either `converterSettings` section or `appSettings` section on `App.config` or `Web.config`. It firstly look for the `converterSettings` section and, if no `converterSettings` section is found, then look for the `appSettings` section.

```xml
<configuration>
  <configSections>
    <section name="converterSettings" type="Aliencube.CloudConvert.Wrapper.ConverterSettings, Aliencube.CloudConvert.Wrapper" requirePermission="false" />
  </configSections>

  <converterSettings>
    <basic processUrl="https://api.cloudconvert.com/process">
      <apiKey value="3qNaQa9iNGOzFv4a2HWtFBWNFGJyyQiBoYtnJLrCUAUppnMzcvZrV7SYKF1_Q4P55zcnFbZni14poKBmCT-BaQ" />
    </basic>
  </converterSettings>
</configuration>
```

If you want to simply use the `appSettings` section, you can do the following instead:

```xml
<configuration>
  <appSettings>
    <add key="ApiKey" value="3qNaQa9iNGOzFv4a2HWtFBWNFGJyyQiBoYtnJLrCUAUppnMzcvZrV7SYKF1_Q4P55zcnFbZni14poKBmCT-BaQ" />
    <add key="ProcessUrl" value="https://api.cloudconvert.com/process" />
  </appSettings>
</configuration>
```

> **NOTE**: Make sure that:
> 
> * The API key **MUST** be changed to yours before running this code; otherwise you'll get an error. The API key can be obtained from [https://cloudconvert.com/user/profile](https://cloudconvert.com/user/profile), once you login.
> * If you want to store your converted result into [Goodle Drive](https://drive.google.com), [Dropbox](https://dropbox.com) or [OneDrive](https://onedrive.live.com), your account should be linked to those services beforehand.


## Converter Options ##

**Acknowledgement**: Not all strongly-type converter options are ready. The rest options will be added in the later version, gradually. In the meantime, you can still add converter options with `Dictionary<string, object>` object for other converter types.


### List of Classes for Converter Options ###

* `MarkdownConverterOptions`


### Usages ###

This is the sample code using the strongly-typed `MarkdownConverterOptions` class:

```csharp
var conversion = new ConversionParameters()
                 {
                   OutputFormat = this._formats.Document.Docx,
                   ConverterOptions = new MarkdownConverterOptions()
                                      {
                                        InputMarkdownSyntax = MarkdownSyntaxType.Auto
                                      },
                 };

```

Alternatively, you can use the `Dictionary<string, object>` object instead:

```csharp
var conversion = new ConversionParameters()
                 {
                   OutputFormat = this._formats.Document.Docx,
                   ConverterOptions = new Dictionary<string, object>()
                                      {
                                        { "input_markdown_syntax", MarkdownSyntaxType.Auto },
                                      },
                 };
```

## Contribution ##

Your contributions are always welcome! All your work should be done in your forked repository. Once you finish your work, please send us a pull request onto our `dev` branch for review.


## License ##

**CloudConver.NET** is released under [MIT License](http://opensource.org/licenses/MIT)

> The MIT License (MIT)
>
> Copyright (c) 2015 [aliencube.org](http://aliencube.org)
> 
> Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
> 
> The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
> 
> THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
