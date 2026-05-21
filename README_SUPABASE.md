# EstoqueSupabase

Versao duplicada do projeto Estoque preparada para usar Supabase/PostgreSQL.

## O que muda em relacao ao projeto local

- O projeto original em `C:\Estoque` continua sendo o plano B com LocalDB.
- Esta copia em `C:\EstoqueSupabase` usa o provider `Npgsql` no `Web.config`.
- O Entity Framework 6 continua sendo usado pelos controllers.
- As migrations SQL Server nao sao executadas automaticamente nesta copia.
- A classe `SupabaseSchemaInitializer` cria as tabelas PostgreSQL esperadas pelo EF6 quando a aplicacao inicia.

## Arquivos principais

- `Estoque/Web.config`: connection string Supabase e provider Npgsql.
- `Estoque/Helpers/SupabaseSchemaInitializer.cs`: cria `Produtoes`, `Movimentacaos` e `Usuarios` no Supabase.
- `supabase-schema.sql`: script equivalente para executar manualmente no SQL Editor do Supabase se preferir.
- `EstoqueSupabase.sln`: solution separada para abrir esta versao no Visual Studio.

## Azure

No Azure App Service, configure a connection string `EstoqueContext` como `Custom` ou `PostgreSQL` com a connection string do Supabase. Isso evita depender do valor salvo no `Web.config`.

Se a conexao direta do Supabase falhar no Azure, use a connection string do Session Pooler exibida no painel do Supabase.
