﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UNIπPapers.Models;

namespace UNIπPapers.Data
{
    public class UNIπPapersContext : IdentityDbContext
    {
        public UNIπPapersContext (DbContextOptions<UNIπPapersContext> options)
            : base(options)
        {
        }

        public DbSet<UNIπPapers.Models.Paper> Paper { get; set; } = default!;
        public DbSet<UNIπPapers.Models.Customer> Customer { get; set; }
    }
}
