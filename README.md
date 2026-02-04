🛠️ Como Rodar o Projeto

Esta seção descreve os passos necessários para subir o ambiente completo (Banco de Dados + Setup + Backend) na sua máquina.
📋 Pré-requisitos

Antes de começar, você precisará ter instalado:

    Docker

    Docker Compose

    Git

🚀 Passo a Passo

    Clone o repositório:
    Bash

    git clone https://github.com/seu-usuario/seu-repositorio.git
    cd dfd-container

    Suba os containers: Certifique-se de que não há outros serviços rodando na porta 5000 (API) ou 1445 (SQL Server). Na raiz do projeto, execute:
    Bash

    docker-compose up --build

    Aguarde a inicialização: O container dfd_backend aguardará o sqlserver ficar saudável (healthcheck) e o sql_setup criar o banco de dados dfd_db. Assim que vir a mensagem Application started no log, a API estará pronta.