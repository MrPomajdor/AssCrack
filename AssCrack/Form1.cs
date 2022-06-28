using System;
using System.Diagnostics;
using System.ComponentModel;
using Microsoft.VisualBasic;
using System.Security.Principal;
namespace AssCrack
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public static int ModifyHostsFile(string entry)
        {
            try
            {
                bool fileExists = File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), @"drivers\etc\hosts"));
                
                if (!fileExists) 
                {
                    using (File.Create(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), @"drivers\etc\hosts"))) ;
                }
                    string text = File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), @"drivers\etc\hosts"));
                
                if (!text.Contains("a086e0efbad65f0bb.awsglobalaccelerator.com"))
                {
                    using (StreamWriter w = File.AppendText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), @"drivers\etc\hosts")))
                    {
                        w.WriteLine(entry);
                        return 0;
                    }
                }
                else
                {
                    return 3;
                }
            }
            catch (Exception ex)
            {
                return 1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ip = System.Net.Dns.GetHostAddresses("ass.dupaa.cf")[0];
            //log.Items.Add(ip);

            int dupa = ModifyHostsFile(ip + " a086e0efbad65f0bb.awsglobalaccelerator.com");
            if (dupa == 0)
            {
                log.Items.Add("\nHosts file modified!");
            }
            else if(dupa == 1)
            {
                log.Items.Add("\nError modifying hosts file: run AssCrack ass administrator!");

            }
            else if(dupa == 3)
            {
                log.Items.Add("\nAssCrack alredy installed!");

            }
            log.TopIndex = log.Items.Count - 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string text = File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), @"drivers\etc\hosts"));
            //log.Items.Add(text);
            if (text.Contains("a086e0efbad65f0bb.awsglobalaccelerator.com"))
            {
                text = text.Replace("51.77.48.168 a086e0efbad65f0bb.awsglobalaccelerator.com", string.Empty);
                //log.Items.Add(text);

                File.WriteAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), @"drivers\etc\hosts"), new[] { text });
                log.Items.Add("\nRemoved!");
            }
            else
            {
                log.Items.Add("\nAssCrack isn't activated!");

            }
            log.TopIndex = log.Items.Count - 1;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("AssCrack Boss : rysiek B)\nDeveloper 1 : pomidorek(crack app/api creator)\nDeveloper 2 : adrianek(researcher)","Our team",MessageBoxButtons.OK,MessageBoxIcon.Information);
            
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://i.imgur.com/rDLgAuj.png",
                UseShellExecute = true
            });
        }
    }
}