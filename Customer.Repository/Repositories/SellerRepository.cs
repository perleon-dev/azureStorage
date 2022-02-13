using Customer.Domain.Aggregates.ConnectionBase;
using Customer.Domain.Aggregates.SellerAggregate;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Repository.Repositories
{
    public class SellerRepository : ISellerRepository
    {
        readonly IConnection _IConnection;

        public SellerRepository(IConnection IConnection) 
        {
            _IConnection = IConnection;
        }

        public async Task<int> Register(Seller seller)
        {
			using (var connection = new SqlConnection(_IConnection.GetConnectionString()))
			{
				await connection.OpenAsync();

				using (var sqlTransaction = connection.BeginTransaction())
				{
					try
					{
						int sqlTransactionTimeOut = 1000;
						var parameters = new DynamicParameters();

						parameters.Add("@cli_i_doc_id", seller.dni, DbType.Int32, ParameterDirection.InputOutput);
						parameters.Add("@cli_v_nombre", seller.nombre, DbType.String, ParameterDirection.Input);
						parameters.Add("@cli_v_apelllido", seller.apellido, DbType.String, ParameterDirection.Input);
						parameters.Add("@cli_d_fecha_nacimiento", seller.fnacimiento, DbType.DateTime, ParameterDirection.Input);

						var result = await connection.ExecuteAsync(@"SELLER.COD_T_SELLER_INSERT_UPDATE",
																	parameters, 
																	commandType: CommandType.StoredProcedure,
																	commandTimeout : sqlTransactionTimeOut,
																	transaction: sqlTransaction);

						sqlTransaction.Commit();
						seller.dni = parameters.Get<int>("@cli_i_doc_id");

						return seller.dni;
					}
					catch (Exception ex)
					{
						sqlTransaction.Rollback();
						throw new Exception(ex.Message);
					}
				}
				
			}
		}
    }
}
