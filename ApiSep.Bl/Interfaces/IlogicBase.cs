using ApiSep.Library.BaseClasses;
using ApiSep.Library.RequestObjects;
using ApiSep.Library.ResponseObjects;

namespace ApiSep.Bl.Interfaces
{
    public interface ILogicBase<TDto, TEntity> where TDto : class, new() where TEntity : class, new()
    {

        CreateResponse<TDto> Create(CreateRequest<TDto> request);

        DeleteResponse<TDto> Delete(DeleteRequest<TDto> request);

        UpdateResponse<TDto> Update(UpdateRequest<TDto> request);

        GetAllResponse<TDto> GetAll(GetAllRequest request);

        GetByIdResponse<TDto> GetById(GetByIdRequest<TDto> request);

        SearchFirstResponse<TDto> SearchFirst(SearchFirstRequest<TEntity> request);

        SearchForResponse<TDto> SearchFor(SearchForRequest<TEntity> request);

        TEntity MapToModel(TDto dto, RequestBase requestBase);
        TDto MapToDto(TEntity model, RequestBase requestBase);
    }
}
