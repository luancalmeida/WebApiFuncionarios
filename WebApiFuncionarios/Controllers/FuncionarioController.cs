 using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApiFuncionarios.Models;
using WebApiFuncionarios.Service.FuncionarioService;

namespace WebApiFuncionarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioInterface _funcionarioInterface;
        public FuncionarioController(IFuncionarioInterface funcionarioInterface)
        {
            _funcionarioInterface = funcionarioInterface;

        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModels>>>> GetFuncionario()
        {
            return Ok(await _funcionarioInterface.GetFuncionario());

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<FuncionarioModels>>> GetFuncionarioById(int id)
        {
            ServiceResponse<FuncionarioModels> serviceResponse = await _funcionarioInterface.GetFuncionarioById(id);
            return Ok(serviceResponse);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModels>>>> CreateFuncionario(FuncionarioModels novoFuncionario)
        {
            return Ok(await _funcionarioInterface.CreateFuncionario(novoFuncionario));
        }


        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModels>>>> UpdateFuncinario(FuncionarioModels novoFuncionario)
        {
            ServiceResponse<List<FuncionarioModels>> serviceResponse = await _funcionarioInterface.UpdateFuncinario(novoFuncionario);
            return Ok(serviceResponse);
        }



        [HttpPut("inativar{id}")]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModels>>>> InativarFuncionario(int id)
        {
            ServiceResponse<List<FuncionarioModels>> serviceResponse = await _funcionarioInterface.InativarFuncionario(id);

            return Ok(serviceResponse);

         }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModels>>>> DeletarFuncionario(int Id)
        {
            ServiceResponse<List<FuncionarioModels>> serviceResponse = await _funcionarioInterface.DeletarFuncionario(Id);

            return Ok(serviceResponse);
        }

    }
}
