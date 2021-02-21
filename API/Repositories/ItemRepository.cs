using API.Models;
using API.Repositories.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace API.Repositories
{
    public class ItemRepository : IItemRepository
    {
        DynamicParameters parameters = new DynamicParameters();
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString);
        public int Create(Item item)
        {
            var SP_Name = "SP_InsertItem";
            parameters.Add("@itemName", item.ItemName);
            parameters.Add("@quantity", item.Quantity);
            parameters.Add("@price", item.Price);
            parameters.Add("@supplierId", item.SupplierId);
            var Create = connection.Execute(SP_Name, parameters, commandType: CommandType.StoredProcedure);
            return Create;
        }

        public int Delete(int ItemId)
        {
            var SP_Name = "SP_DeleteItem";
            parameters.Add("@itemId", ItemId);
            var Delete = connection.Execute(SP_Name, parameters, commandType: CommandType.StoredProcedure);
            return Delete;
        }

        public IEnumerable<ViewModel> Get()
        {
            var SP_Name = "SP_RetrieveItem";
            var GetData = connection.Query<ViewModel>(SP_Name, commandType: CommandType.StoredProcedure);
            return GetData;
        }

        public async Task<IEnumerable<ViewModel>> Get(int ItemId)
        {
            var SP_Name = "SP_RetrieveItemById";
            parameters.Add("@itemId", ItemId);
            var GetData = await connection.QueryAsync<ViewModel>(SP_Name, parameters, commandType: CommandType.StoredProcedure);
            return GetData;
        }

        public int Update(Item item, int ItemId)
        {
            var SP_Name = "SP_UpdateItem";
            parameters.Add("@itemId", ItemId);
            parameters.Add("@itemName", item.ItemName);
            parameters.Add("@quantity", item.Quantity);
            parameters.Add("@price", item.Price);
            parameters.Add("@supplierId", item.SupplierId);
            var GetData = connection.Execute(SP_Name, parameters, commandType: CommandType.StoredProcedure);
            return GetData;
        }
    }
}