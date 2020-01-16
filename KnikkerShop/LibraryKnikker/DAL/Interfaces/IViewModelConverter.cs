using System.Collections.Generic;

namespace LibraryKnikker.Core.DAL.Interfaces
{
    public interface IViewModelConverter<TModel, TViewModel>
    {
        TViewModel ModelToViewModel(TModel model);
        TModel ViewModelToModel(TViewModel viewModel);

        List<TViewModel> ModelsToViewModels(List<TModel> models);
    }
}
