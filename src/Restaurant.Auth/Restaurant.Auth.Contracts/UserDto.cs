namespace Restaurant.Auth.Contracts
{
    public sealed record UserDto(Guid id, string email, string name, DateTime registrationDT);
}
