using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Newtonsoft.Json;

namespace Entities
{
    // The class "Category" will be acting as the data model for the Category Table in the database. 
    public class Category
    {
        /*
	     * This class should have seven fields
	     * (categoryId,categoryName,categoryDescription,
	     * categoryCreatedBy,categoryCreationDate,notes,user). Out of these six fields, the
	     * field categoryId should be primary key and auto-generated. The value of
	     * categoryCreationDate should not be accepted from the user but should be
	     * always initialized with the system date. annotate notes and user field with [JsonIgnore]
	 */
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }

        public DateTime CategoryCreationDate { get; set; }

        public string CategoryCreatedBy { get; set; }

       
        public string user { get; set; }

        
        public string notes { get; set; }

    }




}

