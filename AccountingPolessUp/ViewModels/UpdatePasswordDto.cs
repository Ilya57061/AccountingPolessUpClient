﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingPolessUp.ViewModels
{
    public class UpdatePasswordDto
    {
        public int Id { get; set; }
        public string Password { get; set; } = string.Empty;
    }
}