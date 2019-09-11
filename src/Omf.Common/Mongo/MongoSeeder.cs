﻿using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omf.Common.Mongo
{
    public class MongoSeeder : IDatabaseSeeder
    {
        protected readonly IMongoDatabase Database;
        public MongoSeeder(IMongoDatabase db)
        {
            Database = db;
        }
        public async Task SeedAsync()
        {
            var collectionCursor = await Database.ListCollectionsAsync();
            var collections = await collectionCursor.ToListAsync();
            if(collections.Any())
            {
                return;
            }
            await CustomSeedAsync();
        }
        protected virtual async Task CustomSeedAsync()
        {
            await Task.CompletedTask;
        }
    }
}
