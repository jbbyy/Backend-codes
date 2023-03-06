using System.Collections.Generic;
using System.Linq;
using Keepnote.Models;
using Microsoft.EntityFrameworkCore;

namespace Keepnote.Repository
{
    public class NoteRepository : INoteRepository
    {
        private readonly KeepNoteContext keep;
        public NoteRepository(KeepNoteContext keep)
        {
            this.keep = keep;
        }
        // Save the note in the database(note) table.
        public int AddNote(Note note)
        {
            keep.Notes.Add(note);
            return keep.SaveChanges();
        }
        //Remove the note from the database(note) table.
        public int DeletNote(int noteId)
        {
            var x = keep.Notes.Where(x => x.NoteId == noteId).FirstOrDefault();
            keep.Notes.Remove(x);
            return keep.SaveChanges();
        }

        //can be used as helper method for controller
        public bool Exists(int noteId)
        {
            var x = keep.Notes.Where(x => x.NoteId == noteId).FirstOrDefault();
            if (x != null)
            {
                return true;
            }
            return false;
        }

        /* retrieve all existing notes sorted by created Date in descending
         order(showing latest note first)*/
        public List<Note> GetAllNotes()
        {
            return keep.Notes.OrderByDescending(x => x.CreatedAt).ToList();
        }

        //retrieve specific note from the database(note) table
        public Note GetNoteById(int noteId)
        {
            var x = keep.Notes.Where(x => x.NoteId == noteId).FirstOrDefault();
            return x;
        }
        //Update existing note
        public int UpdateNote(Note note)
        {

            var x = keep.Notes.Where(x => x.NoteId == note.NoteId).FirstOrDefault();
            x.NoteTitle = note.NoteTitle;
            x.NoteStatus = note.NoteStatus;
            x.NoteContent = note.NoteContent;

            keep.Entry<Note>(x).State = EntityState.Modified;
            return keep.SaveChanges();
        }

    }
}
