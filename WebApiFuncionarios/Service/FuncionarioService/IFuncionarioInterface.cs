using WebApiFuncionarios.Models;

namespace WebApiFuncionarios.Service.FuncionarioService
{
    public interface IFuncionarioInterface
    {
        Task<ServiceResponse<List<FuncionarioModels>>> GetFuncionario(); 
        Task<ServiceResponse<List<FuncionarioModels>>> CreateFuncionario(FuncionarioModels novoFuncionario);
        Task<ServiceResponse<FuncionarioModels>> GetFuncionarioById(int Id);
        Task<ServiceResponse<List<FuncionarioModels>>> UpdateFuncinario(FuncionarioModels editaFuncionario);
        Task<ServiceResponse<List<FuncionarioModels>>> DeletarFuncionario(int Id);
        Task<ServiceResponse<List<FuncionarioModels>>> InativarFuncionario(int Id);
    }
}
