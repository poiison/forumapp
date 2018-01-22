using System.ComponentModel.DataAnnotations;

namespace forumapp.entity.dto
{
    public class CategoryDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public string Description { get; set; }

        public int TotalTopics { get; set; }
    }
}
