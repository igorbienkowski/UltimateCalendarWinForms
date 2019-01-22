﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UltimateCalendarWinForms.Models;

namespace UltimateCalendar_WinForms.UI
{
    public partial class NewEventForm : Form
    {
        public NewEventForm()
        {
            InitializeComponent();
            PopulateEventTypeCB();
        }

        private IDataHandler dataHandler;
        private User loggedUser;
        public NewEventForm(IDataHandler dataHandler,User loggedUser)
        {
            InitializeComponent();
            this.dataHandler = dataHandler;
            this.loggedUser = loggedUser;
            PopulateEventTypeCB();
        }

        private void addEventBTN_Click(object sender, EventArgs e)
        {
            Event newEvent = new Event();
            newEvent.Date = eventDatePicker.Value;
            newEvent.Time = eventTimePicker.Value;
            newEvent.Description = descriptionTB.Text;
            newEvent.Type = eventTypeCB.Text;
            newEvent.UserId = loggedUser.UserID;
            dataHandler.AddEvent(newEvent);
            MessageBox.Show("Event successfully added !");
            this.Close();
        }

        private void PopulateEventTypeCB()
        {
            foreach (string type in Enum.GetNames(typeof(EventTypes)))
            {
                eventTypeCB.Items.Add(type);
            }
            eventTypeCB.SelectedIndex = 0;
        }
    }
}