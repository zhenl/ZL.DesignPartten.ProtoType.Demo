using System;
using System.Collections.Generic;
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

        public Workflow Clone()
        {
            //将实体类序列化为JSON
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(this);

            //反序列化JSON
            Workflow newFlow = Newtonsoft.Json.JsonConvert.DeserializeObject<Workflow>(json);

            return newFlow;

        }
    }
}
