using EcoMarket.Applicatioon.Common.Settings;
using EcoMarket.Domain.Entities;
using EcoMarket.Domain.Enums;
using FluentValidation;
using Microsoft.Extensions.Options;

namespace EcoMarket.Infrastructuree.Clients.Validators;

public class ClientValidator:AbstractValidator<Client>
{
    public ClientValidator(IOptions<ValidationSettings> settings)
    {
        var validationsettings = settings.Value;
        RuleSet(
            EntityEvent.OnCreate.ToString(),
            () =>
            {
                RuleFor(client => client.FirstName)
                    .NotEmpty()
                    .MinimumLength(3)
                    .MaximumLength(64)
                    .Matches(validationsettings.NameRegexPattern);
                
                RuleFor(client => client.LastName)
                    .NotEmpty()
                    .MinimumLength(3)
                    .MaximumLength(64)
                    .Matches(validationsettings.NameRegexPattern);
            }
        );
        RuleSet(
            EntityEvent.OnUpdate.ToString(),
            () =>
            {
                RuleFor(client => client.FirstName)
                    .NotEmpty()
                    .MinimumLength(3)
                    .MaximumLength(64)
                    .Matches(validationsettings.NameRegexPattern);
                
                RuleFor(client => client.LastName)
                    .NotEmpty()
                    .MinimumLength(3)
                    .MaximumLength(64)
                    .Matches(validationsettings.NameRegexPattern);
            }
        );
    }
}