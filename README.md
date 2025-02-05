# 🏢 Multi-Schema Customer Management System

## 📌 Overview  
The **Multi-Schema Customer Management System** is a web-based application built with **ASP.NET Core Razor Pages** that enables users to manage customer data across multiple database schemas efficiently. This project consolidates customer management into a single UI, reducing complexity and improving usability.

## 🚀 Features  
✅ **Single-Page CRUD Operations** – Perform Create, Read, Update, and Delete actions dynamically.  
✅ **Schema Selection via Dropdown** – Easily switch between different database schemas.  
✅ **Dynamic Data Loading** – Uses JavaScript `fetch API` for real-time content updates.  
✅ **Partial Views for UI Optimization** – Enhances code maintainability and modularity.  
✅ **Secure API Calls** – Implements **anti-forgery tokens** to prevent CSRF attacks.  
✅ **Logging & Debugging** – Integrated logging for troubleshooting and performance monitoring.  

## 🛠️ Tech Stack  
- **Frontend:** ASP.NET Core Razor Pages, JavaScript (ES6), Bootstrap  
- **Backend:** ASP.NET Core, Entity Framework Core  
- **Database:** Microsoft SQL Server (Multiple Schemas)  
- **Version Control:** Git & GitHub  

## 📂 Project Structure  
📦 MultiSchemaCustomerManager
├── 📁 Pages
│ ├── 📁 Clients
│ │ ├── 📄 CombinedIndex.cshtml (Main UI)
│ │ ├── 📄 CombinedIndex.cshtml.cs (Code-behind logic)
│ │ ├── 📄 _CustomerTablePartial.cshtml (Partial view for table)
│ ├── 📄 _Layout.cshtml (Main layout)
│ ├── 📄 _ViewImports.cshtml
├── 📁 Models
│ ├── 📄 ClientInfo.cs
│ ├── 📄 Schema1Customer.cs
│ ├── 📄 Schema2Customer.cs
│ ├── 📄 Schema3Customer.cs
├── 📁 wwwroot
│ ├── 📁 js
│ │ ├── 📄 CombinedIndex.js (Handles dropdown & data fetching)
├── 📄 Program.cs (Application entry point)
├── 📄 appsettings.json (Database configuration)

## 📖 Installation & Setup  
### 1️⃣ Clone the Repository  
```sh
git clone https://github.com/yourusername/MultiSchemaCustomerManager.git
cd MultiSchemaCustomerManager
```
2️⃣ Configure Database Connection
Modify the appsettings.json file with your SQL Server credentials:
```sh
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=MultiSchemaDB;Integrated Security=true;"
}
```
3️⃣ Run Database Migrations (If using EF Core)
```sh
dotnet ef database update
```
4️⃣ Build & Run the Application
```sh
dotnet run
```
Then, open http://localhost:5000 in your browser.

🎯 How It Works
Select a schema from the dropdown.
The table dynamically loads customer data from the selected schema.
Perform CRUD operations on customer records without page reloads.

🐛 Debugging & Logging
Logs are available in the console output.
Enable developer mode for detailed logs:

👥 Contributing
We welcome contributions! If you’d like to improve the project:

Fork the repository.
Create a new feature branch.
Submit a pull request with detailed changes.

📜 License
This project is open-source and licensed under the MIT License.
