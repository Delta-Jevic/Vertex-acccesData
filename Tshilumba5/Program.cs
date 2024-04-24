/**** NAME	    : Jevic Tshilumba                                   ***
*** CLASS	    : CSC-346                                           ***
*** ASSIGNMENT	:  5                                                ***                                          ***
*** INSTRUCTOR	: GAMRADT                                           ***
*********************************************************************************************
*** DESCRIPTION : Use Visual Studio Code to create a user-defined Abstract Data Type (ADT)
*                 using C# classes named Graph, IAccessData, IGraphAlgorithms,Vertex along with an appropriate set
*                 of C# files as discussed in class                           ***
*********************************************************************************************/

global using global::System;
global using global::System.Collections.Generic;
global using global::System.IO;
global using global::System.Linq;
global using global::System.Net.Http;
global using global::System.Threading;
global using global::System.Threading.Tasks;

global using global::System.Text.Json;
global using global::System.Text.Json.Serialization;

global using global::GraphNS;

using static System.Environment;
using static System.IO.Path;

Graph test = new Graph("Tshilumba5\\Test.json");
test.DFS(0);
test.BFS(0);


