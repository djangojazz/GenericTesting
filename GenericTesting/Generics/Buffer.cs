﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
  public class Buffer<T> : IBuffer<T>
  {
    protected Queue<T> _queue = new Queue<T>();

    public virtual bool IsEmpty
    {
      get { return _queue.Count == 0; }

    }

    public virtual T Read()
    {
      return _queue.Dequeue();
    }
    
    public virtual void Write(T value)
    {
      _queue.Enqueue(value);
    }

    public IEnumerator<T> GetEnumerator()
    {
      foreach (var item in _queue)
      {
        yield return item;
      }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return this.GetEnumerator();
    }
  }
}
