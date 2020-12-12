using API_Remember.Business.Interface;
using API_Remember.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Remember.Business
{
    public class CadastroBusiness : ICadastroBusiness
    {

        private readonly IMongoCollection<User> _users;

        public CadastroBusiness(IRememberDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _users = database.GetCollection<User>(settings.RememberCollectionName);
        }

        public List<User> Get() =>
           _users.Find(book => true).ToList();

        public User Get(string id) =>
            _users.Find<User>(user => user.Id == id).FirstOrDefault();

        public User Create(User user)
        {
            _users.InsertOne(user);
            return user;
        }

        public void Update(string id, User userIn) =>
            _users.ReplaceOne(user => user.Id == id, userIn);

        public void Remove(User userIn) =>
            _users.DeleteOne(book => book.Id == userIn.Id);

        public void Remove(string id) =>
            _users.DeleteOne(book => book.Id == id);

        public ActionResult CadastrarUsuario(User _user)
        {
            ValidarUser(_user);
            throw new NotImplementedException();
        }

        public IEnumerable<User> RetornaUsuarios()
        {
            throw new NotImplementedException();
        }

        public bool ValidarUser(User _user)
        {
            if (string.IsNullOrWhiteSpace(_user.Login))
                return false;

            return true;             
        }
    }
}
