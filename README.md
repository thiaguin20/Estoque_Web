# Estoque Web - Marcenaria

Sistema de controle de estoque para marcenaria desenvolvido em ASP.NET MVC no Visual Studio Community 2022.

## Demonstração

<video src="assets/demo.mp4" controls muted></video>

Se o vídeo não aparecer no GitHub, acesse diretamente: [assets/demo.mp4](assets/demo.mp4).

## Funcionalidades

- Login administrativo.
- Cadastro, edição e exclusão de produtos.
- Upload de imagem do produto.
- Controle de quantidade em estoque.
- Filtro por nível de estoque: baixo, médio e alto.
- Busca de produtos por nome.
- Registro de movimentações de entrada e saída.
- Integração com banco usando Entity Framework 6.

## Tecnologias

- C#
- ASP.NET MVC
- Entity Framework 6
- PostgreSQL / Supabase
- Npgsql
- Razor Views
- Visual Studio Community 2022

## Estrutura principal

```text
Estoque/
  Controllers/
  Models/
  Views/
  Content/
```

- `ProdutoController`: fluxo de cadastro, edição, exclusão, busca e filtros.
- `EstoqueContext`: contexto do Entity Framework.
- `Produto`: entidade principal do estoque.
- `Movimentacao`: histórico de entradas e saídas.

## Como rodar

1. Abra `EstoqueSupabase.sln` no Visual Studio Community 2022.
2. Restaure os pacotes NuGet.
3. Configure a connection string `EstoqueContext`.
4. Execute o projeto com IIS Express.

## Status

Projeto funcional para controle básico de estoque, com versão preparada para PostgreSQL/Supabase.
