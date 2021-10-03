﻿using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IApplicationRepository
    {
        public Task<SendApplication> GetByIdAsync(int id);
        public Task<List<SendApplication>> GetAllAsync();
    }
}
