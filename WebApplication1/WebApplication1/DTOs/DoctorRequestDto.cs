using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.DTOs
{
    public class DoctorRequestDto
    {
        public DoctorRequestDto()
        {
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
