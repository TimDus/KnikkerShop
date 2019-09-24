using KnikkerShop.Models.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KnikkerShop.Context.Authentication
{
    public class MSSQLUserContext : IUserPasswordStore<Account>, IUserEmailStore<Account>, IUserRoleStore<Account>
    {
        private readonly string _connectionString;
        public MSSQLUserContext(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("Development");
        }



        /// <summary>
        /// Create a user in de DB. The userId (in de database) must be set to auto increment. 
        /// The password is hashed automatically.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IdentityResult> CreateAsync(Account user, CancellationToken cancellationToken)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();

                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand("INSERT INTO [Account](naam, Password, Email) VALUES (@naam, @password, @email)", connection);
                    sqlCommand.Parameters.AddWithValue("@naam", user.Naam);
                    sqlCommand.Parameters.AddWithValue("@password", user.Password);
                    sqlCommand.Parameters.AddWithValue("@email", user.Email);
                    sqlCommand.ExecuteScalar();
                    return Task.FromResult<IdentityResult>(IdentityResult.Success);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        ///Delete the user from the database (or make the user obsolete)
        /// </summary>
        /// <param name="user"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IdentityResult> DeleteAsync(Account user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            //nothing to do.
        }


        /// <summary>
        /// Finding a user by Email in the database
        /// </summary>
        /// <param name="normalizedEmail"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<Account> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT id, naam, email FROM [Account] WHERE email=@email", connection);
                sqlCommand.Parameters.AddWithValue("@email", normalizedEmail);
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    Account user = default(Account);
                    if (sqlDataReader.Read())
                    {
                        user = new Account(Convert.ToInt32(sqlDataReader["id"].ToString()), sqlDataReader["naam"].ToString(), sqlDataReader["email"].ToString());

                    }
                    return Task.FromResult(user);
                }
            }
        }

        /// <summary>
        /// Finding a user by id in the datbase
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<Account> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            try
            {

                cancellationToken.ThrowIfCancellationRequested();

                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand("SELECT id, naam, email FROM [Account] WHERE id=@id", connection);
                    sqlCommand.Parameters.AddWithValue("@id", userId);
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        Account user = default(Account);
                        if (sqlDataReader.Read())
                        {
                            user = new Account(Convert.ToInt32(sqlDataReader["id"].ToString()), sqlDataReader["naam"].ToString(), sqlDataReader["email"].ToString());

                        }
                        return Task.FromResult(user);
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<Account> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();

                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand("SELECT id, naam, password, email FROM [Account] WHERE email=@email", connection);
                    sqlCommand.Parameters.AddWithValue("@email", normalizedUserName);
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        Account user = default(Account);
                        if (sqlDataReader.Read())
                        {
                            user = new Account(Convert.ToInt32(sqlDataReader["id"].ToString()), sqlDataReader["naam"].ToString(), sqlDataReader["email"].ToString(), sqlDataReader["password"].ToString());
                        }
                        return Task.FromResult(user);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<string> GetEmailAsync(Account user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Email);
        }

        public Task<bool> GetEmailConfirmedAsync(Account user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetNormalizedEmailAsync(Account user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.NormalizedEmail);
        }

        public Task<string> GetNormalizedUserNameAsync(Account user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.NormalizedNaam);
        }

        public Task<string> GetPasswordHashAsync(Account user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Password);
        }

        public Task<IList<string>> GetRolesAsync(Account user, CancellationToken cancellationToken)
        {
            try
            {


                cancellationToken.ThrowIfCancellationRequested();

                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand("SELECT r.[naam] FROM [Role] r INNER JOIN [AccountRole] ur ON ur.[roleId] = r.id WHERE ur.userId = @userId", connection);
                    sqlCommand.Parameters.AddWithValue("@userId", user.Id);
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        IList<string> roles = new List<string>();
                        while (sqlDataReader.Read())
                        {
                            roles.Add(sqlDataReader["Naam"].ToString());
                        }

                        return Task.FromResult(roles);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<string> GetUserIdAsync(Account user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Id.ToString());
        }

        public Task<string> GetUserNameAsync(Account user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Naam);
        }

        public Task<IList<Account>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasPasswordAsync(Account user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Password != null);
        }

        public Task<bool> IsInRoleAsync(Account user, string roleName, CancellationToken cancellationToken)
        {
            try
            {

                cancellationToken.ThrowIfCancellationRequested();

                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    SqlCommand sqlCommand = new SqlCommand("SELECT [id] FROM [Role] WHERE [naam] = @normalizedNaam", connection);
                    sqlCommand.Parameters.AddWithValue("@normalizedNaam", roleName.ToUpper());
                    int? roleId = sqlCommand.ExecuteScalar() as int?;

                    SqlCommand sqlCommandUserRole = new SqlCommand("SELECT COUNT(*) FROM [UserRole] WHERE [userId] = @userId AND [roleId] =@roleId", connection);
                    sqlCommandUserRole.Parameters.AddWithValue("@userId", user.Id);
                    sqlCommandUserRole.Parameters.AddWithValue("@roleId", roleId);

                    int? roleCount = sqlCommandUserRole.ExecuteScalar() as int?;

                    return Task.FromResult(roleCount > 0);

                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        public Task RemoveFromRoleAsync(Account user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task AddToRoleAsync(Account user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailAsync(Account user, string email, CancellationToken cancellationToken)
        {
            user.Email = email;
            return Task.FromResult(0);
        }

        public Task SetEmailConfirmedAsync(Account user, bool confirmed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedEmailAsync(Account user, string normalizedEmail, CancellationToken cancellationToken)
        {
            user.NormalizedEmail = normalizedEmail;
            return Task.FromResult(0);
        }

        public Task SetNormalizedUserNameAsync(Account user, string normalizedName, CancellationToken cancellationToken)
        {
            user.NormalizedNaam = normalizedName;
            return Task.FromResult(0);
        }

        public Task SetPasswordHashAsync(Account user, string passwordHash, CancellationToken cancellationToken)
        {
            user.Password = passwordHash;
            return Task.FromResult(0);
        }

        public Task SetUserNameAsync(Account user, string userName, CancellationToken cancellationToken)
        {
            user.Naam = userName;
            return Task.FromResult(0);
        }
        /// <summary>
        /// Update user in database
        /// </summary>
        /// <param name="user"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IdentityResult> UpdateAsync(Account user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
