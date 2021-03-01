using System.Collections.Generic;
using System.Linq;

namespace WytFramework.ServiceLocator.Patern
{
    public class Cache
    {
        private List<IService> mServices = new List<IService>();

        public IService GetService(string serviceName)
        {
            return mServices.SingleOrDefault(s => s.Name == serviceName);
        }

        public void AddService(IService service)
        {
            mServices.Add(service);
        }
    }
}