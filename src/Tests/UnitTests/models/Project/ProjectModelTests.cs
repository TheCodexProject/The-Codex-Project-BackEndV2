using domain.models.board;
using domain.models.iteration;
using domain.models.milestone;
using domain.models.project;
using domain.models.project.values;
using domain.models.values;
using domain.models.workitem;

namespace UnitTests.models.project;

public class ProjectModelTests
{
    // # 1 - Project can be created
    [Fact]
    public void Project_can_be_created()
    {
        // Arrange
        var project = Project.Create();

        // Act
        var result = project;

        // Assert
        Assert.NotNull(result);
    }

    // # 2 - Project can have a title
    [Fact]
    public void Project_can_have_a_title()
    {
        // Arrange
        var project = Project.Create();
        var title = "Project Title";

        // Act
        var result = project.UpdateTitle(title);

        // Assert
        Assert.True(result.IsSuccess);
    }

    // # 2A - Project title cannot be empty or null
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Project_title_cannot_be_empty_or_null(string title)
    {
        // Arrange
        var project = Project.Create();

        // Act
        var result = project.UpdateTitle(title);

        // Assert
        Assert.True(result.IsFailure);
    }

    // # 2B - Title has to be at least 3 characters long
    [Theory]
    [InlineData("A")]
    [InlineData("AB")]
    public void Project_title_has_to_be_at_least_3_characters_long(string title)
    {
        // Arrange
        var project = Project.Create();

        // Act
        var result = project.UpdateTitle(title);

        // Assert
        Assert.True(result.IsFailure);
    }

    // # 2C - Title can not be longer than 75 characters
    [Theory]
    [InlineData("Exploring the Challenges and Benefits of Implementing Cloud Computing Solutions 2")]
    [InlineData("How Artificial Intelligence Is Revolutionizing Healthcare by Enhancing Diagnostics and Personalized Treatments")]
    public void Project_title_cannot_be_longer_than_75_characters(string title)
    {
        // Arrange
        var project = Project.Create();

        // Act
        var result = project.UpdateTitle(title);

        // Assert
        Assert.True(result.IsFailure);
    }

    // # 2D - Title can be created with 3 and 75 characters
    [Theory]
    [InlineData("AI!")]
    [InlineData("Exploring the Challenges and Benefits of Implementing Computing Solutions")]
    public void Project_title_can_be_created_with_3_and_75_characters(string title)
    {
        // Arrange
        var project = Project.Create();

        // Act
        var result = project.UpdateTitle(title);

        // Assert
        Assert.True(result.IsSuccess);
    }

    // # 3 - Project can have a description
    [Fact]
    public void Project_can_have_a_description()
    {
        // Arrange
        var project = Project.Create();
        var description = "Project Description";

        // Act
        var result = project.UpdateDescription(description);

        // Assert
        Assert.True(result.IsSuccess);
    }

    // # 3A - Description can not be longer than 500 characters
    [Theory]
    [InlineData("Artificial Intelligence (AI) is transforming various industries, changing the way we live, work, and interact with technology. From healthcare and education to finance and entertainment, AI applications are becoming more integrated into our daily lives. Machine learning, natural language processing, and computer vision are just a few of the tools driving this revolution. AI is not just a concept from science fiction; it is a real, evolving technology that is helping businesses streamline processes, improve efficiency, and deliver personalized experiences to customers. However, while AI offers numerous benefits, it also poses challenges, such as ethical considerations regarding data privacy, bias in algorithms, and the impact on jobs. Companies must carefully address these challenges while adopting AI-driven solutions. Understanding AI's potential and limitations is crucial for harnessing its power responsibly and ensuring that its benefits reach as many people as possible without creating unintended negative consequences.")]
    [InlineData("The rapid growth of renewable energy sources, such as solar, wind, and hydropower, is significantly reshaping the global energy landscape. As countries strive to reduce carbon emissions and transition to cleaner energy, renewable sources have gained prominence as viable and sustainable alternatives to fossil fuels. Technological advancements have led to improved efficiency and affordability, making renewable energy more accessible to both businesses and individuals. This shift towards green energy is driven by both environmental concerns and economic opportunities, as governments and companies recognize the long-term benefits of reducing their carbon footprint. Despite the progress, challenges remain, such as energy storage, grid integration, and the need for consistent policy support to drive widespread adoption. Nonetheless, the momentum behind renewable energy continues to grow, offering hope for a cleaner and more sustainable future for generations to come.")]
    public void Project_description_cannot_be_longer_than_500_characters(string description)
    {
        // Arrange
        var project = Project.Create();

        // Act
        var result = project.UpdateDescription(description);

        // Assert
        Assert.True(result.IsFailure);
    }

