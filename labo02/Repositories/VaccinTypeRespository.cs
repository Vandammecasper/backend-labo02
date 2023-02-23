using System;


namespace labo02.Repositories
{
    public interface IVaccinTypeRepository
    {
        List<VaccinType> GetVaccinTypes();
    }
    public class VaccinTypeRespository : IVaccinTypeRepository
    {
        private static List<VaccinType> _vaccinTypes = new List<VaccinType>();
        public VaccinTypeRespository()
        {
            if (!_vaccinTypes.Any())
            {
                _vaccinTypes.Add(new VaccinType()
                {
                    VaccinTypeId = Guid.Parse("9f3c1360-8969-43a9-9ee6-a2e04b628900"),
                    Name = "pfizer"
                });
                _vaccinTypes.Add(new VaccinType()
                {
                    VaccinTypeId = Guid.Parse("eb276388-677c-4a4a-8a16-22e06ae6f238"),
                    Name = "moderna"
                });
                _vaccinTypes.Add(new VaccinType()
                {
                    VaccinTypeId = Guid.Parse("a9473f5b-c9c6-4e3f-9298-69dfd3e63294"),
                    Name = "astrazeneca"
                });
            }
        }

        public List<VaccinType> GetVaccinTypes()
        {
            return _vaccinTypes.ToList<VaccinType>();
        }
    }
}

public class CsvVaccinTypeRepository : IVaccinTypeRepository
{
    private readonly CsvConfig _csvConfig;
    public CsvVaccinTypeRepository(IOptions<CsvConfig> csvConfig)
    {
        _csvConfig = csvConfig.Value;
    }

    public List<VaccinType> GetVaccinTypes()
    {
        try
        {
            using var reader = new StreamReader(_csvConfig.CsvVaccin);
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                Delimiter = ";"
            };
            using var csv = new CsvReader(reader, config);
            var records = csv.GetRecords<VaccinType>();
            return records.ToList();
        }
        catch (System.Exception)
        {
            throw;
        }
    }
}