﻿using Catering.Core.Domain.Entities;
using Catering.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Catering.Models
{
    public class CustomerControlModel:BaseControlModel
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Note { get; set; }
        public string Address { get; set; }
   

        public CustomerControlModel Clone()
        {
            CustomerControlModel model = new CustomerControlModel();
            model.Id = Id;
            model.No = No;
            model.Name = Name;
            model.Phone = Phone;
            model.Email = Email;
            model.Note = Note;
            model.Address = Address;

            return model;
        }

        public bool IsValid()
        {
            if(string.IsNullOrWhiteSpace(Name))
            {
                ErrorMetods.InValidSpace("Müştəri adı");
                return false;
            }
            else if (Name.Length > 15)
            {
                ErrorMetods.InValidLength("Müştəri adı", 15);
                return false;
            }
            if (string.IsNullOrWhiteSpace(Phone))
            {
                ErrorMetods.InValidSpace("Telefon nömrəsi");
                return false;
            }
            else if (!ErrorMetods.PhoneValidationTest(Phone.ToString()))
            {
                return false;
            }
            if (!string.IsNullOrWhiteSpace(Email) && !ErrorMetods.EmailValidationTest(Email.ToString()))
            {
                return false;
            }
            return true;
        }
    }
}
