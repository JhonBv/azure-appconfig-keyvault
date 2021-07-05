using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;

namespace KeyVaultConnect
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            KeyVaultConfiguration config = new KeyVaultConfiguration
            {
                ConnectionSource = "https://fleet-key-vault-dev.vault.azure.net/secrets/",
                KeyName = "FleetAssistAPIUrl"
            };
            string value = await GetSecretValue($"{config.ConnectionSource}{config.KeyName}");
            Console.WriteLine(value);

        }

        /// <summary>
        /// JB. Obtain a secret from Azure KeyVault.
        /// </summary>
        /// <param name="source">KeyVault source</param>
        /// <returns>Secret value</returns>
        public static async Task<string> GetSecretValue(string source)
        {
            string Secret = "";
            try
            {
                AzureServiceTokenProvider azureServiceTokenProvider = new AzureServiceTokenProvider();
                KeyVaultClient keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));
                var secret = await keyVaultClient.GetSecretAsync(source)
                        .ConfigureAwait(false);
                Secret = secret.Value;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return Secret;
        }

        public static async Task<List<string>> GetSecretValues(string source)
        {
            string SecretPath = "";

            List<SecretValues> Secrets = new List<SecretValues>();
            List<string> Ids = new List<string>();
            try
            {

                AzureServiceTokenProvider azureServiceTokenProvider = new AzureServiceTokenProvider();
                KeyVaultClient keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));

                var secretStore = await keyVaultClient.GetSecretsAsync(source)
                        .ConfigureAwait(false);

                foreach (var i in secretStore)
                {
                    Ids.Add(i.Identifier.Name);
                }
                foreach (var j in Ids)
                {
                    
                }
            }
            finally { }
            return Ids;
        }

    }
}