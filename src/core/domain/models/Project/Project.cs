using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using domain.models.board;
using domain.models.iteration;
using domain.models.milestone;
using domain.models.project.values;
using domain.models.values;
using domain.models.workitem;
using domain.models.workspace;
using OperationResult;

namespace domain.models.project;

public class Project
{
    /// <summary>
    /// The unique identifier of the project.
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Uid  { get; private set; }

    #region Fields

    /// <summary>
    /// The title of the project.
    /// </summary>
    [MaxLength(75)]
    [MinLength(3)]
    [Required]
    public string? Title { get; private set; }

    /// <summary>
    /// The description of the project.
    /// </summary>
    [MaxLength(500)]
    public string? Description { get; private set; }

    /// <summary>
    /// The start time of the project.
    /// </summary>
    public DateTime? StartTime { get; private set; }

    /// <summary>
    /// The end time of the project.
    /// </summary>
    public DateTime? EndTime { get; private set; }

    /// <summary>
    /// The framework of the project.
    /// </summary>
    public Framework? Framework { get; private set; }

    /// <summary>
    /// The status of the project.
    /// </summary>
    public Status? Status { get; private set; }

    /// <summary>
    /// The priority of the project.
    /// </summary>
    public Priority? Priority { get; private set; }
    #endregion

    #region Relations

    /// <summary>
    /// A reference to the Workspace that owns this project.
    /// </summary>
    [ForeignKey("WorkspaceUid")]
    public Guid WorkspaceUid { get; private set; }

    /// <summary>
    /// Reference to the Workspace that owns this project.
    /// (Lazy loaded)
    /// </summary>
    public virtual Workspace? Workspace { get; private set; }

    /// <summary>
    /// The work items of the project.
    /// (Lazy loaded)
    /// </summary>
    public virtual List<WorkItem> WorkItems { get; private set; } = [];

    /// <summary>
    /// The milestones of the project.
    /// (Lazy loaded)
    /// </summary>
    public virtual List<Milestone> Milestones { get; private set; } = [];

    /// <summary>
    /// The boards of the project.
    /// (Lazy loaded)
    /// </summary>
    public virtual List<Board> Boards { get; private set; } = [];

    /// <summary>
    /// The iterations of the project.
    /// (Lazy loaded)
    /// </summary>
    public virtual List<Iteration> Iterations { get; private set; } = [];

    #endregion

    /// <summary>
    /// Private constructor for the <see cref="Project"/> class.
    /// </summary>
    private Project()
    {
        // "Specific" values
        Uid = Guid.NewGuid();
    }

    /// <summary>
    /// Constructs a new instance of the <see cref="Project"/> class.
    /// </summary>
    /// <returns></returns>
    public static Project Create()
    {
        // ! No validation needed here
        // As the Project is to be modified through the provided methods.
        return new Project();
    }

    /// <summary>
    /// Updates the title of the Project
    /// </summary>
    /// <param name="title">The new title to be set.</param>
    /// <returns>A <see cref="Result"/> indicating if the operation was success or a failure.</returns>
    public Result UpdateTitle(string title)
    {
        // ! Validate the title.
        var result = ProjectValidator.ValidateTitle(title);

        // ? Is the result a failure?
        if (result.IsFailure)
        {
            // ! Return the failure.
            return Result.Failure(result.Errors.ToArray());
        }

        // * Update the title.
        Title = title;

        return Result.Success();
    }

    /// <summary>
    /// Updates the description of the Project.
    /// </summary>
    /// <param name="description">The new description to be set.</param>
    /// <returns>A <see cref="Result"/> indicating if the operation was success or a failure.</returns>
    public Result UpdateDescription(string description)
    {
        // ! Validate the description.
        var result = ProjectValidator.ValidateDescription(description);

        // ? Is the result a failure?
        if (result.IsFailure)
        {
            // ! Return the failure.
            return Result.Failure(result.Errors.ToArray());
        }

        // * Update the description.
        Description = description;

        return Result.Success();
    }

