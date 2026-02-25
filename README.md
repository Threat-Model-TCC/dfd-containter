ThreatModel DFD Service

Este projeto consiste em uma API desenvolvida em .NET 10 para a gestão de Diagramas de Fluxo de Dados (DFD), com suporte à modelagem de ameaças e persistência em SQL Server.
1. Instruções para Execução do Projeto

Esta seção detalha os procedimentos necessários para inicializar o ambiente completo, incluindo o banco de dados, o script de configuração inicial e o serviço de backend.
1.1. Pré-requisitos

Para a execução deste projeto, é indispensável a instalação prévia das seguintes ferramentas:

    Docker: Motor de containerização.

    Docker Compose: Orquestrador de múltiplos containers.

    Git: Sistema de controle de versão.

1.2. Procedimento de Instalação

    Clonagem do Repositório:
    Bash

    git clone https://github.com/Threat-Model-TCC/dfd-containter.git
    cd dfd-container

    Inicialização dos Serviços:
    Certifique-se de que as portas 5000 (API) e 1445 (SQL Server) não estejam sendo utilizadas por outros processos. Na raiz do diretório, execute:
    Bash

    docker-compose up --build

    Verificação de Inicialização:
    O serviço dfd_backend possui uma dependência de integridade (healthcheck) em relação ao sqlserver. A API estará plenamente disponível para consumo assim que a mensagem Application started for exibida nos logs do console.

2. Documentação da API e Endpoints

A interface de documentação e testes da API é provida pelo Swagger (OpenAPI), permitindo a interação direta com os recursos disponíveis.

    URL de Acesso: http://localhost:5000

2.1. Endpoints de Domínio (DfdController - v1)
Método	Endpoint	Descrição
POST	/api/v1/dfd	Instancia um novo diagrama. Retorna o identificador único (ID) do objeto criado.
POST	/api/v1/dfd/child adiciona um sub diagrama a partir de um elemento processo
PUT	/api/v1/dfd/{id}/elements	Sincroniza a lista de elementos (Process, Actor, DataStore) vinculados a um DFD.
GET	/api/v1/dfd/{id}	Recupera a estrutura completa e elementos de um DFD específico.