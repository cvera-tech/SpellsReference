namespace SpellsReference.Security
{
    public class ICustomPrincipal
    {
        int Id { get; }
        string Username { get; }
        string FirstName { get; }
        string LastName { get; }
    }
}