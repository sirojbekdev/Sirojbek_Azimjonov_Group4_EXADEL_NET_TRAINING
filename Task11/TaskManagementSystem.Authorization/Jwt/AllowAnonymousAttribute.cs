namespace TaskManagementSystem.Authorization.Jwt;

[AttributeUsage(AttributeTargets.Method)]
public class AllowAnonymousAttribute : Attribute
{ }