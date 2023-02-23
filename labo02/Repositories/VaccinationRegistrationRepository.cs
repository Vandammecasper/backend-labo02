namespace labo02.Repositories;

public interface IVaccinRegistrationRepository
{
    List<VaccinRegistration> GetRegistrations();
}

public class VaccinRegistrationRepository : IVaccinRegistrationRepository
{

    private static List<VaccinRegistration> _registrations = new List<VaccinRegistration>();

    public VaccinRegistrationRepository()
    {
        if (!(_registrations.Any()))
        {
            _registrations.Add(new VaccinRegistration()
            {
                VaccinatinRegistrationId = Guid.Parse("93157a58-d289-47c0-81c1-b921afc5f1d7"),
                Name = "Van den Broeck",
                FirstName = "Jan",
                EMail = "jan.vandenbroeck@gmail.com",
                YearOfBirth = 1980,
                VaccinationDate = "2021-03-01",
                VaccinTypeId = Guid.Parse("a7b4e10c-d387-46da-8ee4-a1128899f490"),
                VaccinationLocationId = Guid.Parse("2774e3d1-2b0f-47ab-b391-8ea43e6f9d80")
            });
            _registrations.Add(new VaccinRegistration()
            {
                VaccinatinRegistrationId = Guid.Parse("b0b5b2a1-1b1f-4b1f-9b1a-1b1f4b1f9b1a"),
                Name = "Van den Broeck",
                FirstName = "Jef",
                EMail = "jef.vandenbroeck",
                YearOfBirth = 1980,
                VaccinationDate = "2021-03-01",
                VaccinTypeId = Guid.Parse("6fd89668-b29e-484d-a2b1-1d1a55a5f503"),
                VaccinationLocationId = Guid.Parse("0bb537ea-8209-422f-a9e1-2c1e37d0cb4d")
            });
        }
    }
    public List<VaccinRegistration> GetRegistrations()
    {
        return _registrations.ToList<VaccinRegistration>();
    }
}

public class CsvVaccinationRegistrationRepository : IVaccinRegistrationRepository
{
    private readonly CsvConfig _csvConfig;
    public CsvVaccinationRegistrationRepository(IOptions<CsvConfig> csvConfig)
    {
        _csvConfig = csvConfig.Value;
    }

    public List<VaccinRegistration> GetRegistrations()
    {
        try
        {
            using var reader = new StreamReader(_csvConfig.CsvRegistrations);
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                Delimiter = ";"
            };
            using var csv = new CsvReader(reader, config);
            var records = csv.GetRecords<VaccinRegistration>();
            return records.ToList();
        }
        catch (Exception ex)
        {
            throw new Exception("Error while reading csv file", ex);
        }
    }
}