    // # 4 - Project can have a status
    [Fact]
    public void Project_can_have_a_status()
    {
        // Arrange
        var project = Project.Create();
        var status = Status.InProgress;

        // Act
        var result = project.UpdateStatus(status);

        // Assert
        Assert.True(result.IsSuccess);
    }

    // # 4A - Project status cannot be empty
    [Fact]
    public void Project_status_cannot_be_empty()
    {
        // Arrange
        var project = Project.Create();
        var status = Status.None;

        // Act
        var result = project.UpdateStatus(status);

        // Assert
        Assert.True(result.IsFailure);
    }

    // # 5 - Project can have a framework
    [Fact]
    public void Project_can_have_a_framework()
    {
        // Arrange
        var project = Project.Create();
        var methodology = Framework.Agile;

        // Act
        var result = project.UpdateFramework(methodology);

        // Assert
        Assert.True(result.IsSuccess);
    }

    // # 6 - Project can have a time range
    [Fact]
    public void Project_can_have_a_time_range()
    {
        // Arrange
        var project = Project.Create();
        var start = DateTime.Today;
        var end = DateTime.Today.AddDays(7);

        // Act
        var result = project.UpdateTimeRange(start, end);

        // Assert
        Assert.True(result.IsSuccess);
    }

    // # 6A - Project time range cannot be empty
    [Fact]
    public void Project_time_range_cannot_be_empty()
    {
        // Arrange
        var project = Project.Create();
        var start = DateTime.MinValue;
        var end = DateTime.MinValue;

        // Act
        var result = project.UpdateTimeRange(start, end);

        // Assert
        Assert.True(result.IsFailure);
    }

    // # 6B - Project start date cannot be in the past
    [Fact]
    public void Project_start_date_cannot_be_in_the_past()
    {
        // Arrange
        var project = Project.Create();
        var start = DateTime.Today.AddDays(-1);
        var end = DateTime.Today.AddDays(7);

        // Act
        var result = project.UpdateTimeRange(start, end);

        // Assert
        Assert.True(result.IsFailure);
    }

    // # 6C - Project start date cannot be after end date
    [Fact]
    public void Project_start_date_cannot_be_after_end_date()
    {
        // Arrange
        var project = Project.Create();
        var start = DateTime.Today.AddDays(7);
        var end = DateTime.Today;

        // Act
        var result = project.UpdateTimeRange(start, end);

        // Assert
        Assert.True(result.IsFailure);
    }

    // # 6D - Project start date cannot be the same as end date
    [Fact]
    public void Project_start_date_cannot_be_the_same_as_end_date()
    {
        // Arrange
        var project = Project.Create();
        var start = DateTime.Today;
        var end = DateTime.Today;

        // Act
        var result = project.UpdateTimeRange(start, end);

        // Assert
        Assert.True(result.IsFailure);
    }

    // # 7 - Project can have a priority
    [Fact]
    public void Project_can_have_a_priority()
    {
        // Arrange
        var project = Project.Create();
        var priority = Priority.High;

        // Act
        var result = project.UpdatePriority(priority);

        // Assert
        Assert.True(result.IsSuccess);
    }

    #region Project Work Items Tests

    // # 8 - Project can have a list of work items
    [Fact]
    public void Project_can_have_a_list_of_work_items()
    {
        // Arrange
        var project = Project.Create();
        var workItem = WorkItem.Create();

        // Act
        var result = project.AddWorkItem(workItem);

        // Assert
        Assert.True(result.IsSuccess);
    }

