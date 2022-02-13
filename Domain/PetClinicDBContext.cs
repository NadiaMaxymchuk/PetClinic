using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public  class PetClinicDBContext: DbContext
    {
        public PetClinicDBContext(DbContextOptions<PetClinicDBContext> options)
            : base(options)
        {
            Database.EnsureCreated();
            //Database.Migrate();
        }
    }
}
