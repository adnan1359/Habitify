using Habitify.Data;
using Habitify.Models;
using Habitify.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Habitify.Repository.Implementation
{
    public class HabitRepository : IHabit
    {

        private readonly AppDbContext _context;

        public HabitRepository(AppDbContext context)
        {
            _context = context;
        }



        public bool Delete(int id)
        {
            Habit? habitToDelete = _context.Habits.FirstOrDefault(h => h.HabitId == id);

            if (habitToDelete == null)
                return false;

            _context.Habits.Remove(habitToDelete);
            _context.SaveChanges();
            return true;
        }




        public IEnumerable<Habit> Get()
        {
            return _context.Habits;
        }



        public Habit Post([FromBody] Habit newHabit)
        {

            Habit? IsPresent = _context.Habits.FirstOrDefault(h => h.HabitName == newHabit.HabitName);

            if (IsPresent != null)
                return new Habit();

            _context.Habits.Add(newHabit);
            _context.SaveChanges();
            return newHabit;
        }




        public bool Put([FromBody] Habit updatedHabit)
        {
            Habit? IsPresent = _context.Habits.FirstOrDefault(h => h.HabitId == updatedHabit.HabitId);

            if (IsPresent == null)
                return false;

            IsPresent.HabitName = updatedHabit.HabitName;
            _context.SaveChanges();
            return true;
        }
    }
}
