using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoAviao.Dominio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAviao.Data.Mapping
{
    public class AviaoMap : IEntityTypeConfiguration<Aviao>
    {
        public void Configure(EntityTypeBuilder<Aviao> builder)
        {
            builder.ToTable("tb_Aviao");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Aviacao)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(a => a.Tipo)
               .IsRequired()
               .HasMaxLength(30);

            builder.Property(a => a.Origem)
               .IsRequired()
               .HasMaxLength(80);

            builder.Property(a => a.Conexao)
               .IsRequired()
               .HasMaxLength(80);

            builder.Property(a => a.Destino)
               .IsRequired()
               .HasMaxLength(80);


        }
    }
}
