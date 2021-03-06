﻿using System;

namespace ZL.DesignPartten.ProtoType.Demo
{
    class Program
    {
        static void Main(string[] args)
        {

            var workflow = CreateWorkflow();
            var workflow_v0 = CreateWorkflow_v0();

            var nw1 = workflow.Clone_Memberwise();

            Console.WriteLine("使用浅复制");
            if (nw1.Nodes[0] == workflow.Nodes[0]) Console.WriteLine("浅复制中的Nodes没有复制，仍然引用是原有对象中的Node");
            else {
                Console.WriteLine(nw1.Nodes[0].Name);
            }
            Console.WriteLine("");

            Console.WriteLine("对Workflow_v0使用序列化方法克隆对象");
            Console.WriteLine("比较原型对象与新对象中的Node，看是否相同");
            var nw0 = workflow_v0.Clone_Serialize();
            Console.WriteLine(nw0.Nodes[0] == workflow_v0.Nodes[0]);

            var newworkflow = workflow.Clone_Serialize();
            Console.WriteLine("对Workflow采用序列化的方法克隆对象，不进行引用处理");
            Console.WriteLine("比较节点集合中的对象与连接中引用的对象，看是否相同");
            Console.WriteLine(newworkflow.Nodes[0]== newworkflow.Links[0].Source);
            

            Console.WriteLine("");
            var newworkflow1 = workflow.Clone();
            Console.WriteLine("采用序列化的方法克隆对象，对引用进行处理");
            Console.WriteLine("比较节点集合中的对象与连接中引用的对象，看是否相同");
            Console.WriteLine(newworkflow1.Nodes[0]== newworkflow1.Links[0].Source);
            Console.ReadLine();
        }

        private static Workflow CreateWorkflow()
        {
            var workflow = new Workflow();

            workflow.Name = "工作流一";

            var beginNode = new Node
            {
                Name = "Start",
                NodeType = "start"
            };
            beginNode.Parent = workflow;
            var inputNode = new Node
            {
                Name = "Input",
                NodeType = "Normal"
            };
            var endNode = new Node
            {
                Name = "End",
                NodeType = "end",
            };

            var linkStartToInput = new Link
            {
                Source = beginNode,
                Target = inputNode,
                Condition = "1==1"
            };

            var linkinputNodeToEnd = new Link
            {
                Source = inputNode,
                Target = endNode,
                Condition = "1==1"
            };

            workflow.Nodes.Add(beginNode);
            workflow.Nodes.Add(inputNode);
            workflow.Nodes.Add(endNode);

            workflow.Links.Add(linkStartToInput);
            workflow.Links.Add(linkinputNodeToEnd);
            return workflow;
        }

        private static Workflow_v0 CreateWorkflow_v0()
        {
            var workflow = new Workflow_v0();

            workflow.Name = "工作流_V0";

            var beginNode = new Node_v0
            {
                Name = "Start",
                NodeType = "start"
            };
            var inputNode = new Node_v0
            {
                Name = "Input",
                NodeType = "Normal"
            };
            var endNode = new Node_v0
            {
                Name = "End",
                NodeType = "end",
            };

            var linkStartToInput = new Link_v0
            {
                SourceNodeName = "Start",
                TargetNodeName = "Input",
                Condition = "1==1"
            };

            var linkinputNodeToEnd = new Link_v0
            {
                SourceNodeName = "Input",
                TargetNodeName = "End",
                Condition = "1==1"
            };

            workflow.Nodes.Add(beginNode);
            workflow.Nodes.Add(inputNode);
            workflow.Nodes.Add(endNode);

            workflow.Links.Add(linkStartToInput);
            workflow.Links.Add(linkinputNodeToEnd);
            return workflow;
        }
    }
}
