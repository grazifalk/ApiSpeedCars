using Microsoft.AspNetCore.Mvc;
using Service.DTOs;
using Service.Interfaces;

namespace WebApiSpeedCars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        /// <summary>
        /// Retorna uma lista com todos os carros cadastrados.
        /// </summary>
        /// <response code="200">Retorna uma lista com todos os carros cadastrados.</response>
        [HttpGet]
        public async Task<ActionResult> FindAll()
        {
            var result = await _carService.FindAll();
            if (result.Code == 200) return Ok(result);
            return BadRequest(result.Data);
        }

        /// <summary>
        /// Realiza busca por ID para localizar um carro específico.
        /// </summary>
        /// <response code="200">Retorna um carro específico.</response>
        /// <response code="404">Carro não encontrado.</response>
        /// <response code="406">Caractere inaceitável.</response>
        [HttpGet("{id}")]
        public async Task<ActionResult> FindById(int id)
        {
            var result = await _carService.FindById(id);
            if (result.Code == 406) return Problem(
                      statusCode: 406, title: "Caractere inaceitavel");
            else if (result.Code == 404) return NotFound(result);
            return Ok(result.Data);
        }

        /// <summary>
        /// Cria um novo carro.
        /// </summary>
        /// <remarks>
        /// Exemplo com campos obrigatórios:
        ///
        ///     POST /Car/register
        ///     {
        ///        "name": "Fiat Uno",
        ///        "photo": "https://production.autoforce.com/uploads/version/profile_image/4976/model_main_webp_comprar-way-1-3_b8ea14c141.png",
        ///        "brand": "FIAT",
        ///        "color": "vermelho",
        ///        "doors": 4,
        ///        "steering": "Direção hidráulica",
        ///        "powerWindow": true,
        ///        "powerDoorLocks": true,
        ///        "airConditioner": true,
        ///        "Trunk": "Medium",
        ///        "Price": 250.00,
        ///        "available": true,        
        ///        "modelId": 2
        ///     }
        /// </remarks>
        /// <response code="201">Retorna o carro recém criado.</response>
        /// <response code="400">Solicitação inválida. Esse erro ocorre quando algum campo obrigatório não foi devidamente preenchido.</response>
        [HttpPost("register")]
        public async Task<ActionResult> Create([FromBody] CarDTO carDTO)
        {
            var result = await _carService.Create(carDTO);
            if (result.Code == 400) return BadRequest(result);
            return Created("Created", result.Data);
        }

        /// <summary>
        /// Atualiza um carro.
        /// </summary>
        /// <remarks>
        /// Exemplo com campos obrigatórios:
        ///
        ///     PUT /Car
        ///     {
        ///        "id": 1,
        ///        "name": "Fiat Uno",
        ///        "photo": "https://production.autoforce.com/uploads/version/profile_image/4976/model_main_webp_comprar-way-1-3_b8ea14c141.png",
        ///        "brand": "FIAT",
        ///        "color": "vermelho",
        ///        "doors": 4,
        ///        "steering": "Direção hidráulica",
        ///        "powerWindow": true,
        ///        "powerDoorLocks": true,
        ///        "airConditioner": true,
        ///        "Trunk": "Medium",
        ///        "Price": 250.00,
        ///        "available": false,      
        ///        "modelId": 2
        ///     }
        /// </remarks>
        /// <response code="200">Retorna o carro recém atualizado.</response>
        /// <response code="400">Solicitação inválida. Esse erro ocorre quando algum campo obrigatório não foi devidamente preenchido.</response>
        /// <response code="404">Carro não encontrado.</response>
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] CarDTO carDTO)
        {
            var result = await _carService.Update(carDTO);
            if (result.Code == 404) return NotFound(result);
            else if (result.Code == 400) return BadRequest(result);
            return Ok(result.Data);
        }

        /// <summary>
        /// Exclui um carro específico.
        /// </summary>
        /// <remarks>
        /// Informe o ID do carro que deseja deletar.
        /// </remarks>
        /// <response code="200">Retorna uma mensagem informando que o carro foi excluído com sucesso.</response>
        /// <response code="400">Solicitação inválida.</response>
        /// <response code="404">Carro não encontrado.</response>
        /// <response code="406">Caractere inaceitável.</response>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _carService.Delete(id);
            if (result.Code == 406) return Problem(
                        statusCode: 406, title: "Caractere inaceitavel");
            else if (result.Code == 404) return NotFound(result);
            return Ok(result.Message);
        }
    }
}
