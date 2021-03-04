using System;
using System.IO;

namespace WytFramework.Singleton
{
    [AttributeUsage(AttributeTargets.Class)]
    public class MonoSingletonPath : Attribute
    {
        private string _pathInHierarchy;

        public MonoSingletonPath(string pathInHierarchy)
        {
            _pathInHierarchy = pathInHierarchy;
        }

        public string PathInHierarchy
        {
            get => _pathInHierarchy;
        }
    }
}