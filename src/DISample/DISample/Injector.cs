using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DISample
{
    public class Injector
    {
        private Dictionary<string, object> _singletonDictionary = new Dictionary<string, object>();
        private Dictionary<string, Func<object>>  _transientDictionary = new Dictionary<string, Func<object>>();
        private static int s_accessNumber = 0;
        public T Get<T>()
        {
            string typeString = typeof(T).ToString();
            object tempObject = null;
            Func<object> tempObjectFunction;
            if (_singletonDictionary.TryGetValue(typeString, out tempObject))
            {
                return (T)tempObject;
            }
            if (_transientDictionary.TryGetValue(typeString, out tempObjectFunction))
            {
                Func<T> t = (Func<T>)tempObjectFunction.Invoke();
                return (T)t();
            }
            return default(T);
        }
        public T Singleton<T>(T value)
        {
            string typeString = typeof(T).ToString(); 
            object tempObject = null;
            Func<object> tempObjectFunction;
            if (_singletonDictionary.TryGetValue(typeString, out tempObject))
            {
                Console.WriteLine("repeated in singleton dictionary");
                return default(T);
            }
            if (_transientDictionary.TryGetValue(typeString, out tempObjectFunction))
            {
                Console.WriteLine("repeated in transition dictionary");
                return default(T);
            }
            _singletonDictionary.Add(typeString, value);
            return (T)value;
        }
        public T Transient<T>(Func<T> method )
        {
            string typeString = typeof(T).ToString(); 
            object tempObject = null;
            Func<object> tempFunctionObject;
            if (_singletonDictionary.TryGetValue(typeString, out tempObject))
            {
                Console.WriteLine("binded in singleton");
                return default(T);
            }
            if (_transientDictionary.TryGetValue(typeString, out tempFunctionObject))
            {
                Console.WriteLine("binded privoisly in transient, value will be updated");
                Func<T> tempFunction = (Func<T>)tempFunctionObject.Invoke();
                return tempFunction();
                return default(T);
            }
            _transientDictionary[typeString] = new Func<object>( () => method);
            return method();
        }
        public static int  WriteResult()
        {
            s_accessNumber++;
            return s_accessNumber;
        }
        public static Logger WriteResult2()
        {
            s_accessNumber++;
            return new Logger(s_accessNumber%2, "e");
        }
    }
}
