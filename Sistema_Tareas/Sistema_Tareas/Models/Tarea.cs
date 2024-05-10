using System;
using System.Collections.Generic;

namespace Sistema_Tareas.Models;

public partial class Tarea
{
    public int IdTareas { get; set; }

    public string? NombreTarea { get; set; }

    public string? EstadoTarea { get; set; }
}
