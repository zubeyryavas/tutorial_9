using tutorial_9.Models;

namespace tutorial_9.Services;

public interface IHospitalServices
{
    Task<Doctor> GetDoctorAsync(int idDoctor);
    Task PutDoctorAsync(Doctor doctor);
    Task PostDoctorAsync(Doctor doctor);
    Task DeleteDoctorAsync(Doctor doctor);
}