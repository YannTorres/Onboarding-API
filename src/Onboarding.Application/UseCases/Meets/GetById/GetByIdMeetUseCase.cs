using AutoMapper;
using Onboarding.Communication.Response.Meets;
using Onboarding.Domain.Repositories.Meets;
using Onboarding.Exception.ExceptionBase;

namespace Onboarding.Application.UseCases.Meets.GetById;
public class GetByIdMeetUseCase : IGetByIdMeetUseCase
{
    private readonly IMapper _mapper;
    private readonly IReadOnlyMeetRepository _repository;
    public GetByIdMeetUseCase(IMapper mapper, IReadOnlyMeetRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }
    public async Task<ResponseMeetJson> Execute(long id)
    {
        var result = await _repository.GetById(id);

        if (result == null)
        {
            throw new NotFoundException("Reunião não encontrada");
        }

        return _mapper.Map<ResponseMeetJson>(result);
    }
}
