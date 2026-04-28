using System;

namespace lab31v7;

public interface IUserRepository
{
    User? GetById(int id);
    bool Create(User user);
    bool Update(User user);
    bool Delete(int id);
}