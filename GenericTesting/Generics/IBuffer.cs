﻿using System.Collections.Generic;

namespace Generics
{
  public interface IBuffer<T> : IEnumerable<T>
  {
    bool IsEmpty { get; }
    void Write(T value);
    T Read();
  }
}
