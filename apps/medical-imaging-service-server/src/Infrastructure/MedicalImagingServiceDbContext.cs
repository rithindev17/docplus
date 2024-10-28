using MedicalImagingService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalImagingService.Infrastructure;

public class MedicalImagingServiceDbContext : DbContext
{
    public MedicalImagingServiceDbContext(DbContextOptions<MedicalImagingServiceDbContext> options)
        : base(options) { }

    public DbSet<PatientDbModel> Patients { get; set; }

    public DbSet<DiseaseDbModel> Diseases { get; set; }

    public DbSet<ResultDbModel> Results { get; set; }

    public DbSet<ScanDbModel> Scans { get; set; }

    public DbSet<UserDbModel> Users { get; set; }
}
