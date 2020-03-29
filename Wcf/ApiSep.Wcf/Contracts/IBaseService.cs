using System.ServiceModel;
using ApiSep.Library.RequestObjects;
using ApiSep.Library.ResponseObjects;

namespace ApiSep.Wcf.Contracts
{
    [ServiceContract]
    public interface IBaseService<TDto, TEntity> where TDto : class, new() where TEntity : class, new()
    {
        [OperationContract]
        CreateResponse<TDto> Create(CreateRequest<TDto> request);

        [OperationContract]
        DeleteResponse<TDto> Delete(DeleteRequest<TDto> request);

        [OperationContract]
        UpdateResponse<TDto> Update(UpdateRequest<TDto> request);

        [OperationContract]
        GetAllResponse<TDto> GetAll(GetAllRequest request);

        [OperationContract]
        GetByIdResponse<TDto> GetById(GetByIdRequest<TDto> request);

        [OperationContract]
        SearchFirstResponse<TDto> SearchFirst(SearchFirstRequest<TEntity> request);

        [OperationContract]
        SearchForResponse<TDto> SearchFor(SearchForRequest<TEntity> request);

        [OperationContract]
        GetAllPagedResponse<TDto> GetAllPaged(GetAllPagedRequest<TDto> request);

        [OperationContract]
        GetAllPagedAndFilteredResponse<TDto> GetAllPagedAndFiltered(GetAllPagedAndFilteredRequest<TDto> request);
    }
}