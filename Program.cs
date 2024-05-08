using System;
using System.Diagnostics;
using System.Threading;
using Newtonsoft.Json;
using System.IO;

public class Program
{
    
    public class AppConfig
    {
        public bool ethernet;
        public bool wifi;
    }
    
    static void Main()
    {

        if (!File.Exists("config.json"))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ERROR: config.json was not found, make sure you have the config.json file in the same directory as NetworkResetter.exe");
            Console.ReadKey();
        }
        
        string json = File.ReadAllText("config.json");

        AppConfig config = JsonConvert.DeserializeObject<AppConfig>(json);
        
        string nrLogo = @"░█▀█░█▀▀░▀█▀░█░█░█▀█░█▀▄░█░█░░░█▀▄░█▀▀░█▀▀░█▀▀░▀█▀░▀█▀░█▀▀░█▀▄
░█░█░█▀▀░░█░░█▄█░█░█░█▀▄░█▀▄░░░█▀▄░█▀▀░▀▀█░█▀▀░░█░░░█░░█▀▀░█▀▄
░▀░▀░▀▀▀░░▀░░▀░▀░▀▀▀░▀░▀░▀░▀░░░▀░▀░▀▀▀░▀▀▀░▀▀▀░░▀░░░▀░░▀▀▀░▀░▀";


        Console.Title = "Network Resetter";
        Console.WriteLine(nrLogo);
        Thread.Sleep(3000);
        Console.Clear();

        bool ethernetEnabled = config.ethernet;
        bool wifiEnabled = config.wifi;

        if (wifiEnabled == true)
        {
            string command = "/c netsh interface set interface Wi-Fi disable && netsh interface set interface Wi-Fi enable";
            Console.Clear();
            Console.Beep(500, 500);
            Console.WriteLine("Resetting Wi-Fi...");
            Process.Start("cmd.exe", command);
            Thread.Sleep(5000);
        }
        else if (ethernetEnabled == true)
        {
            string command = "/c netsh interface set interface Ethernet disable && netsh interface set interface Ethernet enable";
            Console.Clear();
            Console.Beep(500, 500);
            Console.WriteLine("Resetting Ethernet...");
            Process.Start("cmd.exe", command);
        }
    }
  }

