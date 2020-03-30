using System.ServiceModel;
using ApiSep.Bl.BaseClasses;
using ApiSep.Library.RequestObjects;
using ApiSep.Library.ResponseObjects;

namespace ApiSep.Wcf
{
    [ServiceContract(Namespace = "ApiSep.Wcf")]
    public interface IGenericCrudService<TDto, TModel> where TDto : class, new() where TModel : class, new()
    {
        LogicBase<TDto, TModel> LogicBase { get; set; }

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
        SearchFirstResponse<TDto> SearchFirst(SearchFirstRequest<TDto> request);

        [OperationContract(Name = "SearchFor")]
        SearchForResponse<TDto> SearchFor(SearchForRequest<TDto> request);

        [OperationContract(Name = "GetAllPaged")]
        GetAllPagedResponse<TDto> GetAllPaged(GetAllPagedRequest<TDto> request);

        [OperationContract(Name = "GetAllConditional")]
        GetAllPagedAndFilteredResponse<TDto> GetAllPagedAndFiltered(GetAllPagedAndFilteredRequest<TDto> request);
    }
}
