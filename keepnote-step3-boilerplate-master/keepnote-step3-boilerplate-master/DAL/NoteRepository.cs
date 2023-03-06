using System.Collections.Generic;
using System.Linq;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    //Repository class is used to implement all Data access operations
    public class NoteRepository : INoteRepository
    {
        private readonly KeepDbContext dbContext;
        public NoteRepository(KeepDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // This method should be used to save a new note.
        public Note CreateNote(Note note)
        {
            dbContext.Notes.Add(note);
            dbContext.SaveChanges();
            return note;
        }

        /* This method should be used to delete an existing note. */
        public bool DeleteNote(int noteId)
        {
            var p = dbContext.Notes.Where(x => x.NoteId == noteId).FirstOrDefault();
            dbContext.Notes.Remove(p);
            var y = dbContext.SaveChanges();
            return (y == 1);
        }

        //* This method should be used to get all note by userId.
        public List<Note> GetAllNotesByUserId(string userId)
        {
            var p = dbContext.Notes.Where(x => x.CreatedBy == userId);
            return p.ToList();
        }
        //This method should be used to get a note by noteId.
        public Note GetNoteByNoteId(int noteId)
        {
            var p = dbContext.Notes.Where(x => x.NoteId == noteId).FirstOrDefault();
            return p;
        }
        //This method should be used to update a existing note.
        public bool UpdateNote(Note note)
        {
            var p = dbContext.Notes.Where(x => x.NoteId == note.NoteId).FirstOrDefault();
            if (p != null)
            {
                p.NoteTitle = note.NoteTitle;
                p.NoteContent = note.NoteContent;
                p.CreatedAt = note.CreatedAt;
                p.CreatedBy = note.CreatedBy;
                p.NoteStatus = note.NoteStatus;
                p.CategoryId = note.CategoryId;
                p.ReminderId = note.ReminderId;
                dbContext.Entry<Note>(p).State = EntityState.Modified;
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
