﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Faq : Entitybase,IEntitybase
    {
        public string question { get; set; }
        public string answer { get; set; }
        public Faq() { }
        public Faq(string question, string answer)
        {
            this.question = question;
            this.answer = answer;
        }
    }
}
