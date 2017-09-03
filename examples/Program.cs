using System;
using Cody.FacePP.Core;
using Cody.FacePP.Api;
using Cody.FacePP.Api.FaceSet;

namespace examples
{
    class Program
    {
        static void Main(string[] args)
        {
            var profile = new DefaultProfile
            {
                APIKey = "****",
                APISecret = "****"
            };
            var client = new DefaultApiClient(profile);

            //IExample detect = new FaceDetectExample();
            //detect.Run(client);

            //IExample compare = new FaceCompareExample();
            //compare.Run(client);

            //var request = new CreateFaceSetRequest
            //{
            //    DisplayName = "Test",
            //};
            //var response = client.GetResponse(request);

            var request = new AddFaceToFaceSetRequest
            {
                FaceSetToken = "c50c0ef5c877b1184fc2899c54721226",
                FaceTokens = new System.Collections.Generic.List<string>() { "043111b20a7d6b29498991c8ff4071f0" },
            };
            var response = client.GetResponse(request);

            Console.ReadLine();
        }
    }
}
