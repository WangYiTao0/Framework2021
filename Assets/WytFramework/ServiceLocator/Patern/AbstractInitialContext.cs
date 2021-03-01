namespace WytFramework.ServiceLocator.Patern
{
    public abstract class AbstractInitialContext
    {
        public abstract IService LookUp(string name);
    }
}