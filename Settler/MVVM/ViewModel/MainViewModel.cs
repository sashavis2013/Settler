﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Settler.Core;
using Settler.MVVM.Model;

namespace Settler.MVVM.ViewModel
{
    class MainViewModel:ObservableObject
    {
        public ObservableCollection<MessageModel> Messages { get; set; }
        public ObservableCollection<ContactModel> Contacts { get; set; }

        //commands
        public RelayCommand SendCommand { get; set; }

        private ContactModel _selectedContact;

        public ContactModel SelectedContact
        {
            get { return _selectedContact; }
            set
            {
                _selectedContact = value;
                OnPropertyChanged();
            }
        }


        private string _message;

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value; 
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            Messages = new ObservableCollection<MessageModel>();
            Contacts = new ObservableCollection<ContactModel>();
            SendCommand = new RelayCommand(o =>
            {
                Messages.Add(new MessageModel
                {
                    Message=Message, FirstMessage=false
                });
                Message = "";
            });


            Messages.Add(new MessageModel
            {
                Username = "Allison",
                UsernameColor = "#489aff",
                ImageSource = "https://i.imgur.com/yMWvLXd.png",
                Message = "Test",
                Time = DateTime.Now,
                IsNativeOrigin = false,
                FirstMessage = true,
            });

            for (int i = 0; i < 3; i++)
            {
                Messages.Add(new MessageModel
                {
                    Username = "Allison",
                    UsernameColor = "#489aff",
                    ImageSource = "https://i.imgur.com/yMWvLXd.png",
                    Message = "Test",
                    Time = DateTime.Now,
                    IsNativeOrigin = false,
                    FirstMessage = false,
                });
            }

            for (int i = 0; i < 4; i++)
            {
                Messages.Add(new MessageModel
                {
                    Username = "Bunny",
                    UsernameColor = "#489aff",
                    ImageSource = "https://i.imgur.com/yMWvLXd.png",
                    Message = "Test",
                    Time = DateTime.Now,
                    IsNativeOrigin = true,
                });
            }

            for (int i = 0; i < 3; i++)
            {
                Messages.Add(new MessageModel
                {
                    Username = "Allison",
                    UsernameColor = "#489aff",
                    ImageSource = "https://i.imgur.com/yMWvLXd.png",
                    Message = "Last",
                    Time = DateTime.Now,
                    IsNativeOrigin = false,
                    FirstMessage = false,
                });
            }


            for (int i = 0; i < 5; i++)
            {
                Contacts.Add(new ContactModel
                {
                    Username = "Allison",
                    ImageSource = "https://i.imgur.com/yMWvLXd.png",
                    Messages = Messages,
                });
            }


        }
    }
}