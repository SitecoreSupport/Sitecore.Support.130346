﻿using Sitecore.Forms.Mvc.Validators;
using Sitecore.Forms.Mvc.ViewModels;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sitecore.Support.Forms.Mvc.ViewModels.Fields
{
    public class NumberField : ValuedFieldViewModel<string>
    {
        [DefaultValue(0)]
        public double MinimumValue
        {
            get;
            set;
        }

        [DefaultValue(1.7976931348623157E+308)]
        public double MaximumValue
        {
            get;
            set;
        }

        // Sitecore.Support.130346
        [DynamicRange("MinimumValue", "MaximumValue", ErrorMessage = "The number in {0} must be at least {1} and no more than {2}."), DynamicRegularExpression("^[-,+]{0,1}\\d*\\.{0,1}\\d+$", null, ErrorMessage = "The {0} field contains an invalid number.")]
        public override string Value
        {
            get;
            set;
        }

        public override void Initialize()
        {
            if (this.MaximumValue == 0.0)
            {
                this.MaximumValue = 2147483647.0;
            }
        }
    }
}