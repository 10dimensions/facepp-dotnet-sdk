using System;
using Cody.FacePP.Core;
using Cody.FacePP.Api.Face;
using Cody.FacePP.Api.Entity;

namespace examples
{
    public class FaceCompareExample : IExample
    {
        public async void Run(IWebClient client)
        {
            var request = new FaceCompareRequest
            {
                ImageFile1 = new System.IO.FileInfo(@".\imgs\1.jpg"),
                ImageFile2 = new System.IO.FileInfo(@".\imgs\2.jpg"),
            };

            var response = await client.GetResponseAsync(request);

            Console.WriteLine("是同一人的可能性: {0:0.00} %", response.Confidence);
        }
    }
}
