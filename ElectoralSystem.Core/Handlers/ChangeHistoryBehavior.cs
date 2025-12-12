using ElectoralSystem.API.Core.Interfaces;
using ElectoralSystem.API.Repository.Entities;
using ElectoralSystem.API.Repository.Interfaces;
using MediatR;
using Newtonsoft.Json;


namespace ElectoralSystem.API.Core.Handlers
{
    public class ChangeHistoryBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IChangeHistoryRepository _changeHistoryRepository;
        private readonly IUserAccessor _userAccessor;
        private readonly IReadRepository _readRepository;

        public ChangeHistoryBehavior(
            IChangeHistoryRepository changeHistoryRepository, 
            IUserAccessor userAccessor,
            IReadRepository readRepository
           )
        {
            _changeHistoryRepository = changeHistoryRepository;
            _userAccessor = userAccessor;
            _readRepository = readRepository;
        }

        private static readonly JsonSerializerSettings JsonSettings = new JsonSerializerSettings 
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };

        public async Task<TResponse> Handle(
            TRequest request, 
            RequestHandlerDelegate<TResponse> next, 
            CancellationToken cancellationToken
            )
        {
            if (request is IAuditableCommand auditableCommand)
            {
                string oldValueJson = "{}";

                if (auditableCommand.AuditAction.StartsWith("UPDATE") || auditableCommand.AuditAction.StartsWith("DELETE"))
                {
                    var entityBeforeChange = await _readRepository.GetByIdAsync(auditableCommand.EntityType, auditableCommand.RecordId);

                    if (entityBeforeChange != null)
                    { 
                        oldValueJson = JsonConvert.SerializeObject(entityBeforeChange, JsonSettings);
                    }
                }
                              
                TResponse response = await next();

                var userId = _userAccessor.GetUserId();

                if (userId.HasValue)
                //if(true)
                {
                    var historyEntry = new ChangeHistory
                    {
                        Id = new Guid(),
                        UserId = userId.Value,
                        TableName = auditableCommand.EntityType.Name,
                        RecordId = auditableCommand.RecordId,
                        Action = auditableCommand.AuditAction,
                        Date = DateTime.UtcNow,
                        OldValue = oldValueJson,
                        NewValue = JsonConvert.SerializeObject(request, JsonSettings)
                    };

                    await _changeHistoryRepository.CreateAsync(historyEntry);
                }

                return response;
            }

            return await next();
        }
    }
}
