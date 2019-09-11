using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Omf.Common.Mongo
{
    public interface IDatabaseSeeder
    {
        Task SeedAsync();
    }
}
