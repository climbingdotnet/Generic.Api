namespace GenericDemo.Api.Extensions
{
    using System.Collections.Generic;
    using System.Reflection;

    using AutoMapper;

    using FluentValidation;

    using GenericDemo.Domain.Context;
    using GenericDemo.Domain.Mapping;
    using GenericDemo.Domain.Models;
    using GenericDemo.Domain.Services.Abstract;
    using GenericDemo.Domain.Services.Concrete;
    using GenericDemo.Domain.Validators;
    using GenericDemo.Dto.Requests;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceCollectionExtensions
    {
        public static void RegisterWebLayerDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureSwaggerGen(c => { c.CustomSchemaIds(a => a.FullName); });

            services.AddAutoMapper(typeof(LanguageMapping).Assembly);

            services.AddValidatorsFromAssemblies(new List<Assembly> { typeof(LanguageValidator).Assembly });

            services.AddDbContext<GenericDemoContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("GenericDemo")));

            services.AddRepository<Language>();
            services.AddRepository<Like>();

            services.AddCreateService<Language, CreateLanguageDto>();
            services.AddCreateService<Like, CreateLikeDto>();
            services.AddUpdateService<Language, UpdateLanguageDto>();
            services.AddUpdateService<Like, UpdateLikeDto>();

            services.AddControllers();
        }

        private static void AddCreateService<TEntity, TCreate>(this IServiceCollection services) =>
            services.AddScoped<ICreateService<TEntity, TCreate>, CreateService<TEntity, TCreate>>();

        private static void AddUpdateService<TEntity, TUpdate>(this IServiceCollection services) =>
            services.AddScoped<IUpdateService<TEntity, TUpdate>, UpdateService<TEntity, TUpdate>>();

        private static void AddRepository<TEntity>(this IServiceCollection services) where TEntity : class =>
            services.AddScoped<IRepository<TEntity>, Repository<TEntity>>();
    }
}
