using System;
using System.Collections;
using System.Collections.Generic;

namespace Generics
{
  public class CircularBuffer<T> : Buffer<T>
  {
    int _capacity;
    public CircularBuffer(int capacity = 10)
    {
      _capacity = capacity;
    }

    public override void Write(T value)
    {
      base.Write(value);
      if (_queue.Count > _capacity)
      {
        _queue.Dequeue();
      }
    }

    public bool IsFull { get { return _queue.Count == _capacity; } }
  }
}