    /// <summary>
    /// Updates the status of the Project.
    /// </summary>
    /// <param name="status">The new status to be set.</param>
    /// <returns>A <see cref="Result"/> indicating if the operation was success or a failure.</returns>
    public Result UpdateStatus(Status status)
    {
        // ! Validate the status.
        var result = ProjectValidator.ValidateStatus(status);

        // ? Is the result a failure?
        if (result.IsFailure)
        {
            // ! Return the failure.
            return Result.Failure(result.Errors.ToArray());
        }

        // * Update the status.
        Status = status;

        return Result.Success();
    }

    /// <summary>
    /// Updates the time range of the Project.
    /// </summary>
    /// <param name="start">The new start date to be set.</param>
    /// <param name="end">The new end date to be set.</param>
    /// <returns>A <see cref="Result"/> indicating if the operation was success or a failure.</returns>
    public Result UpdateTimeRange(DateTime start, DateTime end)
    {
        // ! Validate the time range.
        var result = ProjectValidator.ValidateTimeRange(start, end);

        // ? Is the result a failure?
        if (result.IsFailure)
        {
            // ! Return the failure.
            return Result.Failure(result.Errors.ToArray());
        }

        // * Update the time range.
        StartTime = start;
        EndTime = end;

        return Result.Success();
    }

    /// <summary>
    /// Updates the framework of the Project.
    /// </summary>
    /// <param name="framework">The new framework to be set.</param>
    /// <returns>A <see cref="Result"/> indicating if the operation was success or a failure.</returns>
    public Result UpdateFramework(Framework framework)
    {
        // * Update the framework.
        Framework = framework;

        return Result.Success();
    }

    /// <summary>
    /// Updates the priority of the Project.
    /// </summary>
    /// <param name="priority">The new priority to be set.</param>
    /// <returns>A <see cref="Result"/> indicating if the operation was success or a failure.</returns>
    public Result UpdatePriority(Priority priority)
    {
        // * Update the priority.
        Priority = priority;

        return Result.Success();
    }

    /// <summary>
    /// Adds a work item to the project.
    /// </summary>
    /// <param name="workItem">The work item to be added.</param>
    /// <returns>A <see cref="Result"/> indicating if the operation was success or a failure.</returns>
    public Result AddWorkItem(WorkItem? workItem)
    {
        // ! Validate the work item.
        var result = ProjectValidator.ValidateAddWorkItem(workItem, WorkItems);

        // ? Is the result a failure?
        if (result.IsFailure)
        {
            // ! Return the failure.
            return Result.Failure(result.Errors.ToArray());
        }

        // * Add the work item.
        // We are sure that the work item is not null, as the validation has passed.
        WorkItems.Add(result);

        return Result.Success();
    }

    /// <summary>
    /// Removes a work item from the project.
    /// </summary>
    /// <param name="workItem">The work item to be removed.</param>
    /// <returns>A <see cref="Result"/> indicating if the operation was success or a failure.</returns>
    public Result RemoveWorkItem(WorkItem? workItem)
    {
        // ! Validate the work item.
        var result = ProjectValidator.ValidateRemoveWorkItem(workItem, WorkItems);

        // ? Is the result a failure?
        if (result.IsFailure)
        {
            // ! Return the failure.
            return Result.Failure(result.Errors.ToArray());
        }

        // * Remove the work item.
        // We are sure that the work item is not null, as the validation has passed.
        WorkItems.Remove(result);

        return Result.Success();
    }

