using System.ComponentModel;

namespace ToDo.Front.Dtos;

public class ToDo(
    int id,
    string title,
    string description,
    DateTime createdAt,
    DateTime? completedAt,
    string completedNote,
    bool isCompleted
)
{
    public int Id { get; set; } = id;
    public string Title { get; set; } = title;
    public string Description { get; set; } = description;
    public DateTime CreatedAt { get; set; } = createdAt;
    public DateTime? CompletedAt { get; set; } = completedAt;
    public string CompletedNote { get; set; } = completedNote;
    public bool IsCompleted { get; set; } = isCompleted;
}

public class ToDoDto(List<ToDo> toDoItems)
{
    public List<ToDo> ToDoItems { get; set; } = toDoItems;
}