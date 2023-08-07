namespace ListImplementation
{
    internal class MyList<T> where T : IComparable<T>
    {
        private T[] _arrayList = new T[8];

        const string stringSplitting = " ";

        public int CapacityOfList { get; }
        public int Count { get; private set; }

        public MyList()
        {

        }

        public MyList(T addElement)
        {
            Add(addElement);
        }

        public MyList(T[] inputArray)
        {
            if (inputArray.Length > _arrayList.Length)
            {
                _arrayList = new T[inputArray.Length];
            }

            for (int i = 0; i < inputArray.Length; i++)
            {
                _arrayList[i] = inputArray[i];
            }

            Count += inputArray.Length;
        }

        public static MyList<T> Create()
        {
            return new MyList<T>();
        }

        //индексатор(разобраться как он работает)
        public T this[int index]
        {
            set
            {
                _arrayList[index] = value;
            }
            get
            {
                return _arrayList[index];
            }
        }

        public void Add(T addElement)
        {
            AddByIndex(Count, addElement);
        }

        public void Clear()
        {
            _arrayList = Array.Empty<T>();
            Count = 0;
        }

        public void AddByIndex(int index, T addElement)
        {
            if (index > _arrayList.Length)
            {
                Console.WriteLine("Такого индекса не сущесвует");
                return;
            }

            var newArray = new T[_arrayList.Length];

            if (Count >= _arrayList.Length)
            {
                newArray = new T[_arrayList.Length + 1];
            }

            for (int i = 0; i < index; i++)
            {
                newArray[i] = _arrayList[i];
            }

            newArray[index] = addElement;

            for (int i = index + 1; i < newArray.Length; i++)
            {
                newArray[i] = _arrayList[i - 1];
            }

            _arrayList = newArray;

            Count++;

        }

        public void AddStart(T addElement)
        {
            AddByIndex(0, addElement);
        }

        //ebanaya nerabotayushaya parasha nahui
        public void AddRangeByIndex(int startingIndex, T[] inputArray)
        {
            var newArray = new T[_arrayList.Length];

            if (Count + inputArray.Length > CapacityOfList)
            {
                newArray = new T[_arrayList.Length + inputArray.Length];
            }

            //left side
            for (int i = 0; i < startingIndex; i++)
            {
                newArray[i] = _arrayList[i];
            }

            //new array
            for (int i = 0; i < inputArray.Length; i++)
            {
                newArray[startingIndex + i] = inputArray[i];
            }

            //right side
            for (int i = startingIndex; i < newArray.Length - inputArray.Length; i++)
            {
                newArray[i + inputArray.Length] = _arrayList[i];
            }

            Count += inputArray.Length;

            _arrayList = newArray;
        }

        public void AddRangeStart(T[] inputArray)
        {
            AddRangeByIndex(0, inputArray);
        }

        public void AddRange(T[] inputArray)
        {
            AddRangeByIndex(Count, inputArray);
        }

        public T RemoveByIndex(int removeIndex)
        {
            var newArray = new T[_arrayList.Length];

            T removeElement = _arrayList[removeIndex];

            if (removeIndex == 0)
            {
                for (int i = 1; i < _arrayList.Length; i++)
                {
                    newArray[i - 1] = _arrayList[i];
                }
            }
            else
            {
                for (int i = 0; i < newArray.Length - 1; i++)
                {
                    newArray[i] = i >= removeIndex ? _arrayList[i + 1] : _arrayList[i];
                }
            }

            Count--;

            _arrayList = newArray;

            return removeElement;
        }

        public T RemoveStart()
        {
            return RemoveByIndex(0);
        }

        public T Remove()
        {
            return RemoveByIndex(Count - 1);
        }

        public void RemoveRangeByIndex(int startingIndex, int lastIndex)
        {
            T[] newArray = new T[_arrayList.Length];

            int index = 0;

            for (int i = 0; i < startingIndex; i++)
            {
                newArray[i] = _arrayList[i];
                index++;
            }

            for (int i = lastIndex; i < _arrayList.Length; i++)
            {
                newArray[index++] = _arrayList[i];
            }

            Count -= lastIndex - startingIndex;

            _arrayList = newArray;
        }

        //public void RemoveRangeByIndex(int startingIndex, int lastIndex)
        //{
        //    for (int i = 0; i < Count - (lastIndex - startingIndex); i++)
        //    {
        //        _arrayList[i] = _arrayList[i + lastIndex];
        //    }

        //    Count -= lastIndex - startingIndex;
        //}

        public void RemoveRangeStart(int lastIndex)
        {
            RemoveRangeByIndex(0, lastIndex);
        }

        public void RemoveRange(int startingIndex)
        {
            RemoveRangeByIndex(startingIndex, Count);
        }

        public void RemoveByValueFirst(T valueForRemove)
        {
            for (int i = 0; i < Count; i++)
            {
                if (valueForRemove.CompareTo(_arrayList[i]) == 0)
                {
                    RemoveByIndex(i);
                    break;
                }
            }
        }

        public void RemoveByValueLast(T valueForRemove)
        {
            for (int i = Count; i >= 0; i--)
            {
                if (valueForRemove.CompareTo(_arrayList[i]) == 0)
                {
                    RemoveByIndex(i);
                    break;
                }
            }
        }

        public void RemoveByValueAll(T valueForRemove)
        {
            for (int i = 0; i < Count; i++)
            {
                if (valueForRemove.CompareTo(_arrayList[i]) == 0)
                {
                    RemoveByIndex(i);
                    i--;
                }
            }
        }

        public int FindIndexByValue(T searchIndex)
        {
            int result = -1;

            for (int i = 0; i < Count; i++)
            {
                if (searchIndex.CompareTo(_arrayList[i]) == 0)
                {
                    result = i;
                }
            }

            return result;
        }

        public int GetMinIndex()
        {
            return 0;
        }

        public int GetMaxIndex()
        {
            return Count - 1;
        }

        public T GetMin()
        {
            T min = _arrayList[0];

            for (int i = 0; i < Count - 1; i++)
            {
                if (_arrayList[i + 1].CompareTo(min) < 0)
                {
                    min = _arrayList[i + 1];
                }
            }

            return min;
        }

        public T GetMax()
        {
            T max = _arrayList[0];

            for (int i = 0; i < Count - 1; i++)
            {
                if (_arrayList[i + 1].CompareTo(max) > 0)
                {
                    max = _arrayList[i];
                }
            }

            return max;
        }

        public void Sort()
        {
            T temp;

            for (int i = 0; i < Count; i++)
            {
                for (int j = 0; j < Count - i - 1; j++)
                {
                    if (_arrayList[j].CompareTo(_arrayList[j + 1]) > 0)
                    {
                        temp = _arrayList[j];
                        _arrayList[j] = _arrayList[j + 1];
                        _arrayList[j + 1] = temp;
                    }
                }
            }
        }

        public void Reverse()
        {
            T temp;

            for (int i = 0; i < Count / 2; i++)
            {
                temp = _arrayList[i];
                _arrayList[i] = _arrayList[Count - 1 - i];
                _arrayList[Count - 1 - i] = temp;
            }
        }

        public void HalfReverse()
        {
            int half = Count / 2;
            int count2 = Count;
            T temp;

            for (int i = 0; i < half / 2; i++)
            {
                temp = _arrayList[i];
                _arrayList[i] = _arrayList[Count - i - 1 - half];
                _arrayList[Count - i - 1 - half] = temp;
            }

            int isHalf = Count % 2 == 0 ? 0 : 1;

            for (int i = isHalf; i < half / 2 + isHalf; i++)
            {
                temp = _arrayList[i + half];
                _arrayList[i + half] = _arrayList[count2 - 1];
                _arrayList[count2 - 1] = temp;
                count2--;
            }
        }

        public override string ToString()
        {
            string stringList = String.Join<T>(stringSplitting, _arrayList);

            return stringList;
        }

        public T[] ToArray()
        {
            return _arrayList;
        }

        public void ResizeUp()
        {
            int sizeOfResize = (int)(_arrayList.Length * 0.3);

            T[] newArray = new T[_arrayList.Length + sizeOfResize];

            for (int i = 0; i < _arrayList.Length; i++)
            {
                newArray[i] = _arrayList[i];
            }

            _arrayList = newArray;
        }

        public void ResizeDown()
        {
            int sizeOfResize = (int)(_arrayList.Length * 0.3);

            T[] newArray = new T[_arrayList.Length - sizeOfResize];

            for (int i = 0; i < newArray.Length; i++)
            {
                newArray[i] = _arrayList[i];
            }

            _arrayList = newArray;
        }

        public void PrintList()
        {
            for (int i = 0; i < _arrayList.Length; i++)
            {
                Console.Write($"{_arrayList[i]} ");
            }

            Console.WriteLine();
        }
    }
}