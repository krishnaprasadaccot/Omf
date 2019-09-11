﻿using Omf.Common.Auth;
using Omf.Common.Exceptions;
using Omf.Services.Identity.Domain.Models;
using Omf.Services.Identity.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Omf.Services.Identity.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEncrypter _encrypter;
        private readonly IJwtHandler _jwtHandler;

        public UserService(IUserRepository userRepository, IEncrypter encrypter,IJwtHandler jwtHandler)
        {
            _userRepository = userRepository;
            _encrypter = encrypter;
            _jwtHandler = jwtHandler;
        }
        public async Task<JsonWebToken> LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetAsync(email);
            if(user==null)
            {
                throw new OmfException("invalid_creadentials", $"Invalid Creadentails Entered : {email}");
            }
            if(!user.ValidatePassword(password,_encrypter))
            {
                throw new OmfException("invalid_creadentials", $"Invalid Password Entered for username: {email}");
            }
            return _jwtHandler.Create(user.Id);
        }

        public async Task RegisterAsync(string email, string password, string name)
        {
            var user = await _userRepository.GetAsync(email);
            if(user!= null)
            {
                throw new OmfException("email_in_use", $"Email:{email} is already used.");
            }
            user = new User(email, name);
            user.SetPassword(password, _encrypter);
            await _userRepository.AddAsync(user);
        }
    }
}
