using _04_Data.Data;
using _04_Data.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace _02_Services.ProductosServices
{
    public class ProductosService
    {
        private static NorthWindTuneadoDbContext _db = null;
        public ProductosService()
        {
            if (_db == null)
            {
                _db = new NorthWindTuneadoDbContext();
            }
        }

        //Index
        public IList<ProductoDto> List(int? id)
        {
            IList<Producto> productos = null;
            if (id == null || id < 1)
            {
                productos = _db.Producto
                            .Include(p => p.Categoria)
                            .Include(p => p.Proveedor)
                            .ToList();
            }
            else
            {
                productos = _db.Producto
                            .Include(p => p.Categoria)
                            .Include(p => p.Proveedor)
                            .Where(x => x.ProductID == id)
                            .ToList();
            }
            IList<ProductoDto> productoDtos = new List<ProductoDto>();
            foreach (var producto in productos)
            {
                ProductoDto productoDto = new ProductoDto(producto);
                productoDtos.Add(productoDto);
            }

            return productoDtos;
        }
        //Details
        public ProductoDto Detail(int id)
        {
            Producto producto = null;
            producto = _db.Producto
                                .Where(x => x.ProductID == id)
                                .FirstOrDefault();
            ProductoDto productoDto = new ProductoDto(producto);

            return productoDto;
        }
        //Create
        public bool Create(ProductoDto productoDto)
        {
            bool ok = false;
            try
            {
                Producto producto = new Producto();
                producto.ProductID = productoDto.ProductID;
                producto.ProductName = productoDto.ProductName;
                producto.unit = productoDto.unit;
                producto.Price = productoDto.Price;

                _db.Producto.Add(producto);
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
        public bool Edit(ProductoDto productoDto)
        {
            bool ok = false;
            try
            {
                //Buscamos el registro de la Tabla Producto que tiene el mismo id
                //que el objeto que ha creado la view
                Producto buscada = _db.Producto
                                    .Where(x => x.ProductID == productoDto.ProductID)
                                    .FirstOrDefault();
                //Le pasamos los valores del objeto que ha creado la vista:
                //buscada.ProductID = producto.ProductID;
                buscada.ProductName = productoDto.ProductName;
                buscada.unit = productoDto.unit;
                buscada.Price = productoDto.Price;

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
        public bool Delete(ProductoDto productoDto)
        {
            bool ok = false;
            try
            {
                Producto producto = _db.Producto.Where(x => x.ProductID == productoDto.ProductID).FirstOrDefault();
                _db.Producto.Remove(producto);
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
    }
}

