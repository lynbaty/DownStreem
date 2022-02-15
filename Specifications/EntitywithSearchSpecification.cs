using downstreem.Dtos;
using downstreem.Models;

namespace downstreem.Specifications
{
    public class EntitywithSearchSpecification : BaseSpecification<Entity>
    {
        public EntitywithSearchSpecification(GetEntityDTO model) : base()
        {
            if(model.Search != null)
            {
                AddSearch(c => c.Name.Contains(model.Search));
            }    
        }
    }
}
