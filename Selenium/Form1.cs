using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;

namespace Selenium
{
    public partial class Form1 : Form
    {
        IWebDriver Browser;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Browser = new OpenQA.Selenium.Chrome.ChromeDriver();
            Browser.Manage().Window.Maximize();
            Browser.Navigate().GoToUrl("http://google.com");

            IWebElement SearchInput = Browser.FindElement (By.Name ("q"));
            SearchInput.SendKeys("Selenium driver how to " + OpenQA.Selenium.Keys.Enter);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Browser.Quit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            OpenQA.Selenium.Chrome.ChromeOptions co = new OpenQA.Selenium.Chrome.ChromeOptions();
            co.AddArgument(@"user-data-dir=C:\Users\Aram\AppData\Local\Google\Chrome\User Data\");
            //co.AddArgument("--disable-infobars");
            Browser = new OpenQA.Selenium.Chrome.ChromeDriver(co);
            //Browser.Navigate().GoToUrl("http://yandex.ru");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            IWebElement element;
            //element = Browser.FindElement(By.Id("text"));
            //element.SendKeys("test");

            // Ищем по DIV 
            //element = Browser.FindElement(By.ClassName("820"));
            // element = Browser.FindElement(By.Id("uniq392"));
            // element.Click();

            //Link search
            //element = Browser.FindElement(By.LinkText("Картинки"));
            //element.Click();

            // поиск по частичному тексту ссылки
            element = Browser.FindElement(By.PartialLinkText("ревод"));
            element.Click();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            List<IWebElement> News = Browser.FindElements(By.CssSelector("#news_panel_news a")).ToList();
            for (int i = 0; i < News.Count; i++)
            {
                textBox1.AppendText(News[i].Text+ "\r\n" );

               /* String s = News[i].Text;
                if (s.Contains("Some text here ..."))
                {
                    textBox1.AppendText(News[i].Text+ "\r\n");
                }
               else  if (s.EndsWith("Some text here ..."))
                {
                    textBox1.AppendText(News[i].Text + "\r\n");
                    News[i].Click();
                    break;*/
                }

            }

        private void button6_Click(object sender, EventArgs e)
        {    // java script executiion 
            IJavaScriptExecutor jse = Browser as IJavaScriptExecutor;
            //jse.ExecuteScript("alert('Java works');");
            jse.ExecuteScript(textBox1.Text);
        }

      private string FindWindow(String Url)
        {
            String StartWindow = Browser.CurrentWindowHandle;
            String Result = "";

            for (int i = 0; i < Browser.WindowHandles.Count; i++)
            {
                if (Browser.WindowHandles[i] != StartWindow)
                {
                    Browser.SwitchTo().Window(Browser.WindowHandles[i]);
                    if (Browser.Url.Contains(Url))
                    {
                        Result = Browser.WindowHandles[i];
                        break;
                    }
                }
            }


            Browser.SwitchTo().Window(StartWindow);
            return Result;
        }
        private void button7_Click(object sender, EventArgs e)
        {
              Browser.SwitchTo().Window( Browser.WindowHandles[1] );
            System.Windows.Forms.MessageBox.Show(Browser.Title + "\r\n" + Browser.Url);

            Browser.SwitchTo().Window(Browser.WindowHandles[0]);
            System.Windows.Forms.MessageBox.Show(Browser.Title + "\r\n" + Browser.Url);

            Browser.SwitchTo().Window(Browser.WindowHandles[2]);
            System.Windows.Forms.MessageBox.Show(Browser.Title + "\r\n" + Browser.Url);

            /*String HabrWindow = FindWindow("habr");
            Browser.SwitchTo().Window(HabrWindow);
            System.Windows.Forms.MessageBox.Show(Browser.Title + "\r\n" + Browser.Url);  */ 

            //List<String> BeforeTabs = Browser.WindowHandles.ToList();
            //делаем что то - открывается одна новая вкладка
            //....
            //List<String> AfterTabs = Browser.WindowHandles.ToList();
            //вкладки до - вкладки после = новая вкладка
            //List<String> OneNewTab = AfterTabs.Except(BeforeTabs).ToList();
            //Browser.SwitchTo().Window(OneNewTab[0]);
            //System.Windows.Forms.MessageBox.Show(Browser.Title + "\r\n" + Browser.Url);
        }
    }

       
    }

