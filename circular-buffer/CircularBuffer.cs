using System;

public class CircularBuffer<T>
{
  T[] elements;
  int current=0, last=0;
  public CircularBuffer(int capacity)
  {
    elements=new T[capacity];
  }

  public T Read()
  {
      throw new NotImplementedException("You need to implement this function.");
  }

  public void Write(T value)
  {
    elements[current]=value;
    ++current;
  }

  public void Overwrite(T value)
  {
      throw new NotImplementedException("You need to implement this function.");
  }

  public void Clear()
  {
      throw new NotImplementedException("You need to implement this function.");
  }
}