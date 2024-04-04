using System;

public class Program
{
    public static void Main(string[] args)
    {
        StringArrayList myList = new StringArrayList();
        myList.Add("Елемент 1");
        myList.Add("Елемент 2");
        myList.Add("Елемент 3");
        Console.WriteLine("Розмір списку: " + myList.Size());
        Console.WriteLine("Перший елемент: " + myList.Get(0));
    }
}

public class StringArrayList
{
    private string[] array;
    private int size;
    private const int DefaultCapacity = 4;

    public StringArrayList()
    {
        array = new string[DefaultCapacity];
        size = 0;
    }

    public void Add(string item)
    {
        if (size == array.Length)
        {
            IncreaseCapacity();
        }
        array[size] = item;
        size++;
    }

    public string Get(int index)
    {
        if (index < 0 || index >= size)
        {
            throw new IndexOutOfRangeException("Індекс виходить за межі діапазону.");
        }
        return array[index];
    }

    public void Set(int index, string newItem)
    {
        if (index < 0 || index >= size)
        {
            throw new IndexOutOfRangeException("Індекс виходить за межі діапазону.");
        }
        array[index] = newItem;
    }

    public void Delete(int index)
    {
        if (index < 0 || index >= size)
        {
            throw new IndexOutOfRangeException("Індекс виходить за межі діапазону.");
        }
        for (int i = index; i < size - 1; i++)
        {
            array[i] = array[i + 1];
        }
        size--;
    }

    public int Size()
    {
        return size;
    }

    private void IncreaseCapacity()
    {
        int newCapacity = array.Length * 2;
        string[] newArray = new string[newCapacity];
        Array.Copy(array, newArray, array.Length);
        array = newArray;
    }
}
