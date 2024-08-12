using System; 
using System.Collections.Generic; //Namespace necess�rio para usar cole��es gen�ricas, como List<T>
using System.IO; //Disponibiliza classes para manipula��o de arquivos e diret�rios, como File, FileStream, StreamReader, e StreamWriter

namespace MonolitoTodoApp
{
    /*
     Esta classe encapsula a l�gica de leitura e escrita de tarefas em um arquivo de texto, 
    permitindo a persist�ncia dos dados*/
    class FileStorage
    {
        /*declara��o de uma vari�vel filePath que armazena o caminho para o arquivo onde as tarefas ser�o salvas. 
         * Neste exemplo, o arquivo � nomeado tasks.txt e ser� criado no mesmo diret�rio da aplica��o */
        private string filePath = "tasks.txt";

        //Este m�todo carrega as tarefas armazenadas no arquivo e as retorna em uma lista de strings.
        public List<string> LoadTasks()
        {
            /*Verifica se o arquivo tasks.txt existe. Se n�o existir, retorna uma nova lista vazia de tarefas
             * (new List<string>()), indicando que n�o h� tarefas salvas anteriormente.*/
            if (!File.Exists(filePath))
            {
                return new List<string>();
            }

            /* Se o arquivo existir, o m�todo l� todas as linhas do arquivo tasks.txt 
             * (cada linha representando uma tarefa) e as armazena em uma nova lista de strings. 
             * Esta lista � ent�o retornada.*/
            return new List<string>(File.ReadAllLines(filePath));

            //Em resumo, este m�todo permite que as tarefas sejam carregadas na mem�ria ao iniciar a aplica��o.
        }

        /*Este m�todo salva a lista de tarefas passada como argumento no arquivo tasks.txt.*/
        public void SaveTasks(List<string> tasks)
        {
            /* Sobrescreve o conte�do do arquivo tasks.txt com as tarefas atuais da lista tasks. 
             * Cada elemento da lista � gravado como uma nova linha no arquivo.*/
            File.WriteAllLines(filePath, tasks);

            //Em resumo, este m�todo � chamado sempre que uma tarefa � adicionada ou removida,
            //garantindo que o estado mais recente das tarefas seja persistido.
        }
    }
}
