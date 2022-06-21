using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace GetInfoGPW
{
    class Program
    {
        static void Main(string[] args)
        {
            string html = string.Empty;
            string url = "https://www.investing.com/equities/x-trade-brokers-dom-maklerski-sa";
            string leading="";
            double valueBefore=0;
            double deviacionVal = 0;
            double val1 = 0;
            double resWeb = 0;
            int i = 0;
            while (i < 100)
            {


                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.UserAgent = "C# console client";

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    html = reader.ReadToEnd();
                }
                //Console.WriteLine(html)rr;

                var cureSubNo = "arial_26 inlineblock pid-977696-last";
                var indexof = html.IndexOf(cureSubNo, StringComparison.Ordinal);

                leading = html.Substring(indexof + 63, 5);

                resWeb = double.Parse(leading, System.Globalization.CultureInfo.InvariantCulture);

                deviacionVal = (resWeb - valueBefore) * 100 / valueBefore;

                valueBefore = resWeb;
                Console.WriteLine(leading + " " + Convert.ToString(deviacionVal, CultureInfo.InvariantCulture));
                System.Threading.Thread.Sleep(10000);
                i = i + 1;
            }

            MessageBox.Show("test111");
            
            Console.ReadKey();
        }

    }

  
}
