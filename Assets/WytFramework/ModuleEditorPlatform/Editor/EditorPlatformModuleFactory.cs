using System;
using System.Collections.Generic;
using System.Linq;
using WytFramework.ServiceLocator;

namespace WytFramework
{
    public class EditorPlatformModuleFactory : IModuleFactory
    {
        /// <summary>
        /// 缓存全部类型
        /// </summary>
        private List<Type> mModuleTypes;

        /// <summary>
        /// 在构造时做扫描操作
        /// </summary>
        public  EditorPlatformModuleFactory()
        {
            mModuleTypes = AppDomain.CurrentDomain.GetAssemblies()
                .Single(a => a.FullName.StartsWith("Assembly-CSharp-Editor"))
                .GetTypes()
                .Where(t => typeof(IEditorPlatformModule).IsAssignableFrom(t) && !t.IsAbstract)
                .ToList();
        }
        
        private IEnumerable<object> CreateAllModules()
        {
            return mModuleTypes.Select(t => t.GetConstructors().First().Invoke(null))
                .Cast<IEditorPlatformModule>();;
        }

        #region 暂时用不上
        public object CreateModuleByName(string name)
        {
            throw new NotImplementedException();
        }

        public object CreateModuleByType(Type type)
        {
            throw new NotImplementedException();
        }

        public object CreateModulesByName(string name)
        {
            throw new NotImplementedException();
        }
        #endregion
        public object CreateModulesByType(Type type)
        {
            return CreateAllModules();
        }
    }
    
}