using cw6.Models;
using cw6.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cw6.Services
{
    public interface IDbService
    {
        Task<IEnumerable<SomeSortOfDoctor>> GetDoctors();
        bool AddDoctor(Doctor doctor);
        bool EditDoctor(int idDoctor,Doctor doctor);
        bool DeleteDoctor(int idDoctor);
        Task<IEnumerable<SomeSortOfAll>> GetPrescription(int idPrescription);

    }
}
