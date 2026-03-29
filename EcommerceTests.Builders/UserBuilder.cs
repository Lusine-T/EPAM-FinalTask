using EcommerceTests.Models;

namespace EcommerceTests.Builders
{
    public class UserBuilder 
    {
        private string _email;
        private string _password;

        public UserBuilder()
        {
            _email = "test@qabrains.com";
            _password = "Password123";
        }

        public UserBuilder WithEmail(string email)
        {
            _email = email;
            return this;
        }

        public UserBuilder WithPassword(string password)
        {
            _password = password;
            return this;
        }

        public UserBuilder WithValidCredentials()
        {
            _email = "test@qabrains.com";
            _password = "Password123";
            return this;
        }

        public UserBuilder WithInvalidCredentials()
        {
            _email = "wrong@example.com";
            _password = "wronggggGGG12@";
            return this;
        }

        public UserBuilder WithInvalidPassword()
        {
            _password = "wrongpassword";
            return this;
        }

        public UserBuilder WithEmptyEmail()
        {
            _email = "";
            return this;
        }

        public UserBuilder WithEmptyPassword()
        {
            _password = "";
            return this;
        }

        public User Build()
        {
            return new User
            {
                Email = _email,
                Password = _password
            };
        }
    }
}