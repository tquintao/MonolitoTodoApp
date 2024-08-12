using System;
using System.Collections.Generic;

namespace MonolitoTodoApp
{
    /*
     * A classe TodoManager encapsula a lógica de negócios da aplicação de lista de tarefas. 
     * Ela gerencia a lista de tarefas (tasks) e interage com o armazenamento (persistido) através da classe FileStorage.
     */
    class TodoManager
    {
        /* Declaração de uma lista de strings chamada tasks, que armazenará as tarefas da lista de afazeres. 
         * A lista é inicializada como uma lista vazia.
         */
        private List<string> tasks = new List<string>();

        /*Declaração de uma instância da classe FileStorage chamada storage, 
         * que é usada para carregar e salvar tarefas em armazenamento persistido (arquivo).
         */
        private FileStorage storage = new FileStorage();
        
        // Construtor da classe TodoManager, chamado automaticamente quando uma nova instância da classe é criada.
         
        public TodoManager()
        {
            /*Quando um objeto da classe TodoManager é criado, ele chama o método LoadTasks, da classe FileStorage 
             * para carregar qualquer tarefa previamente salva e armazená-las na lista tasks.
             * Isso permite que a aplicação persista tarefas entre diferentes execuções, 
             * mantendo o estado salvo em arquivo.*/
            tasks = storage.LoadTasks();
        }
        //Este método adiciona uma nova tarefa à lista de tarefas.
        public void AddTask(string description)
        {
            tasks.Add(description); //Adiciona a tarefa à lista tasks.
            storage.SaveTasks(tasks);// Após adicionar a tarefa, salva a lista atualizada de tarefas no armazenamento persistido.
            Console.WriteLine("Task added.");
        }
        //Lista todas as tarefas atualmente armazenadas na lista.
        public void ListTasks()
        {
            /*Se a lista estiver vazia (tasks.Count == 0), 
             * o método exibe uma mensagem informando que não há tarefas disponíveis e retorna sem fazer mais nada.*/
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks available.");
                return;
            }
            /* Itera por todas as tarefas na lista, exibindo cada uma com seu número correspondente. 
             * Isso facilita ao usuário identificar qual tarefa ele deseja remover.*/
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i]}");
            }
        }

        //Remove uma tarefa da lista com base em seu número.
        public void RemoveTask(int id)
        {
            //Verifica se o id fornecido é válido. Se não for, o método exibe uma mensagem de erro e retorna.
            if (id <= 0 || id > tasks.Count)
            {
                Console.WriteLine("Invalid task ID.");
                return;
            }

            tasks.RemoveAt(id - 1); //Remove a tarefa no índice id - 1 (subtrai 1 porque as listas em C# são indexadas a partir de 0).
            storage.SaveTasks(tasks); //Após remover a tarefa, a lista atualizada de tarefas é salva no armazenamento persistido.
            Console.WriteLine("Task removed.");
        }
    }
}
