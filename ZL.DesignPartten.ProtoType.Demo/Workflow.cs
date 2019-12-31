using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZL.DesignPartten.ProtoType.Demo
{
    public class Workflow
    {
        public string Name { get; set; }

        public string Description { get; set; }
        public List<Node> Nodes { get; set; }
        public List<Link> Links { get; set; }

        public Workflow()
        {
            Nodes = new List<Node>();

            Links = new List<Link>();
        }

        /// <summary>
        /// 最初的版本，仅序列化/反序列化就返回。序列化和反序列化不能区分相同的对象引用，因此会创建新的实例
        /// </summary>
        /// <returns></returns>
        public Workflow Clone_v0()
        {
            //将实体类序列化为JSON
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(this);

            //反序列化JSON
            Workflow newFlow = Newtonsoft.Json.JsonConvert.DeserializeObject<Workflow>(json);

            return newFlow;
        }

        /// <summary>
        /// 根据相同的标识重新组织
        /// </summary>
        /// <returns></returns>
        public Workflow Clone()
        {
            var newFlow=Clone_v0();

            foreach (var link in newFlow.Links)
            {
                if (link.Source != null)
                {
                    var node = newFlow.Nodes.FirstOrDefault(n => n.Name == link.Source.Name);
                    link.Source = node;
                    
                }
                if (link.Target != null)
                {
                    var node = newFlow.Nodes.FirstOrDefault(n => n.Name == link.Target.Name);
                    link.Target = node;
                }
            }

            return newFlow;

        }
    }
}
