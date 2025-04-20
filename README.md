# 🚀 ClientStrive Full-Stack App

This is a **Dockerized Full-Stack Web Application** composed of:

- 🧰 **Backend**: ASP.NET Core Web API (`/ClientStrive_API`)
- 🌐 **Frontend**: Angular 18 (`/startup`)
- 🗃️ **Database**: Azure SQL Edge (via Docker)
- 🐳 **Containerization**: Docker Compose

---

## 📁 Project Structure

angular_18/
│
├── ClientStrive_API/       # .NET Core Web API backend
│   ├── Controllers/
│   ├── Models/
│   ├── QueryHandler/
│   ├── appsettings.json
│   ├── Dockerfile
│   └── …
│
├── startup/                # Angular frontend
│   ├── src/
│   ├── angular.json
│   ├── Dockerfile
│   └── …
│
├── docker-compose.yml      # Main orchestration file
└── README.md               # This file 📘

---

## ✅ Prerequisites

- [Docker Desktop](https://www.docker.com/products/docker-desktop)
- [.NET SDK 8.0+](https://dotnet.microsoft.com/)
- [Node.js (v18+)](https://nodejs.org/)
- [Angular CLI](https://angular.io/cli) (`npm install -g @angular/cli`)

---

## 🛠️ Setup & Run Locally with Docker

### 1. Clone the repository

```bash
git clone https://github.com/your-username/clientstrive-fullstack.git
cd clientstrive-fullstack

2. Start all services
docker-compose up --build

This will start:
	•	🔗 Angular frontend → http://localhost:4200
	•	🔗 .NET Core API → http://localhost:5096
	•	🔗 Azure SQL Edge DB → port 1433

3. Verify everything
	•	✅ Angular UI: http://localhost:4200
	•	✅ Swagger API: http://localhost:5096/swagger


<img width="924" alt="image" src="https://github.com/user-attachments/assets/96e86561-f4eb-42f5-be46-571ca71a5136" />

🗄️ Database Info
	•	Image: mcr.microsoft.com/azure-sql-edge:latest
	•	Volume: sqlserver_data (persistent storage)
	•	Port: 1433
	•	Login:
	•	User: sa
	•	Password: password
	•	Database: ClientStrive

Volume must be defined as:
volumes:
  sqlserver_data:
    external: true

🐳 Docker Commands Cheat Sheet

docker-compose up --build     # Build & start all services
docker-compose down           # Stop all containers
docker volume ls              # List volumes
docker volume inspect <name>  # Check which volume is in use
docker ps                     # Check running containers
docker-compose logs -f        # Follow logs







