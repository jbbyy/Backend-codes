using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    //Repository class is used to implement all Data access operations
    public class ReminderRepository : IReminderRepository
    {
        private readonly KeepDbContext dbContext;
        public ReminderRepository(KeepDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        //This method should be used to save a new reminder.
        public Reminder CreateReminder(Reminder reminder)
        {
            dbContext.Reminders.Add(reminder);
            dbContext.SaveChanges();
            return reminder;
        }
        //This method should be used to delete an existing reminder.
        public bool DeletReminder(int reminderId)
        {
            var p = dbContext.Reminders.Where(x => x.ReminderId == reminderId).FirstOrDefault();
            dbContext.Reminders.Remove(p);
            var y = dbContext.SaveChanges();
            return (y == 1);
        }
        //This method should be used to get all reminder by userId.
        public List<Reminder> GetAllRemindersByUserId(string userId)
        {
            return dbContext.Reminders.ToList();
        }
        //This method should be used to get a reminder by reminderId.
        public Reminder GetReminderById(int reminderId)
        {
            var p = dbContext.Reminders.Where(x => x.ReminderId == reminderId).FirstOrDefault();
            return p;
        }
        // This method should be used to update a existing reminder.
        public bool UpdateReminder(Reminder reminder)
        {
            var a = dbContext.Reminders.Where(x => x.ReminderId == reminder.ReminderId).FirstOrDefault();
            
                a.ReminderName = reminder.ReminderName;
                a.ReminderId = reminder.ReminderId;
                a.ReminderDescription = reminder.ReminderDescription;
                a.ReminderType = reminder.ReminderType;
                a.CreatedBy = reminder.CreatedBy;
                a.CreatedAt = reminder.CreatedAt;
                dbContext.Entry<Reminder>(a).State = EntityState.Modified;
                dbContext.SaveChanges();
                return true;
            
        }
    }
}
