using electric_network_editor.Models.Symbols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkColorPlugin.Models
{
    internal class CircuitTreeNode
    {
        public Node Node { get; set; }
        public CircuitTreeNode Parent { get; set; } = null;
        public List<CircuitTreeNode> Children { get; } = new List<CircuitTreeNode>();

        public CircuitTreeNode(Node node)
        {
            this.Node = node;
        }

        public void AddChild(CircuitTreeNode child)
        {
            child.Parent = this;
            Children.Add(child);
        }

        public bool RemoveChild(CircuitTreeNode child)
        {
            child.Parent = null;
            return Children.Remove(child);
        }

        // Optional: Traverse tree (Depth-First)
        public void Traverse(Action<CircuitTreeNode> action)
        {
            action(this);
            foreach (var child in Children)
            {
                child.Traverse(action);
            }
        }


    }
}
