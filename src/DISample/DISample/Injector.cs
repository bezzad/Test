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

        public T Get<T>() where T : class
        {
            var typeString = typeof(T).FullName;
            if (_singletonDictionary.TryGetValue(typeString, out var tempObject))
            {
                return (T)tempObject;
            }
            if (_transientDictionary.TryGetValue(typeString, out var tempObjectFunction))
            {
                var t = (Func<T>)tempObjectFunction.Invoke();
                return t();
            }

            return null;
        }

        public void Singleton<T>(T value) where T : class
        {
            var typeName = typeof(T).FullName;
            var buffer = Get<T>();
            if (buffer is null)
                _singletonDictionary[typeName] = value;
            else
                throw new Exception("You can't bind twice for a type.");            
        }

        public void Transient<T>(Func<T> method) where T : class
        {
            var typeName = typeof(T).FullName;
            var buffer = Get<T>();
            if (buffer is null)
                _transientDictionary[typeName] = new Func<object>(() => method);
            else
                throw new Exception("You can't bind twice for a type.");
        }

        
    }
}
