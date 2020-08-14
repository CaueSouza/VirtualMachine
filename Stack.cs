using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualMachine
{
    class Stack
    {
		private int top;
		private int capacity;
		private String[] array;

		public Stack()
		{
			capacity = 1;
			array = new String[capacity];
			top = -1;
		}

		public void push(String data)
		{
			if (isFull())
			{
				expandArray(); // if array is full then increase its capacity
			}
			array[++top] = data; // insert the data
		}

		public String pop()
		{
			if (isEmpty())
			{
				Console.WriteLine("Stack is empty");
				return null;
			}
			else
			{
				reduceSize(); // function to check if size can be reduced
				return array[top--];
			}
		}

		public bool isFull()
		{
			if (capacity == top + 1)
				return true;
			else
				return false;
		}

		public bool isEmpty()
		{
			if (top == -1)
				return true;
			else
				return false;
		}

		public void expandArray()
		{
			int curr_size = top + 1;
			String[] new_array = new String[curr_size * 2];
			for (int i = 0; i < curr_size; i++)
			{
				new_array[i] = array[i];
			}
			array = new_array; // refer to the new array
			capacity = new_array.Length;
		}

		public void reduceSize()
		{
			int curr_length = top + 1;
			if (curr_length < capacity / 2)
			{
				String[] new_array = new String[capacity / 2];
				Array.Copy(array, 0, new_array, 0, new_array.Length);
				array = new_array;
				capacity = new_array.Length;
			}
		}

		public int getLength()
		{
			return top;
		}

		public String getPosition(int position)
		{
			if (position > top)
				return "";
			else
			{
				return array[position];
			}
		}

		public void display()
		{
			for (int i = 0; i <= top; i++)
			{
				Console.WriteLine(array[i] + "=>");
			}
			Console.WriteLine();
			Console.WriteLine("ARRAY SIZE:" + array.Length);
		}

		public void cleanStack()
		{
			top = -1;
		}
	}
}
