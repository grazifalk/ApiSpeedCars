using Microsoft.AspNetCore.Mvc;
using Service.DTOs;
using Service.Interfaces;
using Service.Services;

namespace WebApiSpeedCars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RenterController : ControllerBase
    {
        private readonly IRenterService _renterService;

        public RenterController(IRenterService renterService)
        {
            _renterService = renterService;
        }

        /// <summary>
        /// Retorna uma lista com todos os locatários cadastrados.
        /// </summary>
        /// <response code="200">Retorna uma lista com todos os locatários cadastrados.</response>
        [HttpGet]
        public async Task<ActionResult> FindAll()
        {
            var result = await _renterService.FindAll();
            if (result.Code == 200) return Ok(result);
            return BadRequest(result.Data);
        }

        /// <summary>
        /// Realiza busca por ID para localizar um locatário específico.
        /// </summary>
        /// <response code="200">Retorna um locatário específico.</response>
        /// <response code="404">Locatário não encontrado.</response>
        /// <response code="406">Caractere inaceitável.</response>
        [HttpGet("{id}")]
        public async Task<ActionResult> FindById(int id)
        {
            var result = await _renterService.FindById(id);
            if (result.Code == 406) return Problem(
                      statusCode: 406, title: "Caractere inaceitavel");
            else if (result.Code == 404) return NotFound(result);
            return Ok(result.Data);
        }

        /// <summary>
        /// Realiza busca por nome para localizar um locatário específico.
        /// </summary>
        /// <response code="200">Retorna um locatário específico.</response>
        /// <response code="404">Locatário não encontrado.</response>
        /// <response code="406">Caractere inaceitável.</response>
        [HttpGet("name/{name}")]
        public async Task<ActionResult> FindByName(string name)
        {
            var result = await _renterService.FindByName(name);
            if (result.Code == 406) return Problem(
                      statusCode: 406, title: "Caractere inaceitavel");
            else if (result.Code == 404) return NotFound(result);
            return Ok(result.Data);
        }

        /// <summary>
        /// Realiza busca por CPF para localizar um locatário específico.
        /// </summary>
        /// <response code="200">Retorna um locatário específico.</response>
        /// <response code="404">Locatário não encontrado.</response>
        /// <response code="406">Caractere inaceitável.</response>
        [HttpGet("cpf")]
        public async Task<ActionResult> FindByCPF([FromQuery] string cpf)
        {
            var result = await _renterService.FindByCPF(cpf);
            if (result.Code == 406) return Problem(
                      statusCode: 406, title: "Caractere inaceitavel");
            else if (result.Code == 404) return NotFound(result);
            return Ok(result.Data);
        }

        /// <summary>
        /// Realiza busca por RG para localizar um locatário específico.
        /// </summary>
        /// <response code="200">Retorna um locatário específico.</response>
        /// <response code="404">Locatário não encontrado.</response>
        /// <response code="406">Caractere inaceitável.</response>
        [HttpGet("rg")]
        public async Task<ActionResult> FindByRG([FromQuery] string identityDocumentNumber)
        {
            var result = await _renterService.FindByRG(identityDocumentNumber);
            if (result.Code == 406) return Problem(
                      statusCode: 406, title: "Caractere inaceitavel");
            else if (result.Code == 404) return NotFound(result);
            return Ok(result.Data);
        }

        /// <summary>
        /// Realiza busca por CNH para localizar um locatário específico.
        /// </summary>
        /// <response code="200">Retorna um locatário específico.</response>
        /// <response code="404">Locatário não encontrado.</response>
        /// <response code="406">Caractere inaceitável.</response>
        [HttpGet("cnh")]
        public async Task<ActionResult> FindByCNH([FromQuery] string driverLicenseNumber)
        {
            var result = await _renterService.FindByCNH(driverLicenseNumber);
            if (result.Code == 406) return Problem(
                      statusCode: 406, title: "Caractere inaceitavel");
            else if (result.Code == 404) return NotFound(result);
            return Ok(result.Data);
        }

        /// <summary>
        /// Cria um novo locatário.
        /// </summary>
        /// <remarks>
        /// Exemplo com campos obrigatórios:
        ///
        ///     POST /Renter/register
        ///     {
        ///"name": "Graziela Falk",
        /// "birth": "1990-08-17T21:05:53.603Z",
        /// "phoneNumber": "22981122183",
        /// "address": "Rua Prudente de Morais, 128",
        /// "email": "grazifalk@gmail.com",
        /// "cpf": "12345678911",
        /// "identityDocumentNumber": "216586199",
        ///  "driverLicenseNumber": "48948949898",
        /// "documentType": "CPF"
        /// }
        /// </remarks>
        /// <response code="201">Retorna o locatário recém criado.</response>
        /// <response code="400">Solicitação inválida. Esse erro ocorre quando algum campo obrigatório não foi devidamente preenchido.</response>
        [HttpPost("register")]
        public async Task<ActionResult> Create([FromBody] RenterDTO renterDTO)
        {
            var result = await _renterService.Create(renterDTO);
            if (result.Code == 400) return BadRequest(result);
            return Created("Created", result.Data);
        }

        /// <summary>
        /// Atualiza um locatário.
        /// </summary>
        /// <remarks>
        /// Exemplo com campos obrigatórios:
        ///
        ///     PUT /Renter
        ///     {
        /// "id": 0,
        /// "name": "Graziela Falk",
        /// "birth": "1990-08-17T21:05:53.603Z",
        /// "phoneNumber": "22981122183",
        /// "address": "Rua Prudente de Morais, 128",
        /// "email": "grazifalk@gmail.com",
        /// "cpf": "12345678911",
        ///  "identityDocumentNumber": "216586199",
        /// "driverLicenseNumber": "48948949898",
        /// "documentType": "CPF"
        /// }
        /// </remarks>
        /// <response code="200">Retorna o locatário recém atualizado.</response>
        /// <response code="400">Solicitação inválida. Esse erro ocorre quando algum campo obrigatório não foi devidamente preenchido.</response>
        /// <response code="404">Locatário não encontrado.</response>
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] RenterDTO renterDTO)
        {
            var result = await _renterService.Update(renterDTO);
            if (result.Code == 404) return NotFound(result);
            else if (result.Code == 400) return BadRequest(result);
            return Ok(result.Data);
        }

        /// <summary>
        /// Exclui um locatário específico.
        /// </summary>
        /// <remarks>
        /// Informe o ID do locatário que deseja deletar.
        /// </remarks>
        /// <response code="200">Retorna uma mensagem informando que o locatário foi excluído com sucesso.</response>
        /// <response code="400">Solicitação inválida.</response>
        /// <response code="404">Locatário não encontrado.</response>
        /// <response code="406">Caractere inaceitável.</response>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _renterService.Delete(id);
            if (result.Code == 406) return Problem(
                        statusCode: 406, title: "Caractere inaceitavel");
            else if (result.Code == 404) return NotFound(result);
            return Ok(result.Message);
        }
    }
}
