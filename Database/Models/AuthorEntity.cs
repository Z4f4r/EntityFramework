﻿namespace Entity_Framework.Database.Models;

public class AuthorEntity
{
    public int Id { get; set; }

    public string UserName { get; set; } = string.Empty;

    public int CourseId { get; set; }

    public CourseEntity? Course { get; set; }
}
