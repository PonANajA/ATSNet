# ASTNet - Back End Assessment

## Tech Stack
- .NET 7
- ASP.NET Core Web API
- Entity Framework Core (InMemory)
- JWT Authentication
- xUnit (Unit Test)

---

## Features
### 1. GET API
- ดึงข้อมูล Employee จาก InMemory Database
- มีมากกว่า 5 columns
- Join Department
- Protected ด้วย JWT

### 2. POST API
- รับ input string คั่นด้วย comma
- แสดงเฉพาะค่าที่ซ้ำ
- เรียงตัวอักษรก่อนตัวเลข
- ตัวเลขเรียงแบบ int จากน้อยไปมาก

### 3. External API
- เรียก Free API (Public Holiday)
- แสดงผลตาม format ที่โจทย์กำหนด

---

## Authentication
1. เรียก `POST /api/auth/login`
2. นำ token ไปใส่ใน Header  
   `Authorization: Bearer {token}`

---

## How to Run
```bash
dotnet restore
dotnet build
dotnet run
