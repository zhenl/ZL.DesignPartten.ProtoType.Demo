using Newtonsoft.Json;

namespace ZL.DesignPartten.ProtoType.Demo
{
    public class Node
    {
        /// <summary>
        /// 需要增加JsonIgnore避免循环引用
        /// </summary>
        [JsonIgnore]
        public Workflow Parent { get; set; }
        public string Name { get; set; }

        public string NodeType { get; set; }
    }
}
