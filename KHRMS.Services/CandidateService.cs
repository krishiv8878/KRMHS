using KHRMS.Core;
using KHRMS.Services.Interfaces;

namespace KHRMS.Services
{
    public class CandidateService(IUnitOfWork unitOfWork) : ICandidateService
    {
        public IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<bool> CreateCandidate(Candidate candidate)
        {
            if (candidate != null)
            {
                await _unitOfWork.Candidates.Add(candidate);

                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }
        public async Task<bool> DeleteCandidate(int candidateId)
        {
            if (candidateId > 0)
            {
                var candidateDetails = await _unitOfWork.Candidates.GetById(candidateId);
                if (candidateDetails != null)
                {
                    _unitOfWork.Candidates.Delete(candidateDetails);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }
        public async Task<IEnumerable<Candidate>> GetAllCandidates()
        {
            var candidates = await _unitOfWork.Candidates.GetAll();
            return candidates;
        }
        public async Task<Candidate> GetCandidateById(int candidateId)
        {
            if (candidateId > 0)
            {
                var candidateDetails = await _unitOfWork.Candidates.GetById(candidateId);
                if (candidateDetails != null)
                {
                    return candidateDetails;
                }
            }
            return null;
        }
        public Task<bool> UpdateCandidate(Candidate candidate)
        {
            throw new NotImplementedException();
        }
    }
}
