using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace A.V.R.A.S.Models
{
    public partial class avras2019Context : DbContext
    {
        public avras2019Context()
        {
        }

        public avras2019Context(DbContextOptions<avras2019Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Aluguel> Aluguel { get; set; }
        public virtual DbSet<Caixa> Caixa { get; set; }
        public virtual DbSet<Cargo> Cargo { get; set; }
        public virtual DbSet<Conta> Conta { get; set; }
        public virtual DbSet<ContaCorrente> ContaCorrente { get; set; }
        public virtual DbSet<ControleCaixa> ControleCaixa { get; set; }
        public virtual DbSet<Endereco> Endereco { get; set; }
        public virtual DbSet<FluxoCaixa> FluxoCaixa { get; set; }
        public virtual DbSet<ItensVenda> ItensVenda { get; set; }
        public virtual DbSet<Mandado> Mandado { get; set; }
        public virtual DbSet<MensalidadeJogador> MensalidadeJogador { get; set; }
        public virtual DbSet<Pagar> Pagar { get; set; }
        public virtual DbSet<Patrimonio> Patrimonio { get; set; }
        public virtual DbSet<Patrocinadores> Patrocinadores { get; set; }
        public virtual DbSet<Pendencia> Pendencia { get; set; }
        public virtual DbSet<Pessoa> Pessoa { get; set; }
        public virtual DbSet<Produto> Produto { get; set; }
        public virtual DbSet<ProdutoCategoria> ProdutoCategoria { get; set; }
        public virtual DbSet<Receber> Receber { get; set; }
        public virtual DbSet<RetiradaCaixa> RetiradaCaixa { get; set; }
        public virtual DbSet<SociedadeTempo> SociedadeTempo { get; set; }
        public virtual DbSet<TipoAluguel> TipoAluguel { get; set; }
        public virtual DbSet<TipoConta> TipoConta { get; set; }
        public virtual DbSet<TipoPatrimonio> TipoPatrimonio { get; set; }
        public virtual DbSet<Venda> Venda { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("Server=den1.mysql4.gear.host;User ID=avras2019;Password=Nk1xG~g0-yN5;Database=avras2019;Persist Security Info=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Aluguel>(entity =>
            {
                entity.ToTable("aluguel", "avras2019");

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
                entity.ToTable("caixa", "avras2019");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Valor)
                    .HasColumnName("valor")
                    .HasColumnType("decimal(5,2)");
            });

            modelBuilder.Entity<Cargo>(entity =>
            {
                entity.ToTable("cargo", "avras2019");

                entity.HasIndex(e => e.MandadoId)
                    .HasName("MANDADO_CARGO_idx");

                entity.HasIndex(e => e.PessoaId)
                    .HasName("PESSOA_CARGO_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.MandadoId)
                    .HasColumnName("mandado_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.PessoaId)
                    .HasColumnName("pessoa_id")
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
            });

            modelBuilder.Entity<Conta>(entity =>
            {
                entity.ToTable("conta", "avras2019");

                entity.HasIndex(e => e.ContaCorrenteId)
                    .HasName("CONTA_CORRENTE_idx");

                entity.HasIndex(e => e.TipoId)
                    .HasName("TIPO_CONTA_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ContaCorrenteId)
                    .HasColumnName("conta_corrente_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("date");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(60)
                    .IsUnicode(false);

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
                    .HasColumnType("decimal(5,2)");

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
                entity.ToTable("conta_corrente", "avras2019");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Valor)
                    .HasColumnName("valor")
                    .HasColumnType("decimal(7,2)");
            });

            modelBuilder.Entity<ControleCaixa>(entity =>
            {
                entity.ToTable("controle_caixa", "avras2019");

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

                entity.Property(e => e.DataFechamento).HasColumnName("data_fechamento");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.PessoaId)
                    .HasColumnName("pessoa_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ValorAbertura)
                    .HasColumnName("valor_abertura")
                    .HasColumnType("decimal(7,2)");

                entity.Property(e => e.ValorFechamento)
                    .HasColumnName("valor_fechamento")
                    .HasColumnType("decimal(7,2)");

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

                entity.ToTable("endereco", "avras2019");

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
                    .IsUnicode(false);

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

            modelBuilder.Entity<FluxoCaixa>(entity =>
            {
                entity.ToTable("fluxo_caixa", "avras2019");

                entity.HasIndex(e => e.CaixaId)
                    .HasName("CAIXA_FLUXO_CAIXA_idx");

                entity.HasIndex(e => e.ContaId)
                    .HasName("CONTA_FLUXO_idx");

                entity.HasIndex(e => e.RetiradaCaixaId)
                    .HasName("RETIRADA_FLUXO_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CaixaId)
                    .HasColumnName("caixa_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ContaId)
                    .HasColumnName("conta_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.RetiradaCaixaId)
                    .HasColumnName("retirada_caixa_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Valor)
                    .HasColumnName("valor")
                    .HasColumnType("decimal(5,2)");

                entity.HasOne(d => d.Caixa)
                    .WithMany(p => p.FluxoCaixa)
                    .HasForeignKey(d => d.CaixaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CAIXA_FLUXO_CAIXA");

                entity.HasOne(d => d.Conta)
                    .WithMany(p => p.FluxoCaixa)
                    .HasForeignKey(d => d.ContaId)
                    .HasConstraintName("CONTA_FLUXO");

                entity.HasOne(d => d.RetiradaCaixa)
                    .WithMany(p => p.FluxoCaixa)
                    .HasForeignKey(d => d.RetiradaCaixaId)
                    .HasConstraintName("RETIRADA_FLUXO");
            });

            modelBuilder.Entity<ItensVenda>(entity =>
            {
                entity.HasKey(e => new { e.ProdutoId, e.VendaId });

                entity.ToTable("itens_venda", "avras2019");

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
                    .HasColumnType("decimal(5,2)");

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
                entity.ToTable("mandado", "avras2019");

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
                    .IsUnicode(false);

                entity.Property(e => e.Resumo)
                    .HasColumnName("resumo")
                    .HasColumnType("tinytext");
            });

            modelBuilder.Entity<MensalidadeJogador>(entity =>
            {
                entity.HasKey(e => e.Cpf);

                entity.ToTable("mensalidade_jogador", "avras2019");

                entity.Property(e => e.Cpf)
                    .HasColumnName("cpf")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Pagar>(entity =>
            {
                entity.HasKey(e => e.ContaId);

                entity.ToTable("pagar", "avras2019");

                entity.HasIndex(e => e.ContaId)
                    .HasName("CONTA_PAGAR_idx");

                entity.Property(e => e.ContaId)
                    .HasColumnName("conta_id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.DataPagamento)
                    .HasColumnName("data_pagamento")
                    .HasColumnType("date");

                entity.Property(e => e.Parcelas)
                    .HasColumnName("parcelas")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ValorPago)
                    .HasColumnName("valor_pago")
                    .HasColumnType("decimal(5,2)");

                entity.HasOne(d => d.Conta)
                    .WithOne(p => p.Pagar)
                    .HasForeignKey<Pagar>(d => d.ContaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTA_PAGAR");
            });

            modelBuilder.Entity<Patrimonio>(entity =>
            {
                entity.ToTable("patrimonio", "avras2019");

                entity.HasIndex(e => e.TipoPatrimonioId)
                    .HasName("TIPO_PATRIMONIO_ID_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Anotacao)
                    .HasColumnName("anotacao")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.DataAquisicao)
                    .HasColumnName("data_aquisicao")
                    .HasColumnType("date");

                entity.Property(e => e.DataPerda)
                    .HasColumnName("data_perda")
                    .HasColumnType("date");

                entity.Property(e => e.Descicao)
                    .HasColumnName("descicao")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Disponibilidade)
                    .HasColumnName("disponibilidade")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("1");

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
                    .HasColumnType("decimal(5,2)");

                entity.Property(e => e.ValorPerda)
                    .HasColumnName("valor_perda")
                    .HasColumnType("decimal(5,2)");

                entity.HasOne(d => d.TipoPatrimonio)
                    .WithMany(p => p.Patrimonio)
                    .HasForeignKey(d => d.TipoPatrimonioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TIPO_PATRIMONIO_ID");
            });

            modelBuilder.Entity<Patrocinadores>(entity =>
            {
                entity.ToTable("patrocinadores", "avras2019");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DataCadastro)
                    .HasColumnName("data_cadastro")
                    .HasColumnType("date");

                entity.Property(e => e.DataVencimento)
                    .HasColumnName("data_vencimento")
                    .HasColumnType("date");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Parcelas)
                    .HasColumnName("parcelas")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Valor)
                    .HasColumnName("valor")
                    .HasColumnType("decimal(5,2)");
            });

            modelBuilder.Entity<Pendencia>(entity =>
            {
                entity.ToTable("pendencia", "avras2019");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.ToTable("pessoa", "avras2019");

                entity.HasIndex(e => e.Cpf)
                    .HasName("cpf_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.PendenciaId)
                    .HasName("PESSOAPENDENCIA_idx");

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
                    .IsUnicode(false);

                entity.Property(e => e.PendenciaId)
                    .HasColumnName("pendencia_id")
                    .HasColumnType("int(11)");

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
                    .HasConstraintName("PESSOAPENDENCIA");
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.ToTable("produto", "avras2019");

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

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Quantidade)
                    .HasColumnName("quantidade")
                    .HasColumnType("int(11)");

                entity.Property(e => e.QuantidadeMinima)
                    .HasColumnName("quantidade_minima")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ValorCompra)
                    .HasColumnName("valor_compra")
                    .HasColumnType("decimal(5,2)");

                entity.Property(e => e.ValorVenda)
                    .HasColumnName("valor_venda")
                    .HasColumnType("decimal(5,2)");

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.Produto)
                    .HasForeignKey(d => d.CategoriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PRODUTO_CATEGORIA");
            });

            modelBuilder.Entity<ProdutoCategoria>(entity =>
            {
                entity.ToTable("produto_categoria", "avras2019");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Receber>(entity =>
            {
                entity.HasKey(e => e.ContaId);

                entity.ToTable("receber", "avras2019");

                entity.HasIndex(e => e.AluguelId)
                    .HasName("ALUGUEL_RECEBER_idx");

                entity.HasIndex(e => e.ContaId)
                    .HasName("CONTA_RECEBER_idx");

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
                    .HasColumnType("int(11)");

                entity.Property(e => e.DataRecebimento)
                    .HasColumnName("data_recebimento")
                    .HasColumnType("date");

                entity.Property(e => e.Isento)
                    .HasColumnName("isento")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PatrocinioId)
                    .HasColumnName("patrocinio_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PessoaId)
                    .HasColumnName("pessoa_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ValorRecebimento)
                    .HasColumnName("valor_recebimento")
                    .HasColumnType("decimal(5,2)");

                entity.Property(e => e.VendaId)
                    .HasColumnName("venda_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Aluguel)
                    .WithMany(p => p.Receber)
                    .HasForeignKey(d => d.AluguelId)
                    .HasConstraintName("ALUGUEL_RECEBER");

                entity.HasOne(d => d.Conta)
                    .WithOne(p => p.Receber)
                    .HasForeignKey<Receber>(d => d.ContaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTA_RECEBER");

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

            modelBuilder.Entity<RetiradaCaixa>(entity =>
            {
                entity.ToTable("retirada_caixa", "avras2019");

                entity.HasIndex(e => e.PessoaId)
                    .HasName("PESSOA_RETIRADA_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.Motivo)
                    .IsRequired()
                    .HasColumnName("motivo")
                    .HasMaxLength(160)
                    .IsUnicode(false);

                entity.Property(e => e.PessoaId)
                    .HasColumnName("pessoa_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Valor)
                    .HasColumnName("valor")
                    .HasColumnType("decimal(5,2)");

                entity.HasOne(d => d.Pessoa)
                    .WithMany(p => p.RetiradaCaixa)
                    .HasForeignKey(d => d.PessoaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PESSOA_RETIRADA");
            });

            modelBuilder.Entity<SociedadeTempo>(entity =>
            {
                entity.ToTable("sociedade_tempo", "avras2019");

                entity.HasIndex(e => e.PessoaId)
                    .HasName("PESSOA_SOCIEDADE_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.DataFim)
                    .HasColumnName("data_fim")
                    .HasColumnType("date");

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
                entity.ToTable("tipo_aluguel", "avras2019");

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
                    .HasColumnType("decimal(6,2)");
            });

            modelBuilder.Entity<TipoConta>(entity =>
            {
                entity.ToTable("tipo_conta", "avras2019");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoPatrimonio>(entity =>
            {
                entity.ToTable("tipo_patrimonio", "avras2019");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(90)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Venda>(entity =>
            {
                entity.ToTable("venda", "avras2019");

                entity.HasIndex(e => e.PessoaId)
                    .HasName("VENDA_PESSOA_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DataVenda).HasColumnName("data_venda");

                entity.Property(e => e.PessoaId)
                    .HasColumnName("pessoa_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SocioId)
                    .HasColumnName("socio_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Pessoa)
                    .WithMany(p => p.Venda)
                    .HasForeignKey(d => d.PessoaId)
                    .HasConstraintName("VENDA_PESSOA");
            });
        }
    }
}
