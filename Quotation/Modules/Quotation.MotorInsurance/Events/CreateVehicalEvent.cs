﻿using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotation.MotorInsuranceModule.Events
{
    public class CreateVehicalEvent : PubSubEvent<CreateVehicalEventArgs>
    {
    }

    public class CreateVehicalEventArgs
    {
        //public int Id { get; set; }
        //public string ViewModelName { get; set; }
    }
}
