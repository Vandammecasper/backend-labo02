var builder = WebApplication.CreateBuilder(args);

var csvSettings = builder.Configuration.GetSection("CsvConfig");
builder.Services.Configure<CsvConfig>(csvSettings);

builder.Services.AddTransient<IVaccinationLocationRepository, CsvVaccinationLocationRepository>();
builder.Services.AddTransient<IVaccinRegistrationRepository, CsvVaccinationRegistrationRepository>();
builder.Services.AddTransient<IVaccinTypeRepository, CsvVaccinTypeRepository>();
builder.Services.AddTransient<IVaccinService, VaccinService>();
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

app.MapGet("/locations", (IVaccinService service) =>
{
    return Results.Ok(service.GetLocations());
});

app.MapGet("/vaccintypes", (IVaccinService service) =>
{
    return Results.Ok(service.GetVaccinTypes());
});

app.MapGet("/registrations", (IMapper Mapper, IVaccinService service) =>
{
    var mapped = Mapper.Map<List<VaccinRegistrationDTO>>(service.GetRegistrations(), opts =>
    {
        opts.Items["locations"] = service.GetLocations();
        opts.Items["vaccins"] = service.GetVaccinTypes();
    });
    return Results.Ok(mapped);
});

app.Run("http://localhost:5000");