    // # 8A - Project cannot add a null work item
    [Fact]
    public void Project_cannot_add_a_null_work_item()
    {
        // Arrange
        var project = Project.Create();
        WorkItem? workItem = null;

        // Act
        var result = project.AddWorkItem(workItem);

        // Assert
        Assert.True(result.IsFailure);
    }

    // # 8B - Project cannot add a work item that already exists
    [Fact]
    public void Project_cannot_add_a_work_item_that_already_exists()
    {
        // Arrange
        var project = Project.Create();
        var workItem = WorkItem.Create();
        project.AddWorkItem(workItem);

        // Act
        var result = project.AddWorkItem(workItem);

        // Assert
        Assert.True(result.IsFailure);
    }

    // # 9 - Project can remove a work item
    [Fact]
    public void Project_can_remove_a_work_item()
    {
        // Arrange
        var project = Project.Create();
        var workItem = WorkItem.Create();
        project.AddWorkItem(workItem);

        // Act
        var result = project.RemoveWorkItem(workItem);

        // Assert
        Assert.True(result.IsSuccess);
    }

    // # 9A - Project cannot remove a null work item
    [Fact]
    public void Project_cannot_remove_a_null_work_item()
    {
        // Arrange
        var project = Project.Create();
        WorkItem? workItem = null;

        // Act
        var result = project.RemoveWorkItem(workItem);

        // Assert
        Assert.True(result.IsFailure);
    }

    // # 9B - Project cannot remove a work item that does not exist
    [Fact]
    public void Project_cannot_remove_a_work_item_that_does_not_exist()
    {
        // Arrange
        var project = Project.Create();
        var workItem = WorkItem.Create();

        // Act
        var result = project.RemoveWorkItem(workItem);

        // Assert
        Assert.True(result.IsFailure);
    }

    #endregion

    #region Project Milestones Tests

    // # 10 - Project can have a list of milestones
    [Fact]
    public void Project_can_have_a_list_of_milestones()
    {
        // Arrange
        var project = Project.Create();
        var milestone = Milestone.Create();

        // Act
        var result = project.AddMilestone(milestone);

        // Assert
        Assert.True(result.IsSuccess);
    }

    // # 10A - Project cannot add a null milestone
    [Fact]
    public void Project_cannot_add_a_null_milestone()
    {
        // Arrange
        var project = Project.Create();
        Milestone? milestone = null;

        // Act
        var result = project.AddMilestone(milestone);

        // Assert
        Assert.True(result.IsFailure);
    }

    // # 10B - Project cannot add a milestone that already exists
    [Fact]
    public void Project_cannot_add_a_milestone_that_already_exists()
    {
        // Arrange
        var project = Project.Create();
        var milestone = Milestone.Create();
        project.AddMilestone(milestone);

        // Act
        var result = project.AddMilestone(milestone);

        // Assert
        Assert.True(result.IsFailure);
    }

    // # 11 - Project can remove a milestone
    [Fact]
    public void Project_can_remove_a_milestone()
    {
        // Arrange
        var project = Project.Create();
        var milestone = Milestone.Create();
        project.AddMilestone(milestone);

        // Act
        var result = project.RemoveMilestone(milestone);

        // Assert
        Assert.True(result.IsSuccess);
    }

    // # 11A - Project cannot remove a null milestone
    [Fact]
    public void Project_cannot_remove_a_null_milestone()
    {
        // Arrange
        var project = Project.Create();
        Milestone? milestone = null;

        // Act
        var result = project.RemoveMilestone(milestone);

        // Assert
        Assert.True(result.IsFailure);
    }

    // # 11B - Project cannot remove a milestone that does not exist
    [Fact]
    public void Project_cannot_remove_a_milestone_that_does_not_exist()
    {
        // Arrange
        var project = Project.Create();
        var milestone = Milestone.Create();

        // Act
        var result = project.RemoveMilestone(milestone);

        // Assert
        Assert.True(result.IsFailure);
    }

    #endregion

    #region Project Iterations Tests

