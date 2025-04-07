# FTP Manager MCP 📂

[![License: GPL v3](https://img.shields.io/badge/License-GPLv3-blue.svg)](https://www.gnu.org/licenses/gpl-3.0)
[![Maintenance](https://img.shields.io/badge/Maintained%3F-yes-green.svg)](https://github.com/yourusername/FtpManagerMcp/graphs/commit-activity)
[![smithery badge](https://smithery.ai/badge/@taha-ghadirian/ftpmanagermcp)](https://smithery.ai/server/@taha-ghadirian/ftpmanagermcp)

A powerful and user-friendly FTP Manager application that provides a modern interface for managing FTP file operations.

> 🤖 **AI-Powered Development**: This project is a result of vibe coding through AI prompt engineering. The entire codebase was developed by collaborating with AI, showcasing the potential of modern AI-assisted development practices.

## 🚀 Features

- 📁 Browse and manage remote FTP directories
- ⬆️ Upload files and directories
- ⬇️ Download files and directories
- 🗑️ Delete files and directories
- 📝 Create new directories
- 🔄 Recursive file operations support
- 💻 Clean and intuitive user interface

## 🚀 Usage

### Using Smithery Hosted Service (Recommended) 

1. Visit [Ftp Manager on smithery](https://smithery.ai/server/@taha-ghadirian/ftpmanagermcp)

2. Create an account or sign in

3. Connect using your preferred development environment:
   - Visual Studio Code
   - Cursor
   - Any IDE or tool with MCP integration

### Alternative: Local Installation

If you prefer running the application locally, follow these steps:

1. Make sure you have the [.NET 9.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0) installed
2. Follow the installation steps below to build and run the application

### 🛠️ Build and Run Locally

1. Clone the repository:
   
   HTTPS:
   ```bash
   git clone https://github.com/taha-ghadirian/FtpManagerMcp.git
   ```
   
   SSH:
   ```bash
   git clone git@github.com:taha-ghadirian/FtpManagerMcp.git
   ```

   Then navigate to the project directory:
   ```bash
   cd FtpManagerMcp
   ```

2. Install dependencies:
```bash
dotnet restore
```

3. Build the project:
```bash
dotnet build
```

4. Run the application in inspector:
```bash
npx @modelcontextprotocol/inspector dotnet run
```

## 🔧 Configuration

The application uses environment variables for configuration. Here are the required environment variables:

| Option | Description | Required | Default |
|----------|-------------|----------|---------|
| `ftpHost` | FTP server hostname or IP address | Yes | - |
| `ftpUsername` | FTP account username | Yes | - |
| `ftpPassword` | FTP account password | Yes | - |
| `ftpPort` | FTP server port | No | 21 |

You can set these environment variables in several ways:

1. Setting them inline when running the application:
   ```bash
   ftpHost=ftp.example.com ftpUsername=myuser ftpPassword=mypassword npx @modelcontextprotocol/inspector dotnet run
   ```

⚠️ **Security Note**: Never commit sensitive information like passwords to version control. Always use environment variables or secure secrets management for production deployments.


## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

1. Fork the project
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📝 License

This project is licensed under the GNU General Public License v3.0 - see the [LICENSE](LICENSE) file for details. This means:

- You can freely use, modify, and distribute this software
- If you modify and distribute this software, you must:
  - Make your source code available
  - License your modifications under GPL v3.0
  - Document your changes
  - Preserve the original copyright notices

## 📞 Support

If you have any questions or need support, please open an issue in the GitHub repository.

## ✨ Acknowledgments

- Thanks to all contributors who have helped shape this project
- Built with .NET and modern best practices

---

Made with ❤️ by Taha Ghadirian