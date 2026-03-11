namespace CS201;
using System.Collections;
using System.Collections.Generic;

public class MyList<T> : IEnumerable<T>
{
    private int CurentIndex;
    private T[] values;
    private int _stackMultiplier;
    
    public MyList(int Multiplier = 2, int _startLenght = 10)
    {
        _stackMultiplier = Multiplier;
        CurentIndex = -1;
        values = new T[_startLenght];
    }
    
    public int Length() => CurentIndex + 1;

    public T Get(int UserIndex)
    {
        _checkIndex(UserIndex, IncludeNextIndex: false);
        return values[UserIndex];
    }

    public void Add(T value)
    {
        if (CurentIndex == values.Length - 1)
        {
            _extend();
        }
        
        values[CurentIndex + 1] = value;
        CurentIndex++;
    }
    
    public void InsertAt(int UserIndex, T NewValue)
    {
        if (CurentIndex == values.Length - 1)
        {
            _extend();
        }

        _checkIndex(UserIndex, insert: true);
        
        T[] NewValues =  new T[values.Length];

        for (int i = 0; i < values.Length; i++)
        {
            if (i < UserIndex)
            {
                NewValues[i] = values[i];
            }
            else if (i == UserIndex)
            {
                NewValues[i] = NewValue;
            }
            else 
            {
                NewValues[i] = values[i - 1];
            }
        }
        values =  NewValues;
        CurentIndex++;
    }

    public void RemoveAt(int UserIndex)
    {
        _checkIndex(UserIndex, IncludeNextIndex: false);
        
        T[] NewValues =  new T[values.Length];

        for (int i = 0; i < values.Length-1; i++)
        {
            if (i < UserIndex)
            {
                NewValues[i] = values[i];
            }
            else 
            {
                NewValues[i] = values[i + 1];
            }
        }
        values =  NewValues;
        values[CurentIndex] = default;
        CurentIndex--;
    }
    
    private void _extend()
    {
        int NewLength = values.Length * _stackMultiplier;
        T[] NewValues =  new T[NewLength];

        for (int i = 0; i < values.Length; i++)
        {
            NewValues[i] = values[i];
        }
        
        values = NewValues;
    }

    private void _checkIndex(int UserIndex, bool IncludeNextIndex = true, bool insert = false)
    {
        
        int NextIndex = 0;
        if (IncludeNextIndex)
        { 
            NextIndex = 1;
        }

        if (CurentIndex == -1)
        {
            if (!insert)
            {
                throw new IndexOutOfRangeException("List is empty.");
            }
        }
        if (UserIndex > (CurentIndex + NextIndex))
        {
            throw new IndexOutOfRangeException(
                $"Index out of range. Index is too large. " +
                $"Curent Index is {CurentIndex + NextIndex}, your index is {UserIndex}"
            );
        }
        if (UserIndex < 0)
        {
            throw new IndexOutOfRangeException(
                $"Index out of range. Index is too small. " +
                $"Your index is {UserIndex}"
            );
        }
    }
    
    public override string ToString()
    {
        if (CurentIndex == -1)
        {
            return "[]";
        }

        string result = "[";
        for (int i = 0; i <= CurentIndex; i++) 
        {
            result += values[i]?.ToString();
            if (i < CurentIndex) 
            {
                result += " | ";
            }
        }
        result += "]";

        return result;
    }
    
    
    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i <= CurentIndex; i++)
        {
            yield return values[i];
        }
    }
    
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}