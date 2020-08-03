﻿using PizzaRestaurant.Command;
using PizzaRestaurant.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PizzaRestaurant.ViewModel
{
    class MainWindowViewModel
    {
        MainWindow main;
        LoginValidation lv = new LoginValidation();

        public MainWindowViewModel(MainWindow login)
        {
            main = login;
        }
        private ICommand submit;
        public ICommand Submit
        {
            get
            {
                if (submit == null)
                {
                    submit = new RelayCommand(param => SubmitExecute(), param => CanSubmitExecute());
                }
                return submit;
            }
        }
        private void SubmitExecute()
        {
            lv.Login(main.usernameBox.Text, main.passwordBox.Password, main);
        }
        private bool CanSubmitExecute()
        {
            if (String.IsNullOrEmpty(main.usernameBox.Text) || String.IsNullOrEmpty(main.passwordBox.Password))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
