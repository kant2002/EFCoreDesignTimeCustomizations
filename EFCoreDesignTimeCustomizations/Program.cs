
// See https://aka.ms/new-console-template for more information
using EFCoreDesignTimeCustomizations.Design;
using Microsoft.EntityFrameworkCore.Scaffolding;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddSingleton<ModelCodeGeneratorDependencies, ModelCodeGeneratorDependencies>();
builder.Services.AddSingleton<IModelCodeGenerator, MyTextTemplatingModelGenerator>();