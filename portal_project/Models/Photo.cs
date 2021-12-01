using portal_project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portal_project.Models
{
    public class Photo
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.ImageUrl)]
        [FileExtensions(Extensions = "png,jpg,jpeg,gif")]
        [Required]
        public string PhotoLocation { get; set; }
        
        public virtual User UserUploader { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string PhotoTitle { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string PhotoDescription { get; set; }
        [DataType(DataType.DateTime)]
        [Column(TypeName = "datetime2")]
        public DateTime DateUpload { get; set; }
        public virtual Event PhotoEvent { get; set; }

        public Photo()
        {
        }

        public Photo(int id, string photoLocation, User userUploader, string photoTitle, string photoDescription, Event photoEvent, DateTime dateUpload)
        {
            Id = id;
            PhotoLocation = photoLocation;
            UserUploader = userUploader;
            PhotoTitle = photoTitle;
            PhotoDescription = photoDescription;
            PhotoEvent = photoEvent;
            DateUpload = dateUpload;
        }

        public Photo(string photoLocation, User userUploader, string photoTitle, string photoDescription, Event photoEvent, DateTime dateUpload)
        {
            PhotoLocation = photoLocation;
            UserUploader = userUploader;
            PhotoTitle = photoTitle;
            PhotoDescription = photoDescription;
            PhotoEvent = photoEvent;
            DateUpload = dateUpload;
        }
    }
}
