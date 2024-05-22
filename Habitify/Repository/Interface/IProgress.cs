using Habitify.Models;
using Microsoft.AspNetCore.Mvc;

namespace Habitify.Repository.Interface
{
    public interface IProgress
    {
        IEnumerable<Progress> Get(int id);

        IEnumerable<Progress> GetAllProgress();

        bool Post([FromBody] Progress progress);

        int GetCompletedHabits(int habitId);

        //IEnumerable<Progress> GetCompletedHabits(Habit habit);
    }
}
