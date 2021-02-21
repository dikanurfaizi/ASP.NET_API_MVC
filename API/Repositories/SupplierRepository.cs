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
    public class SupplierRepository : ISupplierRepository
    {
        DynamicParameters parameters = new DynamicParameters();
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString);

        public int Create(Supplier supplier)
        {
            var SP_Name = "SP_InsertSupplier";
            parameters.Add("@supplierName", supplier.SupplierName);
            var Create = connection.Execute(SP_Name, parameters, commandType: CommandType.StoredProcedure);
            return Create;
        }

        public int Delete(int Id)
        {
            var SP_Name = "SP_DeleteSupplier";
            parameters.Add("@supplierId", Id);
            var Delete = connection.Execute(SP_Name, parameters, commandType: CommandType.StoredProcedure);
            return Delete;
        }

        public IEnumerable<Supplier> Get()
        {
            var SP_Name = "SP_RetrieveSupplier";
            var GetData = connection.Query<Supplier>(SP_Name, commandType: CommandType.StoredProcedure);
            return GetData;
        }

        public async Task<IEnumerable<Supplier>> Get(int Id)
        {
            var SP_Name = "SP_RetrieveSupplierById";
            parameters.Add("@supplierId", Id);
            var result = await connection.QueryAsync<Supplier>(SP_Name, parameters, commandType: CommandType.StoredProcedure);
            return result;
        }

        public int Update(Supplier supplier, int Id)
        {
            var SP_Name = "SP_UpdateSupplier";
            parameters.Add("@supplierId", Id);
            parameters.Add("@supplierName", supplier.SupplierName);
            var Update = connection.Execute(SP_Name, parameters, commandType: CommandType.StoredProcedure);
            return Update;
        }
    }
}