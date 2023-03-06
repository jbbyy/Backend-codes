using System.Collections.Generic;
using Keepnote_Step1.Models;

namespace Keepnote_Step1.Repository
{
    /*
      This class contains the code for data storage interactions and methods 
      of this class will be used by other parts of the applications such
      as Controllers and Test Cases
      */
    public class NoteRepository : INoteRepository
    {
        private static List<Note> notes;
        /* Declare a variable of List type to store all the notes. */

        public NoteRepository()
        {
            notes = new List<Note>();
            /* Initialize the variable using proper data type */
        }

        /* This method should return all the notes in the list */
        public List<Note> GetNotes()
        {
            return notes;

        }

        /*
	        This method should accept Note object as argument and add the new note object into  list
	    */
        public void AddNote(Note note)
        {
            notes.Add(note);
        }

        /* This method should deleted a specified note from the list */
        public bool DeletNote(int noteId)
        {
            var n = notes.Find(x => x.NoteId == noteId);
            notes.Remove(n);
            return false;
        }

        /*
	      This method should check if the matching note id present in the list or not.
	      Return true if note id exists in the list or return false if note id does not
	      exists in the list
	  */
        public bool Exists(int noteId)
        {
            var x = notes.Find(x => x.NoteId == noteId);
            if (x != null)
            {
                return true;
            }
            else { return false; }
           
        }
    }

}
