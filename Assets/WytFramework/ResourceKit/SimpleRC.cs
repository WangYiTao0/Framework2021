namespace WytFramework.ResourceKit
{
    public interface IRefCounter
    {
        int RefCount { get; }
        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="refOwner"></param>
        void Retain(object refOwner = null);
        void Release(object refOwner = null);
        
    }
    /// <summary>
    /// 简易的引用计数器
    /// </summary>
    public class SimpleRC : IRefCounter
    {
        public SimpleRC()
        {
            RefCount = 0;
        }

        public int RefCount { get; private set; }
        public void Retain(object refOwner = null)
        {
            ++RefCount;
        }

        public void Release(object refOwner = null)
        {
            --RefCount;
            if (RefCount == 0)
            {
                OnZeroRef();
            }
        }

        protected virtual void OnZeroRef()
        {
        }
    }
}