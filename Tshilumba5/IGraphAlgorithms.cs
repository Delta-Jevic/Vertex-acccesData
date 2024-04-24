/**** NAME	    : Jevic Tshilumba                                   ***
*** CLASS	    : CSC-346                                           ***
*** ASSIGNMENT	:  5                                                ***                                          ***
*** INSTRUCTOR	: GAMRADT                                           ***
*********************************************************************************************
*** DESCRIPTION : Use Visual Studio Code to create a user-defined Abstract Data Type (ADT)
*                 using C# classes named Graph, IAccessData, IGraphAlgorithms,Vertex along with an appropriate set
*                 of C# files as discussed in class                           ***
*********************************************************************************************/
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GraphNS 
    
{
    
    // Interface for graph algorithms
    public interface IGraphAlgorithms{
        Queue<Vertex> Queue
        {
            get{ return Queue;}
            set{ Queue = value;}
        }
        Stack<Vertex> Stack
        {
            get{ return Stack;}
            set{ Stack = value;}
        }
         // Method to perform Breadth-First Search traversal
        public void BFS(int start);
        // Method to perform Depth-First Search traversal
        public void DFS(int start);
    }
}
