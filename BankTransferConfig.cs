using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;

namespace Modul9
{
    internal class BankTransferConfig
    {
        private string filepath;
        public Config config { get; set; }

        public BankTransferConfig(string filepath, Config config)
        {
            this.filepath = filepath;
        }

        public string ReadConfigFile()
        {
            return File.ReadAllText(filepath);

        }

        public void WriteConfigFile()
        {
            File.WriteAllText(filepath, ReadConfigFile());
        }

        public void SetDefault()
        {
            config = new Config(
                "en",
                new Transfer (25000000, 6500, 15000),
                ["RTO", "(real-time)", "SKN", "RTGS", "BI", "FAST"],
                new Confirmation ("yes", "ya")
            );
        }
    }
}
