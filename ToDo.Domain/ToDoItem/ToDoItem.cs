using ToDo.Infrastructure.PersistenceContext.Contracts;

namespace ToDo.Domain.ToDoItem;

public class ToDoItem(string title, string description) : IEntity
{
    public int Id { get; set; }

    public string Title { get; } = title;

    public string Description { get; } = description;

    public DateTime CreatedAt { get; } = DateTime.Now;

    public DateTime? CompletedAt { get; private set; }

    public string? CompletedNote { get; private set; }

    public bool IsCompleted { get; private set; }

    public void MarkAsCompleted(string? note)
    {
        IsCompleted = true;
        CompletedAt = DateTime.Now;
        CompletedNote = note;
    }

    public void MarkAsCompleted(string? note, DateTime completedAt)
    {
        if (completedAt < CreatedAt)
        {
            throw new ArgumentException("Completed Date Cannot Be Before Created Date.");
        }

        MarkAsCompleted(note);
        CompletedAt = completedAt;
    }
}