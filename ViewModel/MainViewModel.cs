﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPRSSapp.Model;
using System.ComponentModel;

namespace UWPRSSapp.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private Rss rss;
        public Rss CurrentRss
        {
            get { return this.rss; }
            set
            {
                this.rss = value;
                NotifyPropertyChanged("CurrentRss");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged!=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

    }
}
