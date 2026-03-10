using CommunityToolkit.Mvvm.Input;
using LouisApp.Models;

namespace LouisApp.PageModels
{
    public interface IProjectTaskPageModel
    {
        IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
        bool IsBusy { get; }
    }
}