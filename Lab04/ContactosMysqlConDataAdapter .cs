using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Lab04
{
    class ContactosMysqlConDataAdapter:Contactos
    {
        protected string connectionString
        {
            get
            {
                return "server=localhost;database=net;uid=root;";
            }
        }

        MySqlDataAdapter adapater = new MySqlDataAdapter();

        public ContactosMysqlConDataAdapter(): base()
        {
           
            adapater.InsertCommand = new MySqlCommand(
                "insert into contactos values(@id,@nombre,@apellido,@email,@telefono)");
            adapater.InsertCommand.Parameters.Add("@id", MySqlDbType.Int32, 1, "id");
            adapater.InsertCommand.Parameters.Add("@nombre", MySqlDbType.VarChar, 20, "nombre");
            adapater.InsertCommand.Parameters.Add("@apellido", MySqlDbType.VarChar, 20, "apellido");
            adapater.InsertCommand.Parameters.Add("@email", MySqlDbType.VarChar, 50, "email");
            adapater.InsertCommand.Parameters.Add("@telefono", MySqlDbType.VarChar, 10, "telefono");

            adapater.UpdateCommand = new MySqlCommand(
                "update contactos set nombre=@nombre, apellido=@apellido, email=@email,telefono=@telefono " +
                " where id=@id");
            adapater.UpdateCommand.Parameters.Add("@id", MySqlDbType.Int32, 1, "id");
            adapater.UpdateCommand.Parameters.Add("@nombre", MySqlDbType.VarChar, 20, "nombre");
            adapater.UpdateCommand.Parameters.Add("@apellido", MySqlDbType.VarChar, 20, "apellido");
            adapater.UpdateCommand.Parameters.Add("@email", MySqlDbType.VarChar, 50, "email");
            adapater.UpdateCommand.Parameters.Add("@telefono", MySqlDbType.VarChar, 10, "telefono");

            adapater.DeleteCommand = new MySqlCommand("delete from contactos where id=@id");
            adapater.DeleteCommand.Parameters.Add("@id", MySqlDbType.Int32, 1, "id");
        }

        public override DataTable getTabla()
        {
            adapater = new MySqlDataAdapter("select * from contactos", this.connectionString);
            DataTable contactos = new DataTable();
            adapater.Fill(contactos);
            return contactos;
        }

        public override void aplicaCambios()
        {
            using (MySqlConnection Conn = new MySqlConnection(this.connectionString))
            {
                adapater.InsertCommand.Connection = Conn;
                adapater.UpdateCommand.Connection = Conn;
                adapater.DeleteCommand.Connection = Conn;
                adapater.Update(this.misContactos);
            }
        }

    }
}
