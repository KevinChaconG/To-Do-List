﻿using Microsoft.VisualBasic;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_Do_List.Models
{
    public class Tareas
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public string Estado { get; set; }

        public string Prioridad { get; set; }

    }
}
