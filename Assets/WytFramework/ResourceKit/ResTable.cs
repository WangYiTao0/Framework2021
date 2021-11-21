using WytFramework.DataStructure;

namespace WytFramework.ResourceKit
{
    public class ResTable : Table<Res>
    {
        /// <summary>
        /// 根据
        /// </summary>
        public TableIndex<string,Res> NameIndex { get; private set; }

        public ResTable()
        {
            NameIndex = new TableIndex<string, Res>(res=>res.Name);
        }
        
        protected override void OnAdd(Res item)
        {
            NameIndex.Add(item);
        }

        protected override void OnRemove(Res item)
        {
            NameIndex.Remove(item);
        }

        protected override void OnClear()
        {
            NameIndex.Clear();
        }
    }
}