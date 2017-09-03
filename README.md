# facepp-dotnet-sdk
.NET SDK for face++ api

```
Install-Package FacePlusPlus
```

# example
```c#
using Cody.FacePP.Core;
using Cody.FacePP.Api;
using Cody.FacePP.Api.FaceSet;

var profile = new DefaultProfile
{
    APIKey = "****",
    APISecret = "****"
};
var client = new DefaultApiClient(profile);

IExample detect = new FaceDetectExample();
detect.Run(client);

IExample compare = new FaceCompareExample();
compare.Run(client);

Console.ReadLine();
```
