using Sitecore.Data.Items;
using Sitecore.Forms.Mvc.Models;
using Sitecore.Forms.Mvc.Validators;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sitecore.Forms.Mvc.Models.Fields
{
  public class NumberField : FieldModel
  {
    private object value;

    [DefaultValue(0)]
    public int MinimumValue
    {
      get;
      set;
    }

    [DefaultValue(int.MaxValue)]
    public int MaximumValue
    {
      get;
      set;
    }

    [DynamicRange("MinimumValue", "MaximumValue", ErrorMessage = "The number in {0} must be at least {1} and no more than {2}.")]
    [RegularExpression("^[-,+]{0,1}\\d*\\.{0,1}\\d+$", ErrorMessage = "Field contains an invalid number.")]
    [DataType(DataType.Text)]
    public override object Value
    {
      get
      {
        return value;
      }
      set
      {
        if (!int.TryParse(value.ToString(), out int num))
        {
          this.value = string.Empty;
        }
        else
        {
          this.value = num;
        }
      }
    }

    public NumberField(Item item)
        : base(item)
    {
      Initialize();
    }

    private void Initialize()
    {
      if (MaximumValue == 0)
      {
        MaximumValue = 2147483647;
      }
    }
  }
}