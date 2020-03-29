using ApiSep.Library.BaseClasses;

namespace ApiSep.Library.Utilities
{
    public class PropertyCopier<TDto, TModel> where TDto : class, new()
        where TModel : class, new() 
    {
        public static TModel MapToModel(TDto parent, RequestBase requestBase)
        {
            try
            {
                var child = new TModel();
                var parentProperties = parent.GetType().GetProperties();
                var childProperties = child.GetType().GetProperties();

                foreach (var parentProperty in parentProperties)
                {
                    foreach (var childProperty in childProperties)
                    {
                        if (parentProperty.Name == childProperty.Name && parentProperty.PropertyType == childProperty.PropertyType)
                        {
                            childProperty.SetValue(child, parentProperty.GetValue(parent));
                            break;
                        }
                    }
                }

                return child;
            }
            catch (System.Exception ex)
            {
                //new ErrorHandler(new ApiBase("Svc").ApiLogPath).HandleError(ex, requestBase);
                throw;
            }
        }

        public static TDto MapToDto(TModel parent, RequestBase requestBase)
        {
            try
            {
                var child = new TDto();
                var parentProperties = parent.GetType().GetProperties();
                var childProperties = child.GetType().GetProperties();

                foreach (var parentProperty in parentProperties)
                {
                    foreach (var childProperty in childProperties)
                    {
                        if (parentProperty.Name == childProperty.Name && parentProperty.PropertyType == childProperty.PropertyType)
                        {
                            childProperty.SetValue(child, parentProperty.GetValue(parent));
                            break;
                        }
                    }
                }

                return child;
            }
            catch (System.Exception ex)
            {
                //new ErrorHandler(new ApiBase("Svc").ApiLogPath).HandleError(ex, requestBase);
                throw;
            }
        }
        
    }
}
