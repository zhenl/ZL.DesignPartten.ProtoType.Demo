using System;
using System.Collections.Generic;
using System.Text;

namespace ZL.DesignPartten.ProtoType.Demo
{
    public class Workflow_v0
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Node> Nodes { get; set; }

        public List<Link_v0> Links { get; set; }

        public Workflow Clone_Serialize()
        {
            //将实体类序列化为JSON
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(this);

            //反序列化JSON
            Workflow newFlow = Newtonsoft.Json.JsonConvert.DeserializeObject<Workflow>(json);

            return newFlow;
        }

        public Workflow Clone_Memberwise()
        {
            return this.MemberwiseClone() as Workflow;
        }
    }
}
