using System;

// Define um namespace chamado MonolithicTodoApp para organizar o código
namespace MonolitoTodoApp
{
   //classe principal que contém o método Main (ponto de entrada do programa), onde a execução da aplicação começa.
    class Program
    {
        //Método principal e ponto de entrada do programa, executado quando inicia a aplicação.
        static void Main(string[] args)
        {
            /* Nova instância da classe TodoManager, responsável por gerenciar a lista de tarefas. 
             * Esse objeto (todoManager) será usado para adicionar, listar e remover tarefas.
             */
            var todoManager = new TodoManager();

            /* Este é um loop infinito, o que significa que a aplicação continuará rodando 
             * até que a opção de sair (Exit) seja escolhida. Dentro desse loop, o programa 
             * exibe o menu principal repetidamente e processa a entrada do usuário.
             */
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

