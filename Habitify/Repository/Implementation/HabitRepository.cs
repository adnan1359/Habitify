using Habitify.Models;
using Habitify.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Habitify.Repository.Implementation
{
    public class HabitRepository : IHabit
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Habit> Get()
        {
            throw new NotImplementedException();
        }

        public Habit Post([FromBody] Habit newHabit)
        {
            throw new NotImplementedException();
        }

        public Habit Put([FromBody] Habit updatedHabit)
        {
            throw new NotImplementedException();
        }
    }
}
