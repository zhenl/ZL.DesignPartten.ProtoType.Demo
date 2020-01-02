﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ZL.DesignPartten.ProtoType.Demo
{
    public class Workflow_v0
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Node_v0> Nodes { get; set; }

        public List<Link_v0> Links { get; set; }

        public Workflow_v0()
        {
            Nodes = new List<Node_v0>();
            Links = new List<Link_v0>();
            
        }

        public Workflow_v0 Clone_Serialize()
        {
            //将实体类序列化为JSON
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(this);

            //反序列化JSON
            Workflow_v0 newFlow = Newtonsoft.Json.JsonConvert.DeserializeObject<Workflow_v0>(json);

            return newFlow;
        }

        public Workflow_v0 Clone_Memberwise()
        {
            return this.MemberwiseClone() as Workflow_v0;
        }
    }
}
