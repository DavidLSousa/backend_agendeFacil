# Backend - AgendeFácil

Este repositório contém o backend do projeto **AgendeFácil**, responsável pelas regras de negócio e comunicação com a base de dados.

## Tecnologias

- ASP.NET Core
- PostgreSQL (via container)
- JWT Authentication
- Docker (container)

## Descrição

O backend oferece:
- APIs REST para o consumo pelo frontend
- Gerenciamento de usuários, agendamentos e serviços
- Integração com notificações por e-mail e WhatsApp
- Autenticação e autorização baseadas em tokens JWT

A aplicação é executada em container Docker, permitindo deploy rápido e escalável.

## Links

- [Imagem Frontend no Docker Hub](https://hub.docker.com/r/davidlsousa/frontend-agendefacil)
- [Imagem Backend no Docker Hub](https://hub.docker.com/r/davidlsousa/backend-agendefacil)

## Repositórios Relacionados

- [Frontend - AgendeFácil](https://github.com/DavidLSousa/frontend_agendeFacil)
- [Database - AgendeFácil](https://github.com/DavidLSousa/database_agendeFacil)
