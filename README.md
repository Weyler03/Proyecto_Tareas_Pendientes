# Sistema de Gestión de Tareas

Este es un proyecto de sistema de gestión de tareas desarrollado en C# utilizando ASP.NET Core para el backend y HTML, CSS y JavaScript para el frontend.

## Requisitos

- Visual Studio 2019 (o superior, yo utilice el 2022)
- SQL Server (o SQL Server Express)

## Configuración

1. Clonar este repositorio en tu máquina local.
2. Abrir el proyecto en Visual Studio.

### Backend

1. Asegurarse de tener una instancia de SQL Server disponible.
2. Abrir el archivo `appsettings.json` en el proyecto `SistemaTareas.API`.
3. Configurar la cadena de conexión en la sección `ConnectionStrings` con los detalles de tu base de datos.

### Frontend

No se requiere configuración adicional para el frontend.

## Ejecución

1. Compilar y ejecutar el proyecto desde Visual Studio.
2. El servidor backend estará disponible en `http://localhost:5050`.
3. Acceder al frontend desde un navegador web en `http://localhost:{puerto_frontend}`.

## Uso

- El sistema permite crear, editar, completar y eliminar tareas.
- La página de inicio muestra la lista de tareas existentes y proporciona opciones para interactuar con ellas.
