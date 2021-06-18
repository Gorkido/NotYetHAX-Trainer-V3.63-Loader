using DiscordRPC;
using DiscordRPC.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Button = DiscordRPC.Button;

namespace NotYetHAX
{
    public partial class NotYetHAX : Form
    {
        public DiscordRpcClient client;
        bool initalized = false;
        public NotYetHAX()
        {
            InitializeComponent();
            this.TransparencyKey = this.BackColor; //invisibility command
        }

        // For Extracting Files..
        private static void Extract(string nameSpace, string outDirectory, string internalFilePath, string resourceName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            using (Stream s = assembly.GetManifestResourceStream(nameSpace + "." + (internalFilePath == "" ? "" : internalFilePath + ".") + resourceName))
            using (BinaryReader r = new BinaryReader(s))
            using (FileStream fs = new FileStream(outDirectory + "\\" + resourceName, FileMode.OpenOrCreate))
            using (BinaryWriter w = new BinaryWriter(fs))
                w.Write(r.ReadBytes((int)s.Length));
        }
        // For Extracting Files..

        private void NotYetHAX_Load(object sender, EventArgs e)
        {
            //invisible
            this.Left = 0; // Sets the company not to appear on the screen
            this.Top = 0; // Sets the company not to appear on the screen
            this.Width = Screen.PrimaryScreen.Bounds.Width; // Sets the company not to appear on the screen
            this.Height = Screen.PrimaryScreen.Bounds.Height; // Sets the company not to appear on the screen
            //invisible
            string dir = @"\NotYetHAX";
            string sPath = Path.GetTempPath(); //getting temp's path
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(sPath + dir); //if \NotYetHAX doesn't exist it'll create the folder
            }
            string d = @"\NotYetHAX\NotYetHAX's_Trainer.EXE";
            string c = @"\NotYetHAX\NotYetHAX_Unbanner.exe";
            string a = @"\NotYetHAX\READ_ME.txt";
            File.Delete(sPath + d); // Deletes "\NotYetHAX\NotYetHAX's_Trainer.EXE"
            File.Delete(sPath + c); // Deletes "\NotYetHAX\NotYetHAX_Unbanner.exe"
            File.Delete(sPath + a); // Deletes "\NotYetHAX\READ_ME.txt"
            Thread.Sleep(5000); // Wait for 5 seconds
            string CE = @"\NotYetHAX\NotYetHAX's_Trainer.EXE";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(sPath + dir); //if \NotYetHAX doesn't exist it'll create the folder
            }
            Extract("NotYetHAX", sPath + dir, "Resources", "NotYetHAX_Unbanner.exe"); // Extracting "NotYetHAX_Unbanner.exe"
            Extract("NotYetHAX", sPath + dir, "Resources", "NotYetHAX's_Trainer.EXE");// Extracting "NotYetHAX's_Trainer.EXE"
            Extract("NotYetHAX", sPath + dir, "Resources", "READ_ME.txt");// Extracting "READ_ME.txt"
            Process.Start(sPath + CE); // Starting the trainer ( "NotYetHAX's_Trainer.EXE" )
            Thread.Sleep(15000); // Wait for 5 seconds
            CheckProcess.Start();
        }

        private void NotYetHAX_Shown(object sender, EventArgs e)
        {
            this.Hide();
            // Discord RPC
            initalized = true;
            client = new DiscordRpcClient($"840215665348444190");
            client.Logger = new ConsoleLogger() { Level = LogLevel.Warning };
            client.Initialize();
            Thread.Sleep(500); // Sleep for 0.5 seconds
            if (initalized == false)
            {

            }
            else
            {
                client.SetPresence(new DiscordRPC.RichPresence()
                {
                    Buttons = new Button[]
                {
                    new Button() { Label = "Discord Server", Url = "https://discord.gg/rEAT4SKg4S" }, // First button and its link
                    new Button() { Label = "Website", Url = "https://notyethax.gq/" } // Second button and its link

                },
                    Details = $"A Cheating Tool For Growtopia",
                    Timestamps = Timestamps.Now,
                    Assets = new Assets()
                    {
                        LargeImageKey = $"notyethax",
                        LargeImageText = "NotYetHAX",
                        SmallImageKey = $"gtexe",
                        SmallImageText = $"Growtopia",
                    }
                });
            }
            // Discord RPC
        }

        private void CheckProcess_Tick(object sender, EventArgs e) // Checking if NotYetHAX's_Trainer.EXE running or not. If not it'll close the application. (You can delete this part if you want)
        {
            Process[] pname = Process.GetProcessesByName("NotYetHAX's_Trainer");
            if (pname.Length > 0)
            {

            }
            else
            {
                string d = @"\NotYetHAX\NotYetHAX's_Trainer.EXE";
                string c = @"\NotYetHAX\NotYetHAX_Unbanner.exe";
                string a = @"\NotYetHAX\READ_ME.txt";
                string sPath = Path.GetTempPath();
                File.Delete(sPath + d); // Deletes "\NotYetHAX\NotYetHAX's_Trainer.EXE"
                File.Delete(sPath + c); // Deletes "\NotYetHAX\NotYetHAX_Unbanner.exe"
                File.Delete(sPath + a); // Deletes "\NotYetHAX\READ_ME.txt"
                Thread.Sleep(5000); // Wait for 5 seconds
                Application.Exit();
            }
        }

        private void CETimer_Tick(object sender, EventArgs e) // CE Check (Remove this part if you wish)
        {
            var processkill1 = Process.GetProcesses().
            Where(pr => pr.ProcessName == "Fixed Cheat Engine By NotYetHAX (7.1)");
            foreach (var process in processkill1)
            {
                process.Kill(); // Kill "Fixed Cheat Engine By NotYetHAX (7.1)"
                Application.Exit();
            }
            var processkill2 = Process.GetProcesses().
                Where(pr => pr.ProcessName == "Fixed Cheat Engine By NotYetHAX (7.2)");
            foreach (var process in processkill2)
            {
                process.Kill(); // Kill "Fixed Cheat Engine By NotYetHAX (7.2)"
                Application.Exit();
            }
            var processkill3 = Process.GetProcesses().
               Where(pr => pr.ProcessName == "Fixed Engine");
            foreach (var process in processkill3)
            {
                process.Kill(); // Kill "Fixed Engine"
                Application.Exit();
            }
            var processkill4 = Process.GetProcesses().
               Where(pr => pr.ProcessName == "draqxorengine-x86_64");
            foreach (var process in processkill4)
            {
                process.Kill(); // Kill "draqxorengine-x86_64"
                Application.Exit();
            }
            var processkill5 = Process.GetProcesses().
               Where(pr => pr.ProcessName == "Cheat Engine");
            foreach (var process in processkill5)
            {
                process.Kill(); // Kill "Cheat Engine"
                Application.Exit();
            }
            var processkill6 = Process.GetProcesses().
               Where(pr => pr.ProcessName == "cheatengine-x86_64");
            foreach (var process in processkill6)
            {
                process.Kill(); // Kill "cheatengine-x86_64"
                Application.Exit();
            }
        }
    }
}
