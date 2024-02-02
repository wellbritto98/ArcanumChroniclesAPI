using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UsuariosApi.Data.Seeders;
using UsuariosApi.Models;

namespace UsuariosApi.Data
{
    public class ACDbContext : IdentityDbContext<Usuario>
    {
        public DbSet<Ability> Abilities { get; set; }
        public DbSet<ChildhoodBackground> ChildhoodBackgrounds { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyShareholder> CompanyShareholders { get; set; }
        public DbSet<FatherBackground> FatherBackgrounds { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<MotherBackground> MotherBackgrounds { get; set; }
        public DbSet<Polo> Polos { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Spell> Spells { get; set; }
        public DbSet<TypeOfMagic> TypesOfMagic { get; set; }
        public DbSet<WayOfMagic> WaysOfMagic { get; set; }
        public DbSet<WayOfMagicAbility> WayOfMagicAbilities { get; set; }
        public DbSet<WayOfMagicSpell> WayOfMagicSpells { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Name> Names { get; set; }
        public DbSet<Surname> Surnames { get; set; }


        public ACDbContext(DbContextOptions<ACDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ACDbContext).Assembly);
            
            SeedDatabase(modelBuilder);
        }
        private void SeedDatabase(ModelBuilder modelBuilder)
        {
            // Instanciando e chamando o método Seed de cada seeder
            new UsuarioSeeder().Seed(modelBuilder);
            new NameSeeder().Seed(modelBuilder);
            new SurnameSeeder().Seed(modelBuilder);
            new RegionSeeder().Seed(modelBuilder);
            new PoloSeeder().Seed(modelBuilder);
            new AbilitySeeder().Seed(modelBuilder);
            new ChildhoodBackgroundSeeder().Seed(modelBuilder);
            new FatherBackgroundSeeder().Seed(modelBuilder);
            new MotherBackgroundSeeder().Seed(modelBuilder);
            new CompanySeeder().Seed(modelBuilder);
            new LocationSeeder().Seed(modelBuilder);
            new SpellSeeder().Seed(modelBuilder);
            new TypeOfMagicSeeder().Seed(modelBuilder);
            new WayOfMagicSeeder().Seed(modelBuilder);
            new WayOfMagicAbilitySeeder().Seed(modelBuilder);
            new WayOfMagicSpellSeeder().Seed(modelBuilder);
            new CompanyShareholderSeeder().Seed(modelBuilder);
            new CharacterSeeder().Seed(modelBuilder);
 
        }
    }
}