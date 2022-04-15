using HowToMakeItAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HowToMakeItAPI.Data;

public class StepEntityTypeConfiguration : IEntityTypeConfiguration<Step>
{
    public void Configure(EntityTypeBuilder<Step> builder)
    {
        builder.ToTable("steps");

        builder
            .Property(s => s.Id)
            .HasColumnName("id");

        builder
            .Property(s => s.StepNumber)
            .HasColumnName("step_number");

        builder
            .Property(s => s.Description)
            .HasColumnName("description")
            .HasMaxLength(60)
            .IsRequired();

        builder
            .Property(s => s.TutorialId)
            .HasColumnName("tutorial_id")
            .IsRequired();
    }
}