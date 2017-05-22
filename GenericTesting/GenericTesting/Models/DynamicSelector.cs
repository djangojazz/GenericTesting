using System;
using System.Collections.Generic;

namespace GenericTesting.Models
{
  [Serializable]
  public class DynamicSelector
  {
    public Dictionary<string, string> Joins { get; set; }
    //public Dictionary<string, string> Predicate { get; set; }
  }
}
