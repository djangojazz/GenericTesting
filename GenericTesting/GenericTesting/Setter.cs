using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTesting
{
  public class Setter : Base_Setter
  {
    public Setter() {}

    public Setter(string overrideValue) 
      : base(overrideValue)  { }
      

    public string Description { get; set; }
    public string Notes { get; set; }
    
  }
}
