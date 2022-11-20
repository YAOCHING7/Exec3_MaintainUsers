using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace iSpan.Utility
{
	public class SqlParameterBuilder
	{

		//public SqlParameter Insert()
		//{
		//}
		private List<SqlParameter> parameters = new List<SqlParameter>();
		public SqlParameterBuilder AddNvarchar(string name, int length, string value)
		{
			SqlParameter param = new SqlParameter(name, SqlDbType.NVarChar, length) { Value = value};
			parameters.Add(param);
			return this;
		}
		public SqlParameterBuilder AddInt(string name, int value)
		{
			SqlParameter param = new SqlParameter(name, SqlDbType.Int) { Value = value };
			parameters.Add(param);
			return this;
		}
		public SqlParameterBuilder AddDateTime(string name, DateTime value)
		{
			SqlParameter param = new SqlParameter(name, SqlDbType.DateTime) { Value = value};
			parameters.Add(param);
			return this;
		}
		public SqlParameter[] Build()
		{
			return parameters.ToArray();
		}
	}
}
