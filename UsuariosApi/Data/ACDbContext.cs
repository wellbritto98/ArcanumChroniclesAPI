using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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
            // Configuração de chaves compostas
            modelBuilder.Entity<CompanyShareholder>()
                .HasKey(cs => new { cs.CharacterId, cs.CompanyId });

            // Configuração de chaves compostas wayofmagicability and wayofmagicspell
            modelBuilder.Entity<WayOfMagicAbility>()
                .HasKey(wma => new { wma.WayOfMagicId, wma.AbilityId });
            modelBuilder.Entity<WayOfMagicSpell>()
                .HasKey(wms => new { wms.WayOfMagicId, wms.SpellId });

            modelBuilder.Entity<Usuario>()
                .Property(u => u.PasswordResetToken)
                .IsRequired(false);
            
                        // Seeding the Region table
                        modelBuilder.Entity<Region>().HasData(
                            new Region { Id = 1, Name = "Solária" },
                            new Region { Id = 2, Name = "Glacialis" });

                        // Seeding the Polo table
                        modelBuilder.Entity<Polo>().HasData(
                            new Polo { Id = 1, Name = "Maris", RegionId = 1 },
                            new Polo { Id = 2, Name = "Marécanto", RegionId = 1 },
                            new Polo { Id = 3, Name = "Frostland", RegionId = 2 },
                            new Polo { Id = 4, Name = "Summitia", RegionId = 2 }
                        );

                        // Seeding the ChildhoodBackground table

                        modelBuilder.Entity<ChildhoodBackground>().HasData(
                            new ChildhoodBackground { Id = 1, Description = "Cresci nas vielas estreitas e movimentadas do polo em que nasci. Aprendi desde cedo a ser ágil, atento e a encontrar meu caminho nas situações mais desafiadoras. A vida nas ruas me ensinou a ser resiliente e a valorizar cada pequena conquista." },
                            new ChildhoodBackground { Id = 2, Description = "Parte da minha infância foi passada em um berço de ouro, cercado por luxo e privilégios. Isso me deu acesso a educação de elite e influências culturais diversas, mas também me ensinou sobre as responsabilidades que vêm com a riqueza e o poder." },
                            new ChildhoodBackground { Id = 3, Description = "Fui criado em um mosteiro mágico, onde os mistérios da magia e da sabedoria antiga eram parte do cotidiano. Essa educação única me deu uma profunda compreensão do mundo mágico e uma conexão especial com as forças arcanas." },
                            new ChildhoodBackground { Id = 4, Description = "Minha infância foi passada na natureza selvagem, aprendendo a linguagem dos animais e as lições das florestas. Essa conexão íntima com a natureza me deu habilidades de sobrevivência e uma percepção aguçada do mundo ao meu redor." },
                            new ChildhoodBackground { Id = 5, Description = "Fui criado em uma comunidade nômade, sempre viajando e explorando novas terras. Isso me ensinou a adaptabilidade, o valor da liberdade e a importância de histórias e tradições passadas de geração em geração." }
                        );

                        // Seeding the FatherBackground table

                        modelBuilder.Entity<FatherBackground>().HasData(
                            new FatherBackground { Id = 1, Description = "Meu pai era um aventureiro que viajou para terras distantes, em busca de riquezas e glória. Ele me deixou com parentes quando eu era criança e nunca mais voltou. Eu o idolatrava e sempre sonhei em seguir seus passos." },
                            new FatherBackground { Id = 2, Description = "Meu pai era um soldado que serviu em uma guerra. Ele me ensinou a importância da disciplina, da coragem e da honra. Eu sempre quis ser como ele." },
                            new FatherBackground { Id = 3, Description = "Meu pai era um nobre ou um governante que me ensinou a importância da tradição, da responsabilidade e do dever. Eu sempre quis ser como ele." },
                            new FatherBackground { Id = 4, Description = "Meu pai era um artesão ou mercador que me ensinou a importância do trabalho duro, da honestidade e da justiça. Eu sempre quis ser como ele." },
                            new FatherBackground { Id = 5, Description = "Meu pai era um criminoso que foi preso ou morto por suas ações. Eu sei que ele estava errado, mas eu também sei que ele agiu por amor." }
                            );

                        // Seeding the MotherBackground table

                        modelBuilder.Entity<MotherBackground>().HasData(
                            new MotherBackground { Id = 1, Description = "Minha mãe era uma aventureira que viajou para terras distantes, em busca de riquezas e glória. Ela me deixou com parentes quando eu era criança e nunca mais voltou. Eu a idolatrava e sempre sonhei em seguir seus passos." },
                            new MotherBackground { Id = 2, Description = "Minha mãe era uma soldado que serviu em uma guerra. Ela me ensinou a importância da disciplina, da coragem e da honra. Eu sempre quis ser como ela." },
                            new MotherBackground { Id = 3, Description = "Minha mãe era uma nobre ou um governante que me ensinou a importância da tradição, da responsabilidade e do dever. Eu sempre quis ser como ela." },
                            new MotherBackground { Id = 4, Description = "Minha mãe era uma artesã ou mercadora que me ensinou a importância do trabalho duro, da honestidade e da justiça. Eu sempre quis ser como ela." },
                            new MotherBackground { Id = 5, Description = "Minha mãe era uma criminosa que foi presa ou morta por suas ações. Eu sei que ela estava errada, mas eu também sei que ela agiu por amor." }
                            );

                        // Seeding the WayOfMagic table

                        modelBuilder.Entity<WayOfMagic>().HasData(
                            new WayOfMagic { Id = 1, Name = "Arcana", Description = "arcana" },
                            new WayOfMagic { Id = 2, Name = "Divina", Description = "divina" },
                            new WayOfMagic { Id = 3, Name = "Druida", Description = "druida" },
                            new WayOfMagic { Id = 4, Name = "Feiticeiro", Description = "feiticeiro" }

                            );

                        // Seeding the TypeOfMagic table

                        modelBuilder.Entity<TypeOfMagic>().HasData(
                            new TypeOfMagic { Id = 1, Name = "Não-magico", Description = "Não-magico" },
                            new TypeOfMagic { Id = 2, Name = "Magico", Description= "Magico" },
                            new TypeOfMagic { Id = 3, Name = "Mestiço", Description="Mestiço" }
                            );

                        // Seeding the Ability table

                        modelBuilder.Entity<Ability>().HasData(
                            new Ability { Id = 1, Name = "Natação", Description = "Nadar" },
                            new Ability { Id = 2, Name = "Corrida", Description = "Correr" },
                            new Ability { Id = 3, Name = "Luta", Description = "Lutar" },
                            new Ability { Id = 4, Name = "Escalada", Description = "Escalar" },
                            new Ability { Id = 5, Name = "Pulo", Description = "Pular" }


                            );

                        // Seeding the Company table
                        modelBuilder.Entity<Company>().HasData(
                            new Company { Id = 1, Name = "Ministério de Solária", PoloId = 1, Type = CompanyType.Ministry, Money = 1000000 }
                            );



                        // Seeding the Location table

                        modelBuilder.Entity<Location>().HasData(
                            new Location { Id = 1, Name = "Ministério de Solária", PoloId = 1, CompanyId = 1 }
                            );

                        // Seeding the Spell table

                        modelBuilder.Entity<Spell>().HasData(
                                new Spell { Id = 1, Name = "Bola de Fogo", Description = "Uma bola de fogo é atirada em uma criatura ou objeto dentro do alcance do feitiço. Faça um ataque à distância com magia contra o alvo. Se atingir, o alvo sofre 1d10 de dano de fogo. Um objeto inflamável atingido pelo feitiço é incendiado. Este feitiço causa dano extra quando você atinge um alvo com mais de um slot de feitiço. No 5º nível, o dano aumenta para 2d10; 11º nível, 3d10; e 17º nível, 4d10. " }
                                );


                        // Seeding the WayOfMagicAbility table

                        modelBuilder.Entity<WayOfMagicAbility>().HasData(
                            new WayOfMagicAbility { WayOfMagicId = 1, AbilityId = 1 },
                            new WayOfMagicAbility { WayOfMagicId = 1, AbilityId = 2 },
                            new WayOfMagicAbility { WayOfMagicId = 1, AbilityId = 3 },
                            new WayOfMagicAbility { WayOfMagicId = 1, AbilityId = 4 },
                            new WayOfMagicAbility { WayOfMagicId = 1, AbilityId = 5 },
                            new WayOfMagicAbility { WayOfMagicId = 2, AbilityId = 1 },
                            new WayOfMagicAbility { WayOfMagicId = 2, AbilityId = 2 },
                            new WayOfMagicAbility { WayOfMagicId = 2, AbilityId = 3 },
                            new WayOfMagicAbility { WayOfMagicId = 2, AbilityId = 4 },
                            new WayOfMagicAbility { WayOfMagicId = 2, AbilityId = 5 },
                            new WayOfMagicAbility { WayOfMagicId = 3, AbilityId = 1 },
                            new WayOfMagicAbility { WayOfMagicId = 3, AbilityId = 2 },
                            new WayOfMagicAbility { WayOfMagicId = 3, AbilityId = 3 },
                            new WayOfMagicAbility { WayOfMagicId = 3, AbilityId = 4 },
                            new WayOfMagicAbility { WayOfMagicId = 3, AbilityId = 5 },
                            new WayOfMagicAbility { WayOfMagicId = 4, AbilityId = 1 },
                            new WayOfMagicAbility { WayOfMagicId = 4, AbilityId = 2 },
                            new WayOfMagicAbility { WayOfMagicId = 4, AbilityId = 3 },
                            new WayOfMagicAbility { WayOfMagicId = 4, AbilityId = 4 },
                            new WayOfMagicAbility { WayOfMagicId = 4, AbilityId = 5 }
                            );

                        // Seeding the WayOfMagicSpell table

                        modelBuilder.Entity<WayOfMagicSpell>().HasData(
                            new WayOfMagicSpell { WayOfMagicId = 1, SpellId = 1 },
                            new WayOfMagicSpell { WayOfMagicId = 2, SpellId = 1 },
                            new WayOfMagicSpell { WayOfMagicId = 3, SpellId = 1 },
                            new WayOfMagicSpell { WayOfMagicId = 4, SpellId = 1 }
                            );

                        //Seeding the Character table

                        modelBuilder.Entity<Character>().HasData(
                            new Character
                            {
                                Id= 1,
                                Name = "Admilson",
                                Surname = "Silva",
                                UsuarioId = "6f028247-bf27-4ab5-93a8-87931b58944a",
                                FatherBackgroundId = 1,
                                MotherBackgroundId = 1,
                                ChildhoodBackgroundId = 1,
                                Gender = Enums.GenderEnum.Male,
                                BirthDate = DateTime.UtcNow,
                                BirthPoloId = 1,
                                CurrentLocationId = 1,
                                CharacterAvatarUrl = "https://img.freepik.com/fotos-gratis/homem-bonito-posando-e-sorrindo_23-2149396133.jpg",
                                WayOfMagicId = 1,
                                TypeOfMagicId = 1
                            });

                        // Seeding the CompanyShareholder table

                        modelBuilder.Entity<CompanyShareholder>().HasData(
                            new CompanyShareholder { CharacterId = 1, CompanyId = 1, Shares = 100 }
                            );
                        
                        
        }


    }
}
