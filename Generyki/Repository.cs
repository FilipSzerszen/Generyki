using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generyki
{
    //możliwe ograniczenia generyczne to wymuszenie typu wartściowego/referencyjnego,
    //implementacja interfejsu czy konstruktora bezparametrowego
    //                                V
    public class Repository<T> where T: IEntity, new() 
    {

        private List<T> data = new List<T>();
        public void AddElement(T element)
        {
            //var newElement = new T();
            //newElement.id = 23;

            if(element != null)
            {
                Console.WriteLine(element.id);
                data.Add(element);
            }
        }

        public T GetElement(int index)
        {
            if (index >= 0 && data.Count() > index) return data[index];
            else return default;
        }

        public T GetElementById(int id)
        {
            return data.FirstOrDefault(i => i.id == id);
        }
    }

    public class Repository<TKey, TValue>
        where TKey : class
        where TValue : new()
    {
        private Dictionary<TKey, TValue> data = new Dictionary<TKey, TValue>();
        public void AddElement(TKey key, TValue value)
        {
            if (key != null || value != null)
            {
                data.Add(key, value);
            }
        }

        public TValue GetElement(TKey key)
        {
            if (data.TryGetValue(key, out TValue result)) return result;
            else return default;
        }
    }
}
