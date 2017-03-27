﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;

namespace MVC.ViewModels
{
    public class CreateBetViewModel
    {
        [DisplayName("Buy in")]
        public string BuyIn { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("Start date")]
        public string StartDate { get; set; }

        [DisplayName("Stop date")]
        public string StopDate { get; set; }

        [DisplayName("Title")]
        public string Title { get; set; }
        
         //public List<string> Outcomes { get; set; }
        [DisplayName("Outcome #1")]
        public string Outcome1 { get; set; }

        [DisplayName("Outcome #2")]
        public string Outcome2 { get; set; }

        public string Judge { get; set; }

        [HiddenInput]
        public long LobbyID { get; set; }
    }
}