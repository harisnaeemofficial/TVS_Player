﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;

namespace TVS_Player {
    /// <summary>
    /// Interaction logic for ShowInfo.xaml
    /// </summary>
    public partial class ShowInfo : Page {
        ShowRectangle sr;
        public ShowInfo() {
            InitializeComponent();
        }

        public ShowInfo(int ID, ShowRectangle sr) {
            this.sr = sr;
            InitializeComponent();
            JObject jo = JObject.Parse(Api.apiGet(ID));
            JmenoSerialu.Content = jo["data"]["seriesName"].ToString();
            Popisek.Text = jo["data"]["overview"].ToString();
            Rok.Text = jo["data"]["firstAired"].ToString();
            Api.apiGetPoster(ID,false);
            Obrazek.Source = new BitmapImage(new Uri(Helpers.path + "//"+ sr.ID+"//"+ sr.filename));
        }

        private void ReturnBack_Event(object sender, MouseButtonEventArgs e) {
            Window main = Window.GetWindow(this);
            ((MainWindow)main).SetFrameView((Page)new Shows());
        }
    }
}