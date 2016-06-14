using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
   
    public  class TreeNode<T> where T :IComparable<T>

    {
        public int Value { get; set; }
        public List<TreeNode<T>> children { get; set; }
        public bool HasParent { get; set; }

        public List<TreeNode<T>> Children
        {
            get { return this.children; }
        }

        public TreeNode(int value)
        {
            this.Value = value;
            this.children = new List<TreeNode<T>>();
        }

        public void addChild(TreeNode<T> child)
        {
            child.HasParent = true;
            this.children.Add(child);
            
        }

        public TreeNode<T> GetChild(int index)
        {
            return this.children[index];
        }

        

      

    }


    public class Tree<T> where T : IComparable<T>
    {
        public TreeNode<T> root;
        public int longestPath { get; set; }
        public  int currentSumNode = 0;
        public static List<TreeNode<int>> currentPath = new List<TreeNode<int>>();
        public static List<TreeNode<int>> path = new List<TreeNode<int>>();


        public Tree(int value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Can't insert null value");
            }

            this.root = new TreeNode<T>(value);
        }

        public Tree(int value,params Tree<T>[] children):
            this(value)
        {

            foreach (Tree<T> child in children)
            {
                this.root.addChild(child.root);
            }
        }


        public  TreeNode<T> Root
        {
            get { return this.root; }
        }


        private void TraversalDFS(TreeNode<T>root,String space)
        {
            if (this.root == null)
            {
                return;
            }
            //find leafs
            //if (root.children.Count == 0)
            //{
            //    Console.WriteLine("{0},",root.Value);
            //}
            
            Console.WriteLine(space + root.Value);

            TreeNode<T> child = null;
            for(int i = 0; i < root.children.Count; i++)
            {
                child = root.GetChild(i);
                TraversalDFS(child, space + " ");
            }
        }
      
        public void TraversalDFS()
        {
            this.TraversalDFS(this.root,string.Empty);
        }
       

        public void TraversalBFS()
        {
            Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();
            queue.Enqueue(this.root);

            while (queue.Count > 0)
            {
                TreeNode<T> currentNode = queue.Dequeue();
                Console.WriteLine("{0}",currentNode.Value);
                
                for(int i = 0; i < currentNode.children.Count; i++)
                {
                    TreeNode<T> childNode = currentNode.GetChild(i);
                    queue.Enqueue(childNode);
                }

            }

        }

        public void TraversalDFSwithStack()
        {
            Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();
            stack.Push(this.root);

            while (stack.Count > 0)
            {
                TreeNode<T> currentNode = stack.Pop();
                Console.WriteLine("{0} ",currentNode.Value);

                for(int i = 0; i < currentNode.children.Count; i++)
                {
                    TreeNode<T> childNode = currentNode.GetChild(i);
                    stack.Push(childNode);
                }

            }
        }

        //find All leafs
        public void FindAlLeafs()
        {
            Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();
            List<TreeNode<T>> leafs = new List<TreeNode<T>>();
            queue.Enqueue(this.root);

            while (queue.Count > 0)
            {

                TreeNode<T> currentNode = queue.Dequeue();
                if (currentNode.children.Count == 0)
                {
                    Console.WriteLine("{0}", currentNode.Value);
                }


                for (int i = 0; i < currentNode.children.Count; i++)
                {
                    TreeNode<T> childNode = currentNode.GetChild(i);

                    queue.Enqueue(childNode);

                }


            }



        }

        //find all middle leafs
        private void FindAllMiddleLeafs(TreeNode<T>root)
        {

            if (root == null)
            {
                return;
            }

            if(root.children.Count>0 && root.HasParent)
            {
                Console.WriteLine("{0}",root.Value);
            }

            TreeNode<T> child = null;
            for(int i =0;i<root.children.Count;i++)
            {
                child = root.GetChild(i);
                FindAllMiddleLeafs(child);
            }

        }

        public  void FindAllMiddleLeafs()
        {
            this.FindAllMiddleLeafs(this.root);
        }

        //find the longest path
        public void FindLongestPath(TreeNode<int> root)
        {
            currentSumNode += root.Value;

            if (root.children.Count == 0)
            {
                if (currentSumNode > longestPath)
                {
                    longestPath = currentSumNode;
                }
                return;
            }

            for(int i = 0; i < root.children.Count; i++)
            {
                FindLongestPath(root.children[i]);
                currentSumNode -= root.children[i].Value;
            }

           
        }


       
        public void FindAllPathsWithGivenSum(TreeNode<int> root, int sum,int currentSum)
        {
            currentPath.Add(root);
            currentSum += root.Value;

            if (root.children.Count == 0)
            {
                if (currentSum == sum)
                {
                    for(int i = 0; i < currentPath.Count; i++)
                    {
                        path.Add(currentPath[i]);
                    }
                }
                return;
            }

            for(int i = 0; i < root.children.Count; i++)
            {
                FindAllPathsWithGivenSum(root.children[i], sum, currentSum);
                currentPath.RemoveAt(currentPath.Count - 1);
            }
        }

        public void printFindAllPathsWithGivenSum(int sum)
        {
            if (path.Count != 0)
            {
                Console.Write("Paths are: ");
                for (int i = 0; i < path.Count; i++)
                {
                    if (path[i].Value == root.Value && i != 0)
                    {
                        Console.Write(", ");
                    }

                    Console.Write(path[i].Value + " ");
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("There is no paths with sum {0} of their nodes!", sum);
            }
        }
    }


    }
   

    


