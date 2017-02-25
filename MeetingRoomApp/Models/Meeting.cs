using System;
using System.ComponentModel.DataAnnotations;

namespace MeetingRoomApp.Models
{
    public class Meeting
    {
        public int Id { get; set; }
        
        //Who's leading 
        
        public ApplicationUser leadBy { get; set; }

        [Required]
        public string leadById { get; set; }
        
        //When 
        public DateTime DateTime { get; set; }
        
        //Place 
        [Required]
        [StringLength(255)]
        public string Venue { get; set; }
        
        //Type 
        public Category Category { get; set;}

        [Required]
        public byte CategoryId { get; set; }
    }

}