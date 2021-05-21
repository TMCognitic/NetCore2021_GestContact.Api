using GestContact.Api.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace GestContact.Api.Models.Mappers
{
    internal static class DataRecord
    {
        internal static Contact ToContact(this IDataRecord dataRecord)
        {
            return new Contact()
            {
                Id = (int)dataRecord["Id"],
                LastName = (string)dataRecord["LastName"],
                FirstName = (string)dataRecord["FirstName"],
                Email = dataRecord["Email"] is DBNull ? null : (string)dataRecord["Email"],
                Phone = dataRecord["Phone"] is DBNull ? null : (string)dataRecord["Phone"],
                BirthDate = dataRecord["Birthdate"] is DBNull ? null : (DateTime?)dataRecord["Birthdate"]
            };
        }
    }
}
