using System.Threading.Tasks;
using BackendChallenge.Models.TokenAuth;
using BackendChallenge.Web.Controllers;
using Shouldly;
using Xunit;

namespace BackendChallenge.Web.Tests.Controllers
{
    public class HomeController_Tests: BackendChallengeWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}