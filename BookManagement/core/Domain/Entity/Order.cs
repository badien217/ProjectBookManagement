﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Order : Entitybase,IEntitybase
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public decimal Amount { get; set; }
        public string PaymentOption { get; set; }
        public bool TransactionStatus { get; set; }
        public string CheckStatus { get; set; }
        public Order() { }
        public Order(string name, string email, string phone, string address, decimal amount, string paymentOption, bool transactionStatus, string checkStatus)
        {
            Name = name;
            Email = email;
            Phone = phone;
            Address = address;
            Amount = amount;
            PaymentOption = paymentOption;
            TransactionStatus = transactionStatus;
            CheckStatus = checkStatus;
        }
    }
}
