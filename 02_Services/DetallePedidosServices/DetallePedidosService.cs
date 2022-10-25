using _04_Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using _04_Data.ViewModels;
using _02_Services.ProductosServices;
using _02_Services.PedidosServices;
using _02_Services.NavierasServices;
using _04_Data.Dtos;

namespace _02_Services.DetallePedidosServices
{
    public class DetallePedidosService
    {
        private static NorthWindTuneadoDbContext _db = null;
        public DetallePedidosService()
        {
            if (_db == null)
            {
                _db = new NorthWindTuneadoDbContext();
            }
        }

        //Index
        public IList<DetallePedidoDto> List(int? id, string madre)
        {
            IList<DetallePedido> detallePedidos = null;
            if (id == null || id < 1)
            {
                detallePedidos = _db.DetallePedido
                            .Include(p => p.Producto)
                            .Include(p => p.Pedido)
                            .ToList();
            }
            else
            {
                if (madre != null && madre != "")
                {
                    if (madre == "Pedido")
                    {
                        detallePedidos = _db.DetallePedido
                                    .Include(p => p.Producto)
                                    .Include(p => p.Pedido)
                                    .Where(x => x.OrderID == id)
                                    .ToList();
                    }
                    if (madre == "Producto")
                    {
                        detallePedidos = _db.DetallePedido
                                    .Include(p => p.Producto)
                                    .Include(p => p.Pedido)
                                    .Where(x => x.ProductID == id)
                                    .ToList();
                    }
                }
            }
            IList<DetallePedidoDto> detallePedidoDtos = new List<DetallePedidoDto>();
            foreach (var detallePedido in detallePedidos)
            {
                DetallePedidoDto detallePedidoDto = new DetallePedidoDto(detallePedido);
            }

            return detallePedidoDtos;
        }
        //Details
        public DetallePedidoDto Detail(int id)
        {
            DetallePedido detallePedido = null;
            detallePedido = _db.DetallePedido
                                .Where(x => x.OrderDetailID == id)
                                .FirstOrDefault();
            DetallePedidoDto detallePedidoDto = new DetallePedidoDto(detallePedido);
            return detallePedidoDto;
        }
        //Create
        public bool Create(DetallePedidoDto detallePedidoDto)
        {
            bool ok = false;
            try
            {
                DetallePedido detallePedido = new DetallePedido();
                detallePedido.OrderDetailID = detallePedido.OrderDetailID;
                detallePedido.OrderID = detallePedido.OrderID;
                detallePedido.ProductID = detallePedido.ProductID;
                detallePedido.Quantity = detallePedido.Quantity;
                _db.DetallePedido.Add(detallePedido);
                ok = SaveChanges();
            }
            catch (Exception e)
            {
                //Log
                //throw;
            }

            return ok;
        }
        //Edit
        public bool Edit(DetallePedidoDto detallePedidoDto)
        {
            bool ok = false;
            try
            {
                //Buscamos el registro de la Tabla DetallePedido que tiene el mismo id
                //que el objeto que ha creado la view
                DetallePedido buscada = _db.DetallePedido
                                    .Where(x => x.OrderDetailID == detallePedidoDto.OrderDetailID)
                                    .FirstOrDefault();
                //Le pasamos los valores del objeto que ha creado la vista:
                //buscada.OrderDetailID = detallePedido.OrderDetailID;
                buscada.OrderID = detallePedidoDto.OrderID;
                buscada.ProductID = detallePedidoDto.ProductID;
                buscada.Quantity = detallePedidoDto.Quantity;

        //Guardamos cambios:
        ok = SaveChanges();
            }
            catch (Exception e)
            {
                //Log
                //throw;
            }

            return ok;
        }
        //Delete
        public bool Delete(DetallePedidoDto detallePedidoDto)
        {
            bool ok = false;
            try
            {
                DetallePedido detallePedido = _db.DetallePedido.Where(x => x.OrderDetailID == detallePedidoDto.OrderDetailID).FirstOrDefault();
                _db.DetallePedido.Remove(detallePedido);
                //Guardamos cambios:
                ok = SaveChanges();
            }
            catch (Exception e)
            {
                //Log
                //throw;
            }

            return ok;
        }
        //SaveChanges
        public bool SaveChanges()
        {
            bool ok = false;
            try
            {
                int retorno = 0;
                retorno = _db.SaveChanges();
                if (retorno > 0)
                {
                    ok = true;
                }
            }
            catch (Exception e)
            {
                //Log
                //throw;
            }

            return ok;
        }
        //Dispose
        public bool Dispose(bool ok)
        {
            if (ok == true)
            {
                _db.Dispose();
            }

            return ok;
        }
        //Creamos y Rellenamos el ViewModel
        
    }
}

