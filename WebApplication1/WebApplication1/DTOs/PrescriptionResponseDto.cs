using System;
using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.DTOs
{
    public class PrescriptionResponseDto
    {
        public PrescriptionResponseDto()
        {
            Medicaments = new HashSet<MedicamentResponseDto>();
        }
        public PatientResponseDto Patient { get; set; }
        public DoctorRequestDto Doctor { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public ICollection<MedicamentResponseDto> Medicaments { get; set; }

    }
}
