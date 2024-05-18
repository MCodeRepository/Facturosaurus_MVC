﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturosaurus.Domain.Entities
{
    public class PaymentType
    {
        public int Id { get; set; }
        public string Description { get; set; } = "";
        public int DaysToAddToDatePayment { get; set; }
    }
}
