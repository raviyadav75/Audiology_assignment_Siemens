using JewelleryAssignmentClient.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryAssignmentClient
{
    public sealed class Account
    {
        private static Account _account;
        private UserViewModel _user;
        public UserViewModel User { get { return _user; } }
        private readonly ServiceClient _serviceClient;

        private Account()
        {
            _serviceClient = new ServiceClient();
        }

        public static Account GetObject()
        {
            if (_account == null)
            {
                _account = new Account();
                return _account;
            }
            else
                return _account;
        }

        public bool Login(string userName, string password)
        {
            LoginDTO req = new LoginDTO() { UserName = userName, password = password };
            try
            {
                Task.Run(async () => {
                    _user = await _serviceClient.PostAnonymousAsync<LoginDTO, UserViewModel>("api/Account/login", req);
                }).Wait();
            }
            catch(AggregateException ex)
            {
                foreach(var e in ex.Flatten().InnerExceptions)
                {
                    Console.WriteLine(e.Message);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            if (_user != null)
                return true;
            else
                return false;
        }
    }
}
