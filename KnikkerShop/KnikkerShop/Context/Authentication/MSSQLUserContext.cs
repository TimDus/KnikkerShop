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
    public class MSSQLUserContext : IUserStore<Account>, IUserPasswordStore<Account>, IUserEmailStore<Account>, IUserRoleStore<Account>
    {
        private readonly string _connectionString;
        public MSSQLUserContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
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
                    SqlCommand sqlCommand = new SqlCommand("INSERT INTO [Account](username, email, password, RoleId) OUTPUT INSERTED.ID VALUES (@username,@email,@password, 1)", connection);
                    sqlCommand.Parameters.AddWithValue("@username", user.UserName);
                    sqlCommand.Parameters.AddWithValue("@email", user.Email);
                    sqlCommand.Parameters.AddWithValue("@password", user.Password);
                    user.Id = Convert.ToInt32(sqlCommand.ExecuteScalar());
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
                SqlCommand sqlCommand = new SqlCommand("SELECT id, username, email FROM [Account] WHERE email=@email", connection);
                sqlCommand.Parameters.AddWithValue("@email", normalizedEmail);
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    Account user = default(Account);
                    if (sqlDataReader.Read())
                    {
                        user = new Account(Convert.ToInt32(sqlDataReader["id"].ToString()), sqlDataReader["username"].ToString(), sqlDataReader["email"].ToString());

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
                    SqlCommand sqlCommand = new SqlCommand("SELECT id, username, email FROM [Account] WHERE id=@id", connection);
                    sqlCommand.Parameters.AddWithValue("@id", userId);
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        Account user = default(Account);
                        if (sqlDataReader.Read())
                        {
                            user = new Account(Convert.ToInt32(sqlDataReader["id"].ToString()), sqlDataReader["username"].ToString(), sqlDataReader["email"].ToString());

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

        public Task<Account> FindByNameAsync(string normalizedAccountName, CancellationToken cancellationToken)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();

                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand("SELECT id, username, email, password FROM [Account] WHERE email=@email", connection);
                    sqlCommand.Parameters.AddWithValue("@email", normalizedAccountName);
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        Account user = default(Account);
                        if (sqlDataReader.Read())
                        {
                            user = new Account(Convert.ToInt32(sqlDataReader["id"].ToString()), sqlDataReader["username"].ToString(), sqlDataReader["email"].ToString(), sqlDataReader["password"].ToString());
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
            return Task.FromResult(user.NormalizedUserName);
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
                    SqlCommand sqlCommand = new SqlCommand("SELECT r.[naam] FROM [Role] r INNER JOIN [Account] ur ON ur.[roleId] = r.id WHERE ur. Id = @userId", connection);
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
            return Task.FromResult(user.UserName);
        }

        public Task<IList<Account>> GetAccountsInRoleAsync(string roleName, CancellationToken cancellationToken)
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

                    SqlCommand sqlCommand = new SqlCommand("SELECT [id] FROM [Role] WHERE [name] = @normalizedName", connection);
                    sqlCommand.Parameters.AddWithValue("@normalizedName", roleName.ToUpper());
                    int? roleId = sqlCommand.ExecuteScalar() as int?;

                    SqlCommand sqlCommandAccountRole = new SqlCommand("SELECT COUNT(*) FROM [AccountRole] WHERE [userId] = @userId AND [roleId] =@roleId", connection);
                    sqlCommandAccountRole.Parameters.AddWithValue("@userId", user.Id);
                    sqlCommandAccountRole.Parameters.AddWithValue("@roleId", roleId);

                    int? roleCount = sqlCommandAccountRole.ExecuteScalar() as int?;

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

        public Task SetNormalizedAccountNameAsync(Account user, string normalizedName, CancellationToken cancellationToken)
        {
            user.NormalizedUserName = normalizedName;
            return Task.FromResult(0);
        }

        public Task SetPasswordHashAsync(Account user, string passwordHash, CancellationToken cancellationToken)
        {
            user.Password = passwordHash;
            return Task.FromResult(0);
        }

        public Task SetAccountNameAsync(Account user, string userName, CancellationToken cancellationToken)
        {
            user.UserName = userName;
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

        public Task<IList<Account>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetUserNameAsync(Account user, string userName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedUserNameAsync(Account user, string normalizedName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
