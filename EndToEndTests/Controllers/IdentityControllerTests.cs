using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EndToEndTests.Controllers
{
    public class IdentityControllerTests: IntegrationTest
    {
        [Fact]
        public async Task LoginTest()
        {
            LoginModel loginModel = new ();
            loginModel.Username = "tomek";
            loginModel.Password = "Pass123!#";

            //var isPasswordCorrect = await _userManager.CheckPasswordAsync(user, loginModel.Password);
        }
    }
}
