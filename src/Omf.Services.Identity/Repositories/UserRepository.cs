﻿using Omf.Services.Identity.Domain.Models;
using Omf.Services.Identity.Domain.Repositories;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Omf.Services.Identity.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoDatabase _database;

        public UserRepository(IMongoDatabase database)
        {
            _database = database;
        }
        public async Task AddAsync(User user) => await Collection.InsertOneAsync(user);
       

        public async Task<User> GetAsync(Guid id) => await Collection.AsQueryable().FirstOrDefaultAsync(x => x.Id == id);

        public async Task<User> GetAsync(string email) => await Collection.AsQueryable().FirstOrDefaultAsync(x => x.Email == email.ToLowerInvariant());

        private IMongoCollection<User> Collection => _database.GetCollection<User>("Users");
    }
}

