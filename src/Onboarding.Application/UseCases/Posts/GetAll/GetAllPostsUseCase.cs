using AutoMapper;
using Onboarding.Communication.Response.Posts;
using Onboarding.Domain.Repositories.Post;

namespace Onboarding.Application.UseCases.Posts.GetAll;
public class GetAllPostsUseCase : IGetAllPostsUseCase
{
    private readonly IReadOnlyPostRepository _repository;
    private readonly IMapper _mapper;
    public GetAllPostsUseCase(IMapper mapper, IReadOnlyPostRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }
    public async Task<ResponsePostsJson> Execute()
    {
        var result = await _repository.GetAll();

        return new ResponsePostsJson
        {
            Posts = _mapper.Map<List<ResponsePostJson>>(result)
        };
    }
}
