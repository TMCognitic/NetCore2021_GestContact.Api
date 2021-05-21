using Cognitic.Tools.Connections.Database;
using GestContact.Api.Models.Entities;
using GestContact.Api.Models.Mappers;
using GestContact.Api.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestContact.Api.Models.Services
{
    public class ContactService : IContactRepository
    {
        private readonly IConnection _connection;

        public ContactService(IConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Contact> Get()
        {
            Command command = new Command("SELECT Id, LastName, FirstName, Email, Phone, Birthdate FROM Contact;", false);
            return _connection.ExecuteReader(command, dr => dr.ToContact());
        }

        public Contact Get(int id)
        {
            Command command = new Command("SELECT Id, LastName, FirstName, Email, Phone, Birthdate FROM Contact WHERE Id = @Id;", false);
            command.AddParameters("Id", id);
            return _connection.ExecuteReader(command, dr => dr.ToContact()).SingleOrDefault();
        }

        public IEnumerable<Contact> Get(string name)
        {
            Command command = new Command("SELECT Id, LastName, FirstName, Email, Phone, Birthdate FROM Contact WHERE LastName Like @Prefix + '%';", false);
            command.AddParameters("Prefix", name);
            return _connection.ExecuteReader(command, dr => dr.ToContact());
        }

        public void Insert(Contact contact)
        {
            Command command = new Command("INSERT INTO Contact (LastName, FirstName, Email, Phone, Birthdate) VALUES (@LastName, @FirstName, @Email, @Phone, @Birthdate);", false);
            command.AddParameters("LastName", contact.LastName);
            command.AddParameters("FirstName", contact.FirstName);
            command.AddParameters("Email", contact.Email);
            command.AddParameters("Phone", contact.Phone);
            command.AddParameters("Birthdate", contact.BirthDate);

            _connection.ExecuteNonQuery(command);

        }

        public bool Update(int id, Contact contact)
        {
            Command command = new Command("UPDATE Contact SET LastName = @LastName, FirstName = @FirstName, Email = @Email, Phone = @Phone, Birthdate = @Birthdate WHERE Id = @Id;", false);
            command.AddParameters("LastName", contact.LastName);
            command.AddParameters("FirstName", contact.FirstName);
            command.AddParameters("Email", contact.Email);
            command.AddParameters("Phone", contact.Phone);
            command.AddParameters("Birthdate", contact.BirthDate);
            command.AddParameters("Id", id);

            return _connection.ExecuteNonQuery(command) == 1;
        }

        public bool Delete(int id)
        {
            Command command = new Command("DELETE From Contact WHERE Id = @Id;", false);
            command.AddParameters("Id", id);

            return _connection.ExecuteNonQuery(command) == 1;
        }
    }
}
