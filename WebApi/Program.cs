using FluentValidation;
using FluentValidation.AspNetCore;
using WebApi.Models;
using WebApi.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddFluentValidation(fv =>
    fv.RegisterValidatorsFromAssemblyContaining<UsuarioValidator>());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/usuarios", (UsuarioModel usuarioModel, IValidator<UsuarioModel> validator, HttpContext httpContext) =>
{
    var validationResult = validator.Validate(usuarioModel);

    return !validationResult.IsValid ? Results.BadRequest(validationResult.Errors.Select(e => e.ErrorMessage)) : Results.Ok(usuarioModel);
});

app.Run();
