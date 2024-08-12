using System;
using System.Collections.Generic;

namespace MonolithicTodoApp
{
    class TodoManager
    {
        private List<string> tasks = new List<string>();
        private FileStorage storage = new FileStorage();

        public TodoManager()
        {
            tasks = storage.LoadTasks();
        }

        public void AddTask(string description)
        {
            tasks.Add(description);
            storage.SaveTasks(tasks);
            Console.WriteLine("Task added.");
        }

        public void ListTasks()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks available.");
                return;
            }

            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i]}");
            }
        }

        public void RemoveTask(int id)
        {
            if (id <= 0 || id > tasks.Count)
            {
                Console.WriteLine("Invalid task ID.");
                return;
            }

            tasks.RemoveAt(id - 1);
            storage.SaveTasks(tasks);
            Console.WriteLine("Task removed.");
        }
    }
}
