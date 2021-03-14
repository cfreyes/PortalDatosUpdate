using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDatos.BL

{
    public class ClientesBL
    {
        Contexto _contexto;
      public List<Cliente> ListasdeClientes { get; set; }

        public ClientesBL()
        {
            _contexto = new Contexto();
            ListasdeClientes = new List<Cliente>();
        }

        public List<Cliente> ObtenerClientes()
        {
            ListasdeClientes = _contexto.Clientes
                .OrderBy(r => r.Nombre)
                .ToList();

            return ListasdeClientes;
        }

        public List<Cliente> ObtenerClientesActivos();
        {
               ListadeClientes = _contexto.Clientes
                .Where(r => r.Activo == true)
                .OrderBy(r => r.Nombre)
                .ToList(); 

                return ListasdeClientes;
            }
        }

        public void GuardarCliente(Cliente cliente)
        {
            if (cliente.Id == 0)
            {
                _contexto.Clientes.Add(cliente);
            }
            else
            {
                var clienteExistente = _contexto.Clientes.Find(cliente.Id);

                clienteExistente.Nombre = cliente.Nombre;
                clienteExistente.Telefono = cliente.Telefono;
                clienteExistente.Direccion = cliente.Direccion;
                clienteExistente.Activo = cliente.Activo;
            }

            _contexto.SaveChanges();
        }

        public Cliente ObtenerCliente(int id)
        {
            var cliente = _contexto.Clientes.Find(id);

            return cliente;
        }

        public void EliminarCliente(int id)
        {
            var cliente = _contexto.Clientes.Find(id);

            _contexto.Clientes.Remove(cliente);
            _contexto.SaveChanges();
        }
    }
}
