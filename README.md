# 🏥 Clinic Management System

Um sistema completo de **gestão clínica** desenvolvido em **.NET 9**, com foco em **Clean Architecture**, **boas práticas de código** e **alta escalabilidade**.

O objetivo é fornecer uma base sólida para aplicações modernas, integrando **padrões de projeto**, **cache distribuído**, **integrações externas** e **observabilidade**.

---

## 🚀 Tecnologias e Conceitos Utilizados

- **.NET 9**
- **Entity Framework Core**
- **Clean Architecture / Clean Code**
- **CQRS (Command Query Responsibility Segregation)**
- **Repository Pattern**
- **Dependency Injection**
- **Caching com Redis**
- **Docker** (containerização)
- **CI/CD (GitHub Actions ou Azure DevOps)**
- **Background Services**
- *(Em breve)* Integração com **Grafana** e **Prometheus** para métricas e observabilidade
- *(Em breve)* **Autenticação e Autorização (JWT + Perfis de Acesso)**
-  Integração com **OpenAI API**
- Testes automatizados com **xUnit / NUnit**

---

## 🧩 Entidades Principais

### 🧍 Paciente
---
### 🩺 Médico
---
### 💼 Serviço
---
### 📅 Atendimento
---

## ⚙️ Funcionalidades

- CRUD completo de **Paciente**, **Médico**, **Serviço** e **Atendimento**  
- Busca de paciente por **CPF** e **Telefone**  
- Envio de **confirmação de agendamento (Email/SMS)**  
- Integração com **Google Calendar**  
- **Background Service** para notificações automáticas  
- **Gestão de anexos** (Atestado, Receita, Evolução)  
- **Perfis de Acesso**: Médico, Administrador, Recepcionista *(em desenvolvimento)*  

## 🧠 Estrutura do Projeto

/ClinicManagement
│
├── Application/        → Handlers, DTOs, CQRS, Services
├── Domain/             → Entidades e Interfaces
├── Infrastructure/     → EF Core, Repositórios, Redis Cache
├── Presentation/       → Controllers e Endpoints
├── Tests/              → Testes Unitários e de Integração
└── docker-compose.yml  → Configuração do Redis


## 📈 Próximos Passos

🔐 Autenticação e Autorização (JWT + Perfis)

📊 Integração com Prometheus e Grafana

🧠 Integração com OpenAI API (assistente inteligente)

🧪 Testes automatizados com xUnit / NUnit
