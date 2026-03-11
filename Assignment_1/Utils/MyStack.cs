namespace CS201;

public class MyStack<T>
{
    private int CurentIndex;
    private T[] values;
    private int _stackMultiplier = 2;

    public MyStack(int Multiplier = 2, int StartLenght = 10)
    {
        _stackMultiplier =  Multiplier;
        CurentIndex = -1;
        values = new T[StartLenght];
    }

    // Скільки елементів 
    public int Length() => CurentIndex + 1;

    public T Peek() => values[CurentIndex];

    public bool IsEmpty()
    {
        if (CurentIndex == -1) { return true; }
        return false;
    }

    // Зменшити індекс
    public T Remove()
    {
        if (CurentIndex > -1)
        {
            CurentIndex--;
            return values[CurentIndex + 1];
        }
        return default;
    }
    
    public void Add(T newValue)
    {
        if (CurentIndex >= values.Length - 1) { _extend(); }
        
        CurentIndex++;
        values[CurentIndex] = newValue;
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
}