namespace MeTube.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class TubeUploadBindingModel
    {
        [Required(ErrorMessage = "Title is required!")]
        [MinLength(3)]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author is required!")]
        public string Author { get; set; }

        [Required(ErrorMessage = "YouTube link is required!")]
        [DataType(DataType.Url)]
        public string YouTubeLink { get; set; }

        public string Description { get; set; }
    }
}