using System.Data.Entity.Core.Metadata.Edm;
using System.ServiceModel;
using System.ServiceModel.Activation;
using ApiSep.Bl.BaseClasses;
using ApiSep.Library.RequestObjects;
using ApiSep.Library.ResponseObjects;
using ConcurrencyMode = System.ServiceModel.ConcurrencyMode;

namespace ApiSep.Wcf
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class GenericCrudService<TDto, TModel> : IGenericCrudService<TDto, TModel> where TDto : class, new() where TModel : class, new()
    {
        public LogicBase<TDto, TModel> LogicBase { get; set; } = new LogicBase<TDto, TModel>();

        public CreateResponse<TDto> Create(CreateRequest<TDto> request)
        {
            return LogicBase.Create(request);
        }

        public DeleteResponse<TDto> Delete(DeleteRequest<TDto> request)
        {
            return LogicBase.Delete(request);
        }

        public UpdateResponse<TDto> Update(UpdateRequest<TDto> request)
        {
            return LogicBase.Update(request);
        }

        public GetAllResponse<TDto> GetAll(GetAllRequest request)
        {
            return LogicBase.GetAll(request);
        }

        public GetByIdResponse<TDto> GetById(GetByIdRequest<TDto> request)
        {
            return LogicBase.GetById(request);
        }

        public SearchFirstResponse<TDto> SearchFirst(SearchFirstRequest<TDto> request)
        {
            return LogicBase.SearchFirst(request);
        }

        public SearchForResponse<TDto> SearchFor(SearchForRequest<TDto> request)
        {
            return LogicBase.SearchFor(request);
        }

        public GetAllPagedResponse<TDto> GetAllPaged(GetAllPagedRequest<TDto> request)
        {
            return LogicBase.GetAllPaged(request);
        }

        public GetAllPagedAndFilteredResponse<TDto> GetAllPagedAndFiltered(GetAllPagedAndFilteredRequest<TDto> request)
        {
            return LogicBase.GetAllPagedAndFiltered(request);
        }
    }
}
