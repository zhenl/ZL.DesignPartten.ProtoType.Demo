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
            Console.WriteLine("输出第一个节点的名称");
            Console.WriteLine(workflow.Nodes[0].Name);
            Console.WriteLine("通过连接引用修改开始节点的名称");
            workflow.Links[0].Source.Name = "开始";
            Console.WriteLine("应该修改为开始");
            Console.WriteLine(workflow.Nodes[0].Name);
            Console.WriteLine("");
            var newworkflow = workflow.Clone_v0();
            Console.WriteLine("输出克隆对象的第一个节点的名称");
            Console.WriteLine(newworkflow.Nodes[0].Name);
            Console.WriteLine("通过连接引用修改开始节点的名称");
            newworkflow.Links[0].Source.Name = "开始1";
            Console.WriteLine("名称没有被修改，说明Clone时Link中的每个节点创建了新的对象");
            Console.WriteLine(newworkflow.Links[0].Source.Name);
            Console.WriteLine(newworkflow.Nodes[0].Name);

            Console.WriteLine("");
            var newworkflow1 = workflow.Clone();
            Console.WriteLine("输出克隆对象的第一个节点的名称");
            Console.WriteLine(newworkflow1.Nodes[0].Name);
            Console.WriteLine("通过连接引用修改开始节点的名称");
            newworkflow1.Links[0].Source.Name = "Start";
            Console.WriteLine("名称相同,说明指向相同的节点");
            Console.WriteLine(newworkflow1.Links[0].Source.Name);
            Console.WriteLine(newworkflow1.Nodes[0].Name);

            Console.ReadLine();
        }
    }
}
