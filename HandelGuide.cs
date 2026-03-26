using System;
using System.Windows;
using System.Collections.Generic;
using System.Windows.Controls;
using System.IO;

namespace Hackathon
{
    public class HandelGuide
    {
        public List<GuideEntry> seList = new List<GuideEntry>();
        private StackPanel sp = new StackPanel();

        public HandelGuide(StackPanel stackpannel)
        {
            this.sp = stackpannel;
        }

        public void Load(string path)
        {
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] splitted = line.Split('|');

                        if (splitted.Length < 3)
                            continue;

                        GuideEntry se1 = new GuideEntry(splitted[0], splitted[1], splitted[2]);
                        se1.Margin = new Thickness(10, 10, 10, 0);

                        sp.Children.Add(se1);
                        seList.Add(se1);
                    }
                }
            }
        }
    }
}