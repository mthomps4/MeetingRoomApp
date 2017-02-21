using System;
using System.ComponentModel.DataAnnotations;

namespace MeetingRoomApp.Models
{
    public class Meeting
    {
        public int Id { get; set; }
        
        //Who's leading 
        [Required]
        public ApplicationUser leadBy { get; set; }
        
        //When 
        public DateTime DateTime { get; set; }
        
        //Place 
        [Required]
        [StringLength(255)]
        public string Venue { get; set; }
        
        //Type 
        [Required]
        public Category Category { get; set;}
    }

}