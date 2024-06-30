using ApiOfLineLlama3.model;


class Program
{
    static async Task Main()
    {
        Console.WriteLine("Digite sua pergunta para llama3\n Digite 'sair' para encerrar o chat :)\n");

        while (true) {
            
            Console.Write("Voce: ");
            string pergunta = Console.ReadLine();
            if(pergunta == "sair")
            {
                return;
            }

            Requisicao requestData = new Requisicao(pergunta);
            string resposta = await JsonConnection.GetResposta(requestData);

            Console.WriteLine($"Resposta da API: {resposta}\n");
        }      
        
    }
}
