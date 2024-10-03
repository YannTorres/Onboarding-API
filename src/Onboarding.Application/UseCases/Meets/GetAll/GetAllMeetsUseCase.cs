
using AutoMapper;
using Onboarding.Communication.Response.Meets;
using Onboarding.Domain.Entities;
using Onboarding.Domain.Repositories.Meets;

namespace Onboarding.Application.UseCases.Meets.GetAll;
public class GetAllMeetsUseCase : IGetAllMeetsUseCase
{
    private readonly IMapper _mapper;
    private readonly IReadOnlyMeetRepository _meetRepository;
    public GetAllMeetsUseCase(IMapper mapper, IReadOnlyMeetRepository meetRepository)
    {
        _mapper = mapper;
        _meetRepository = meetRepository;
    }
    public async Task<ResponseMeetsJson> Execute()
    {
        var result = await _meetRepository.GetAll();

        return new ResponseMeetsJson
        {
            Meets = _mapper.Map<List<ResponseMeetJson>>(result)
        };
    }
}
