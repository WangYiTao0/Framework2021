using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace WytFramework
{
    public class ModuleContainer<T>
    {
        /// <summary>
        /// Editor Module
        /// </summary>
        static List<T> mModules = new List<T>();

        public List<T> Modules
        {
            get { return mModules; }
        }

        public void Scan(string assemblyName)
        {
            // 1. Get all the assmeblies in Current Project (dll)
            // AppDomain.CurrentDomain  Current Project
            var assmeblies = AppDomain.CurrentDomain.GetAssemblies();
            // 2. Get Current Editor Environment (dll)
            var editorAssembly = assmeblies.First(assmebly => assmebly.FullName.StartsWith(assemblyName));
            // 3. Get IEditorPlatformModule Type
            var moduleTyoe = typeof(T);

            mModules = editorAssembly.
                // Get all Type in Editor Environment
                GetTypes()
                // Remove abstract type,  Unimplement the IEditorPlatformModeule Type
                .Where(type => moduleTyoe.IsAssignableFrom(type) && !type.IsAbstract)
                // Get Constructor to Create instance
                .Select(type => type.GetConstructors().First().Invoke(null))
                // Cast to IEditorPlatformModule Type
                .Cast<T>()
                // Cast List<IEditorPlatformModule>
                .ToList();
        }

    }
}
