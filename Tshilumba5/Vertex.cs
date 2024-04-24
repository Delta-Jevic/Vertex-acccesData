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

namespace GraphNS
{
    // Represents a vertex in a graph
    public class Vertex
    {
        // The number associated with the vertex
        public int Number { get; set; }

        // Indicates whether the vertex has been visited during traversal
        public bool Visited { get; set; }

        // List of boolean values representing adjacent vertices
        //  List<Vertex> depending on your needs
        public List<Boolean> AdjVertices { get; set; }

        // Constructor for creating a new vertex
        public Vertex(int number = -1, bool visited = false)
        {
            this.Number = number;
            this.Visited = visited;
            this.AdjVertices = new List<Boolean>(); // Initialize with an empty list
        }
    }
}
