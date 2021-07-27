using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IDbService
    {
        public Task<DoctorRequestDto> GetDoctor(int id);
        public Task<Doctor> AddDoctor(DoctorRequestDto doctor);
        public Task<bool> UpdateDoctor(int id, DoctorRequestDto doctor);
        public Task<bool> DeleteDoctor(int id);
        public Task<PrescriptionResponseDto> GetPrescription(int id);
    }
    public class DatabaseService : IDbService
    {
        private readonly MainDbContext _context;
        public DatabaseService(MainDbContext context)
        {
            _context = context;
        }
        public async Task<DoctorRequestDto> GetDoctor(int id)
        {
            var tmp = await _context.Doctors.FindAsync(id);
            if (tmp == null)
            {
                return null;
            }
            return new DoctorRequestDto { FirstName = tmp.FirstName, LastName = tmp.LastName, Email = tmp.Email };
        }

        public async Task<bool> DeleteDoctor(int id)
        {
            if ((await _context.Doctors.FirstOrDefaultAsync(d => d.IdDoctor == id)) == null)
            {
                return false;
            }
            _context.Doctors.Remove(await _context.Doctors.FindAsync(id));
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateDoctor(int id, DoctorRequestDto doctor)
        {
            var upDoctor = await _context.Doctors.FirstOrDefaultAsync(c => c.IdDoctor == id);
            if (upDoctor == null)
            {
                return false;
            }

            upDoctor.FirstName = doctor.FirstName;
            upDoctor.LastName = doctor.LastName;
            upDoctor.Email = doctor.Email;

            _context.Entry(upDoctor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Doctor> AddDoctor(DoctorRequestDto doctor)
        {
            var cl = new Doctor();
            cl.FirstName = doctor.FirstName;
            cl.LastName = doctor.LastName;
            cl.Email = doctor.Email;

            _context.Doctors.Add(cl);
            await _context.SaveChangesAsync();
            return cl;
        }

        public async Task<PrescriptionResponseDto> GetPrescription(int id)
        {
            if (await _context.Prescriptions.FindAsync(id) == null)
            {
                return null;
            }
            var response = await _context.Prescriptions.Where(p => p.IdPerscription == id)
                                   .Select(pwm => new PrescriptionResponseDto
                                   {
                                       Patient = new PatientResponseDto
                                       {
                                           FirstName = pwm.Patient.FirstName,
                                           LastName = pwm.Patient.LastName,
                                           Birthdate = pwm.Patient.Birthdate
                                       },
                                       Doctor = new DoctorRequestDto
                                       {
                                           FirstName = pwm.Doctor.FirstName,
                                           LastName = pwm.Doctor.LastName,
                                           Email = pwm.Doctor.Email
                                       },
                                       Date = pwm.Date,
                                       DueDate = pwm.DueDate,
                                       Medicaments = pwm.Medicaments.Select(pm =>
                                           new MedicamentResponseDto
                                           {
                                               Name = pm.Medicament.Name,
                                               Type = pm.Medicament.Type,
                                               Description = pm.Medicament.Description,
                                               Dose = pm.Dose,
                                               Details = pm.Details
                                           }
                                       ).ToHashSet()
                                   }).SingleAsync();
            return response;
        }
    }
}

