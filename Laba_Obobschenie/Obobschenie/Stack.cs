using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Obobschenie
{
    

    public class StackFixed<T>
    {
        private int _currentSize; 
        private T[] _dataArray; 
        private int _stackMaxSize; 
        public StackFixed(int stackMaxSize)
        {
            _dataArray = new T[stackMaxSize];
            _currentSize = 0;
            _stackMaxSize = stackMaxSize;
        }

        public int Size()
        {
            return _currentSize;
        }

        public void Push(T item)
        {
            if (_currentSize == _stackMaxSize)
            {
                RebuildData();
            }

            _dataArray[_currentSize] = item;
            _currentSize++;
        }

        public T Peek()
        {
            if (Size() == 0)
            {
                throw new Exception("Stack is empty");
            }

            return _dataArray[_currentSize - 1];
        }

        public T Pop()
        {
            var item = Peek();
            _currentSize--;
            return item;
        }

        public void Clear()
        {
            _dataArray = new T[_stackMaxSize];
            _currentSize = 0;
        }

        private void RebuildData()
        {
            var newData = new T[_stackMaxSize];
            for (var i = 1; i < _dataArray.Length; i++)
            {
                newData[i - 1] = _dataArray[i];
            }

            _dataArray = newData;
            _currentSize = _stackMaxSize - 1;
        }
    }

}
