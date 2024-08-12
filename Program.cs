// See https://aka.ms/new-console-template for more information
using System;

namespace MonolithicTodoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var todoManager = new TodoManager();

            while (true)
            {
                Console.WriteLine("To-Do List Application");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. List Tasks");
                Console.WriteLine("3. Remove Task");
                Console.WriteLine("4. Exit");
                Console.Write("Select an option: ");
                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.Write("Enter task description: ");
                        var description = Console.ReadLine();
                        todoManager.AddTask(description);
                        break;
                    case "2":
                        todoManager.ListTasks();
                        break;
                    case "3":
                        Console.Write("Enter task ID to remove: ");
                        if (int.TryParse(Console.ReadLine(), out int id))
                        {
                            todoManager.RemoveTask(id);
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID!");
                        }
                        break;
                    case "4":
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid option, try again.");
                        break;
                }
            }
        }
    }
}

