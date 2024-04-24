
/**** NAME	    : Jevic Tshilumba                                   ***
*** CLASS	    : CSC-346                                           ***
*** ASSIGNMENT	:  5                                                ***                                          ***
*** INSTRUCTOR	: GAMRADT                                           ***
*********************************************************************************************
*** DESCRIPTION : Use Visual Studio Code to create a user-defined Abstract Data Type (ADT)
*                 using C# classes named Graph, IAccessData, IGraphAlgorithms,Vertex along with an appropriate set
*                 of C# files as discussed in class                           ***
*********************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

    
namespace GraphNS
{

    public class Graph : IAccessData, IGraphAlgorithms
    {
        public List<Vertex> _vertex; // List of vertices in the graph

        // Queue for BFS (Breadth-First Search)
        public Queue<Vertex>? Queue;
        
        // Stack for DFS (Depth-First Search)
        public Stack<Vertex>? Stack;

        // Constructor to initialize the graph with data from a file
        public Graph(string FilePath)
        {
            _vertex = new List<Vertex>(); // Initialize the vertex list
            GetData(FilePath); // Get graph data from file
        }

        // Method to get graph data from a file
        public void GetData(string path)
        {
            string? jString = null;
            try
            {
                jString = File.ReadAllText(path); // Read data from file
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            if (jString != null)
            {
                var vertex = JsonSerializer.Deserialize<List<Vertex>>(jString)!; // Deserialize JSON data
                _vertex = new List<Vertex>(); // Initialize vertex list
                _vertex = (List<Vertex>)vertex!; // Assign deserialized data to vertex list
            }

            if (jString != null)
            {
                jString = JsonSerializer.Serialize<List<Vertex>>(_vertex); // Serialize vertex list
                File.WriteAllText(path, jString); // Write serialized data back to file
            }
        }

        // Method to reset the visited flag for all vertices in the graph
        private void ResetVisitedSet()
        {
            foreach (Vertex count in _vertex)
            {
                count.Visited = false;
            }
        }

        // Method to get an adjacent unvisited vertex from a given vertex
        private Vertex? GetAdjUnvisitedVertex(Vertex start)
        {
            if (start.AdjVertices == null)
            {
                return null;
            }
            else
            {
                for (int i = 0; i < start.AdjVertices.Count; i++)
                {
                    if (_vertex[i].Number == start.Number)
                    {
                        continue;
                    }
                    if(start.AdjVertices[i] == true)
                    {
                        if(_vertex[i].Visited == false)
                        {
                            return _vertex[i];
                        }
                    }
                }
            }
            return null;
        }

        // Method to view a vertex
        private void ViewVertex(Vertex Vertex)
        {
            if (Vertex == null)
            {
                return;
            }
            else
            {
                Console.Write(Vertex.Number.ToString() + " ");
            }
        }

        // Method to perform Breadth-First Search traversal
        public void BFS(int start)
        {
            Queue = new Queue<Vertex>(); // Initialize the queue
            Vertex obj = new Vertex();
            _vertex[start].Visited = true; // Mark the start vertex as visited
            Queue.Enqueue(_vertex[start]); // Enqueue the start vertex

            Console.Write("BFS= "); // Print BFS label

            while (Queue.Count > 0)
            {
                obj = Queue.Dequeue(); // Dequeue a vertex from the queue
                ViewVertex(obj); // View the dequeued vertex
                Vertex? adjVertex = GetAdjUnvisitedVertex(obj); // Get an adjacent unvisited vertex
                while (adjVertex != null)
                {
                    Queue.Enqueue(adjVertex); // Enqueue the adjacent unvisited vertex
                    adjVertex.Visited = true; // Mark the adjacent vertex as visited
                    adjVertex = GetAdjUnvisitedVertex(obj); // Get the next adjacent unvisited vertex
                }
            }

            ResetVisitedSet(); // Reset the visited flag for all vertices
            Console.WriteLine(" "); // Print newline
        }
  
        // Method to perform Depth-First Search traversal
        public void DFS(int start) 
        {
            Stack = new Stack<Vertex>(); // Initialize the stack
            Vertex ? obj = new Vertex();

            if (_vertex.Count == 0)
                return;

            Stack.Push(_vertex[start]); // Push the start vertex onto the stack
            Console.Write("DFS= "); // Print DFS label

            while (Stack.Any())
            {
                obj = Stack.Peek(); // Get the top vertex from the stack

                // Check if the vertex is visited and has no unvisited adjacent vertices
                if (obj.Visited && GetAdjUnvisitedVertex(obj) == null)
                {
                    obj = Stack.Pop(); // Pop the vertex from the stack
                }
                // Check if the vertex is visited and has unvisited adjacent vertices
                else if (obj.Visited && GetAdjUnvisitedVertex(obj) != null)
                {
                    Vertex ? obj2 = GetAdjUnvisitedVertex(obj); // Get an unvisited adjacent vertex
                    if (obj2 != null)
                    {
                        Stack.Push(obj2); // Push the unvisited adjacent vertex onto the stack
                    }
                }
                // Check if the vertex is unvisited and has unvisited adjacent vertices
                else if (!obj.Visited && GetAdjUnvisitedVertex(obj) != null)
                {
                    obj.Visited = true; // Mark the vertex as visited
                    ViewVertex(obj); // View the vertex

                    Vertex ? obj2 = GetAdjUnvisitedVertex(obj); // Get an unvisited adjacent vertex
                    if (obj2 != null)
                    {
                        Stack.Push(obj2); // Push the unvisited adjacent vertex onto the stack
                    }
                }
                // Check if the vertex is unvisited and has no unvisited adjacent vertices
                else if (!obj.Visited && GetAdjUnvisitedVertex(obj) == null)
                {
                    obj.Visited = true; // Mark the vertex as visited
                    ViewVertex(obj); // View the vertex
                    Stack.Pop(); // Pop the vertex from the stack
                }

            }

            ResetVisitedSet(); // Reset the visited flag for all vertices
            Console.WriteLine(" "); // Print newline
        }
    }
 }

