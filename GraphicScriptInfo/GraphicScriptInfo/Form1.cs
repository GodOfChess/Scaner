using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicScriptInfo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Computer> computerList;
        List<Error> errorList;
        string writePath = @"C:\Pool\info.txt";

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ScanButton_Click(object sender, EventArgs e)
        {
            Thread progressbar = new Thread(new ThreadStart(StartProgressBar));
            progressbar.IsBackground = true;
            progressbar.Start();
            bool flag = false;
            computerList = new List<Computer>();
            errorList = new List<Error>();

            //очистка предыдущего пула
            ComputerListBox.Items.Clear();

            // получение пула адресов из txt
            List<IPAddress> pool = new List<IPAddress>();
            var data = File.ReadAllLines("C:/Pool/pool.txt").ToList();
            foreach (var ip in data)
            {
                if (ip.StartsWith("10.13"))
                {
                    pool.Add(IPAddress.Parse(ip));
                }
            }

            UpdateArp(errorList, pool);
            string output = CreateProcess("/c arp -a");
            string[] lines = output.Split('\n');

            //Заполнение списка компьютеров
            for (int i = 3; i < lines.Length - 1; i++)
            {
                lines[i] = System.Text.RegularExpressions.Regex.Replace(lines[i], @"\s+", " ").Trim();
                string[] sublines = lines[i].Split(' ');
                Computer computer = new Computer();
                computer.IpAddr = sublines[0];
                computer.MacAddr = sublines[1];
                computerList.Add(computer);
            }
            GetNames(computerList);


            //Проверка на получение всех сетевых имен
            while (flag == false)
            {
                flag = CheckNames(computerList);
            }

            //Чистка списка
            computerList.RemoveAll(CheckName);

            //вывод в ListBox
            ComboBox.SelectedItem = "Все кабинеты";
        }

        private void StartProgressBar()
        {
            ProgressBar.Value = ProgressBar.Minimum;
            for (int n = 0; n < 100; n++)
            {
                Thread.Sleep(1);
                ProgressBar.BeginInvoke(new Action(() => ProgressBar.Value = n));
            }
        }

        private static bool CheckName(Computer computer)
        {
            return (!computer.HostName.StartsWith("U3") || computer.HostName.StartsWith("U305"));
        }

        // создание процесса
        private static string CreateProcess(string cmd)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = "cmd.exe";
            proc.StartInfo.Arguments = cmd;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.Start();
            return proc.StandardOutput.ReadToEnd();
        }

        //обновление арп таблицы
        private static void UpdateArp(List<Error> errorList, List<IPAddress> pool)
        {
            List<Task> tps = new List<Task>();
            foreach (var ip in pool)
            {
                tps.Add(InitiatePingAsync(ip, errorList));
            }
            Task.WhenAll(tps.ToArray());
        }

        // пинг по компам
        private static async Task InitiatePingAsync(IPAddress ip, List<Error> errorList)
        {
            var result = await new Ping().SendPingAsync(ip);
            if (result.Status.ToString() == "DestinationHostUnreachable")
            {
                errorList.Add(new Error { ErrorMessage = "Хост недоступен", IpAddr = ip, bytes = ip.ToString().Split('.') });
            }
            else if (result.Status.ToString() == "TimedOut")
            {
                errorList.Add(new Error { ErrorMessage = "Истекло время ожидания", IpAddr = ip, bytes = ip.ToString().Split('.') });
            }
            else if (result.Status.ToString() == "11050" || result.Status.ToString() != "Success")
            {
                errorList.Add(new Error { ErrorMessage = "Неизвестная ошибка", IpAddr = ip, bytes = ip.ToString().Split('.') });
            }
        }

        // получение сетевых имен
        private static void GetNames(List<Computer> computerList)
        {
            List<Task> tps = new List<Task>();
            for (int i = 0; i < computerList.Count; i++)
            {
                tps.Add(GetHostNameAsync(computerList[i]));
            }
        }

        // получение отдельного сетевого имени
        private static async Task GetHostNameAsync(Computer computer)
        {
            await Task.Run(() =>
            {
                try
                {
                    var host = Dns.GetHostEntry(IPAddress.Parse(computer.IpAddr));
                    computer.HostName = host.HostName.Substring(0,7);
                }
                catch
                {
                    computer.HostName = "Хост неизвестен";
                }
            });
        }

        // проверка на наличие всех сетевых имен
        private static bool CheckNames(List<Computer> computerList)
        {
            for (int i = 0; i < computerList.Count; i++)
            {
                if (computerList[i].HostName == null)
                {
                    break;
                }
                else if (i == computerList.Count - 1)
                {
                    return true;
                }
            }
            return false;
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filter(ComboBox.SelectedItem.ToString());
        }

        private void Filter(string filter)
        {
            ComputerListBox.Items.Clear();
            if (filter == "Все кабинеты")
            {
                Print(computerList);
            }
            else if (filter == "U301")
            {
                foreach(var computer in computerList)
                {
                    if (computer.HostName.StartsWith("U301"))
                    {
                        ComputerListBox.Items.Add($"Имя узла: { computer.HostName} MAC: { computer.MacAddr} IP: { computer.IpAddr}");
                    }
                }
            }
            else if (filter == "U302")
            {
                foreach (var computer in computerList)
                {
                    if (computer.HostName.StartsWith("U302"))
                    {
                        ComputerListBox.Items.Add($"Имя узла: { computer.HostName} MAC: { computer.MacAddr} IP: { computer.IpAddr}");
                    }
                }
            }
            else if (filter == "U303")
            {
                foreach (var computer in computerList)
                {
                    if (computer.HostName.StartsWith("U303"))
                    {
                        ComputerListBox.Items.Add($"Имя узла: { computer.HostName} MAC: { computer.MacAddr} IP: { computer.IpAddr}");
                    }
                }
            }
            else if (filter == "U304")
            {
                foreach (var computer in computerList)
                {
                    if (computer.HostName.StartsWith("U304"))
                    {
                        ComputerListBox.Items.Add($"Имя узла: { computer.HostName} MAC: { computer.MacAddr} IP: { computer.IpAddr}");
                    }
                }
            }
            else if (filter == "U306")
            {
                foreach (var computer in computerList)
                {
                    if (computer.HostName.StartsWith("U306"))
                    {
                        ComputerListBox.Items.Add($"Имя узла: { computer.HostName} MAC: { computer.MacAddr} IP: { computer.IpAddr}");
                    }
                }
            }
            else if (filter == "U307")
            {
                foreach (var computer in computerList)
                {
                    if (computer.HostName.StartsWith("U307"))
                    {
                        ComputerListBox.Items.Add($"Имя узла: { computer.HostName} MAC: { computer.MacAddr} IP: { computer.IpAddr}");
                    }
                }
            }
            else if (filter == "U308")
            {
                foreach (var computer in computerList)
                {
                    if (computer.HostName.StartsWith("U308"))
                    {
                        ComputerListBox.Items.Add($"Имя узла: { computer.HostName} MAC: { computer.MacAddr} IP: { computer.IpAddr}");
                    }
                }
            }
            else if (filter == "U309")
            {
                foreach (var computer in computerList)
                {
                    if (computer.HostName.StartsWith("U309"))
                    {
                        ComputerListBox.Items.Add($"Имя узла: { computer.HostName} MAC: { computer.MacAddr} IP: { computer.IpAddr}");
                    }
                }
            }
            else if (filter == "U310")
            {
                foreach (var computer in computerList)
                {
                    if (computer.HostName.StartsWith("U310"))
                    {
                        ComputerListBox.Items.Add($"Имя узла: { computer.HostName} MAC: { computer.MacAddr} IP: { computer.IpAddr}");
                    }
                }
            }
            else if (filter == "U311")
            {
                foreach (var computer in computerList)
                {
                    if (computer.HostName.StartsWith("U311"))
                    {
                        ComputerListBox.Items.Add($"Имя узла: { computer.HostName} MAC: { computer.MacAddr} IP: { computer.IpAddr}");
                    }
                }
            }
            else if (filter == "U312")
            {
                foreach (var computer in computerList)
                {
                    if (computer.HostName.StartsWith("U312"))
                    {
                        ComputerListBox.Items.Add($"Имя узла: { computer.HostName} MAC: { computer.MacAddr} IP: { computer.IpAddr}");
                    }
                }
            }
            else if (filter == "U313")
            {
                foreach (var computer in computerList)
                {
                    if (computer.HostName.StartsWith("U313"))
                    {
                        ComputerListBox.Items.Add($"Имя узла: { computer.HostName} MAC: { computer.MacAddr} IP: { computer.IpAddr}");
                    }
                }
            }
            else if (filter == "U314")
            {
                foreach (var computer in computerList)
                {
                    if (computer.HostName.StartsWith("U314"))
                    {
                        ComputerListBox.Items.Add($"Имя узла: { computer.HostName} MAC: { computer.MacAddr} IP: { computer.IpAddr}");
                    }
                }
            }
            else if (filter == "U315")
            {
                foreach (var computer in computerList)
                {
                    if (computer.HostName.StartsWith("U315"))
                    {
                        ComputerListBox.Items.Add($"Имя узла: { computer.HostName} MAC: { computer.MacAddr} IP: { computer.IpAddr}");
                    }
                }
            }
            else if (filter == "Ошибки")
            {
                errorList = errorList.OrderBy(err => Convert.ToInt32(err.bytes[2])).ThenBy(err => Convert.ToInt32(err.bytes[3])).ToList();
                foreach (var error in errorList)
                {
                    ComputerListBox.Items.Add($"IP: {error.IpAddr, -20} Error: {error.ErrorMessage}");
                }
            }
        }

        private void Print(List<Computer> computerList)
        {
            if (computerList.Count != 0)
            {
                foreach (var computer in computerList)
                {
                    ComputerListBox.Items.Add($"Имя узла: { computer.HostName, -5} MAC: { computer.MacAddr, -10} IP: { computer.IpAddr}");
                }
            }
            else
            {
                ComputerListBox.Items.Add("Компьютеров не найдено");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = new StreamWriter(writePath, false, Encoding.Default))
            {
                for(int i = 0; i < ComputerListBox.Items.Count; i++)
                {
                    sw.WriteLine(ComputerListBox.Items[i]);
                }
            }
            MessageBox.Show("Готово! Путь к файлу C:/Pool/info.txt");
        }

        private void NameButton_Click(object sender, EventArgs e)
        {
            string s = NameText.Text;
            ComputerListBox.Items.Clear();
            foreach (var computer in computerList)
            {
                if (computer.HostName == s && (computer.HostName.StartsWith(ComboBox.SelectedItem.ToString()) ||
                    ComboBox.SelectedItem.ToString() == "Все кабинеты"))
                {
                    ComputerListBox.Items.Add($"Имя узла: { computer.HostName,-5} MAC: { computer.MacAddr,-10} IP: { computer.IpAddr}");
                }
            }
        }

        private void MACButton_Click(object sender, EventArgs e)
        {
            string s = MacText.Text;
            ComputerListBox.Items.Clear();
            foreach (var computer in computerList)
            {
                if (computer.MacAddr == s && (computer.HostName.StartsWith(ComboBox.SelectedItem.ToString()) ||
                    ComboBox.SelectedItem.ToString() == "Все кабинеты"))
                {
                    ComputerListBox.Items.Add($"Имя узла: { computer.HostName,-5} MAC: { computer.MacAddr,-10} IP: { computer.IpAddr}");
                }
            }
        }

        private void IPButton_Click(object sender, EventArgs e)
        {
            string s = IPText.Text;
            ComputerListBox.Items.Clear();
            if (ComboBox.SelectedItem.ToString() == "Ошибки")
            {
                foreach(var error in errorList)
                {
                    if (error.IpAddr.ToString() == s)
                    {
                        ComputerListBox.Items.Add($"IP: {error.IpAddr,-20} Error: {error.ErrorMessage}");
                    }
                }
            }
            else
            {
                foreach (var computer in computerList)
                {
                    if (computer.IpAddr == s && (computer.HostName.StartsWith(ComboBox.SelectedItem.ToString()) ||
                        ComboBox.SelectedItem.ToString() == "Все кабинеты"))
                    {
                        ComputerListBox.Items.Add($"Имя узла: { computer.HostName,-5} MAC: { computer.MacAddr,-10} IP: { computer.IpAddr}");
                    }
                }
            }
        }
    }
}
