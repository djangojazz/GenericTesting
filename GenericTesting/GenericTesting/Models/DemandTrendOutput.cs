using System;     

namespace CSharpDataAccess.Enterprise.Models
{
  public sealed class DemandTrendOutput
  {
    public string GroupingName { get; set; }
    public int Grouping { get; set; }
    public DateTime GroupingStartDate { get; set; }
    public decimal DemandQty { get; set; }
    public decimal DemandAdQty { get; set; }
  }
}
