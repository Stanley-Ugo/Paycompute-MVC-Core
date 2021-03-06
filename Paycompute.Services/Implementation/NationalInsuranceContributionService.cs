﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Paycompute.Services.Implementation
{
    public class NationalInsuranceContributionService : INationalInsuranceContributionService
    {
        private decimal NIRate;
        private decimal NIC;
        public decimal NIContribution(decimal totalAmount)
        {
            if (totalAmount < 719)
            {
                //Lower Earning Limit Rate and below primary threshold
                NIRate = .0m;
                NIC = .0m;
            }
            else if (totalAmount >= 719 && totalAmount <= 4167)
            {
                //Between Primary threshold and upper Earning Limits
                NIRate = .12m;
                NIC = ((totalAmount - 719) * NIRate);
            }
            else if( totalAmount > 4167)
            {
                //Above upper Earning Limit
                NIRate = .02m;
                NIC = ((4167 - 719) * .12m) + ((totalAmount - 4167) * NIRate);
            }
            return NIC;
        }
    }
}
