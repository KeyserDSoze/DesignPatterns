using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Composite
{
    public class HtmlComposite : DesignPattern, IDesignPattern
    {
        public static HtmlComposite Instance
        {
            get
            {
                Project project = new Project() { Title = "First Project" };
                Project secondProject = new Project() { Title = '\n'.ToString() + '\t'.ToString() + "First SubProject" };
                Project thirdProject = new Project() { Title = '\n'.ToString() + '\t'.ToString() + "Second SubProject" };
                ToDo toDo = new ToDo() { Text = '\n'.ToString() + '\t'.ToString() + '\t'.ToString() + "Text" };
                secondProject.AddChild(toDo);
                secondProject.AddChild(toDo);
                thirdProject.AddChild(toDo);
                thirdProject.AddChild(toDo);
                project.AddChild(secondProject);
                project.AddChild(thirdProject);
                Console.WriteLine(project.GetText());
                return null;
            }
        }
    }
    public interface ToDoList
    {
        string GetText();
    }
    //Leaf
    public class ToDo : ToDoList
    {
        public string Text { get; set; }
        public string GetText()
        {
            return this.Text;
        }
    }
    //Composite
    public class Project : ToDoList
    {
        public string Title { get; set; }
        private List<ToDoList> toDoLists = new List<ToDoList>();
        public void AddChild(ToDoList toDoList)
        {
            this.toDoLists.Add(toDoList);
        }
        public void RemoveChild(ToDoList toDoList)
        {
            this.toDoLists.Remove(toDoList);
        }
        public string GetText()
        {
            string result = this.Title;
            foreach(ToDoList toDoList in this.toDoLists)
            {
                result += toDoList.GetText();
            }
            return result;
        }
    }
}
