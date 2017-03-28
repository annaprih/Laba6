using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Laba6_2
{
    class CollectionType<T> : IList<T> where T : class
    {
        public int sizeGrow { get; private set; }
        public int size { get; private set; }
        private int count;

        private T[] array;

        public CollectionType()
        {
            this.array = new T[4];
            this.sizeGrow = 4;
            this.size = 4;
            this.count = 0;
        }

        public CollectionType(int size)
        {
            this.array = new T[size];
            this.size = size;
            this.sizeGrow = 4;
            this.count = 0;
        }

        public CollectionType(params T[] array)
        {
            this.array = new T[array.Length + 4];
            this.sizeGrow = 4;
            this.size = this.array.Length;
            this.count = array.Length;
            array.CopyTo(this.array, 0);
        }

        public T this[int index]
        {
            get
            {
                try
                {
                    if (this.count == 0)
                        throw new Exception("Коллекция пустая");
                    else if (this.count > index)
                        return this.array[index];
                    else
                        throw new Exception("Выход за пределы массива!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return default(T);
                }
            }

            set
            {
                try
                {
                    if (this.count > index)
                    {
                        this.array[index] = value;
                    }
                    else if (this.count <= index)
                    {
                        throw new Exception("Выход за допустимый диапазон добавления элементов");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("Элемент изменен");
                }
            }
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void Add(T item)
        {
            if (this.count == this.size)
            {
                this.size += this.sizeGrow;
                T[] temp = new T[this.size];
                this.array.CopyTo(temp, 0);
                this.array = temp;
            }

            this.array[this.count] = item;
            this.count++;
        }

        public void Clear()
        {
            this.count = 0;
            this.array = new T[this.size];
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < this.count; i++)
            {
                if (this.array[i].Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            try
            {
                this.array.CopyTo(array, arrayIndex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < this.count; i++)
            {
                yield return this.array[i];
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.count; i++)
            {
                yield return this.array[i];
            }
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < this.count; i++)
            {
                if (this.array[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            if ((this.count == this.size) && (index <= this.count))
            {
                this.size += this.sizeGrow;
                T[] temp = new T[this.size];
                for (int i = 0, j = 0; i < this.count; i++)
                {
                    if (j == index)
                    {
                        temp[j++] = item;
                        continue;
                    }
                    temp[j++] = this.array[i];
                }
                this.array = temp;
                this.count++;
            }
            else if (index <= this.count)
            {
                T[] temp = new T[this.size];
                for (int i = 0, j = 0; i < this.count; i++)
                {
                    if (j == index)
                    {
                        temp[j++] = item;
                        continue;
                    }

                    temp[j++] = this.array[i];

                }
                this.array = temp;
                this.count++;
            }

        }

        public bool Remove(T item)
        {
            bool flag = false;
            T[] temp = new T[this.size];
            int j = 0;

            for (int i = 0; i < this.count; i++)
            {
                if (item.Equals(this.array[i]))
                {
                    flag = true;
                    continue;
                }
                else
                {
                    temp[j++] = this.array[i];
                }
            }

            this.array = temp;
            this.count = j;
            return flag;
        }

        public void RemoveAt(int index)
        {
            T[] temp = new T[this.size];
            for (int i = 0, j = 0; i < this.count; i++)
            {
                if (index == i)
                {
                    continue;
                }

                temp[j++] = this.array[i];
            }
            this.count--;
            this.array = temp;
        }

        public bool WriteToFile(string nameOfFile)
        {
            using (StreamWriter log = new StreamWriter(nameOfFile))
            {
                for (int i = 0; i < this.count; i++)
                {
                    log.WriteLine(this.array[i]);
                }
            }
            return true;
        }
    }
}