﻿using domain.models.workspace;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCore.configs;


public class WorkspaceConfiguration : IEntityTypeConfiguration<Workspace>
{
    public void Configure(EntityTypeBuilder<Workspace> builder)
    {
        // * Many-to-Many: Workspace to Users (Contacts)
        builder.
            HasMany(w => w.Contacts)
            .WithMany()
            .UsingEntity(j => j.ToTable("WorkspaceContacts"));
    }
}