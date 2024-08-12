using System; 
using System.Collections.Generic; //Namespace necessário para usar coleções genéricas, como List<T>
using System.IO; //Disponibiliza classes para manipulação de arquivos e diretórios, como File, FileStream, StreamReader, e StreamWriter

namespace MonolitoTodoApp
{
    /*
     Esta classe encapsula a lógica de leitura e escrita de tarefas em um arquivo de texto, 
    permitindo a persistência dos dados*/
    class FileStorage
    {
        /*declaração de uma variável filePath que armazena o caminho para o arquivo onde as tarefas serão salvas. 
         * Neste exemplo, o arquivo é nomeado tasks.txt e será criado no mesmo diretório da aplicação */
        private string filePath = "tasks.txt";

        //Este método carrega as tarefas armazenadas no arquivo e as retorna em uma lista de strings.
        public List<string> LoadTasks()
        {
            /*Verifica se o arquivo tasks.txt existe. Se não existir, retorna uma nova lista vazia de tarefas
             * (new List<string>()), indicando que não há tarefas salvas anteriormente.*/
            if (!File.Exists(filePath))
            {
                return new List<string>();
            }

            /* Se o arquivo existir, o método lê todas as linhas do arquivo tasks.txt 
             * (cada linha representando uma tarefa) e as armazena em uma nova lista de strings. 
             * Esta lista é então retornada.*/
            return new List<string>(File.ReadAllLines(filePath));

            //Em resumo, este método permite que as tarefas sejam carregadas na memória ao iniciar a aplicação.
        }

        /*Este método salva a lista de tarefas passada como argumento no arquivo tasks.txt.*/
        public void SaveTasks(List<string> tasks)
        {
            /* Sobrescreve o conteúdo do arquivo tasks.txt com as tarefas atuais da lista tasks. 
             * Cada elemento da lista é gravado como uma nova linha no arquivo.*/
            File.WriteAllLines(filePath, tasks);

            //Em resumo, este método é chamado sempre que uma tarefa é adicionada ou removida,
            //garantindo que o estado mais recente das tarefas seja persistido.
        }
    }
}
