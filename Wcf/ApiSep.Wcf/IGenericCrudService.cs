using System.ServiceModel;
using ApiSep.Library.RequestObjects;
using ApiSep.Library.ResponseObjects;

namespace ApiSep.Wcf
{
    [ServiceContract(Namespace = "ApiSep.Wcf")]
    public interface IGenericCrudService<TDto, TModel> where TDto : class, new() where TModel : class, new()
    {
        //LogicBase<TDto, TEntity> LogicBase { get; set; }

        [OperationContract(Name = "Create")]
        CreateResponse<TDto> Create(CreateRequest<TDto> request);

        [OperationContract(Name = "Delete")]
        DeleteResponse<TDto> Delete(DeleteRequest<TDto> request);

        [OperationContract(Name = "Update")]
        UpdateResponse<TDto> Update(UpdateRequest<TDto> request);

        [OperationContract(Name = "GetAll")]
        GetAllResponse<TDto> GetAll(GetAllRequest request);

        [OperationContract(Name = "GetById")]
        GetByIdResponse<TDto> GetById(GetByIdRequest<TDto> request);

        [OperationContract(Name = "SearchFirst")]
        SearchFirstResponse<TDto> SearchFirst(SearchFirstRequest<TModel> request);

        [OperationContract(Name = "SearchFor")]
        SearchForResponse<TDto> SearchFor(SearchForRequest<TModel> request);

        [OperationContract(Name = "GetAllPaged")]
        GetAllPagedResponse<TDto> GetAllPaged(GetAllPagedRequest<TDto> request);

        [OperationContract(Name = "GetAllConditional")]
        GetAllPagedAndFilteredResponse<TDto> GetAllPagedAndFiltered(GetAllPagedAndFilteredRequest<TDto> request);
    }
}
