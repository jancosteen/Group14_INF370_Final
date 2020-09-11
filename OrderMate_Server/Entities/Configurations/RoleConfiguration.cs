﻿using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Configurations
{
   
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
            new IdentityRole
            {
              
             
                Name = "Customer",
                NormalizedName = "CUSTOMER"
            },
            new IdentityRole
            {
           
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR"
            });
        }
    }
}
