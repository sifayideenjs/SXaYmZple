﻿using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotation.MotorInsuranceModule.Events
{
    public class CancelEvent : PubSubEvent<CancelEventArgs>
    {
    }

    public class CancelEventArgs
    {
    }
}
