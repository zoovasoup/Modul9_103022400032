// See https://aka.ms/new-console-template for more information


using Modul9;

namespace Modul9
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string filepath = @"../../../config/bank_transfer_config.json";
            Config config = new Config();

            BankTransferConfig bank = new BankTransferConfig(filepath, config);

            bank.SetDefault();
            bank.ReadConfigFile();
            bank.WriteConfigFile();

            bool en = bank.config.lang == "en";
            Transfer fee;
            double fees;

            if (en)
            {
                Console.WriteLine("Please insert the amout of money to transfer: ");
                string amountS = Console.ReadLine();
                double amount = Convert.ToDouble(amountS);
               fee = bank.config.transfer;
                if (amount <= bank.config.transfer.threshold)
                {
                    fees = fee.low_fee;
                } else
                {
                    fees = fee.high_fee;
                }
                Console.WriteLine("Transfer fee = " + fees);
                Console.WriteLine("Amount = " + (amount += fees) );

                int count = 1;
                foreach (String item in bank.config.methods)
                {
                    Console.WriteLine(count + " " + item);
                    count++;
                }
                Console.WriteLine("Select transfer method = ");
                string transferMethod = Console.ReadLine();

                Console.WriteLine("Please Type " + bank.config.confirmation.en + " to confirm the transaction");
                string input = Console.ReadLine();
                if (input == bank.config.confirmation.en)
                {
                    Console.WriteLine("The transfer is completed using " + transferMethod);
                } else
                {
                    Console.WriteLine("Transfer is canceled");
                }

            } else
            {
                Console.WriteLine("Masukan jumlah uang yang akan di transfer: ");
                string amountS = Console.ReadLine();
                double amount = Convert.ToDouble(amountS);
                fee = bank.config.transfer;
                if (amount <= bank.config.transfer.threshold)
                {
                    fees = fee.low_fee;
                }
                else
                {
                    fees = fee.high_fee;
                }
                Console.WriteLine("biaya transfer = " + fees);
                
                Console.WriteLine("total biaya = " + (amount += fees));

                int count = 1;
                foreach (String item in bank.config.methods)
                {
                    Console.WriteLine(count + " " + item);
                    count++;
                }
                Console.WriteLine("pilih metode transfer = ");
                string transferMethod = Console.ReadLine();

                Console.WriteLine("ketik " + bank.config.confirmation.id + " untuk mengkonfirmasi transaksi");
                string input = Console.ReadLine();
                if (input == bank.config.confirmation.en)
                {
                    Console.WriteLine("proses trasfer berhasil menggunakan " + transferMethod);
                }
                else
                {
                    Console.WriteLine("transfer dibatalkan");
                }
            }

            
        }
    }
}