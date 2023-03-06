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
    public class UserController : ControllerBase
    {
        /*
         * UserService should  be injected through constructor injection. Please note that we should not create service
         * object using the new keyword
        */
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        /*
	     * Define a handler method which will create a specific user by reading the
	     * Serialized object from request body and save the user details in a User table
	     * in the database. This handler method should return any one of the status
	     * messages basis on different situations: 1. 201(CREATED) - If the user created
	     * successfully. 2. 409(CONFLICT) - If the userId conflicts with any existing
	     * user
	     * 
	     * 
	     * This handler method should map to the URL "/api/user/register" using HTTP POST
	     * method
	     */
        [HttpPost("register")]
        public IActionResult Post(User user)
        {

            try
            {
                var x = userService.RegisterUser(user);
                return StatusCode(201, x);
            }
            catch (UserAlreadyExistException e)
            {
                return StatusCode(409, e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /*
         * Define a handler method which will login a specific user by reading the
         * Serialized object from request body and validate the userId and Password
         * from User table in the database. This handler method should return any one of 
         * the status messages basis on different situations: 
         * 1. 200(OK) - If the user successfully logged in. 
         * 2. 404(NOTFOUND) -If the user with specified userId is not found.
         * 
         * This handler method should map to the URL "/api/user/login" using HTTP POST
         * method
         */
        [HttpPost]
        [Route("login")]
        public IActionResult login(string userId, string password)
        {

            try
            {
                var x = userService.ValidateUser(userId, password);
                return StatusCode(200, x);
            }
            catch (UserNotFoundException e)
            {
                return StatusCode(404, e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        /*
         * Define a handler method which will update a specific user by reading the
         * Serialized object from request body and save the updated user details in a
         * user table in database handle exception as well. This handler method should
         * return any one of the status messages basis on different situations: 1.
         * 200(OK) - If the user updated successfully. 2. 404(NOT FOUND) - If the user
         * with specified userId is not found. 
         * 
         * This handler method should map to the URL "/api/user/{id}" using HTTP PUT method.
         */
        [HttpPut("{userId}")]
        public IActionResult update(string userId, User user)
        {
            try
            {
                var x = userService.UpdateUser(userId, user);
                return Ok(x);
            }
            catch (UserNotFoundException e)
            {
                return StatusCode(404, e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /*
         * Define a handler method which will delete a user from a database.
         * 
         * This handler method should return any one of the status messages basis on
         * different situations: 1. 200(OK) - If the user deleted successfully from
         * database. 2. 404(NOT FOUND) - If the user with specified userId is not found.
         * 
         * This handler method should map to the URL "/api/user/{id}" using HTTP Delete
         * method" where "id" should be replaced by a valid userId without {}
         */
        [HttpDelete("{userId}")]

        public IActionResult Delete(string userId)
        {

            try
            {
                var x = userService.DeleteUser(userId);
                return Ok(x);
            }
            catch (UserNotFoundException e)
            {
                return StatusCode(404, e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

       

        /*
         * Define a handler method which will show details of a specific user handle
         * UserNotFoundException as well. This handler method should return any one of
         * the status messages basis on different situations: 1. 200(OK) - If the user
         * found successfully. 2. 404(NOT FOUND) - If the user with specified
         * userId is not found. This handler method should map to the URL "/api/user/{userId}"
         * using HTTP GET method where "id" should be replaced by a valid userId without
         * {}
         */

        [HttpGet("{userId}")]
        public IActionResult getId(string userId)
        {
            try
            {
                var x = userService.GetUserById(userId);
                return StatusCode(200, x);
            }
            catch (UserNotFoundException e)
            {
                return StatusCode(404, e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
