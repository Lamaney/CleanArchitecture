﻿using System.Reflection;
using Microsoft.EntityFrameworkCore;
using RpgMerchant.Application.Common.Interfaces;

namespace RpgMerchant.Infrastructure.EntityFrameworkCore;

public class MerchantDbContext:DbContext,IMerchantDbContext
{
  
    public MerchantDbContext(DbContextOptions<MerchantDbContext> options):base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MerchantDbContext).Assembly);
    }
}