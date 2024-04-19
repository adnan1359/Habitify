using Habitify.Models;
using Microsoft.AspNetCore.Mvc;

namespace Habitify.Repository.Interface
{
    public interface IHabit
    {
        IEnumerable<Habit> Get();
        Habit Post([FromBody] Habit newHabit);
        bool Put([FromBody] Habit updatedHabit);
        bool Delete(int id);
    }
}
