using Microsoft.Extensions.Configuration;

namespace CashMachineApp.Services
{
    public class ConfigCashMachineStatusService : ICashMachineStatusService
    {
        private readonly IConfiguration _configuration;
        private readonly int[] _defaultAvailableNotes = { 10,20,50,100 };

        private const string AvalableBanknotesKey = "CashMachineConfig:AvailableBanknotes";

        public ConfigCashMachineStatusService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public int[] GetAvailableBanknotes()
        {
            return _configuration.GetSection(AvalableBanknotesKey).Get<int[]>() ?? _defaultAvailableNotes;

        }
    }
}