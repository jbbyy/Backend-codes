using System.Collections.Generic;
using DAL;
using Entities;
using Exceptions;

namespace Service
{
    /*
   * Service classes are used here to implement additional business logic/validation
   * */
    public class ReminderService : IReminderService
    {
        /*
        Use constructor Injection to inject all required dependencies.
        */
        private readonly IReminderRepository reminderRepository;
        public ReminderService(IReminderRepository reminderRepository)
        {
            this.reminderRepository = reminderRepository;
        }

        //This method should be used to save a new reminder.
        public Reminder CreateReminder(Reminder reminder)
        {

          
                return reminderRepository.CreateReminder(reminder);
   
           
        }

        //This method should be used to delete an existing reminder.
        public bool DeletReminder(int reminderId)
        {
            var x = reminderRepository.DeletReminder(reminderId);
            if (x == false)
            {
                throw new ReminderNotFoundException($"Reminder with id: {reminderId} does not exist");
            }
            return x;
        }

        //This method should be used to get all reminder by userId.
        public List<Reminder> GetAllRemindersByUserId(string userId)
        {
           return reminderRepository.GetAllRemindersByUserId(userId);
        }
        //This method should be used to get a reminder by reminderId.
        public Reminder GetReminderById(int reminderId)
        {
           var x = reminderRepository.GetReminderById(reminderId);
            if (x == null)
            {
                throw new ReminderNotFoundException($"Reminder with id: {reminderId} does not exist");
            }
            return x;
        }

        // This method should be used to update a existing reminder.
        public bool UpdateReminder(int reminderId, Reminder reminder)
        {
            var x = reminderRepository.GetReminderById(reminderId);
            if (x == null)
            {
                throw new ReminderNotFoundException($"Reminder with id: {reminderId} does not exist");
            }
            else
            {
                reminderRepository.UpdateReminder(reminder);
                return true;
            }
        }
    }
}
