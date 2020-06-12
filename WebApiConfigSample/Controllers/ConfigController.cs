using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;  

using WebApiConfigSample.Options;  

namespace WebApiConfigSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConfigController : ControllerBase
    {
        IConfiguration _configuration ;

        AzureKeyVaultOptions _keyVaultConfiguation;

        public ConfigController(IConfiguration configuration, IOptions<AzureKeyVaultOptions> azureKeyVaultOptions)
        {
            _configuration = configuration;
            _keyVaultConfiguation = azureKeyVaultOptions.Value;
        }

        [HttpGet]
        public string Get()
        {
            string server = _configuration["Repository:Server"];  
            string database = _configuration["Repository:Database"];
            string connectionString = $"Server={server}; Database={database}";
            return connectionString;
        }


        [HttpGet("optionsmanual")]
        public string GetOptionsManual()
        {
            //1. 
        //    var azureKeyvaultOptions  = new AzureKeyVaultOptions(); 
        //    _configuration.GetSection(AzureKeyVaultOptions.Azure).Bind(azureKeyvaultOptions); 

           //2.
            var azureKeyvaultOptions  =  _configuration.GetSection(AzureKeyVaultOptions.Azure).Get<AzureKeyVaultOptions>(); 
           return azureKeyvaultOptions.KeyvaultKey;
        }


         [HttpGet("optionsdi")]
        public string GetOptionsDI()
        {
           return _keyVaultConfiguation.KeyvaultKey;
        }
    }
}
