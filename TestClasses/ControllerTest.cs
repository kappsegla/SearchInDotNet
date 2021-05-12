using ConsoleApp2.Examples;
using Moq;
using System;
using Xunit;

namespace TestProject1
{
    public class ControllerTest
    {

        [Fact]
        public void IndexReturnsEmptyString()
        {
            Controller controller = new Controller(new DummyAuthorizer());

            Assert.Equal("", controller.Index());
        }

        [Fact]
        public void SecretInformationIsReturnedIfAuthorized()
        {
            var authorizerMock = new Mock<IAuthorize>();
            authorizerMock.Setup(p => p.Authorize("adam", "pwd")).Returns(true);

            Controller controller = new Controller(authorizerMock.Object);

            Assert.Equal("Secret information", controller.GetInformation("adam", "pwd"));
        }


        class DummyAuthorizer : IAuthorize
        {
            public bool Authorize(string name, string passwd)
            {
                throw new NotImplementedException();
            }
        }


    }
}
