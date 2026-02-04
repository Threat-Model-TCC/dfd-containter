🛠️ Como Rodar o Projeto

Esta seção descreve os passos necessários para subir o ambiente completo (Banco de Dados + Setup + Backend) na sua máquina.
📋 Pré-requisitos

Antes de começar, você precisará ter instalado:

    Docker

    Docker Compose

    Git

🚀 Passo a Passo

Clone o repositório:

    git clone https://github.com/seu-usuario/seu-repositorio.git
    cd dfd-container

Suba os containers: Certifique-se de que não há outros serviços rodando na porta 5000 (API) ou 1445 (SQL Server). Na raiz do projeto, execute:

    docker-compose up --build

    Aguarde a inicialização: O container dfd_backend aguardará o sqlserver ficar saudável (healthcheck) e o sql_setup criar o banco de dados dfd_db. Assim que vir a mensagem Application started no log, a API estará pronta.
_______________________________________________

📖 Como Usar os Endpoints (Swagger)

A API utiliza Swagger (OpenAPI) para documentação e testes rápidos. Com os containers rodando, você pode acessar a interface visual para interagir com os endpoints.

🔗 URL do Swagger: http://localhost:5000
📌 Endpoints Principais

Abaixo estão os endpoints disponíveis no DfdController (Versão v1):
Método	Endpoint	Descrição
POST	/api/v1/dfd	Cria um novo diagrama. Retorna o ID do objeto criado.
PUT	/api/v1/dfd/{id}/elements	Sincroniza (cria ou atualiza) a lista de elementos (Process, Actor, DataStore) de um DFD.
GET	/api/v1/dfd/{id}	Retorna todos os elementos e detalhes de um DFD específico.
💡 Exemplo de Uso (Sincronização de Elementos)

Para adicionar ou atualizar elementos em um DFD, utilize o método PUT. O sistema utiliza herança TPT (Table-Per-Type) para persistir corretamente cada tipo de elemento.

Payload de exemplo (PUT /api/v1/dfd/1/elements):
JSON

[
  {
    "id": 0,
    "name": "Processo de Autenticação",
    "type": "Process",
    "xValue": 120.5,
    "yValue": 200.0,
    "width": 100,
    "height": 50
  },
  {
    "id": 0,
    "name": "Banco de Dados de Usuários",
    "type": "DataStore",
    "xValue": 400.0,
    "yValue": 200.0,
    "width": 100,
    "height": 50
  }
]

    Nota: Enviar o id: 0 indica a criação de um novo elemento. Se enviar um id existente, o sistema realizará o update dos dados na tabela correspondente.