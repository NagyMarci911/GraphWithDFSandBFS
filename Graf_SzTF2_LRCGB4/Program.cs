using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Graf_SzTF2_LRCGB4
{
    class Program
    {
        static void Main(string[] args)
        {
            Person Stew = new Person() { Name = "Stew" };
            Person Joseph = new Person() { Name = "Joseph" };
            Person Marge = new Person() { Name = "Marge" };
            Person Gerald = new Person() { Name = "Gerald" };
            Person Zack = new Person() { Name = "Zack" };
            Person Peter = new Person() { Name = "Peter" };
            Person Janet = new Person() { Name = "Janet" };
            Graph<Person> graph = new Graph<Person>();
            graph.graphEventHandler += ExternalNewEdgeMethod;
            graph.AddNode(Stew);
            graph.AddNode(Joseph);
            graph.AddNode(Marge);
            graph.AddNode(Gerald);
            graph.AddNode(Zack);
            graph.AddNode(Peter);
            graph.AddNode(Janet);

            graph.AddEdge(Stew, Joseph);
            graph.AddEdge(Stew, Marge);
            graph.AddEdge(Marge, Joseph);
            graph.AddEdge(Joseph, Gerald);
            graph.AddEdge(Joseph, Zack);
            graph.AddEdge(Gerald, Zack);
            graph.AddEdge(Zack, Peter);
            graph.AddEdge(Peter, Janet);

            Console.WriteLine();
            graph.BFS(Gerald, (Person person, int? distance) => Console.WriteLine(distance + ". " + person.ToString()));
            Console.WriteLine();
            graph.DFS(Gerald, (Person person, int? distance) => Console.WriteLine(person.ToString()));
        }
        static void ExternalProcessor(string item)
        {
            string path = Directory.GetCurrentDirectory() + "\\GraphOutput";
            File.AppendAllText(path, item);
        }
        static void ExternalNewEdgeMethod<T>(object source, GraphEventArgs<T> geargs)
        {
            Console.WriteLine(" Between: " + geargs.From.ToString() + " and " + geargs.To.ToString() + "new edge added!");
        }



    }
}
