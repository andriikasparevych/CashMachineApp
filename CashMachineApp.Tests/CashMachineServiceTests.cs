using System;
using CashMachineApp.Exceptions;
using CashMachineApp.Services;
using Xunit;

namespace CashMachineApp.Tests
{

    public class CashMachineServiceTests
    {
        private readonly ICashMachineStatusService _fakeStatusService;

        public CashMachineServiceTests()
        {
            // possible to use some mocking framework here like Moq
            // I decided just to create a fake class not to introduce extra lib dependency for such a small project
            _fakeStatusService = new FakeStatusService();
        }

        [Theory]
        [InlineData(0, new int[] {})]
        [InlineData(30, new[] {20,10})]
        [InlineData(80, new[] {50,20,10})]
        [InlineData(100, new[] {100})]
        [InlineData(550, new[] {100,100,100,100,100,50})]
        public void Withdraw_ValidInputs_ShouldReturn_Expected(int amount, int[] expected)
        {
            var service = new CashMachineService(_fakeStatusService);
            var result = service.Withdraw(amount);

            Assert.Equal(expected, result.Banknotes);
        }

        [Fact]
        public void Withdraw_NegativeAmount_ShouldThrow_InvalidArgumentException()
        {
            var negativeArgument = -1;
            var service = new CashMachineService(_fakeStatusService);

            var act = new Action( () => service.Withdraw(negativeArgument));

            Assert.Throws<InvalidArgumentException>(act);
        }


        [Fact]
        public void Withdraw_ImpossibleToChangeAmount_ShouldThrow_InvalidArgumentException()
        {
            var impossibleToChangeAmount = 35;
            var service = new CashMachineService(_fakeStatusService);

            var act = new Action(() => service.Withdraw(impossibleToChangeAmount));

            Assert.Throws<NoteUnavailableException>(act);
        }

        
        private class FakeStatusService : ICashMachineStatusService
        {
            public int[] GetAvailableBanknotes()
            {
                return new[] { 10, 20, 50, 100 };
            }
        }
    }
}