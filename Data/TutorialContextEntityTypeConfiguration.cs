using HowToMakeItAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HowToMakeItAPI.Data;

public class TutorialEntityTypeConfiguration : IEntityTypeConfiguration<Tutorial>
{
    public void Configure(EntityTypeBuilder<Tutorial> builder)
    {
        builder
            .ToTable("tutorials")
            .HasMany(t => t.StepByStep);

        builder
            .Property(t => t.Id)
            .HasColumnName("id");

        builder
            .Property(t => t.TutorialName)
            .HasColumnName("tutorial_name")
            .HasMaxLength(60);
    }
}