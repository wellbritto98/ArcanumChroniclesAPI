using Microsoft.EntityFrameworkCore;

namespace UsuariosApi.Data.Seeders;

public class ChildhoodBackgroundSeeder
{
    public void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChildhoodBackground>().HasData(
            new ChildhoodBackground
            {
                Id = 1,
                Description =
                    "Cresci nas vielas estreitas e movimentadas do polo em que nasci. Aprendi desde cedo a ser ágil, atento e a encontrar meu caminho nas situações mais desafiadoras. A vida nas ruas me ensinou a ser resiliente e a valorizar cada pequena conquista."
            },
            new ChildhoodBackground
            {
                Id = 2,
                Description =
                    "Parte da minha infância foi passada em um berço de ouro, cercado por luxo e privilégios. Isso me deu acesso a educação de elite e influências culturais diversas, mas também me ensinou sobre as responsabilidades que vêm com a riqueza e o poder."
            },
            new ChildhoodBackground
            {
                Id = 3,
                Description =
                    "Fui criado em um mosteiro mágico, onde os mistérios da magia e da sabedoria antiga eram parte do cotidiano. Essa educação única me deu uma profunda compreensão do mundo mágico e uma conexão especial com as forças arcanas."
            },
            new ChildhoodBackground
            {
                Id = 4,
                Description =
                    "Minha infância foi passada na natureza selvagem, aprendendo a linguagem dos animais e as lições das florestas. Essa conexão íntima com a natureza me deu habilidades de sobrevivência e uma percepção aguçada do mundo ao meu redor."
            },
            new ChildhoodBackground
            {
                Id = 5,
                Description =
                    "Fui criado em uma comunidade nômade, sempre viajando e explorando novas terras. Isso me ensinou a adaptabilidade, o valor da liberdade e a importância de histórias e tradições passadas de geração em geração."
            }
        );
    }
}