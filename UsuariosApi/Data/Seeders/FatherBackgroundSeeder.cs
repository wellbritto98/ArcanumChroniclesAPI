using Microsoft.EntityFrameworkCore;
using UsuariosApi.Models;

namespace UsuariosApi.Data.Seeders;

public class FatherBackgroundSeeder
{
    public void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FatherBackground>().HasData(
            new FatherBackground
            {
                Id = 1,
                Description =
                    "Meu pai era um aventureiro que viajou para terras distantes, em busca de riquezas e glória. Ele me deixou com parentes quando eu era criança e nunca mais voltou. Eu o idolatrava e sempre sonhei em seguir seus passos."
            },
            new FatherBackground
            {
                Id = 2,
                Description =
                    "Meu pai era um soldado que serviu em uma guerra. Ele me ensinou a importância da disciplina, da coragem e da honra. Eu sempre quis ser como ele."
            },
            new FatherBackground
            {
                Id = 3,
                Description =
                    "Meu pai era um nobre ou um governante que me ensinou a importância da tradição, da responsabilidade e do dever. Eu sempre quis ser como ele."
            },
            new FatherBackground
            {
                Id = 4,
                Description =
                    "Meu pai era um artesão ou mercador que me ensinou a importância do trabalho duro, da honestidade e da justiça. Eu sempre quis ser como ele."
            },
            new FatherBackground
            {
                Id = 5,
                Description =
                    "Meu pai era um criminoso que foi preso ou morto por suas ações. Eu sei que ele estava errado, mas eu também sei que ele agiu por amor."
            }
        );
    }
}