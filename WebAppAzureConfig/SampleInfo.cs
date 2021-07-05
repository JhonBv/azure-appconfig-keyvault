using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAzureConfig.Configuration;

namespace WebAppAzureConfig
{
    public class SampleInfo
    {
        private readonly KeyVaultConfig _config;
        public SampleInfo(IOptions<KeyVaultConfig> config)
        {
            _config = config.Value;
        }

        public string KeyValue()
        {
            return _config.Value;
        }
    }
}
