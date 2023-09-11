using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using Service.DTOs;
using Service.Exceptions;
using Service.Interfaces;

namespace Service.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _repository;
        private readonly IMapper _mapper;

        public CarService(ICarRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResultService<CarDTO>> Create(CarDTO carDTO)
        {
            var car = _mapper.Map<CarDTO>(carDTO);
            if (car == null) return ResultService.Fail<CarDTO>(400, "O carro deve ser informado");
            var result = new CarDTOValidator().Validate(car);
            if (!result.IsValid) return ResultService.RequestError<CarDTO>(400, "Problemas na validação", result);

            var isUnique = await _repository.IsCarUnique(car.Name);
            if (!isUnique) return ResultService.Fail<CarDTO>(400, "Já existe um carro com esse nome");

            var newCar = _mapper.Map<Car>(car);
            var data = await _repository.Create(newCar);
            return ResultService.Ok<CarDTO>(201, _mapper.Map<CarDTO>(data));
        }

        public async Task<ResultService> Delete(int id)
        {
            if (id <= 0) return ResultService.Fail(406, "Valor informado inválido");
            var car = await _repository.FindById(id);
            if (car == null) return ResultService.Fail<CarDTO>(404, "Carro não encontrado");

            await _repository.Delete(id);
            return ResultService.Ok(200, "O carro foi excluído com sucesso");
        }

        public async Task<ResultService<ICollection<CarDTO>>> FindAll()
        {
            var cars = await _repository.FindAll();
            return ResultService.Ok<ICollection<CarDTO>>(200, _mapper.Map<ICollection<CarDTO>>(cars));
        }

        public async Task<ResultService<CarDTO>> FindById(int id)
        {
            if (id <= 0) return ResultService.Fail<CarDTO>(406, "Valor informado inválido");
            var car = await _repository.FindById(id);
            if (car == null) return ResultService.Fail<CarDTO>(404, "Carro não encontrado");
            return ResultService.Ok<CarDTO>(200, _mapper.Map<CarDTO>(car));
        }

        public async Task<ResultService<CarDTO>> Update(CarDTO car)
        {
            if (car == null) return ResultService.Fail<CarDTO>(404, "O carro deve ser informado");
            var result = new CarDTOValidator().Validate(car);
            if (!result.IsValid) return ResultService.RequestError<CarDTO>(400, "Problemas na validação", result);

            var newCar = await _repository.FindById(car.Id);
            if (newCar == null) return ResultService.Fail<CarDTO>(404, "Carro não encontrado");

            newCar = _mapper.Map<CarDTO, Car>(car, newCar);

            var data = await _repository.Update(newCar);
            return ResultService.Ok<CarDTO>(200, _mapper.Map<CarDTO>(data));
        }
    }
}
