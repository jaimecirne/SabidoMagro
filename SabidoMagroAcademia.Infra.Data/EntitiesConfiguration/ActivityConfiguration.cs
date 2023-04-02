using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SabidoMagroAcademia.Domain.Entities;

namespace SabidoMagroAcademia.Infra.Data.EntitiesConfiguration
{
    class ActivityConfiguration : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Label).HasMaxLength(250).IsRequired();

            builder.HasData(
                new Activity(1, "Agachamento com barra"),
                new Activity(2, "Agachamento com halteres"),
                new Activity(3, "Agachamento com kettlebell"),
                new Activity(4, "Agachamento isométrico"),
                new Activity(5, "Levantamento terra com barra"),
                new Activity(6, "Levantamento terra com halteres"),
                new Activity(7, "Puxada de peso com barra"),
                new Activity(8, "Puxada de peso com halteres"),
                new Activity(9, "Remada alta com barra"),
                new Activity(10, "Remada alta com halteres"),
                new Activity(11, "Remada baixa com barra"),
                new Activity(12, "Remada baixa com halteres"),
                new Activity(13, "Flexão de braço tradicional"),
                new Activity(14, "Flexão de braço em diamante"),
                new Activity(15, "Flexão de braço com as mãos afastadas"),
                new Activity(16, "Flexão de braço em plyo"),
                new Activity(17, "Flexão de braço com uma mão"),
                new Activity(18, "Abdominal tradicional"),
                new Activity(19, "Abdominal inverso"),
                new Activity(20, "Abdominal oblíquo"),
                new Activity(21, "Prancha tradicional"),
                new Activity(22, "Prancha lateral"),
                new Activity(23, "Prancha com elevação de perna"),
                new Activity(24, "Prancha com rotação do tronco"),
                new Activity(25, "Burpee tradicional"),
                new Activity(26, "Burpee com elevação de perna"),
                new Activity(27, "Burpee com flexão de braço"),
                new Activity(28, "Burpee com salto"),
                new Activity(29, "Corrida na esteira"),
                new Activity(30, "Caminhada na esteira com inclinação"),
                new Activity(31, "Ciclismo na bicicleta ergométrica"),
                new Activity(32, "Remo na máquina de remo"),
                new Activity(33, "Escalada na máquina de escalada"),
                new Activity(34, "Step na plataforma"),
                new Activity(35, "Jumping Jacks"),
                new Activity(36, "Jump Squats"),
                new Activity(37, "Lunge tradicional"),
                new Activity(38, "Lunge com salto"),
                new Activity(39, "Lunge lateral"),
                new Activity(40, "Flexão plantar na máquina"),
                new Activity(41, "Stiff com barra"),
                new Activity(42, "Stiff com halteres"),
                new Activity(43, "Cadeira extensora"),
                new Activity(44, "Cadeira flexora"),
                new Activity(45, "Leg Press"),
                new Activity(46, "Agachamento sumô"),
                new Activity(47, "Agachamento com salto"),
                new Activity(48, "Elevação de panturrilha com barra"),
                new Activity(49, "Elevação de panturrilha com halteres"),
                new Activity(50, "Elevação posterior"),
                new Activity(51, "Abdução de quadril na máquina"),
                new Activity(52, "Adição de quadril na máquina"),
                new Activity(53, "Flexão de perna na máquina"),
                new Activity(54, "Extensão de perna na máquina"),
                new Activity(55, "Rosca direta com barra"),
                new Activity(56, "Rosca direta com halteres"),
                new Activity(57, "Rosca inversa com barra"),
                new Activity(58, "Rosca inversa com halteres"),
                new Activity(59, "Rosca concentrada com halteres"),
                new Activity(60, "Tríceps na barra paralela"),
                new Activity(61, "Tríceps com halteres"),
                new Activity(62, "Tríceps com corda"),
                new Activity(63, "Flexão de antebraço com barra"),
                new Activity(64, "Flexão de antebraço com halteres"),
                new Activity(65, "Flexão de antebraço com corda"),
                new Activity(66, "Remada alta com barra T"),
                new Activity(67, "Remada alta com halteres T"),
                new Activity(68, "Remada curvada com barra"),
                new Activity(69, "Remada curvada com halteres"),
                new Activity(70, "Desenvolvimento com barra"),
                new Activity(71, "Desenvolvimento com halteres"),
                new Activity(72, "Elevação lateral com halteres"),
                new Activity(73, "Elevação frontal com halteres"),
                new Activity(74, "Elevação frontal com barra")
            );


        }
    }
}