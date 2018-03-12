using FluentValidation.Results;
using SPE.Domain.Core.Bus;
using SPE.Domain.Core.Notifications;
using SPE.Domain.Products.Repository;

namespace SPE.Domain.CommandsHandlers
{
    public abstract class CommandHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBus _bus;
        private readonly IDomainNotificationHandler<DomainNotification> _notifications;

        protected CommandHandler(IUnitOfWork unitOfWork, IBus bus, IDomainNotificationHandler<DomainNotification> notifications)
        {
            _unitOfWork = unitOfWork;
            _bus = bus;
            _notifications = notifications;
        }

        protected void NotifyErrorValidations(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                _bus.RaiseEvent(new DomainNotification(error.PropertyName, error.ErrorMessage));
            }
        }

        protected bool Commit()
        {
            if (_notifications.HasNotifications()) return false;

            var commandResponse = _unitOfWork.Commit();
            if (commandResponse.Success) return true;

            _bus.RaiseEvent(new DomainNotification("Commit", "There was an error saving the data."));
            return false;
        }
    }
}