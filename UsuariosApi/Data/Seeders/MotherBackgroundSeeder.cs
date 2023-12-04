using Microsoft.EntityFrameworkCore;
using UsuariosApi.Models;

namespace UsuariosApi.Data.Seeders;

public class MotherBackgroundSeeder
{
    public void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MotherBackground>().HasData(
            new MotherBackground
            {
                Id = 1,
                Description =
                    "Minha mãe era uma aventureira que viajou para terras distantes, em busca de riquezas e glória. Ela me deixou com parentes quando eu era criança e nunca mais voltou. Eu a idolatrava e sempre sonhei em seguir seus passos."
            },
            new MotherBackground
            {
                Id = 2,
                Description =
                    "Minha mãe era uma soldado que serviu em uma guerra. Ela me ensinou a importância da disciplina, da coragem e da honra. Eu sempre quis ser como ela."
            },
            new MotherBackground
            {
                Id = 3,
                Description =
                    "Minha mãe era uma nobre ou um governante que me ensinou a importância da tradição, da responsabilidade e do dever. Eu sempre quis ser como ela."
            },
            new MotherBackground
            {
                Id = 4,
                Description =
                    "Minha mãe era uma artesã ou mercadora que me ensinou a importância do trabalho duro, da honestidade e da justiça. Eu sempre quis ser como ela."
            },
            new MotherBackground
            {
                Id = 5,
                Description =
                    "Minha mãe era uma criminosa que foi presa ou morta por suas ações. Eu sei que ela estava errada, mas eu também sei que ela agiu por amor."
            }
        );
    }
}