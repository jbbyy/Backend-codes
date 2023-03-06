using System;
using Keepnote.Models;
using Keepnote.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Keepnote.Controllers
{
    public class NoteController : Controller
    {
        /*
	     From the problem statement, we can understand that the application
	     requires us to implement the following functionalities.
	     1. display the list of existing notes from the collection. Each note 
	        should contain Note Id, title, content, status and created date.
	     2. Add a new note which should contain the title, content and status.
	     3. Delete an existing note.
         4. Update an existing Note.
	    */

        //Inject the noteRepository instance through constructor injection.
        private readonly INoteRepository noterepo;
        public NoteController(INoteRepository noterepo)
        {
            this.noterepo = noterepo;
        }
        /*
      * Define a handler method to read the existing notes from the database and use it as
      * model data for use with views. it should map to the default URL i.e. "/index"
      */

        [HttpGet]
        public IActionResult Index()
        {
            var x = noterepo.GetAllNotes();
            return View(x);
        }


        /*
         * Define a handler method which will read the NoteTitle, NoteContent,
         * NoteStatus from request parameters and save the note in note table in
         * database. Please note that the CreatedAt should always be auto populated with
         * system time and should not be accepted from the user. Also, after saving the
         * note, it should show the same along with existing messages. Hence, reading
         * note has to be done here again and the retrieved notes object should be sent
         * back to the view. This handler method should map to the URL "/create".
         */

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Note note)
        {
            if (ModelState.IsValid)
            {
                noterepo.AddNote(note);
                return RedirectToAction("Index");
            }
            return View(note);
        }
        /*
         * Define a handler method which will read the NoteId from request parameters
         * and remove an existing note by calling the deleteNote() method of the
         * NoteRepository class.".
         */

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int noteId)
        {
            noterepo.DeletNote(noteId);
            return RedirectToAction("Index");
        }
        /*
         * Define a handler method which will update the existing note.
         */
        public IActionResult Edit(int id)
        {

            return View(noterepo.GetNoteById(id));
        }
        [HttpPut]
        public IActionResult Edit(Note note)
        {
            noterepo.UpdateNote(note);
            return RedirectToAction("Index");
        }
    }
}