using InventoryWebApp.BusinessLogicLayer;
using InventoryWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryWebApp.DataAccessLayer
{
    public class UserService : IUser
    {
        private ProductDbContext context;
        private DbSet<User> userEntity;
        public UserService(ProductDbContext context)
        {
            this.context = context;
            userEntity = context.Set<User>();
        }
        public bool GetUser(User user)
        {
            return userEntity.Any(x => x.UserName == user.UserName && x.Password == user.Password);
        }
    }
}
