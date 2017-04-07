using System;
using System.Web;

namespace WebUI.Context
{
    public class ContextManager<T> : IContextManager<T> where T : class 
    {
        private readonly object syncRoot = new object();

        private Func<T> _func;

        public string CacheKey { get; }

        public ContextManager(string key, Func<T> func)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("cacheKey cannot be empty");
            }
            if (func == null)
            {
                throw new ArgumentNullException(nameof(func));
            }
            CacheKey = key;
            _func = func;
        }

        public void LoadContext()
        {
            var currentContext = HttpContext.Current.Items[CacheKey] as T;
            if (currentContext == null)
            {
                lock (syncRoot)
                {
                    currentContext = _func();
                    HttpContext.Current.Items[CacheKey] = currentContext;
                }
            }
        }

        public void ClearContext()
        {
            lock (syncRoot)
            {
                HttpContext.Current.Items.Remove(CacheKey);
            }
        }

        public T GetContext()
        {
            LoadContext();

            return HttpContext.Current.Items[CacheKey] as T;
        }
    }
}