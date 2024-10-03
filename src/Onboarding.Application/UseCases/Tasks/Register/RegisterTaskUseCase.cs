using AutoMapper;
using Onboarding.Communication.Requests;
using Onboarding.Communication.Response.Tasks;
using Onboarding.Domain.Repositories;
using Onboarding.Domain.Repositories.Tasks;
using Onboarding.Exception.ExceptionBase;

namespace Onboarding.Application.UseCases.Tasks.Register;
internal class RegisterTaskUseCase : IRegisterTaskUseCase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWriteOnlyTaskRepository _taskRepository;
    private readonly IMapper _mapper;
    public RegisterTaskUseCase(
        IUnitOfWork unitOfWork, 
        IWriteOnlyTaskRepository taskRepository,
        IMapper mapper
        )
    {
        _unitOfWork = unitOfWork;
        _taskRepository = taskRepository;
        _mapper = mapper;
    }
    public async Task<ResponseRegisteredTaskJson> Execute(RequestTaskJson request)
    {
        Validator(request);

        var task = _mapper.Map<Domain.Entities.Task>(request);
        task.CreatedAt = DateTime.UtcNow;

        await _taskRepository.Register(task);
        await _unitOfWork.Commit();

        return _mapper.Map<ResponseRegisteredTaskJson>(task);
    }

    private void Validator(RequestTaskJson request)
    {
        var validator = new TaskValidator();

        var result = validator.Validate(request);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();


            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
