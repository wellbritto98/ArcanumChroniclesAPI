using Microsoft.EntityFrameworkCore;

namespace UsuariosApi.Data.Seeders;

public class SpellSeeder
{
    public void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Spell>().HasData(
            new Spell
            {
                Id = 1, Name = "Bola de Fogo",
                Description =
                    "Uma bola de fogo é atirada em uma criatura ou objeto dentro do alcance do feitiço. Faça um ataque à distância com magia contra o alvo. Se atingir, o alvo sofre 1d10 de dano de fogo. Um objeto inflamável atingido pelo feitiço é incendiado. Este feitiço causa dano extra quando você atinge um alvo com mais de um slot de feitiço. No 5º nível, o dano aumenta para 2d10; 11º nível, 3d10; e 17º nível, 4d10. "
            }
        );
    }
}