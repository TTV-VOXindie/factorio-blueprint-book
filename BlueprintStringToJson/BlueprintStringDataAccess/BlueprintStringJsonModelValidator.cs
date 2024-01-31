using BlueprintStringDataModels;

namespace BlueprintStringDataAccess
{
    public class BlueprintStringJsonModelValidator
    {
        public bool IsValid(BlueprintStringJsonModel blueprintStringJsonModel)
        {
            //if there's neither a blueprint or a blueprint book
            if(blueprintStringJsonModel.Blueprint == null && blueprintStringJsonModel.BlueprintBook == null)
            {
                //A Blueprint or a Blueprint Book must be supplied.
                return false;
            }

            //if there's both a blueprint and a blueprint book
            if (blueprintStringJsonModel.Blueprint != null && blueprintStringJsonModel.BlueprintBook != null)
            {
                //Either a Blueprint or a Blueprint Book should be supplied, not both.
                return false;
            }

            return true;
        }
    }
}