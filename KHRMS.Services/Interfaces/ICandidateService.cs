using KHRMS.Core;
using KHRMS.Core.Models;

namespace KHRMS.Services.Interfaces
{
    public interface ICandidateService
    {
        Task<bool> CreateCandidate(Candidate candidate);
        Task<IEnumerable<Candidate>> GetAllCandidates();
        Task<Candidate> GetCandidateById(int candidateId);
        Task<bool> UpdateCandidate(Candidate candidate);
        Task<bool> DeleteCandidate(long candidateId);
    }
}
