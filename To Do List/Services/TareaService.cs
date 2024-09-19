using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using To_Do_List.Models;

namespace To_Do_List.Services
{
    public class TareaService
    {
        private readonly SQLiteConnection dbConnection;

        public TareaService()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Tareas.db3");

            dbConnection = new SQLiteConnection(dbPath);

            dbConnection.CreateTable<Tareas>();

            Tareas tarea = new Tareas();
            tarea.Nombre = "Test 1";
            tarea.Estado = "Incompleta";
            tarea.Prioridad = "1";
            this.Insert(tarea);

        }

        public List<Tareas> GetAll()
        {
            var res = dbConnection.Table<Tareas>().ToList();
            return res;
        }


        public int Insert(Tareas Tareas)
        {
            return dbConnection.Insert(Tareas);
        }

        public int Update(Tareas Tareas)
        {
            return dbConnection.Update(Tareas);
        }

        public int Delete(Tareas Tareas)
        {
            return dbConnection.Delete(Tareas);
        }
    }
}
