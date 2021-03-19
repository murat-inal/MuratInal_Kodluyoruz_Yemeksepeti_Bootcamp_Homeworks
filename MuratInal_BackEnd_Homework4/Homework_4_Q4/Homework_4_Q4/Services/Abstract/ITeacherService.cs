using Homework_4_Q4.Core.DataAccess;
using Homework_4_Q4.Entity;

namespace Homework_4_Q4.Services
{
    public interface ITeacherService : IEntityRepository<Teacher>, IServiceRepository<Teacher>
    {
    }
}
