using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using Service.DTOs;
using Service.Exceptions;
using Service.Interfaces;

namespace Service.Services
{
    public class RenterService : IRenterService
    {
        private readonly IRenterRepository _repository;
        private readonly IMapper _mapper;

        public RenterService(IRenterRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResultService<RenterDTO>> Create(RenterDTO renterDTO)
        {
            var renter = _mapper.Map<RenterDTO>(renterDTO);
            if (renter == null) return ResultService.Fail<RenterDTO>(400, "O locatário deve ser informado");
            var result = new RenterDTOValidator().Validate(renter);
            if (!result.IsValid) return ResultService.RequestError<RenterDTO>(400, "Problemas na validação", result);

            var isUnique = await _repository.IsRenterUnique(renter.CPF);
            if (!isUnique) return ResultService.Fail<RenterDTO>(400, "Já existe um locatário com esse CPF");

            var newRenter = _mapper.Map<Renter>(renter);
            var data = await _repository.Create(newRenter);
            return ResultService.Ok<RenterDTO>(201, _mapper.Map<RenterDTO>(data));
        }

        public async Task<ResultService> Delete(int id)
        {
            if (id <= 0) return ResultService.Fail(406, "Valor informado inválido");
            var renter = await _repository.FindById(id);
            if (renter == null) return ResultService.Fail<RenterDTO>(404, "Locatário não encontrado");

            await _repository.Delete(id);
            return ResultService.Ok(200, "O locatário foi excluído com sucesso");
        }

        public async Task<ResultService<ICollection<RenterDTO>>> FindAll()
        {
            var renters = await _repository.FindAll();
            return ResultService.Ok<ICollection<RenterDTO>>(200, _mapper.Map<ICollection<RenterDTO>>(renters));
        }

        public async Task<ResultService<RenterDTO>> FindByCNH(string driverLicenseNumber)
        {
            var renter = await _repository.FindByCNH(driverLicenseNumber);
            if (renter == null) return ResultService.Fail<RenterDTO>(404, "Locatário não encontrado");
            return ResultService.Ok<RenterDTO>(200, _mapper.Map<RenterDTO>(renter));
        }

        public async Task<ResultService<RenterDTO>> FindByCPF(string cpf)
        {
            var renter = await _repository.FindByCPF(cpf);
            if (renter == null) return ResultService.Fail<RenterDTO>(404, "Locatário não encontrado");
            return ResultService.Ok<RenterDTO>(200, _mapper.Map<RenterDTO>(renter));
        }

        public async Task<ResultService<RenterDTO>> FindById(int id)
        {
            if (id <= 0) return ResultService.Fail<RenterDTO>(406, "Valor informado inválido");
            var renter = await _repository.FindById(id);
            if (renter == null) return ResultService.Fail<RenterDTO>(404, "Locatário não encontrado");
            return ResultService.Ok<RenterDTO>(200, _mapper.Map<RenterDTO>(renter));
        }

        public async Task<ResultService<RenterDTO>> FindByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return ResultService.Fail<RenterDTO>(400, "Nome não informado");

            var users = await _repository.FindAll();
            var response = users.FirstOrDefault(i => i.Name == name);

            if (response == null)
                return ResultService.Fail<RenterDTO>(404, "Locatário não encontrado");

            return ResultService.Ok<RenterDTO>(200, _mapper.Map<RenterDTO>(response));
        }


        public async Task<ResultService<RenterDTO>> FindByRG(string identityDocumentNumber)
        {
          //  if (identityDocumentNumber <= 0) return ResultService.Fail<RenterDTO>(406, "Valor informado inválido");
            var renter = await _repository.FindByRG(identityDocumentNumber);
            if (renter == null) return ResultService.Fail<RenterDTO>(404, "Locatário não encontrado");
            return ResultService.Ok<RenterDTO>(200, _mapper.Map<RenterDTO>(renter));
        }

        public async Task<ResultService<RenterDTO>> Update(RenterDTO renterDTO)
        {
            if (renterDTO == null) return ResultService.Fail<RenterDTO>(404, "O locatário deve ser informado");
            var result = new RenterDTOValidator().Validate(renterDTO);
            if (!result.IsValid) return ResultService.RequestError<RenterDTO>(400, "Problemas na validação", result);

            var newRenter = await _repository.FindById(renterDTO.Id);
            if (newRenter == null) return ResultService.Fail<RenterDTO>(404, "Locatário não encontrado");

            newRenter = _mapper.Map<RenterDTO, Renter>(renterDTO, newRenter);

            var data = await _repository.Update(newRenter);
            return ResultService.Ok<RenterDTO>(200, _mapper.Map<RenterDTO>(data));
        }
    }
}
