using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using SaleSystemAPI.Data;
using SaleSystemAPI.Models;
using SaleSystemAPI.Repositories.Interfaces;

namespace SaleSystemAPI.Repositories.Classes
{
    public class SaleRepository : GenericRepository<SaleModel>, ISaleRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public SaleRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<SaleModel> GetSaleByIdAsync(int id)
        {
            var sale = await _dbContext.Sales
            .Include(s => s.SaleItemModel)
            .ThenInclude(si => si.ProductModel)
            .FirstOrDefaultAsync(s => s.Id == id);

            return sale;
        }

        public async Task<List<int>> GetSaleItemIdAsync(int id)
        {
            var sale = await _dbContext.Sales.Include(s => s.SaleItemModel).FirstOrDefaultAsync(s => s.Id == id);


            return sale.SaleItemModel.Select(item => item.Id).ToList();
        }

        public async Task<SaleModel> UpdateSale(int id, SaleModel saleModel)
        {
            var existingSale = await _dbContext.Sales
                .Include(s => s.SaleItemModel)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (existingSale == null)
            {
                throw new KeyNotFoundException("Sale not found.");
            }

            // Actualizar los campos principales de la venta
            existingSale.ClientId = saleModel.ClientId;
            existingSale.Date = saleModel.Date;
            existingSale.Total = saleModel.Total;

            // Eliminar los SaleItemModel existentes que no están en el DTO
            var existingItemIds = existingSale.SaleItemModel.Select(si => si.Id).ToList();
            var updatedItemIds = saleModel.SaleItemModel.Select(si => si.Id).ToList();

            var itemsToRemove = existingSale.SaleItemModel
                .Where(si => !updatedItemIds.Contains(si.Id))
                .ToList();

            _dbContext.SalesItems.RemoveRange(itemsToRemove);

            // Actualizar o agregar SaleItemModel
            foreach (var item in saleModel.SaleItemModel)
            {
                if (item.Id == 0) // Si el ID es 0, es un nuevo ítem
                {
                    _dbContext.SalesItems.Add(item);
                }
                else // Actualiza los ítems existentes
                {
                    var existingItem = existingSale.SaleItemModel.FirstOrDefault(si => si.Id == item.Id);
                    if (existingItem != null)
                    {
                        existingItem.ProductId = item.ProductId;
                        existingItem.Quantity = item.Quantity;
                        existingItem.PricePerUnit = item.PricePerUnit;
                        existingItem.TotalPrice = item.TotalPrice;
                    }
                }
            }

            await _dbContext.SaveChangesAsync();

            return existingSale;
        }
    }
}

