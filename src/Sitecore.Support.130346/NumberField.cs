using Sitecore.Data.Items;
using Sitecore.Forms.Mvc.Models;
using Sitecore.Forms.Mvc.Validators;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sitecore.Support.Forms.Mvc.Models.Fields
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

    [DynamicRange("MinimumValue", "MaximumValue")]
    [DynamicRegularExpression("^[-,+]{0,1}\\d*\\.{0,1}\\d+$", null)]
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