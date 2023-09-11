using Microsoft.AspNetCore.Mvc;
using Service.DTOs;
using Service.Interfaces;

namespace WebApiSpeedCars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        private readonly IModelService _modelService;

        public ModelController(IModelService modelService)
        {
            _modelService = modelService;
        }

        /// <summary>
        /// Retorna uma lista com todos os modelos cadastrados.
        /// </summary>
        /// <response code="200">Retorna uma lista com todos os modelos cadastrados.</response>
        [HttpGet]
        public async Task<ActionResult> FindAll()
        {
            var result = await _modelService.FindAll();
            if (result.Code == 200) return Ok(result);
            return BadRequest(result.Data);
        }

        /// <summary>
        /// Realiza busca por ID para localizar um modelo específico.
        /// </summary>
        /// <response code="200">Retorna um modelo específico.</response>
        /// <response code="404">Modelo não encontrado.</response>
        /// <response code="406">Caractere inaceitável.</response>
        [HttpGet("{id}")]
        public async Task<ActionResult> FindById(int id)
        {
            var result = await _modelService.FindById(id);
            if (result.Code == 406) return Problem(
                      statusCode: 406, title: "Caractere inaceitavel");
            else if (result.Code == 404) return NotFound(result);
            return Ok(result.Data);
        }

        /// <summary>
        /// Cria um novo modelo.
        /// </summary>
        /// <remarks>
        /// Exemplo com campos obrigatórios:
        ///
        ///     POST /Model/register
        ///     {
        ///        "name": "Executivo"
        ///     }
        /// </remarks>
        /// <response code="201">Retorna o modelo recém criado.</response>
        /// <response code="400">Solicitação inválida. Esse erro ocorre quando algum campo obrigatório não foi devidamente preenchido.</response>
        [HttpPost("register")]
        public async Task<ActionResult> Create([FromBody] ModelDTO modelDTO)
        {
            var result = await _modelService.Create(modelDTO);
            if (result.Code == 400) return BadRequest(result);
            return Created("Created", result.Data);
        }

        /// <summary>
        /// Atualiza um modelo.
        /// </summary>
        /// <remarks>
        /// Exemplo com campos obrigatórios:
        ///
        ///     PUT /Model
        ///     {
        ///        "name": "Elétrico"
        ///     }
        /// </remarks>
        /// <response code="200">Retorna o modelo recém atualizado.</response>
        /// <response code="400">Solicitação inválida. Esse erro ocorre quando algum campo obrigatório não foi devidamente preenchido.</response>
        /// <response code="404">Modelo não encontrado.</response>
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] ModelDTO modelDTO)
        {
            var result = await _modelService.Update(modelDTO);
            if (result.Code == 404) return NotFound(result);
            else if (result.Code == 400) return BadRequest(result);
            return Ok(result.Data);
        }

        /// <summary>
        /// Exclui um modelo específico.
        /// </summary>
        /// <remarks>
        /// Informe o ID do modelo que deseja deletar.
        /// </remarks>
        /// <response code="200">Retorna uma mensagem informando que o modelo foi excluído com sucesso.</response>
        /// <response code="400">Solicitação inválida.</response>
        /// <response code="404">Modelo não encontrado.</response>
        /// <response code="406">Caractere inaceitável.</response>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _modelService.Delete(id);
            if (result.Code == 406) return Problem(
                        statusCode: 406, title: "Caractere inaceitavel");
            else if (result.Code == 404) return NotFound(result);
            return Ok(result.Message);
        }
    }
}
