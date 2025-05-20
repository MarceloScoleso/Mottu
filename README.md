🏍️ API de Gestão de Movimentação de Motos

🔍 Descrição
Esta é uma API RESTful desenvolvida para gerenciar a movimentação de motos em estacionamentos.
O sistema permite o controle eficiente de vagas, operadores, sensores e histórico de movimentações, facilitando a administração e automatizando processos.

Com esta API você pode:

Registrar entrada e saída de motos

Gerenciar sensores vinculados às motos

Consultar movimentações por operador

Controlar vagas de estacionamento

🛠️ Tecnologias Utilizadas
.NET 8 / C#

ASP.NET Core Web API

Entity Framework Core

Oracle SQL

Swagger (OpenAPI) para documentação interativa

Docker

Azure CLI (para deploy em nuvem)

🚀 Rotas Principais da API

Movimentação
Método	Rota	Descrição
GET	/api/Movimentacao	Lista todas movimentações
POST	/api/Movimentacao	Cria nova movimentação
GET	/api/Movimentacao/{id}	Busca movimentação por ID
PUT	/api/Movimentacao/{id}	Atualiza movimentação por ID
DELETE	/api/Movimentacao/{id}	Deleta movimentação por ID
GET	/api/Movimentacao/por-operador/{idOperador}	Lista movimentações por operador

Sensor
Método	Rota	Descrição
GET	/api/Sensor	Lista todos sensores
POST	/api/Sensor	Cria novo sensor
GET	/api/Sensor/{id}	Busca sensor por ID
PUT	/api/Sensor/{id}	Atualiza sensor por ID
DELETE	/api/Sensor/{id}	Deleta sensor por ID

Outras entidades como Moto, Operador e Vaga possuem rotas CRUD similares.

⚙️ Instalação Local

Pré-requisitos
.NET 8 SDK

Oracle SQL

Visual Studio 2022 ou VS Code

Passos para executar localmente

# 1. Clone o repositório
git clone https://github.com/seu-usuario/seu-repositorio.git
cd seu-repositorio

# 2. Configure a connection string no appsettings.json

# 3. Rode as migrations
dotnet ef database update

# 4. Execute o projeto
dotnet run
Documentação Interativa (Swagger)
Acesse em:
📄 https://localhost:5000/swagger/index.html

☁️ Deploy com Docker e Azure CLI

Esta seção descreve como provisionar uma VM Linux na Azure, instalar o Docker e fazer o deploy da API como container.

🔧 Variáveis de Ambiente

RESOURCE_GROUP="mottu-api-rg"
LOCATION="eastus"
VM_NAME="mottu-api-vm"
IMAGE="Ubuntu2204"
ADMIN_USER="azureuser"

📦 Criar Grupo de Recursos

az group create --name $RESOURCE_GROUP --location $LOCATION

🖥️ Criar Máquina Virtual

az vm create \
  --resource-group $RESOURCE_GROUP \
  --name $VM_NAME \
  --image $IMAGE \
  --admin-username $ADMIN_USER \
  --generate-ssh-keys \
  --size Standard_B1s
🔓 Abrir Portas (HTTP e API)

# Porta da API
az vm open-port --port 8080 --resource-group $RESOURCE_GROUP --name $VM_NAME

# Porta HTTP padrão
az vm open-port \
  --port 80 \
  --resource-group $RESOURCE_GROUP \
  --name $VM_NAME \
  --priority 1010
  
🔐 Conectar na VM

ssh azureuser@<ip-publico-da-vm>

🐳 Instalar e Habilitar Docker

sudo apt update
sudo apt install -y docker.io
sudo systemctl start docker
sudo systemctl enable docker

🛠️ Build e Execução do Container

# Build da imagem
docker build -t api-mottu .

# Rodar o container
docker run -d -p 8080:8080 --name api-mottu-container --restart unless-stopped api-mottu

❌ Remover Grupo de Recursos (deleta a VM junto)

az group delete --name mottu-api-rg

📬 Contato

Caso tenha dúvidas ou sugestões, entre em contato com a equipe de desenvolvimento ou abra uma issue no repositório.
