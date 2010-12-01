﻿using AgileWizard.Domain.Repositories;

namespace AgileWizard.Domain.Services
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        public IUserRepository UserRepository { get; set; }

        public UserAuthenticationService(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        public bool IsMatch(string userName, string password)
        {
            var user = UserRepository.GetUserByName(userName);

            return user.Password == password;
        }
    }
}