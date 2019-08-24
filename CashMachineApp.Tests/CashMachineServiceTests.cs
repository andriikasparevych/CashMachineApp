using System;
using CashMachineApp.Exceptions;
using CashMachineApp.Services;
using Xunit;

namespace CashMachineApp.Tests
{

    public class CashMachineServiceTests
    {
        [Theory]
        [InlineData(0, new int[] {})]
        [InlineData(30, new[] {20,10})]
        [InlineData(80, new[] {50,20,10})]
        [InlineData(100, new[] {100})]
        [InlineData(550, new[] {100,100,100,100,100,50})]
        public void Withdraw_ValidInputs_ShouldReturn_Expected(int amount, int[] expected)
        {
            var service = new CashMachineService();
            var result = service.Withdraw(amount);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Withdraw_NegativeAmount_ShouldThrow_InvalidArgumentException()
        {
            var negativeArgument = -1;
            var service = new CashMachineService();

            var act = new Action( () => service.Withdraw(negativeArgument));

            Assert.Throws<InvalidArgumentException>(act);
        }


        [Fact]
        public void Withdraw_ImpossibleToChangeAmount_ShouldThrow_InvalidArgumentException()
        {
            var impossibleToChangeAmount = 35;
            var service = new CashMachineService();

            var act = new Action(() => service.Withdraw(impossibleToChangeAmount));

            Assert.Throws<NoteUnavailableException>(act);
        }


    }
}