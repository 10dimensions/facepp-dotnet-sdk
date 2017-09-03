using System;
using Cody.FacePP.Core;
using Cody.FacePP.Api.Face;
using Cody.FacePP.Api.Entity;

namespace examples
{
    public class FaceDetectExample : IExample
    {
        public async void Run(IWebClient client)
        {
            var request = new FaceDetectRequest
            {
                ImageFile = new System.IO.FileInfo(@".\imgs\1.jpg"),
                IsReturnLandMark = true,
                ReturnAttributesType = AttributesType.All
            };

            var response = await client.GetResponseAsync(request);

            foreach (Face face in response.Faces)
            {
                Console.WriteLine("token:\t{0}\t{1}", face.FaceToken, face.FaceRectangle.ToString());
                Console.WriteLine("性别:\t{0}", face.Attributes.GenderValue.Value);
                Console.WriteLine("年龄:\t{0}", face.Attributes.Age);
                Console.WriteLine("颜值:\t{0}", face.Attributes.Gender == Gender.Male ? face.Attributes.Beauty.MaleScore : face.Attributes.Beauty.FemaleScore);
            }
        }
    }
}
