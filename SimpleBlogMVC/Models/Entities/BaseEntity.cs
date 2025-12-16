using System.ComponentModel.DataAnnotations;

namespace SimpleBlogMVC.Models.Entities;

public class BaseEntity
{
    [Key]
    public int Id { get; set; }
}