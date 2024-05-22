using Habitify.Data;
using Habitify.Models;
using Habitify.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Habitify.Repository.Implementation
{
    public class ProgressRepository : IProgress
    {


        private readonly AppDbContext _context;

        public ProgressRepository(AppDbContext context)
        {
            _context = context;
        }


        public IEnumerable<Progress> Get(int id)
        {
            return _context.UserProgress.Where(p => p.HabitIdentity == id);
        }





        public IEnumerable<Progress> GetAllProgress()
        {
            return _context.UserProgress;
        }


        
        public bool Post([FromBody] Progress progress)
        {
            /*
            var IsPresent = _context.UserProgress.FirstOrDefault(
                p => DateTime.Parse(p.DateUpdated).Date.ToShortDateString() == DateTime.Parse(progress.DateUpdated).Date.ToShortDateString() && 
                p.HabitIdentity == progress.HabitIdentity);
            */

          var IsPresent = _context.UserProgress.AsEnumerable()
            .FirstOrDefault(p => DateTime.Parse(p.DateUpdated).Date.ToShortDateString() == DateTime.Parse(progress.DateUpdated).Date.ToShortDateString() &&
                p.HabitIdentity == progress.HabitIdentity);

            if (IsPresent != null)
                return false;


            _context.UserProgress.Add(progress);
            _context.SaveChanges();
            return true;
        }

        public int GetCompletedHabits(int habitId)
        {

            var completedHabits = _context.UserProgress.Where(p => p.HabitIdentity == habitId).Count();

            return completedHabits;
        }

    }
}
