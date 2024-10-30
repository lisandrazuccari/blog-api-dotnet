# Blog API

A RESTful API for managing blog posts built with ASP.NET Core 8.0 and Entity Framework Core.

## 🚀 Features

- CRUD operations for blog posts
- Entity Framework Core with SQL Server
- Swagger documentation
- Automated database migrations
- Error handling and logging
- Clean architecture principles

## 🛠️ Technologies

- ASP.NET Core 8.0
- Entity Framework Core 8.0
- SQL Server
- Swagger/OpenAPI
- C# 12

## 📋 Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download)
- SQL Server (LocalDB or higher)
- Visual Studio 2022 or VS Code

## ⚙️ Installation

1. Clone the repository
```bash
git clone https://github.com/lisandrazuccari/blog-api-dotnet.git
```

2. Navigate to the project directory
```bash
cd blog-api-dotnet
```

3. Install dependencies
```bash
dotnet restore
```

4. Update database
```bash
dotnet ef database update
```

5. Run the application
```bash
dotnet run
```

The API will be available at `http://localhost:5000`

## 🔄 API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET    | /api/blogposts | Get all posts |
| GET    | /api/blogposts/{id} | Get post by ID |
| POST   | /api/blogposts | Create new post |
| PUT    | /api/blogposts/{id} | Update post |
| DELETE | /api/blogposts/{id} | Delete post |

## 📝 Usage Example

```bash
# Create a new post
curl -L -X POST "http://localhost:5000/api/blogposts" \
     -H "Content-Type: application/json" \
     -d "{\"title\":\"Hello World\",\"content\":\"First post!\"}"
```

## 🧪 Running Tests

```bash
dotnet test
```

## 📈 Future Improvements

- [ ] Add authentication and authorization
- [ ] Implement caching
- [ ] Add comment functionality
- [ ] Add user management
- [ ] Add file upload support

## 👥 Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](https://github.com/lisandrazuccari/blog-api-dotnet/blob/8700f3a5333fa9de361074d3273bc253aca57744/LICENCE.md) file for details

## 📧 Contact

Lisandra Zuccari - lisandrazuccari@gmail.com