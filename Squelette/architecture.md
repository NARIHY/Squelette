Squelette/
│
├── Controllers/               // Contrôleurs MVC
│   └── UserController.cs
│
├── Models/                    // Modèles de données
│   ├── Entities/              // Entités (tables ou objets métiers)
│   │   └── User.cs
│   ├── Enums/                 // Vos enums ici
│   │   └── UserRole.cs
│   ├── Interfaces/            // Interfaces liées aux entités ou services
│   │   ├── IUser.cs
│   │   └── IAuthenticatable.cs
│   └── DTOs/                  // Data Transfer Objects (facultatif mais recommandé)
│       └── UserDTO.cs
│
├── Views/                     // Vues (WPF, WinForms, ou .cshtml pour ASP.NET MVC)
│   └── User/
│       ├── Index.xaml/.cshtml
│       └── Details.xaml/.cshtml
│
├── Services/                  // Logique métier
│   ├── Interfaces/            // Interfaces des services
│   │   └── IUserService.cs
│   └── Implementations/
│       └── UserService.cs
│
├── Repositories/             // Gestion des données (base de données, API, etc.)
│   ├── Interfaces/
│   │   └── IUserRepository.cs
│   └── Implementations/
│       └── UserRepository.cs
│
├── Data/                      // Contexte de base de données (DbContext)
│   └── AppDbContext.cs
│
├── Helpers/                   // Fonctions utilitaires, extensions, validations
│   ├── PasswordHasher.cs
│   └── EnumHelper.cs
│
├── Mappers/                   // AutoMapper ou mappage manuel entre entités/DTOs
│   └── UserMapper.cs
│
├── Configurations/            // Configuration de l'application
│   ├── AppSettings.json
│   └── ServiceRegistration.cs
│
├── Program.cs                 // Point d’entrée
├── Startup.cs (si Web)        // Configuration des services, middlewares
└── README.md
