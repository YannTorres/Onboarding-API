using AutoMapper;
using Onboarding.Application.UseCases.Tasks;
using Onboarding.Communication.Requests;
using Onboarding.Communication.Response.Feedback;
using Onboarding.Domain.Entities;
using Onboarding.Domain.Repositories;
using Onboarding.Domain.Repositories.Feedback;
using Onboarding.Exception.ExceptionBase;

namespace Onboarding.Application.UseCases.Feedback.Register;
public class RegisterFeedbackUseCase : IRegisterFeedbackUseCase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWriteOnlyFeedbackRepository _repository;
    private readonly IMapper _mapper;
    public RegisterFeedbackUseCase(IWriteOnlyFeedbackRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<ResponseRegisteredFeedbackJson> Execute(RequestFeedbackJson request)
    {
        Validator(request);

        var feedback = _mapper.Map<Domain.Entities.Feedback>(request);
        feedback.CreatedAt = DateTime.Now;

        await _repository.Register(feedback);
        await _unitOfWork.Commit();

        return _mapper.Map<ResponseRegisteredFeedbackJson>(feedback);
    }

    private void Validator(RequestFeedbackJson request)
    {
        var validator = new FeedbackValidator();

        var result = validator.Validate(request);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();


            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
