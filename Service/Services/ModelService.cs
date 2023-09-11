using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using Service.DTOs;
using Service.Exceptions;
using Service.Interfaces;

namespace Service.Services
{
    public class ModelService : IModelService
    {
        private readonly IModelRepository _repository;
        private readonly IMapper _mapper;

        public ModelService(IModelRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResultService<ModelDTO>> Create(ModelDTO modelDTO)
        {
            var model = _mapper.Map<ModelDTO>(modelDTO);
            if (model == null) return ResultService.Fail<ModelDTO>(400, "O modelo deve ser informado");
            var result = new ModelDTOValidator().Validate(model);
            if (!result.IsValid) return ResultService.RequestError<ModelDTO>(400, "Problemas na validação", result);

            var isUnique = await _repository.IsModelUnique(model.Name);
            if (!isUnique) return ResultService.Fail<ModelDTO>(400, "Já existe um modelo com esse nome");

            var newModel = _mapper.Map<Model>(model);
            var data = await _repository.Create(newModel);
            return ResultService.Ok<ModelDTO>(201, _mapper.Map<ModelDTO>(data));
        }

        public async Task<ResultService> Delete(int id)
        {
            if (id <= 0) return ResultService.Fail(406, "Valor informado inválido");
            var model = await _repository.FindById(id);
            if (model == null) return ResultService.Fail<ModelDTO>(404, "Modelo não encontrado");

            await _repository.Delete(id);
            return ResultService.Ok(200, "O modelo foi excluído com sucesso");
        }

        public async Task<ResultService<ICollection<ModelDTO>>> FindAll()
        {
            var models = await _repository.FindAll();
            return ResultService.Ok<ICollection<ModelDTO>>(200, _mapper.Map<ICollection<ModelDTO>>(models));
        }

        public async Task<ResultService<ModelDTO>> FindById(int id)
        {
            if (id <= 0) return ResultService.Fail<ModelDTO>(406, "Valor informado inválido");
            var model = await _repository.FindById(id);
            if (model == null) return ResultService.Fail<ModelDTO>(404, "Modelo não encontrado");
            return ResultService.Ok<ModelDTO>(200, _mapper.Map<ModelDTO>(model));
        }

        public async Task<ResultService<ModelDTO>> Update(ModelDTO modelDTO)
        {
            if (modelDTO == null) return ResultService.Fail<ModelDTO>(404, "O modelo deve ser informado");
            var result = new ModelDTOValidator().Validate(modelDTO);
            if (!result.IsValid) return ResultService.RequestError<ModelDTO>(400, "Problemas na validação", result);

            var newModel = await _repository.FindById(modelDTO.Id);
            if (newModel == null) return ResultService.Fail<ModelDTO>(404, "Modelo não encontrado");

            newModel = _mapper.Map<ModelDTO, Model>(modelDTO, newModel);

            var data = await _repository.Update(newModel);
            return ResultService.Ok<ModelDTO>(200, _mapper.Map<ModelDTO>(data));
        }
    }
}