    /// <summary>
    /// Adds a milestone to the project.
    /// </summary>
    /// <param name="milestone">The milestone to be added.</param>
    /// <returns>A <see cref="Result"/> indicating if the operation was success or a failure.</returns>
    public Result AddMilestone(Milestone? milestone)
    {
        // ! Validate the milestone.
        var result = ProjectValidator.ValidateAddMilestone(milestone, Milestones);

        // ? Is the result a failure?
        if (result.IsFailure)
        {
            // ! Return the failure.
            return Result.Failure(result.Errors.ToArray());
        }

        // * Add the milestone.
        // We are sure that the milestone is not null, as the validation has passed.
        Milestones.Add(result);

        return Result.Success();
    }

    /// <summary>
    /// Removes a milestone from the project.
    /// </summary>
    /// <param name="milestone">The milestone to be removed.</param>
    /// <returns>A <see cref="Result"/> indicating if the operation was success or a failure.</returns>
    public Result RemoveMilestone(Milestone? milestone)
    {
        // ! Validate the milestone.
        var result = ProjectValidator.ValidateRemoveMilestone(milestone, Milestones);

        // ? Is the result a failure?
        if (result.IsFailure)
        {
            // ! Return the failure.
            return Result.Failure(result.Errors.ToArray());
        }

        // * Remove the milestone.
        // We are sure that the milestone is not null, as the validation has passed.
        Milestones.Remove(result);

        return Result.Success();
    }

    /// <summary>
    /// Adds a board to the project.
    /// </summary>
    /// <param name="board">The board to be added.</param>
    /// <returns>A <see cref="Result"/> indicating if the operation was success or a failure.</returns>
    public Result AddBoard(Board? board)
    {
        // ! Validate the board.
        var result = ProjectValidator.ValidateAddBoard(board, Boards);

        // ? Is the result a failure?
        if (result.IsFailure)
        {
            // ! Return the failure.
            return Result.Failure(result.Errors.ToArray());
        }

        // * Add the board.
        // We are sure that the board is not null, as the validation has passed.
        Boards.Add(result);

        return Result.Success();
    }

    /// <summary>
    /// Removes a board from the project.
    /// </summary>
    /// <param name="board">The board to be removed.</param>
    /// <returns>A <see cref="Result"/> indicating if the operation was success or a failure.</returns>
    public Result RemoveBoard(Board? board)
    {
        // ! Validate the board.
        var result = ProjectValidator.ValidateRemoveBoard(board, Boards);

        // ? Is the result a failure?
        if (result.IsFailure)
        {
            // ! Return the failure.
            return Result.Failure(result.Errors.ToArray());
        }

        // * Remove the board.
        // We are sure that the board is not null, as the validation has passed.
        Boards.Remove(result);

        return Result.Success();
    }

    /// <summary>
    /// Adds an iteration to the project.
    /// </summary>
    /// <param name="iteration">The iteration to be added.</param>
    /// <returns>A <see cref="Result"/> indicating if the operation was success or a failure.</returns>
    public Result AddIteration(Iteration? iteration)
    {
        // ! Validate the iteration.
        var result = ProjectValidator.ValidateAddIteration(iteration, Iterations);

        // ? Is the result a failure?
        if (result.IsFailure)
        {
            // ! Return the failure.
            return Result.Failure(result.Errors.ToArray());
        }

        // * Add the iteration.
        // We are sure that the iteration is not null, as the validation has passed.
        Iterations.Add(result);

        return Result.Success();
    }

    /// <summary>
    /// Removes an iteration from the project.
    /// </summary>
    /// <param name="iteration">The iteration to be removed.</param>
    /// <returns>A <see cref="Result"/> indicating if the operation was success or a failure.</returns>
    public Result RemoveIteration(Iteration? iteration)
    {
        // ! Validate the iteration.
        var result = ProjectValidator.ValidateRemoveIteration(iteration, Iterations);

        // ? Is the result a failure?
        if (result.IsFailure)
        {
            // ! Return the failure.
            return Result.Failure(result.Errors.ToArray());
        }

        // * Remove the iteration.
        // We are sure that the iteration is not null, as the validation has passed.
        Iterations.Remove(result);

        return Result.Success();
    }
}