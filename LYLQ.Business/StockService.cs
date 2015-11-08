using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LYLQ.Business
{
    public class StockService
    {
        private InStore _instore = new InStore();
        private OutStore _outStore = new OutStore();
        private Stock _stock = new Stock();

        public void Instock(InStore inStock)
        {
            _instore.Create(inStock);

            var stock = GetStockFromInstock(inStock);
            _stock.Create(stock);
        }

        public void CancelInStock(string id)
        {
            _instore.Delete(id);

            _stock.Delete(id);
        }

        public void OutStcok(OutStore outStore, string updatedBy)
        {            
            var code = outStore.Code;
            var uintPrice = outStore.UnitPrice;
            var instores = _instore.GetByCodeUnitPrice(code, uintPrice.Value);

            foreach (var instore in instores)
            {
                if (instore.RemainNumber >= outStore.Number)
                {
                    outStore.InstoreId = instore.Id;
                    _outStore.Create(outStore);

                    instore.RemainNumber -= outStore.Number;
                    instore.RemainTotalPrice -= outStore.Number * outStore.UnitPrice.Value;
                    instore.UpdatedDate = DateTime.Now;
                    instore.UpdatedBy = updatedBy;
                    _instore.Update(instore);

                    var stock = _stock.GetByInstoreId(instore.Id);
                    stock.Number -= outStore.Number;
                    stock.TotalPrice -= outStore.Number * outStore.UnitPrice.Value;
                    stock.UpdatedDate = DateTime.Now;
                    stock.UpdatedBy = updatedBy;
                    _stock.Update(stock);

                    return;
                }
                else
                {
                    outStore.InstoreId = instore.Id;
                    var newOutStore = new OutStore();
                    newOutStore.Code = outStore.Code;
                    newOutStore.CreatedBy = updatedBy;
                    newOutStore.CreatedDate = DateTime.Now;
                    newOutStore.Department = outStore.Department;
                    newOutStore.Id = Guid.NewGuid().ToString();
                    newOutStore.InstoreId = outStore.InstoreId;
                    newOutStore.Number = instore.RemainNumber;
                    newOutStore.TotalPrice = instore.RemainTotalPrice;
                    newOutStore.UnitPrice = instore.UnitPrice;
                    newOutStore.Type = instore.Type;
                    newOutStore.UpdatedBy = updatedBy;
                    newOutStore.UpdatedDate = DateTime.Now;
                    _outStore.Create(newOutStore);

                    instore.RemainNumber = 0;
                    instore.RemainTotalPrice = 0;
                    instore.UpdatedBy = updatedBy;
                    instore.UpdatedDate = DateTime.Now;
                    _instore.Update(instore);

                    var stock = _stock.GetByInstoreId(instore.Id);
                    stock.Number = 0;
                    stock.TotalPrice = 0;
                    stock.UpdatedDate = DateTime.Now;
                    stock.UpdatedBy = updatedBy;
                    _stock.Update(stock);

                    outStore.Number -= newOutStore.Number;
                    outStore.TotalPrice -= newOutStore.TotalPrice;
                    if (outStore.Number == 0)
                    {
                        return;
                    }
                }
            }
        }

        public void CancelOutStock(OutStore outStore, string updatedBy)
        {
            //restore instore
            var instore = _instore.GetById(outStore.InstoreId);
            instore.RemainNumber += outStore.Number;
            instore.RemainTotalPrice += outStore.TotalPrice.Value;
            instore.UpdatedBy = updatedBy;
            instore.Update(instore);

            var stock = _stock.GetByInstoreId(instore.Id);
            stock.Number += outStore.Number;
            stock.TotalPrice += outStore.TotalPrice.Value;
            stock.UpdatedBy = updatedBy;
            stock.UpdatedDate = DateTime.Now;
            _stock.Update(stock);

            //delete outore 
            _outStore.Delete(outStore.Id);
        }

        public void ClearData()
        {
            _instore.Delete();
            _outStore.Delete();
            _stock.Delete();
        }

        public Task SyncInStockToStock(DateTime beginDate, DateTime endDate, string type, string code)
        {
            return new Task(() =>
            {
                var stocks = _stock.Query(beginDate, endDate, type, code);                
                if (stocks == null || stocks.Count == 0)
                {
                    var inStores = _instore.GetRemainAll();
                    if (inStores != null && inStores.Count > 0)
                    {
                        var _stocks = GetStocksFromInstocks(inStores);
                        foreach (var stock in _stocks)
                        {
                            _stock.Create(stock);
                        }
                    }
                }
            });
        }

        private Stock GetStockFromInstock(InStore instock)
        {
            var stock = new Stock()
            {
                Id = Guid.NewGuid().ToString(),
                Code = instock.Code,
                CreatedBy = instock.CreatedBy,
                CreatedDate = DateTime.Now,
                Department = instock.Department,
                InstoreId = instock.Id,
                Number = instock.RemainNumber,
                TotalPrice = instock.RemainTotalPrice,
                Type = instock.Type,
                UnitPrice = instock.UnitPrice,
                UpdatedBy = instock.UpdatedBy,
                UpdatedDate = DateTime.Now
            };
            return stock;
        }

        private List<Stock> GetStocksFromInstocks(List<InStore> inStocks)
        {
            var stocks = new List<Stock>();
            foreach (var inStock in inStocks)
            {
                stocks.Add(GetStockFromInstock(inStock));
            }
            return stocks;
        }

    }
}
