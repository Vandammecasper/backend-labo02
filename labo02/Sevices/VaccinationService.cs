namespace labo02.Services;

public interface IVaccinService
{
    VaccinRegistration AddRegistration(VaccinRegistration registration);
    List<VaccinationLocation> GetLocations();
    List<VaccinRegistration> GetRegistrations();
    List<VaccinType> GetVaccinTypes();
}

public class VaccinService : IVaccinService
{
    private readonly IVaccinationLocationRepository _locationRepository;
    private readonly IVaccinTypeRepository _vaccinTypeRepository;
    private readonly IVaccinRegistrationRepository _vaccinRegistrationRepository;

    public VaccinService(IVaccinationLocationRepository locationRepository, IVaccinTypeRepository vaccinTypeRepository, IVaccinRegistrationRepository vaccinRegistrationRepository)
    {
        _locationRepository = locationRepository;
        _vaccinTypeRepository = vaccinTypeRepository;
        _vaccinRegistrationRepository = vaccinRegistrationRepository;
    }

    public VaccinRegistration AddRegistration(VaccinRegistration registration)
    {
        throw new NotImplementedException();
    }

    public List<VaccinationLocation> GetLocations()
    {
        return _locationRepository.GetLocations();
    }

    public List<VaccinRegistration> GetRegistrations()
    {
        return _vaccinRegistrationRepository.GetRegistrations();
    }

    public List<VaccinType> GetVaccinTypes()
    {
        return _vaccinTypeRepository.GetVaccinTypes();
    }
}