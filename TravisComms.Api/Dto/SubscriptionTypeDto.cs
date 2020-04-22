﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravisComms.Api.Dto
{
    public class SubscriptionTypeDto
    {
        public Guid SubscriptionTypeId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int PeriodInDays { get; set; }

    }
}
