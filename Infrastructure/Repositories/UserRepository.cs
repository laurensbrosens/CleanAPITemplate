using Core.Interfaces;
using Core.Model;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        TestAPIContext ctx;
        public UserRepository(TestAPIContext ctx)
        {
            this.ctx = ctx;
        }

        async public Task<User> Add(User u)
        {
            await ctx.Users.AddAsync(u);
            await ctx.SaveChangesAsync();
            return u;
        }

        async public Task<bool> Delete(int id)
        {
            var user = await ctx.Users.Where(p => p.Id == id).FirstOrDefaultAsync();
            if (user == null) return false;
            ctx.Users.Remove(user);
            await ctx.SaveChangesAsync();
            return true;
        }

        public async Task<User> Get(string fingerprint)
        {
            var user = await ctx.Users.Where(p => p.Fingerprint == fingerprint).FirstOrDefaultAsync();
            return user;
        }

        async public Task<User> Update(User u)
        {
            ctx.Users.Update(u);
            await ctx.SaveChangesAsync();
            return u;
        }
    }
}
