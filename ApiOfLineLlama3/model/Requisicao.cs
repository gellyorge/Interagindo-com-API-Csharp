
namespace ApiOfLineLlama3.model
{
    public class Requisicao
    {
        public string model { get; } = "llama3";
        public string prompt { get; set; }
        public bool stream { get; } = false;

        public Requisicao(string comando)
        {
            prompt = comando;
        }

    }
}
