﻿using KHRMS.Core;

namespace KHRMS.Services.Interfaces
{
    public interface ICandidateService
    {
        Task<bool> CreateCandidate(Candidate candidate);
        Task<IEnumerable<Candidate>> GetAllCandidates();
        Task<Candidate> GetCandidateById(int candidateId);
        //Task<bool> UpdateCandidate(Candidate candidate);
        Task<bool> DeleteCandidate(int candidateId);
    }
}
