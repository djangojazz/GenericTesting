using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDataAccess.Enterprise.Models
{
  public sealed class DemandLocation : INotifyPropertyChanged
  {

    //CONSTRUCTOR
    public DemandLocation()
    {
    }
    public DemandLocation(int locationID, string companyNbr, string divisionNbr, string branchNbr, string branchName)
    {
      this.LocationID = locationID;
      this.CompanyNbr = companyNbr;
      this.DivisionNbr = divisionNbr;
      this.BranchNbr = branchNbr;
      this.BranchName = branchName;
    }


    //PROPERTIES
    public int LocationID { get; set; }

    public string CompanyNbr { get; set; }

    public string DivisionNbr { get; set; }

    public string BranchNbr { get; set; }

    public string BranchName { get; set; }


    private bool _isUsed;
    public bool IsUsed
    {
      get { return _isUsed; }
      set
      {
        _isUsed = value;
        OnPropertyChanged(nameof(IsUsed));
      }
    }

    //METHODS
    public override string ToString()
    {
      return $"{CompanyNbr.Trim()}-{DivisionNbr.Trim()}-{BranchNbr.Trim()} {BranchName.Trim()}";
    }

    public override bool Equals(object obj)
    {
     if (obj.GetType() == typeof(int))
      {
        return Nullable.Equals(this.LocationID, Convert.ToInt32(obj));
      }                                                               
     else
      {
        DemandLocation othr = obj as DemandLocation;
        return (othr == null) ? false : Nullable.Equals(othr.LocationID, this.LocationID);
      }

    }

    public override int GetHashCode()
    {
      return LocationID.GetHashCode();
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public void OnPropertyChanged(string info)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
    }

  }
}
