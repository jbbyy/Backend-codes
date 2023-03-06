using DAL;
using Entities;
using Exceptions;
using System.Collections.Generic;

namespace Service
{
    /*
   * Service classes are used here to implement additional business logic/validation
   * */
    public class NoteService : INoteService
    {
        /*
         Use constructor Injection to inject all required dependencies.
             */

        private readonly INoteRepository repository;
        private readonly ICategoryRepository category;
        private readonly IReminderRepository reminder;
        public NoteService(INoteRepository repository, ICategoryRepository category, IReminderRepository reminder)
        {
            this.repository = repository;
            this.category = category;
            this.reminder = reminder;
        }

        /*
	     * This method should be used to save a new note.
	     */
        public Note CreateNote(Note note)
        {
           
            var y = category.GetCategoryById(note.CategoryId);
            var z = reminder.GetReminderById(note.ReminderId);
            if (y == null && z != null)
            {
                throw new CategoryNotFoundException($"Category with id: {note.CategoryId} does not exist");
            }
           else if (z == null && y != null)
            {
                 throw new ReminderNotFoundException($"Reminder with id: {note.ReminderId} does not exist");
            }
             return repository.CreateNote(note);
            

        }
        /* This method should be used to delete an existing note. */
        public bool DeleteNote(int noteId)
        {
            var x = repository.GetNoteByNoteId(noteId);
            if (x == null)
            {
                throw new NoteNotFoundException($"Note with id: {noteId} does not exist");
            }
            return repository.DeleteNote(noteId);
        }

        /*
	     * This method should be used to get all note by userId.
	     */
        public List<Note> GetAllNotesByUserId(string userId)
        {
            return repository.GetAllNotesByUserId(userId);
        }

        //This method should be used to get a note by noteId.
        public Note GetNoteByNoteId(int noteId)
        {
            var x =  repository.GetNoteByNoteId(noteId);
            if (x == null)
            {
                throw new NoteNotFoundException($"Note with id: {noteId} does not exist");
            }
            return x;
        }
        //This method should be used to update a existing note.
        public bool UpdateNote(int noteId, Note note)
        {
         
            var x = repository.GetNoteByNoteId(noteId);
            var y = category.GetCategoryById(note.CategoryId);
            var z = reminder.GetReminderById(note.ReminderId);
            if (x == null)
            {
                throw new NoteNotFoundException($"Note with id: {noteId} does not exist");
            }
            else 
            {
                if (z == null)
                {
                    throw new ReminderNotFoundException($"Reminder with id: {note.ReminderId} does not exist");
                }
                else if (y == null)
                {
                    throw new CategoryNotFoundException($"Category with id: {note.CategoryId} does not exist");
                }
                return repository.UpdateNote(note);
            }
            
        }
    }
}
