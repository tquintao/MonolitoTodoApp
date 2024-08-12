using System;
using System.Collections.Generic;

namespace MonolitoTodoApp
{
    /*
     * A classe TodoManager encapsula a l�gica de neg�cios da aplica��o de lista de tarefas. 
     * Ela gerencia a lista de tarefas (tasks) e interage com o armazenamento (persistido) atrav�s da classe FileStorage.
     */
    class TodoManager
    {
        /* Declara��o de uma lista de strings chamada tasks, que armazenar� as tarefas da lista de afazeres. 
         * A lista � inicializada como uma lista vazia.
         */
        private List<string> tasks = new List<string>();

        /*Declara��o de uma inst�ncia da classe FileStorage chamada storage, 
         * que � usada para carregar e salvar tarefas em armazenamento persistido (arquivo).
         */
        private FileStorage storage = new FileStorage();
        
        // Construtor da classe TodoManager, chamado automaticamente quando uma nova inst�ncia da classe � criada.
         
        public TodoManager()
        {
            /*Quando um objeto da classe TodoManager � criado, ele chama o m�todo LoadTasks, da classe FileStorage 
             * para carregar qualquer tarefa previamente salva e armazen�-las na lista tasks.
             * Isso permite que a aplica��o persista tarefas entre diferentes execu��es, 
             * mantendo o estado salvo em arquivo.*/
            tasks = storage.LoadTasks();
        }
        //Este m�todo adiciona uma nova tarefa � lista de tarefas.
        public void AddTask(string description)
        {
            tasks.Add(description); //Adiciona a tarefa � lista tasks.
            storage.SaveTasks(tasks);// Ap�s adicionar a tarefa, salva a lista atualizada de tarefas no armazenamento persistido.
            Console.WriteLine("Task added.");
        }
        //Lista todas as tarefas atualmente armazenadas na lista.
        public void ListTasks()
        {
            /*Se a lista estiver vazia (tasks.Count == 0), 
             * o m�todo exibe uma mensagem informando que n�o h� tarefas dispon�veis e retorna sem fazer mais nada.*/
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks available.");
                return;
            }
            /* Itera por todas as tarefas na lista, exibindo cada uma com seu n�mero correspondente. 
             * Isso facilita ao usu�rio identificar qual tarefa ele deseja remover.*/
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i]}");
            }
        }

        //Remove uma tarefa da lista com base em seu n�mero.
        public void RemoveTask(int id)
        {
            //Verifica se o id fornecido � v�lido. Se n�o for, o m�todo exibe uma mensagem de erro e retorna.
            if (id <= 0 || id > tasks.Count)
            {
                Console.WriteLine("Invalid task ID.");
                return;
            }

            tasks.RemoveAt(id - 1); //Remove a tarefa no �ndice id - 1 (subtrai 1 porque as listas em C# s�o indexadas a partir de 0).
            storage.SaveTasks(tasks); //Ap�s remover a tarefa, a lista atualizada de tarefas � salva no armazenamento persistido.
            Console.WriteLine("Task removed.");
        }
    }
}
