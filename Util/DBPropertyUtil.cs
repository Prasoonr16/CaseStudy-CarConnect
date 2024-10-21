using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public static class DBPropertyUtil
    {
        private static IConfigurationRoot _configuration;
        static string s = null;

        static DBPropertyUtil()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("C:\\Users\\HP\\source\\repos\\CarConnect\\Util\\appsettings.json",
                optional: true, reloadOnChange: true);
            _configuration = builder.Build();
        }
        public static string ReturnCn(string key)
        {
            s = _configuration.GetConnectionString("dbCn");
            return s;
        }

    }
}

