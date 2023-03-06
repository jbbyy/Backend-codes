using Entities;
using Exceptions;
using Microsoft.AspNetCore.Mvc;
using Service;
using System;

namespace KeepNote.Controllers
{
    /*
    * As in this assignment, we are working with creating RESTful web service, hence annotate
    * the class with [ApiController] annotation and define the controller level route as per REST Api standard.
    */

    [Route("api/[controller]")]
    [ApiController]
    public class ReminderController : ControllerBase
    {
        private readonly IReminderService reminderService;
        /*
       * ReminderService should  be injected through constructor injection. Please note that we should not create service
       * object using the new keyword
       */
        public ReminderController(IReminderService reminderService)
        {
            this.reminderService = reminderService;
        }

        /*
	     * Define a handler method which will create a reminder by reading the
	     * Serialized reminder object from request body and save the reminder in
	     * reminder table in database. Please note that the reminderId has to be unique
	     * and userID should be taken as the reminderCreatedBy for the
	     * reminder. This handler method should return any one of the status messages
	     * basis on different situations: 1. 201(CREATED - In case of successful
	     * creation of the reminder 2. 409(CONFLICT) - In case of duplicate reminder ID
	     * 
	     * This handler method should map to the URL "/api/reminder" using HTTP POST
	     * method".
	     */

        [HttpPost]
        public IActionResult post(Reminder reminder)
        {
            try
            {
                var x = reminderService.CreateReminder(reminder);
                return StatusCode(201, x);
            }
            catch (Exception e)
            {
                return StatusCode(409, e.Message);
            }

        }
        /*
         * Define a handler method which will delete a reminder from a database.
         * 
         * This handler method should return any one of the status messages basis on
         * different situations: 1. 200(OK) - If the reminder deleted successfully from
         * database. 2. 404(NOT FOUND) - If the reminder with specified reminderId is
         * not found. 
         * 
         * This handler method should map to the URL "/api/reminder/{id}" using HTTP Delete
         * method" where "id" should be replaced by a valid reminderId without {}
         */

        [HttpDelete("{id}")]
        public IActionResult delete(int id)
        {
            try
            {
                var x = reminderService.DeletReminder(id);
                return Ok(x);
            }
            catch (ReminderNotFoundException e)
            {
                return StatusCode(404, e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        /*
         * Define a handler method which will update a specific reminder by reading the
         * Serialized object from request body and save the updated reminder details in
         * a reminder table in database handle ReminderNotFoundException as well.
         * This handler method should return any one of the status
         * messages basis on different situations: 1. 200(OK) - If the reminder updated
         * successfully. 2. 404(NOT FOUND) - If the reminder with specified reminderId
         * is not found. 
         * 
         * This handler method should map to the URL "/api/reminder/{id}" using HTTP PUT
         * method.
         */
        [HttpPut("{id}")]
        public IActionResult update(int id, Reminder reminder)
        {
            try
            {
                var x = reminderService.UpdateReminder( id, reminder);
                return Ok(x);
            }
            catch (ReminderNotFoundException e)
            {
                return StatusCode(404, e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /*
         * Define a handler method which will get us the reminders by a userId.
         * 
         * This handler method should return any one of the status messages basis on
         * different situations: 1. 200(OK) - If the reminder found successfully.
         * 
         * This handler method should map to the URL "/api/reminder/{userId}" using HTTP GET method
         */

        [HttpGet("{userId}")]
        public IActionResult Get(string userId)
        {
            return Ok(reminderService.GetAllRemindersByUserId(userId));
        }

        /*
         * Define a handler method which will show details of a specific reminder handle
         * ReminderNotFoundException as well. This handler method should return any one
         * of the status messages basis on different situations: 1. 200(OK) - If the
         * reminder found successfully. 2. 404(NOT FOUND) - If the reminder
         * with specified reminderId is not found. This handler method should map to the
         * URL "/api/reminder/{id}" using HTTP GET method where "id" should be replaced by a
         * valid reminderId without {}
         */

        [HttpGet("{id}")]
        public IActionResult GetbyId(int id)
        {

            try
            {
                var x = reminderService.GetReminderById(id);
                return Ok(x);
            }
            catch (ReminderNotFoundException e)
            {
                return StatusCode(404, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(404, e.Message);
            }
        }
    }
}
