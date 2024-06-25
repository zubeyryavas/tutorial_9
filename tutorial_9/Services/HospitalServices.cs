using Microsoft.EntityFrameworkCore;
using tutorial_9.Context;
using tutorial_9.Exceptions;
using tutorial_9.Models;

namespace tutorial_9.Services;

 public class HospitalServices : IHospitalServices
    {
        private readonly HospitalDbContext _hospitalDbContext;

        public HospitalServices(HospitalDbContext hospitalDbContext)
        {
            _hospitalDbContext = hospitalDbContext;
        }

        public async Task<Doctor> GetDoctorAsync(int idDoctor)
        {
            var result = await _hospitalDbContext.Doctors
                .FirstAsync(x => x.IdDoctor == idDoctor);
                /*.Select(x => new Doctor
                {
                    IdDoctor = x.IdDoctor,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email
                })
                .ToListAsync();*/

            return result;
        }
        public async Task PutDoctorAsync(Doctor doctor)
        {
            var result = await GetDoctorAsync(doctor.IdDoctor);

            if (result == null)
                throw new NotFoundException();

            result = new Doctor
            {
                IdDoctor = doctor.IdDoctor,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Email = doctor.Email
            };
            await _hospitalDbContext.SaveChangesAsync();
        }
        public async Task PostDoctorAsync(Doctor doctor)
        {
            _hospitalDbContext.Doctors
                .Add(new Doctor
                {
                    IdDoctor = doctor.IdDoctor,
                    FirstName = doctor.FirstName,
                    LastName = doctor.LastName,
                    Email = doctor.Email
                });
            await _hospitalDbContext.SaveChangesAsync();
        }

        public async Task DeleteDoctorAsync(Doctor doctor)
        {
            var result = await GetDoctorAsync(doctor.IdDoctor);

            if (result == null)
                throw new NotFoundException();

            _hospitalDbContext.Doctors
                .Remove(result);
            await _hospitalDbContext.SaveChangesAsync();
        }
    }