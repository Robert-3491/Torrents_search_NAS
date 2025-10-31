# Hello World App - React/TypeScript + C#

Simple hello world app with React/TypeScript frontend and C# backend.

## Project Structure

```
hello-world-app/
├── frontend/          # React TypeScript app
│   ├── src/
│   │   ├── App.tsx    # Main component
│   │   └── main.tsx   # Entry point
│   ├── index.html
│   ├── package.json
│   └── vite.config.ts
└── backend/           # C# API
    ├── Program.cs     # Minimal API
    └── backend.csproj
```

## Setup & Run

### Backend (C#)

```bash
cd backend
dotnet run
dotnet watch run
```

Backend will start at http://localhost:5000

### Frontend (React)

```bash
cd frontend
npm install
npm run dev
```

Frontend will start at http://localhost:3000

## How it works

1. The React frontend makes a GET request to `/api/hello`
2. The C# backend responds with a JSON message
3. The frontend displays the message

## Future Docker Setup

Both apps are ready to be containerized. You can create Dockerfiles for each when needed.
