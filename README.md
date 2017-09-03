# facepp-dotnet-sdk
.NET SDK for face++ api

```c#
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
