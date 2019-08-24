using CashMachineApp.Controllers;
using Xunit;

namespace CashMachineApp.Tests
{

    public class CashMachineServiceTests
    {

        [Theory]
        [InlineData(30, new[] {20,10})]
        [InlineData(80, new[] {50,20,10})]
        public void Withdraw_ValidInputs_ShouldReturn_Expected(int amount, int[] expected)
        {
            var service = new CashMachineService();

            var result = service.Withdraw(amount);

            Assert.Equal(expected, result);
        }

    }
}