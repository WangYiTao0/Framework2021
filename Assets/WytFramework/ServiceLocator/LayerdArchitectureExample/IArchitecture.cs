namespace WytFramework.ServiceLocator.LayerdArchitectureExample
{
    public interface IArchitecture
    {
        ILogicLayer LogicLayer { get; }

        IBusinessModuleLayer BusinessModuleLayer { get; }

        IPublichModuleLayer PublichModuleLayer { get; }

        IUtiltyLayer UtiltyLayer { get; }

        IBasicModuleLayer BasicModuleLayer { get; }
    }
}