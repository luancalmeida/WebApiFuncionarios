namespace WebApiFuncionarios.Models
{
    // o T é para informar que vai receber dados genericos.  Os dados seja eles quais forem, as respotas vão ser as mesmas. Ela pode receber qualquer tipo de obj
    public class ServiceResponse<T>
    {
        // O T? é para informar que os dados podem ser nulos
       public T? Dados { get; set; }
        public string Mensagem { get; set; } = string.Empty;
        public bool Sucesso { get; set; } = true;
    }
}
