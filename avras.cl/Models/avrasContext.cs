using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace avras.cl.Models
{
    internal partial class avrasContext : DbContext
    {
        //Scaffold-DbContext "Server=mysql.avras.kinghost.net;User ID=avras;Password=avras2019;Database=avras;Persist Security Info=True" MySql.Data.EntityFrameworkCore -OutputDir Models -f
        internal avrasContext()
        {
        }

        internal avrasContext(DbContextOptions<avrasContext> options)
            : base(options)
        {
        }

        internal virtual DbSet<Aluguel> Aluguel { get; set; }
        internal virtual DbSet<Caixa> Caixa { get; set; }
        internal virtual DbSet<Cargo> Cargo { get; set; }
        internal virtual DbSet<CompraProduto> CompraProduto { get; set; }
        internal virtual DbSet<Conta> Conta { get; set; }
        internal virtual DbSet<ContaCorrente> ContaCorrente { get; set; }
        internal virtual DbSet<ControleCaixa> ControleCaixa { get; set; }
        internal virtual DbSet<Endereco> Endereco { get; set; }
        internal virtual DbSet<ItensVenda> ItensVenda { get; set; }
        internal virtual DbSet<Mandado> Mandado { get; set; }
        internal virtual DbSet<MovimentacaoCaixa> MovimentacaoCaixa { get; set; }
        internal virtual DbSet<MovimentacaoConta> MovimentacaoConta { get; set; }
        internal virtual DbSet<Pagar> Pagar { get; set; }
        internal virtual DbSet<Patrimonio> Patrimonio { get; set; }
        internal virtual DbSet<Patrocinadores> Patrocinadores { get; set; }
        internal virtual DbSet<Pendencia> Pendencia { get; set; }
        internal virtual DbSet<Pessoa> Pessoa { get; set; }
        internal virtual DbSet<Produto> Produto { get; set; }
        internal virtual DbSet<Receber> Receber { get; set; }
        internal virtual DbSet<SociedadeTempo> SociedadeTempo { get; set; }
        internal virtual DbSet<TipoAluguel> TipoAluguel { get; set; }
        internal virtual DbSet<TipoCargo> TipoCargo { get; set; }
        internal virtual DbSet<TipoConta> TipoConta { get; set; }
        internal virtual DbSet<TipoPatrimonio> TipoPatrimonio { get; set; }
        internal virtual DbSet<TipoProduto> TipoProduto { get; set; }
        internal virtual DbSet<Venda> Venda { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseMySQL("Server=mysql.avras.kinghost.net;User ID=avras;Password=avras2019;Database=avras;Persist Security Info=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Aluguel>(entity =>
            {
                entity.ToTable("aluguel", "avras");

                entity.HasIndex(e => e.PessoaId)
                    .HasName("USUARIO_ALUGUEL_idx");

                entity.HasIndex(e => e.TipoAluguelId)
                    .HasName("TIPO_ALUGUEL_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DataReserva).HasColumnName("data_reserva");

                entity.Property(e => e.DataSolicitacao)
                    .HasColumnName("data_solicitacao")
                    .HasColumnType("date");

                entity.Property(e => e.PessoaId)
                    .HasColumnName("pessoa_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TipoAluguelId)
                    .HasColumnName("tipo_aluguel_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Pessoa)
                    .WithMany(p => p.Aluguel)
                    .HasForeignKey(d => d.PessoaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("USUARIO_ALUGUEL");

                entity.HasOne(d => d.TipoAluguel)
                    .WithMany(p => p.Aluguel)
                    .HasForeignKey(d => d.TipoAluguelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TIPO_ALUGUEL");
            });

            modelBuilder.Entity<Caixa>(entity =>
            {
                entity.ToTable("caixa", "avras");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Valor)
                    .HasColumnName("valor")
                    .HasColumnType("decimal(8,2)");
            });

            modelBuilder.Entity<Cargo>(entity =>
            {
                entity.ToTable("cargo", "avras");

                entity.HasIndex(e => e.MandadoId)
                    .HasName("MANDADO_CARGO_idx");

                entity.HasIndex(e => e.PessoaId)
                    .HasName("PESSOA_CARGO_idx");

                entity.HasIndex(e => e.TipoCargoId)
                    .HasName("TIPO_CARGO_CARGO_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MandadoId)
                    .HasColumnName("mandado_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PessoaId)
                    .HasColumnName("pessoa_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TipoCargoId)
                    .HasColumnName("tipo_cargo_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Mandado)
                    .WithMany(p => p.Cargo)
                    .HasForeignKey(d => d.MandadoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MANDADO_CARGO");

                entity.HasOne(d => d.Pessoa)
                    .WithMany(p => p.Cargo)
                    .HasForeignKey(d => d.PessoaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PESSOA_CARGO");

                entity.HasOne(d => d.TipoCargo)
                    .WithMany(p => p.Cargo)
                    .HasForeignKey(d => d.TipoCargoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TIPO_CARGO_CARGO");
            });

            modelBuilder.Entity<CompraProduto>(entity =>
            {
                entity.ToTable("compra_produto", "avras");

                entity.HasIndex(e => e.ProdutoId)
                    .HasName("PRODUTO_COMPRA_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DataCompra).HasColumnName("data_compra");

                entity.Property(e => e.ProdutoId)
                    .HasColumnName("produto_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Quantidade)
                    .IsRequired()
                    .HasColumnName("quantidade")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.ValorCompra)
                    .HasColumnName("valor_compra")
                    .HasColumnType("decimal(8,2)");

                entity.HasOne(d => d.Produto)
                    .WithMany(p => p.CompraProduto)
                    .HasForeignKey(d => d.ProdutoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PRODUTO_COMPRA");
            });

            modelBuilder.Entity<Conta>(entity =>
            {
                entity.ToTable("conta", "avras");

                entity.HasIndex(e => e.ContaCorrenteId)
                    .HasName("CONTA_CORRENTE_idx");

                entity.HasIndex(e => e.TipoId)
                    .HasName("TIPO_CONTA_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ContaCorrenteId)
                    .HasColumnName("conta_corrente_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("date");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.TipoId)
                    .HasColumnName("tipo_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Valor)
                    .HasColumnName("valor")
                    .HasColumnType("decimal(8,2)");

                entity.HasOne(d => d.ContaCorrente)
                    .WithMany(p => p.Conta)
                    .HasForeignKey(d => d.ContaCorrenteId)
                    .HasConstraintName("CONTA_CORRENTE");

                entity.HasOne(d => d.Tipo)
                    .WithMany(p => p.Conta)
                    .HasForeignKey(d => d.TipoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TIPO_CONTA");
            });

            modelBuilder.Entity<ContaCorrente>(entity =>
            {
                entity.ToTable("conta_corrente", "avras");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Valor)
                    .HasColumnName("valor")
                    .HasColumnType("decimal(8,2)");
            });

            modelBuilder.Entity<ControleCaixa>(entity =>
            {
                entity.ToTable("controle_caixa", "avras");

                entity.HasIndex(e => e.CaixaId)
                    .HasName("CAIXA_ABERTURA_idx");

                entity.HasIndex(e => e.PessoaId)
                    .HasName("PESSOA_CONTROLE_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CaixaId)
                    .HasColumnName("caixa_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DataAbertura).HasColumnName("data_abertura");

                entity.Property(e => e.DataFechamento)
                    .HasColumnName("data_fechamento")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.PessoaId)
                    .HasColumnName("pessoa_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ValorAbertura)
                    .HasColumnName("valor_abertura")
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.ValorFechamento)
                    .HasColumnName("valor_fechamento")
                    .HasColumnType("decimal(8,2)")
                    .HasDefaultValueSql("NULL");

                entity.HasOne(d => d.Caixa)
                    .WithMany(p => p.ControleCaixa)
                    .HasForeignKey(d => d.CaixaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CAIXA_ABERTURA");

                entity.HasOne(d => d.Pessoa)
                    .WithMany(p => p.ControleCaixa)
                    .HasForeignKey(d => d.PessoaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PESSOA_CONTROLE");
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.HasKey(e => e.PessoaId);

                entity.ToTable("endereco", "avras");

                entity.HasIndex(e => e.PessoaId)
                    .HasName("ENDERECO_PESSOA_idx");

                entity.Property(e => e.PessoaId)
                    .HasColumnName("pessoa_id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Bairro)
                    .IsRequired()
                    .HasColumnName("bairro")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Cep)
                    .IsRequired()
                    .HasColumnName("cep")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasColumnName("cidade")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Complemento)
                    .HasColumnName("complemento")
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.Numero)
                    .HasColumnName("numero")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Rua)
                    .IsRequired()
                    .HasColumnName("rua")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.Pessoa)
                    .WithOne(p => p.Endereco)
                    .HasForeignKey<Endereco>(d => d.PessoaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ENDERECO_PESSOA");
            });

            modelBuilder.Entity<ItensVenda>(entity =>
            {
                entity.HasKey(e => new { e.ProdutoId, e.VendaId });

                entity.ToTable("itens_venda", "avras");

                entity.HasIndex(e => e.ProdutoId)
                    .HasName("fk_produto_has_venda_produto1_idx");

                entity.HasIndex(e => e.VendaId)
                    .HasName("fk_produto_has_venda_venda1_idx");

                entity.Property(e => e.ProdutoId)
                    .HasColumnName("produto_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.VendaId)
                    .HasColumnName("venda_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ProdutoValorUnitario)
                    .HasColumnName("produto_valor_unitario")
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.Quantidade)
                    .HasColumnName("quantidade")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Produto)
                    .WithMany(p => p.ItensVenda)
                    .HasForeignKey(d => d.ProdutoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_produto_has_venda_produto1");

                entity.HasOne(d => d.Venda)
                    .WithMany(p => p.ItensVenda)
                    .HasForeignKey(d => d.VendaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_produto_has_venda_venda1");
            });

            modelBuilder.Entity<Mandado>(entity =>
            {
                entity.ToTable("mandado", "avras");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DataFim)
                    .HasColumnName("data_fim")
                    .HasColumnType("date");

                entity.Property(e => e.DataInicio)
                    .HasColumnName("data_inicio")
                    .HasColumnType("date");

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.Resumo)
                    .HasColumnName("resumo")
                    .HasColumnType("tinytext")
                    .HasDefaultValueSql("NULL");
            });

            modelBuilder.Entity<MovimentacaoCaixa>(entity =>
            {
                entity.ToTable("movimentacao_caixa", "avras");

                entity.HasIndex(e => e.CaixaId)
                    .HasName("CAIXA_RETIRADA_idx");

                entity.HasIndex(e => e.CargoId)
                    .HasName("CARGO_RETIRADA_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CaixaId)
                    .HasColumnName("caixa_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CargoId)
                    .HasColumnName("cargo_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.Motivo)
                    .IsRequired()
                    .HasColumnName("motivo")
                    .HasMaxLength(160)
                    .IsUnicode(false);

                entity.Property(e => e.Valor)
                    .HasColumnName("valor")
                    .HasColumnType("decimal(8,2)");

                entity.HasOne(d => d.Caixa)
                    .WithMany(p => p.MovimentacaoCaixa)
                    .HasForeignKey(d => d.CaixaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CAIXA_RETIRADA");

                entity.HasOne(d => d.Cargo)
                    .WithMany(p => p.MovimentacaoCaixa)
                    .HasForeignKey(d => d.CargoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CARGO_RETIRADA");
            });

            modelBuilder.Entity<MovimentacaoConta>(entity =>
            {
                entity.ToTable("movimentacao_conta", "avras");

                entity.HasIndex(e => e.CargoId)
                    .HasName("CARGO_MOVIMENTACAO_idx");

                entity.HasIndex(e => e.ContaCorrenteId)
                    .HasName("MOVIMENTACAO_CONTACORRENTE_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CargoId)
                    .HasColumnName("cargo_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ContaCorrenteId)
                    .HasColumnName("conta_corrente_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.Motivo)
                    .IsRequired()
                    .HasColumnName("motivo")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Valor)
                    .HasColumnName("valor")
                    .HasColumnType("decimal(8,2)");

                entity.HasOne(d => d.Cargo)
                    .WithMany(p => p.MovimentacaoConta)
                    .HasForeignKey(d => d.CargoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CARGO_MOVIMENTACAO");

                entity.HasOne(d => d.ContaCorrente)
                    .WithMany(p => p.MovimentacaoConta)
                    .HasForeignKey(d => d.ContaCorrenteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MOVIMENTACAO_CONTACORRENTE");
            });

            modelBuilder.Entity<Pagar>(entity =>
            {
                entity.HasKey(e => e.ContaId);

                entity.ToTable("pagar", "avras");

                entity.HasIndex(e => e.ContaId)
                    .HasName("CONTA_PAGAR_idx");

                entity.Property(e => e.ContaId)
                    .HasColumnName("conta_id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.DataPagamento)
                    .HasColumnName("data_pagamento")
                    .HasColumnType("date")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.Parcelas)
                    .HasColumnName("parcelas")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ValorPago)
                    .HasColumnName("valor_pago")
                    .HasColumnType("decimal(8,2)")
                    .HasDefaultValueSql("NULL");

                entity.HasOne(d => d.Conta)
                    .WithOne(p => p.Pagar)
                    .HasForeignKey<Pagar>(d => d.ContaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTA_PAGAR");
            });

            modelBuilder.Entity<Patrimonio>(entity =>
            {
                entity.ToTable("patrimonio", "avras");

                entity.HasIndex(e => e.TipoPatrimonioId)
                    .HasName("TIPO_PATRIMONIO_ID_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Anotacao)
                    .HasColumnName("anotacao")
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.DataAquisicao)
                    .HasColumnName("data_aquisicao")
                    .HasColumnType("date")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.DataPerda)
                    .HasColumnName("data_perda")
                    .HasColumnType("date")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.Disponibilidade)
                    .HasColumnName("disponibilidade")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Quantidade)
                    .HasColumnName("quantidade")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TipoPatrimonioId)
                    .HasColumnName("tipo_patrimonio_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ValorCompra)
                    .HasColumnName("valor_compra")
                    .HasColumnType("decimal(8,2)")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.ValorPerda)
                    .HasColumnName("valor_perda")
                    .HasColumnType("decimal(8,2)")
                    .HasDefaultValueSql("NULL");

                entity.HasOne(d => d.TipoPatrimonio)
                    .WithMany(p => p.Patrimonio)
                    .HasForeignKey(d => d.TipoPatrimonioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TIPO_PATRIMONIO_ID");
            });

            modelBuilder.Entity<Patrocinadores>(entity =>
            {
                entity.ToTable("patrocinadores", "avras");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DataCadastro)
                    .HasColumnName("data_cadastro")
                    .HasColumnType("date");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Parcelas)
                    .HasColumnName("parcelas")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SrcImagem)
                    .HasColumnName("src_imagem")
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.Valor)
                    .HasColumnName("valor")
                    .HasColumnType("decimal(8,2)");
            });

            modelBuilder.Entity<Pendencia>(entity =>
            {
                entity.ToTable("pendencia", "avras");

                entity.HasIndex(e => e.CargoId)
                    .HasName("SOCIEDADE_CARGO_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CargoId)
                    .HasColumnName("cargo_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.DataDeferimento)
                    .HasColumnName("data_deferimento")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.DataSolicitacao).HasColumnName("data_solicitacao");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cargo)
                    .WithMany(p => p.Pendencia)
                    .HasForeignKey(d => d.CargoId)
                    .HasConstraintName("SOCIEDADE_CARGO");
            });

            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.ToTable("pessoa", "avras");

                entity.HasIndex(e => e.Cpf)
                    .HasName("cpf_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.PendenciaId)
                    .HasName("PENDENCIA_PESSOA");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("cpf")
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.DataNascimento)
                    .HasColumnName("data_nascimento")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Isento)
                    .HasColumnName("isento")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Jogador)
                    .HasColumnName("jogador")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Observacoes)
                    .HasColumnName("observacoes")
                    .HasMaxLength(240)
                    .IsUnicode(false)
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.PendenciaId)
                    .HasColumnName("pendencia_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("senha")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Socio)
                    .HasColumnName("socio")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasColumnName("telefone")
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.HasOne(d => d.Pendencia)
                    .WithMany(p => p.Pessoa)
                    .HasForeignKey(d => d.PendenciaId)
                    .HasConstraintName("PENDENCIA_PESSOA");
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.ToTable("produto", "avras");

                entity.HasIndex(e => e.CategoriaId)
                    .HasName("PRODUTO_CATEGORIA_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CategoriaId)
                    .HasColumnName("categoria_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Disponível)
                    .HasColumnName("disponível")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Estoque)
                    .HasColumnName("estoque")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EstoqueMinimo)
                    .HasColumnName("estoque_minimo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.ValorVenda)
                    .HasColumnName("valor_venda")
                    .HasColumnType("decimal(8,2)");

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.Produto)
                    .HasForeignKey(d => d.CategoriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PRODUTO_CATEGORIA");
            });

            modelBuilder.Entity<Receber>(entity =>
            {
                entity.HasKey(e => e.ContaId);

                entity.ToTable("receber", "avras");

                entity.HasIndex(e => e.AluguelId)
                    .HasName("ALUGUEL_RECEBER_idx");

                entity.HasIndex(e => e.ContaId)
                    .HasName("CONTA_RECEBER_idx");

                entity.HasIndex(e => e.ControleId)
                    .HasName("CONTROLE_RECEBER_idx");

                entity.HasIndex(e => e.PatrocinioId)
                    .HasName("PATROCINADOR_RECEBER_idx");

                entity.HasIndex(e => e.PessoaId)
                    .HasName("PESSOA_RECEBER_idx");

                entity.HasIndex(e => e.VendaId)
                    .HasName("VENDA_RECEBER_idx");

                entity.Property(e => e.ContaId)
                    .HasColumnName("conta_id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AluguelId)
                    .HasColumnName("aluguel_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.ControleId)
                    .HasColumnName("controle_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.DataRecebimento)
                    .HasColumnName("data_recebimento")
                    .HasColumnType("date")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.Isento)
                    .HasColumnName("isento")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.PatrocinioId)
                    .HasColumnName("patrocinio_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.PessoaId)
                    .HasColumnName("pessoa_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.ValorRecebimento)
                    .HasColumnName("valor_recebimento")
                    .HasColumnType("decimal(8,2)")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.VendaId)
                    .HasColumnName("venda_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("NULL");

                entity.HasOne(d => d.Aluguel)
                    .WithMany(p => p.Receber)
                    .HasForeignKey(d => d.AluguelId)
                    .HasConstraintName("ALUGUEL_RECEBER");

                entity.HasOne(d => d.Conta)
                    .WithOne(p => p.Receber)
                    .HasForeignKey<Receber>(d => d.ContaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTA_RECEBER");

                entity.HasOne(d => d.Controle)
                    .WithMany(p => p.Receber)
                    .HasForeignKey(d => d.ControleId)
                    .HasConstraintName("CONTROLE_RECEBER");

                entity.HasOne(d => d.Patrocinio)
                    .WithMany(p => p.Receber)
                    .HasForeignKey(d => d.PatrocinioId)
                    .HasConstraintName("PATROCINADOR_RECEBER");

                entity.HasOne(d => d.Pessoa)
                    .WithMany(p => p.Receber)
                    .HasForeignKey(d => d.PessoaId)
                    .HasConstraintName("PESSOA_RECEBER");

                entity.HasOne(d => d.Venda)
                    .WithMany(p => p.Receber)
                    .HasForeignKey(d => d.VendaId)
                    .HasConstraintName("VENDA_RECEBER");
            });

            modelBuilder.Entity<SociedadeTempo>(entity =>
            {
                entity.ToTable("sociedade_tempo", "avras");

                entity.HasIndex(e => e.PessoaId)
                    .HasName("PESSOA_SOCIEDADE_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DataFim)
                    .HasColumnName("data_fim")
                    .HasColumnType("date")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.DataInicio)
                    .HasColumnName("data_inicio")
                    .HasColumnType("date");

                entity.Property(e => e.PessoaId)
                    .HasColumnName("pessoa_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Pessoa)
                    .WithMany(p => p.SociedadeTempo)
                    .HasForeignKey(d => d.PessoaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PESSOA_SOCIEDADE");
            });

            modelBuilder.Entity<TipoAluguel>(entity =>
            {
                entity.ToTable("tipo_aluguel", "avras");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Valor)
                    .HasColumnName("valor")
                    .HasColumnType("decimal(8,2)");
            });

            modelBuilder.Entity<TipoCargo>(entity =>
            {
                entity.ToTable("tipo_cargo", "avras");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("descricao")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Permissao)
                    .IsRequired()
                    .HasColumnName("permissao")
                    .HasColumnType("int(11)"); 
            });

            modelBuilder.Entity<TipoConta>(entity =>
            {
                entity.ToTable("tipo_conta", "avras");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoPatrimonio>(entity =>
            {
                entity.ToTable("tipo_patrimonio", "avras");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(90)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoProduto>(entity =>
            {
                entity.ToTable("tipo_produto", "avras");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.SrcImagem)
                    .HasColumnName("src_imagem")
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasDefaultValueSql("NULL");
            });

            modelBuilder.Entity<Venda>(entity =>
            {
                entity.ToTable("venda", "avras");

                entity.HasIndex(e => e.CargoId)
                    .HasName("VENDA_CARGO_idx");

                entity.HasIndex(e => e.PessoaId)
                    .HasName("VENDA_PESSOA_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CargoId)
                    .HasColumnName("cargo_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DataVenda).HasColumnName("data_venda");

                entity.Property(e => e.PessoaId)
                    .HasColumnName("pessoa_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("NULL");

                entity.HasOne(d => d.Cargo)
                    .WithMany(p => p.Venda)
                    .HasForeignKey(d => d.CargoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("VENDA_CARGO");

                entity.HasOne(d => d.Pessoa)
                    .WithMany(p => p.Venda)
                    .HasForeignKey(d => d.PessoaId)
                    .HasConstraintName("VENDA_PESSOA");
            });
        }
    }
}
