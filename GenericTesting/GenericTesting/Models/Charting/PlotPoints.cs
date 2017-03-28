﻿
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace Controls.Charting
{
  public sealed class PlotPoints
  {                            
    public PlotPoint X { get; }
    public PlotPoint Y { get; }

    public PlotPoints(PlotPoint x, PlotPoint y)
    {
      this.X = x;
      this.Y = y;
      if ((Y.PointType == typeof(int)) || (Y.PointType == typeof(double)) || (Y.PointType == typeof(decimal)))
      {

      }
    }

    public double XAsDouble
    {
      get
      {
        if (X.PointType == typeof(int)) { return Convert.ToDouble(((PlotPoint<int>)X).Point); }
        else if (X.PointType == typeof(double)) { return Convert.ToDouble(((PlotPoint<double>)X).Point); }
        else if (X.PointType == typeof(decimal)) { return Convert.ToDouble(((PlotPoint<decimal>)X).Point); }
        else if (X.PointType == typeof(DateTime)) { return Convert.ToDouble(((PlotPoint<DateTime>)X).Point.Ticks); }
        else { return 0; }
      }
    }

    public double YAsDouble
    {
      get
      {
        if (Y.PointType == typeof(int)) { return Convert.ToDouble(((PlotPoint<int>)Y).Point); }
        else if (Y.PointType == typeof(double)) { return Convert.ToDouble(((PlotPoint<double>)Y).Point); }
        else if (Y.PointType == typeof(decimal)) { return Convert.ToDouble(((PlotPoint<decimal>)Y).Point); }
        else if (Y.PointType == typeof(DateTime)) { return Convert.ToDouble(((PlotPoint<DateTime>)Y).Point.Ticks); }
        else { return 0; }
      }
    }

    public override string ToString()
    {
      return $"X {XAsDouble} Y {YAsDouble}";
    } 
  }
}