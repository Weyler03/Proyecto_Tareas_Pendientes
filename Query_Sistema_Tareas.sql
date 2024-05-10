CREATE DATABASE Sistema_Tareas
use Sistema_Tareas


CREATE TABLE Tareas(
Id_Tareas int identity primary key,
Nombre_Tarea varchar(100),
Estado_Tarea varchar(20)default 'No Completada'
)

	


CREATE PROCEDURE dbo.sp_insertar_tarea
@Nombre_Tarea varchar(100)

AS
BEGIN
	
	insert into Tareas(
	Nombre_Tarea)
	values
	(@Nombre_Tarea)
END
GO

CREATE PROCEDURE dbo.sp_listar_tareas


AS
BEGIN
	
	select Id_Tareas,Nombre_Tarea,Estado_Tarea from Tareas;
										
END
GO

CREATE PROCEDURE dbo.sp_editar_tareas
@Id_Tareas int,
@Nombre_Tarea varchar (100)

AS
BEGIN
	
	update Tareas set Nombre_Tarea = @Nombre_Tarea
			where Id_Tareas = @Id_Tareas;
												
END
GO

CREATE PROCEDURE dbo.sp_eliminar_tareas
@Id_Tarea int

AS
BEGIN
	
	delete from Tareas where Id_Tareas = @Id_Tarea;
												
END
GO