    // # 12 - Project can have a list of iterations
    [Fact]
    public void Project_can_have_a_list_of_iterations()
    {
        // Arrange
        var project = Project.Create();
        var iteration = Iteration.Create();

        // Act
        var result = project.AddIteration(iteration);

        // Assert
        Assert.True(result.IsSuccess);
    }

    // # 12A - Project cannot add a null iteration
    [Fact]
    public void Project_cannot_add_a_null_iteration()
    {
        // Arrange
        var project = Project.Create();
        Iteration? iteration = null;

        // Act
        var result = project.AddIteration(iteration);

        // Assert
        Assert.True(result.IsFailure);
    }

    // # 12B - Project cannot add an iteration that already exists
    [Fact]
    public void Project_cannot_add_an_iteration_that_already_exists()
    {
        // Arrange
        var project = Project.Create();
        var iteration = Iteration.Create();
        project.AddIteration(iteration);

        // Act
        var result = project.AddIteration(iteration);

        // Assert
        Assert.True(result.IsFailure);
    }

    // # 13 - Project can remove an iteration
    [Fact]
    public void Project_can_remove_an_iteration()
    {
        // Arrange
        var project = Project.Create();
        var iteration = Iteration.Create();
        project.AddIteration(iteration);

        // Act
        var result = project.RemoveIteration(iteration);

        // Assert
        Assert.True(result.IsSuccess);
    }

    // # 13A - Project cannot remove a null iteration
    [Fact]
    public void Project_cannot_remove_a_null_iteration()
    {
        // Arrange
        var project = Project.Create();
        Iteration? iteration = null;

        // Act
        var result = project.RemoveIteration(iteration);

        // Assert
        Assert.True(result.IsFailure);
    }

    // # 13B - Project cannot remove an iteration that does not exist
    [Fact]
    public void Project_cannot_remove_an_iteration_that_does_not_exist()
    {
        // Arrange
        var project = Project.Create();
        var iteration = Iteration.Create();

        // Act
        var result = project.RemoveIteration(iteration);

        // Assert
        Assert.True(result.IsFailure);
    }

    #endregion

    #region Project Boards Tests

    // # 14 - Project can have a list of boards
    [Fact]
    public void Project_can_have_a_list_of_boards()
    {
        // Arrange
        var project = Project.Create();
        var board = Board.Create();

        // Act
        var result = project.AddBoard(board);

        // Assert
        Assert.True(result.IsSuccess);
    }

    // # 14A - Project cannot add a null board
    [Fact]
    public void Project_cannot_add_a_null_board()
    {
        // Arrange
        var project = Project.Create();
        Board? board = null;

        // Act
        var result = project.AddBoard(board);

        // Assert
        Assert.True(result.IsFailure);
    }

    // # 14B - Project cannot add a board that already exists
    [Fact]
    public void Project_cannot_add_a_board_that_already_exists()
    {
        // Arrange
        var project = Project.Create();
        var board = Board.Create();
        project.AddBoard(board);

        // Act
        var result = project.AddBoard(board);

        // Assert
        Assert.True(result.IsFailure);
    }

    // # 15 - Project can remove a board
    [Fact]
    public void Project_can_remove_a_board()
    {
        // Arrange
        var project = Project.Create();
        var board = Board.Create();
        project.AddBoard(board);

        // Act
        var result = project.RemoveBoard(board);

        // Assert
        Assert.True(result.IsSuccess);
    }

    // # 15A - Project cannot remove a null board
    [Fact]
    public void Project_cannot_remove_a_null_board()
    {
        // Arrange
        var project = Project.Create();
        Board? board = null;

        // Act
        var result = project.RemoveBoard(board);

        // Assert
        Assert.True(result.IsFailure);
    }

    // # 15B - Project cannot remove a board that does not exist
    [Fact]
    public void Project_cannot_remove_a_board_that_does_not_exist()
    {
        // Arrange
        var project = Project.Create();
        var board = Board.Create();

        // Act
        var result = project.RemoveBoard(board);

        // Assert
        Assert.True(result.IsFailure);
    }

    #endregion
}