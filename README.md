# ✅ Todo API

Uma API RESTful desenvolvida em **.NET 8**, utilizando **Entity Framework Core** e **PostgreSQL** como banco de dados.  
O projeto implementa um CRUD completo da entidade **Todo** e consultas específicas filtrando por **data**, **status** e **título**.

---

## 🧱 Tecnologias Utilizadas

- [.NET 8](https://dotnet.microsoft.com/)
- [Entity Framework Core](https://learn.microsoft.com/ef/)
- [PostgreSQL](https://www.postgresql.org/)
- [Swagger / OpenAPI](https://swagger.io/)
- [C#](https://learn.microsoft.com/dotnet/csharp/)

---

## 📦 Estrutura do Projeto

TodoApi/
├── Data/
│ ├── AppDbContext.cs
│ └── Migrations/
├── Models/
│ ├── Todo.cs
│ ├── Enums/
│ │ └── TodoStatus.cs
├── Properties/
│ └── launchSettings.json
├── appsettings.json
├── Program.cs
└── TodoApi.csproj

---

## 🧩 Entidade Todo

| Campo        | Tipo           | Descrição                          |
|---------------|----------------|------------------------------------|
| `id`          | `int`          | Identificador único                |
| `title`       | `string`       | Título da tarefa                   |
| `description` | `string`       | Descrição da tarefa                |
| `date`        | `DateTime`     | Data para realização da tarefa     |
| `status`      | `TodoStatus`   | Enum representando o status atual  |

### Enum `TodoStatus`
```csharp
public enum TodoStatus
{
    Pending,
    InProgress,
    Completed
}
```
## 🚀 Executando o Projeto

Restaure as dependências:
```
dotnet restore

Execute a aplicação:
dotnet run

Acesse o Swagger UI:
http://localhost:5000/swagger

```

## 📚 Endpoints Principais
Método	Endpoint	Descrição
GET	/api/todos	Lista todas as tarefas
GET	/api/todos/{id}	Busca uma tarefa por ID
POST	/api/todos	Cria uma nova tarefa
PUT	/api/todos/{id}	Atualiza uma tarefa existente
DELETE	/api/todos/{id}	Exclui uma tarefa
GET	/api/todos/search?date=&status=&title=	Busca por filtros (data, status e título)

## 🧔 Autor

Alansidney Júnior
💻 Projeto desenvolvido para aprendizado de .NET + PostgreSQL + EF Core
