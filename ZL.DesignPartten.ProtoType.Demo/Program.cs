using System;

namespace ZL.DesignPartten.ProtoType.Demo
{
    class Program
    {
        static void Main(string[] args)
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

            var nw1 = workflow.Clone_v1();

            if (nw1.Nodes[0] == null) Console.WriteLine("浅复制不能复制子对象");
            else {
                Console.WriteLine(nw1.Nodes[0].Name);
            }

            Console.WriteLine("比较节点集合中的对象与连接中引用的对象，看是否相同");
            Console.WriteLine(workflow.Nodes[0] == workflow.Links[0].Source);
            Console.WriteLine("");
            var newworkflow = workflow.Clone_v0();
            Console.WriteLine("采用序列化的方法克隆对象，不进行引用处理");
            Console.WriteLine("比较节点集合中的对象与连接中引用的对象，看是否相同");
            Console.WriteLine(newworkflow.Nodes[0]== newworkflow.Links[0].Source);
            

            Console.WriteLine("");
            var newworkflow1 = workflow.Clone();
            Console.WriteLine("采用序列化的方法克隆对象，对引用进行处理");
            Console.WriteLine("比较节点集合中的对象与连接中引用的对象，看是否相同");
            Console.WriteLine(newworkflow1.Nodes[0]== newworkflow1.Links[0].Source);
            Console.ReadLine();
        }
    }
}
