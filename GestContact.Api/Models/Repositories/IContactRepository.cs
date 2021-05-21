using GestContact.Api.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestContact.Api.Models.Repositories
{
    public interface IContactRepository
    {
        IEnumerable<Contact> Get();
        Contact Get(int id);
        IEnumerable<Contact> Get(string name);
        void Insert(Contact contact);
        bool Update(int id, Contact contact);
        bool Delete(int id);
    }
}
