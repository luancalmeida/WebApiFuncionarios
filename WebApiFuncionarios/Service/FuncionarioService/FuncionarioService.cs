using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApiFuncionarios.DataContext;
using WebApiFuncionarios.Models;

namespace WebApiFuncionarios.Service.FuncionarioService
{

    public class FuncionarioService : IFuncionarioInterface
    {
        //esse construtor que vai se comunicar com o banco, da linha 9 ate 12
        private readonly ApplicationDbContext _context;
        public FuncionarioService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<FuncionarioModels>>> CreateFuncionario(FuncionarioModels novoFuncionario)
        {
            ServiceResponse<List<FuncionarioModels>> serviceResponse = new ServiceResponse<List<FuncionarioModels>>();

            try
            {
                if (novoFuncionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informar dados!";
                    serviceResponse.Sucesso = false;
                    return serviceResponse;
                }

                _context.Add(novoFuncionario);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModels>>> DeletarFuncionario(int Id)
        {
            ServiceResponse<List<FuncionarioModels>> serviceResponse = new ServiceResponse<List<FuncionarioModels>>();
            
            try
            {
                FuncionarioModels funcionarioModels = _context.FuncionarioModels.FirstOrDefault(x => x.Id == Id);
                if (funcionarioModels == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Não localizado";
                    serviceResponse.Sucesso = false;
                    return serviceResponse;
                }


                _context.FuncionarioModels.Remove(funcionarioModels);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.FuncionarioModels.ToList();
               
            }
            catch (Exception ex)
            {

                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
            

        }

        public async Task<ServiceResponse<List<FuncionarioModels>>> GetFuncionario()
        {
            ServiceResponse<List<FuncionarioModels>> serviceResponse = new ServiceResponse<List<FuncionarioModels>>();

            try
            {
                serviceResponse.Dados = _context.FuncionarioModels.ToList();
                if (serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhum dado encontrado!";
                    
                }
            }
            catch (Exception ex)
            {

                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;

        }

        public async Task<ServiceResponse<FuncionarioModels>> GetFuncionarioById(int Id)
        {
            ServiceResponse<FuncionarioModels> serviceResponse = new ServiceResponse<FuncionarioModels>();

            try
            {
                FuncionarioModels funcionarioModels = _context.FuncionarioModels.FirstOrDefault(x => x.Id == Id);

               

                serviceResponse.Dados = funcionarioModels;
            }
            catch (Exception ex)
            {

                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModels>>> InativarFuncionario(int Id)
        {
            ServiceResponse<List<FuncionarioModels>> serviceResponse = new ServiceResponse<List<FuncionarioModels>>();

            try
            {
                FuncionarioModels funcionarioModels = _context.FuncionarioModels.FirstOrDefault(x => x.Id == Id);

                if (funcionarioModels == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Não encotrado!";
                    serviceResponse.Sucesso = false;
                }

                funcionarioModels.Ativo = false;
                funcionarioModels.DataAlteracao = DateTime.Now.ToLocalTime();

                _context.FuncionarioModels.Update(funcionarioModels);
                await _context.SaveChangesAsync() ;

                serviceResponse.Dados = _context.FuncionarioModels.ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
                
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModels>>> UpdateFuncinario(FuncionarioModels editaFuncionario)
        {
            ServiceResponse<List<FuncionarioModels>> serviceResponse = new ServiceResponse<List<FuncionarioModels>>();

            try
            {
                FuncionarioModels funcionarioModels = _context.FuncionarioModels.AsNoTracking().FirstOrDefault(x => x.Id == editaFuncionario.Id);

                if (funcionarioModels == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Não encotrado!";
                    serviceResponse.Sucesso = false;
                }

                funcionarioModels.DataCriacao = DateTime.Now.ToLocalTime();

                _context.FuncionarioModels.Update(editaFuncionario);
                await _context.SaveChangesAsync() ;

                serviceResponse.Dados = _context.FuncionarioModels.ToList();

            }
            catch (Exception ex)
            {

                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;

        }
    }
}
